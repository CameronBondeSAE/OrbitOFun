using System.Collections.Generic;
using LukeBaker;
using System.Linq;
using Tim;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zach;

namespace John
{
	public class MenuUI : MonoBehaviour
	{
		[SerializeField]
		private CustomNetworkManager networkManager = null;

		public GameManager GameManager;

		public List<GameModeBase> GameModeBases;
		public GameObject         gameModesParentGO;
		public GameObject         gameModeSelectorPrefab;
		public Transform          gameModeUIPanel;
		public Transform          userUIPanel;
		public GameObject         userLobbyUIPrefab;

		public Transform          levelUIPanel;
		public GameObject         levelUIPrefab;

		void Awake()
		{
			GameModeBases = gameModesParentGO.GetComponentsInChildren<GameModeBase>().ToList();

			foreach (GameModeBase gameModeBase in GameModeBases)
			{
				GameObject go = Instantiate(gameModeSelectorPrefab, gameModeUIPanel);
				go.GetComponentInChildren<TextMeshProUGUI>().text =  gameModeBase.gameModeName;
				go.GetComponentInChildren<Button>().onClick.AddListener(() => SetGameManager(gameModeBase));
			}
			
			foreach (string ip in networkManager.playerIP)
			{
				GameObject go = Instantiate(userLobbyUIPrefab, userUIPanel);
				go.GetComponentInChildren<TextMeshProUGUI>().text = ip; // TODO replace with player names from a real lobby player
			}
		}

		void SetGameManager(GameModeBase gameModeBase)
		{
			GameManager.gameModeBase = gameModeBase;
			UpdateLevelPanel(gameModeBase);
		}

		void UpdateLevelPanel(GameModeBase gameModeBase)
		{
			foreach (Transform t in levelUIPanel.GetComponentsInChildren<Transform>().ToList())
			{

				if (t != levelUIPanel)
				{
					/// Unsub click
					Destroy(t.gameObject);
				}
			}
		
			foreach (string level in gameModeBase.levels)
			{
				GameObject go = Instantiate(levelUIPrefab, levelUIPanel);
				go.GetComponentInChildren<TextMeshProUGUI>().text = level;
				
				go.GetComponentInChildren<Button>().onClick.AddListener( ()=>GameManager.LoadLevel(level) );
			}
		}

		public void HostLobby()
		{
			networkManager.StartHost();

			//toggle UI from menu to lobby UI
		}
	}
}