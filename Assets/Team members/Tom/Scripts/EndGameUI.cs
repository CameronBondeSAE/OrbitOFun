using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Tom
{
    public class EndGameUI : MonoBehaviour
    {
        public TextMeshProUGUI winnerName;
    
        public void SetWinnerName(string newName)
        {
            winnerName.text = newName + "!";
        }
    }
}