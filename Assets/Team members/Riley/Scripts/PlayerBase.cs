using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RileyMcGowan
{
    public class PlayerBase : MonoBehaviour
    {
        /// <summary>
        /// Function for controlling a simple action
        /// </summary>
        public virtual void Fire() {}
        /// <summary>
        /// Function for controlling player movement
        /// </summary>
        public virtual void Movement() {}
    }
}