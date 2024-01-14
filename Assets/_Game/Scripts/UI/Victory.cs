using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class Victory : UICanvas
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Button retryButton;
    [SerializeField] Button rankButton;
    [SerializeField] TMP_InputField namePlayerInputField;
    int score;

    public int Score { get => score;}

    public string GetPlayerName() => namePlayerInputField.text;



    public override void Open()
    {
        base.Open();
        namePlayerInputField.text = null;
    }

    public void RetryButton()
    {
        LevelManager.Instance.OnRetry();
        Close(0f);
        DeAtiveButton();
    }

    public void MenuButton()
    {
        UIManager.Instance.OpenUI<Rank>();
        Close(0f);
        DeAtiveButton();
    }

    public void ShowScore(int score)
    {
        scoreText.text = "Score \n" +  score.ToString();
        this.score = score;
    }

    public void ActiveButton()
    {
        retryButton.gameObject.SetActive(true);
        rankButton.gameObject.SetActive(true);
    }

    private void DeAtiveButton()
    {
        retryButton.gameObject.SetActive(false);
        rankButton.gameObject.SetActive(false);
    }

    public void ActiveButtonAfterTime()
    {
        Invoke(nameof(ActiveButton), 3f);
    }

}
