using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Damien
{
    public class BaseSpawner : MonoBehaviour
    {
        public GameObject playerBasePiece;
        private Vector3 playerPos;

        public void SpawnPlayerBases(GameObject player)
        { //Redundant Code
            //Not Used
            playerPos = player.transform.position;
            Instantiate(playerBasePiece, new Vector3(playerPos.x - 10, playerPos.y, playerPos.z), 
                Quaternion.identity);
            Instantiate(playerBasePiece, new Vector3(playerPos.x - 20, playerPos.y, playerPos.z), 
                Quaternion.identity);
            Instantiate(playerBasePiece, new Vector3(playerPos.x + 10, playerPos.y, playerPos.z), 
                Quaternion.identity);
            Instantiate(playerBasePiece, new Vector3(playerPos.x + 20, playerPos.y, playerPos.z), 
                Quaternion.identity);
        }
    }
}