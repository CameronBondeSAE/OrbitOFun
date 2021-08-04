using UnityEngine;
using UnityEngine.SceneManagement;
using Zach;

namespace Tim
{
    //public enum GameState {Menu, Race, Battle}

    //public delegate void OnStateChangeHandler();
    
    public class GameManager : MonoBehaviour
    {
        protected GameManager() {}
        private static GameManager instance = null;
        public GameModeBase gameModeBase;
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
        }

        public void LoadLevel()
        {
            //loads the specified scene
            SceneManager.LoadScene("Main", LoadSceneMode.Additive);
        }

		public void UnLoadLevel()
		{
			SceneManager.UnloadSceneAsync("Main");
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

