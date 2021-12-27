using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugUI : MonoBehaviour
{
#if UNITY_EDITOR
    public Text nowStateText;
    public Text selectTowerText;
    public Builder player;

    private void Update()
    {
        nowStateText.text = "Player State : " + player.stateMachine.nowState.name;
        selectTowerText.text = "Select Tower : " + (player.selectTower != null ? player.selectTower.name : "X");
    }
#endif
}
