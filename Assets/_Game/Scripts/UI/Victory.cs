using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using UnityEditor;

public class Victory : UICanvas
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI distanceText;
    [SerializeField] Button retryButton;
    [SerializeField] Button rankButton;
    [SerializeField] Button backButton;
    [SerializeField] TMP_InputField namePlayerInputField;
    int score;
    float distance;

    public int Score { get => score;}
    public float Distance { get => distance; }

    public string GetPlayerName() => namePlayerInputField.text;



    public override void Open()
    {
        base.Open();
        namePlayerInputField.text = null;
    }

    public void BackButton()
    {
        UIManager.Instance.OpenUI<MainMenu>();
        Close(0f);
        DeAtiveButton();
    }

    public void RetryButton()
    {
        LevelManager.Instance.OnRetry();
        Close(0f);
        DeAtiveButton();
    }

    public void RankButton()
    {
        UIManager.Instance.OpenUI<Rank>();
        Close(0f);
        DeAtiveButton();
    }

    public void DisplayResult(float distance, int score)
    {
        ShowDistance(distance);
        ShowScore(score);
    }

    public void ShowScore(int score)
    {
        scoreText.text = score.ToString();
        this.score = score;
    }

    public void ShowDistance(float distance)
    {
        distanceText.text = "Distance \n" +  distance.ToString("F2");
        this.distance = distance;
    }

    public void ActiveButton()
    {
        retryButton.gameObject.SetActive(true);
        rankButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
    }

    private void DeAtiveButton()
    {
        retryButton.gameObject.SetActive(false);
        rankButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
    }

    public void ActiveButtonAfterTime()
    {
        Invoke(nameof(ActiveButton), 3f);
    }

}
