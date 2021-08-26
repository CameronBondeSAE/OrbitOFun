using System.Collections.Generic;
using LukeBaker;
using Mirror;
using System;
using System.Linq;
using Tim;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Zach;
using NetworkLobbyPlayer = LukeBaker.NetworkLobbyPlayer;

namespace John
{
	public class MenuUI : NetworkBehaviour
	{
		public GameObject menuView;
		
		[SerializeField]
		private CustomNetworkManager networkManager = null;

		public GameManager GameManager;

		public List<GameModeBase> GameModeBases;
		public GameObject         gameModesParentGO;
		public GameObject         gameModeSelectorPrefab;
		public Transform          gameModeUIPanel;
		public Transform          userUIPanel;
		public GameObject         userLobbyUIPrefab;

		public TMP_InputField nameInput;
		
		public Transform  levelUIPanel;
		public GameObject levelUIPrefab;
		List<GameObject>            listOfPlayersNames = new List<GameObject>();

		void Awake()
		{
			GameModeBases = gameModesParentGO.GetComponentsInChildren<GameModeBase>().ToList();

			if(isServer)
				nameInput.onEndEdit.AddListener(newName => CmdUpdateName(newName, NetworkClient.localPlayer));
			
			networkManager.newPlayerJoinedEvent += NewPlayerJoined;
			
			foreach (GameModeBase gameModeBase in GameModeBases)
			{
				GameObject go = Instantiate(gameModeSelectorPrefab, gameModeUIPanel);
				go.GetComponentInChildren<TextMeshProUGUI>().text = gameModeBase.gameModeName;
				go.GetComponentInChildren<Button>().onClick.AddListener(() => SetGameManager(gameModeBase));
			}
		}

		void NewPlayerJoined(NetworkLobbyPlayer obj)
		{
			//this code works however is not being called on play due to network being disconnected at play
			//will need to be called each time a player joins/leaves the lobby
			//refreshes the list of player names each time the function is called
			// for (int i = networkManager.roomSlots.Count - 1; i >= 0; i--)
			// {
			// 	foreach (Transform child in userUIPanel.transform)
			// 	{
			// 		GameObject.Destroy(child.gameObject);
			// 	}
			// 	GameObject go = Instantiate(userLobbyUIPrefab, userUIPanel);
			// 	go.GetComponentInChildren<TextMeshProUGUI>().text = networkManager.roomSlots[i].name;
			// }

			RefreshPlayerNames();
		}

		void RefreshPlayerNames()
		{
			foreach (GameObject listOfPlayersName in listOfPlayersNames)
			{
				Destroy(listOfPlayersName);
			}
			listOfPlayersNames.Clear();
			
			foreach (NetworkLobbyPlayer lobbyPlayer in networkManager.roomSlots)
			{
				GameObject go = Instantiate(userLobbyUIPrefab, userUIPanel);
				listOfPlayersNames.Add(go);
				go.GetComponentInChildren<TextMeshProUGUI>().text = lobbyPlayer.name;
			}
		}

		[Command]
		public void CmdUpdateName(string name, NetworkIdentity player)
		{
			player.GetComponent<NetworkLobbyPlayer>().name = name;
			UpdateName(name, player);
		}
		
		void UpdateName(string name, NetworkIdentity player)
		{
			// NetworkClient.localPlayer.GetComponent<NetworkLobbyPlayer>().name = name;

			RefreshPlayerNames();
			
			// foreach (GameObject listOfPlayersName in listOfPlayersNames)
			// {
			// 	
			// }
			//
			// foreach (NetworkLobbyPlayer lobbyPlayer in networkManager.roomSlots)
			// {
			// 	if (lobbyPlayer.netIdentity == player.GetComponent<NetworkIdentity>())
			// 	{
			// 		
			// 		go.GetComponentInChildren<TextMeshProUGUI>().text = lobbyPlayer.name;
			// 		
			// 	}
			// }

		}

		public void OnEnable()
		{
			GameManager.gameStartEvent += HideMenu;
			GameManager.gameEndEvent   += ShowMenu;
		}

		public void OnDisable()
		{
			GameManager.gameStartEvent -= HideMenu;
			GameManager.gameEndEvent   -= ShowMenu;
		}

		public void HideMenu()
		{
			menuView.SetActive(false);
		}

		public void ShowMenu()
		{
			menuView.SetActive(true);
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
				go.GetComponentInChildren<Button>().onClick.AddListener( ()=>GameManager.SetLevel(level));
			}
		}

		public void HostLobby()
		{
			networkManager.StartHost();

			//toggle UI from menu to lobby UI
		}

		public void Update()
		{
			// HACK, use action map
			if (InputSystem.GetDevice<Keyboard>().escapeKey.wasPressedThisFrame)
			{
				if(menuView.activeSelf)
				{
					HideMenu();
				}
				else
				{
					ShowMenu();
				}
			}
		}
	}
}