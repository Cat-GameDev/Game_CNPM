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
        string distanceString;

        if (distance >= 1000)
        {
            float km = distance / 1000f;
            float remainingMeters = distance % 1000f;
            distanceString = $"{km:F0} k {remainingMeters:F0} m";
        }
        else
        {
            distanceString = $"{distance:F2} m";
        }

        distanceText.text = "Distance " + distanceString;
    }

    public void SettingButton()
    {
        UIManager.Instance.OpenUI<Setting>();
    }
}
