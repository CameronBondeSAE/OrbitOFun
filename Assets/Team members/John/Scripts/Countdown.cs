using LukeBaker;
using Mirror;
using Tim;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace John
{
    public class Countdown : NetworkBehaviour
    {
        [SerializeField] private CustomNetworkManager networkManager = null;
        [SerializeField] private GameManager gameManager;
        [SyncVar] public float roundTimer;
        private string roundText;
        public TextMeshProUGUI UIText;
        private bool startCount;
    
        public override void OnStartServer()
        {
            base.OnStartServer();
            if (isServer)
            {
                // un-subscribe game manager to start round function
            }
        }
        public override void OnStopServer()
        {
            base.OnStopServer();
            // un-subscribe game manager to start round function
        }

        public void Update()
        {   
            //formatting timer in minutes and seconds
            int minutes = Mathf.FloorToInt(roundTimer / 60F);
            int seconds = Mathf.FloorToInt(roundTimer - minutes * 60);
            roundText = string.Format("{0:0}:{1:00}", minutes, seconds);
        
            //updating timer text with the remaining time
            UIText.text = ("Time Remaining: " + roundText);
        
            //able to delay the timer for the game
            if (startCount)
            {
                roundTimer = (roundTimer - Time.deltaTime);
            }
            //when the timer hits zero, stop counting
            if (roundTimer <= -0.1f)
            {
                //call the end of the round function in game manager
                startCount = false;
                roundTimer = default;
            }
        }
    
        //start the countdown
        [ClientRpc]
        public void RPCStartRound()
        {
            startCount = true;
        }
    } 
}

