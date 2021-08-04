using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
[Serializable]
public class User : NetworkBehaviour
{
    public string name;
    public Color skinColour;
    public NetworkConnection networkConnection;
}
