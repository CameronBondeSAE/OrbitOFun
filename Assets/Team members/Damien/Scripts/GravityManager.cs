using System;
using System.Collections;
using Sirenix.Utilities;
using Damien;
using UnityEngine;

namespace Damien
{
    public class GravityManager : MonoBehaviour
    {
        public Rigidbody[] staticEntities;

        public Rigidbody[] nonstaticEntities;
        // Start is called before the first frame update
        void Start()
        {
            Rigidbody[] allEntities = FindObjectsOfType<Rigidbody>();
            
            foreach (var entity in allEntities)
            {
                if (gameObject.GetComponent<Gravity>())
                {
                    bool isStaticEntity = GetComponent<Gravity>().isStaticEntity;
                    if (isStaticEntity)
                    {
                        
                    }

                    if (!isStaticEntity)
                    {
                        
                    }
                    
                }

            }
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}