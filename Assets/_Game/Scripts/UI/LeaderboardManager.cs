using UnityEngine;
using TMPro;
using Dan.Main;
using System.Collections.Generic;
using System;


public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] List<TextMeshProUGUI> names;
    [SerializeField] List<TextMeshProUGUI> scores;
    string publicLeaderboardKey = 
    "67a2d55e3fb8894a2d72c474fed06d4e3010db89e757b338d417f5ea8d833c7f";

    private void Start()
    {
        GetLeaderboard();
    }

    public void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, ((msg) =>  
        {
            int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count;
            for(int i=0; i < loopLength; ++i)
            {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        }));
    }

    public void SetLeaderboardEntry(string username, int score)
    {
        LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, username, score, ((msg) => {
            GetLeaderboard();
        }));
    }


}
