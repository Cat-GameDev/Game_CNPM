using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlay : UICanvas
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI distanceText;
    public void SetCoin(int score)
    {
        scoreText.text = score.ToString();
    }

    public void SetDistance(float distance)
    {
        distanceText.text = "Distance " +  distance.ToString("F2");
    }

    public void SettingButton()
    {
        UIManager.Instance.OpenUI<Setting>();
    }
}
