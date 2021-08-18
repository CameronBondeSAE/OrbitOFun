using LukeBaker;
using Mirror;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zach;

namespace Tim
{
    //public enum GameState {Menu, Race, Battle}

    //public delegate void OnStateChangeHandler();
    
    public class GameManager : NetworkBehaviour
    {
        protected GameManager() {}
        private static GameManager instance = null;
        public GameModeBase gameModeBase;

		public CustomNetworkManager customNetworkManager;

        public string currentLevel;
        public event Action gameStartEvent;
        public event Action gameEndEvent;
		
        //public GameModeBase gameMode;
        //public event OnStateChangeHandler OnStateChange;
        //public GameState gamestate { get; private set; }

        public static GameManager Instance
        {
            get
            {
                if (GameManager.instance == null)
                {
                    DontDestroyOnLoad(GameManager.instance);
                    GameManager.instance = new GameManager();
                }
                return GameManager.instance;
            }
        }

        public void GameStart()
        {
            //calls the activate function of the game mode
            gameModeBase.Activate();
            
            RpcGameStart();
        }

        [ClientRpc]
        public void RpcGameStart()
        {
            gameStartEvent?.Invoke();
        }

        
        
        
        public void GameEnd()
        {
            gameEndEvent?.Invoke();
        }

        public void SetLevel(string level)
        {
            currentLevel = level;
        }

        public void LoadLevel()
        {
            //level = "Levels/" + "";
            //loads the specified scene
            // SceneManager.LoadSceneAsync(level);
			customNetworkManager.ServerChangeScene(currentLevel);
		}
 

		public void UnLoadLevel(string level)
		{
			SceneManager.UnloadSceneAsync(level);
		}

        /*public void SetGameState(GameState state)
        {
            this.gamestate = state;
            OnStateChange();
        }
        */

        public void OnApplicationQuit()
        {
            GameManager.instance = null;
        }
    }
}

