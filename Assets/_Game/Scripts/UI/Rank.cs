using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Rank : UICanvas
{
    Victory victoryUI;
    public UnityEvent<string, int> submitScoreEvent;

    public override void Open()
    {
        base.Open();
        if(victoryUI == null)
        {
            victoryUI = FindObjectOfType<Victory>();
        }

        if(victoryUI != null)
            SubmitScoreEvent();
    }
    public void BackButton()
    {
        UIManager.Instance.OpenUI<MainMenu>();
        Close(0f);
    }

    public void SubmitScoreEvent()
    {
        string playerName = victoryUI.GetPlayerName();
        int playerScore = victoryUI.Score;

        if (string.IsNullOrEmpty(playerName))
            playerName = "undefined";

        submitScoreEvent.Invoke(playerName, playerScore);
    }

}
