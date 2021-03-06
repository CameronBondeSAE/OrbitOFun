using System.Collections;
using System.Collections.Generic;
using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameInput : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_InputField nameInputField = null;
    [SerializeField] private Button continueButton = null;
    
    public static string DisplayName { get; private set; }

    private const string PlayerPrefsNameKey = "PlayerName";

    // Start is called before the first frame update
    private void Start()
    {
        SetUpInputField();
    }

    private void SetUpInputField()
    {
        if (!PlayerPrefs.HasKey(PlayerPrefsNameKey))
        {
            return;
        }

        string defaultName = PlayerPrefs.GetString(PlayerPrefsNameKey);

        nameInputField.text = defaultName;

        SetPlayerName(defaultName);
    }

    //TODO inputfield component needs to call this On Value Changed
    public void SetPlayerName(string name)
    {
        continueButton.interactable = !string.IsNullOrEmpty(name);
    }

    //when next open up the game the name saves
    //TODO attach to a "Confirm" button
    public void SavePlayerName()
    {
        DisplayName = nameInputField.text;
        
        PlayerPrefs.SetString(PlayerPrefsNameKey, DisplayName);
    }
}
