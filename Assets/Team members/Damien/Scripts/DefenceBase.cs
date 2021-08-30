using System.Collections;
using System.Collections.Generic;
using Mirror;
using RileyMcGowan;
using UnityEngine;

public class DefenceBase : NetworkBehaviour
{
    private GameObject self;
    // Start is called before the first frame update
    void Start()
    {
        self = gameObject;
        GetComponent<Health>().deathEvent += Die;
    }

    public void Die(Health obj)
    {
        if (isServer)
        {
            GetComponent<Health>().deathEvent -= Die;
            NetworkServer.Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
