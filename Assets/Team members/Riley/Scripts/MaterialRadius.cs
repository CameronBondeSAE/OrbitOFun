using System;
using System.Collections;
using System.Collections.Generic;
using LukeBaker;
using UnityEngine;

namespace RileyMcGowan
{
    public class MaterialRadius : CommonObject, IGameModeInteractable
    {
        private bool isActive = false;
        private GameObject gravityObject;
        private GravityManager gravityManager;
        private List<GameObject> players;
        private Material currentMaterial;
        private float distanceToPlayer;

        private void Update()
        {
            if (isActive == true)
            {
                foreach (GameObject playerGameObject in players)
                {
                    distanceToPlayer = Vector3.Distance(gravityObject.transform.position, playerGameObject.transform.position);
                    currentMaterial.SetFloat("appearVariable", distanceToPlayer/10);
                }
            }
        }

        public void Activate()
        {
            isActive = true;
            gravityObject = GetComponentInParent<Gravity>().gameObject;
            gravityManager = FindObjectOfType<GravityManager>();
            players = FindObjectOfType<CustomNetworkManager>().playerInstances;
            currentMaterial = GetComponent<Renderer>().material;
            Vector3 bounds = gravityObject.GetComponent<Renderer>().bounds.size;
            transform.localScale = new Vector3(bounds.x,bounds.y,0)*(2+gravityManager.areaToAffectGravity/10);
            transform.position = gravityObject.transform.position;
        }
    }
}