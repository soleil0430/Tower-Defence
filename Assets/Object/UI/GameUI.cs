using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Builder player;
    public GameObject standUI;
    public GameObject buildUI;

    private void Start()
    {
        State<Builder> standState = player.stateMachine.GetState("Stand");
        standState.doEnter += () => { standUI.SetActive(true); };
        standState.doExit += () => { standUI.SetActive(false); };

        State<Builder> buildState = player.stateMachine.GetState("Build");
        buildState.doEnter += () => { buildUI.SetActive(true); };
        buildState.doExit += () => { buildUI.SetActive(false); };
    }

}
