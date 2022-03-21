using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugCanvas : MonoBehaviour
{
    public TextMeshProUGUI O2_BubbleText;
    public TextMeshProUGUI O2_PlayerText;
    public TextMeshProUGUI PlayerHP_Text;


    private void Update()
    {
        O2_BubbleText.text = "Oxygen in Bubble:" + StaticValues.oxygenInBubble;
        O2_PlayerText.text = "Oxygen on Player:" + StaticValues.oxygenOnPlayer;
        PlayerHP_Text.text = "Player HP:" + StaticValues.playerHP;
    }
}
