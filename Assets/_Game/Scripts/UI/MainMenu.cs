using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenu : UICanvas
{

    [SerializeField] Transform musicPanal;
    [SerializeField] Button mute;
    [SerializeField] Button unmute;

    public void ShopButton()
    {
        GameManager.Instance.ChangeState(GameState.Shop);

        UIManager.Instance.OpenUI<Shop>();
        Close(0f);
    }


    public void PlayButton()
    {
        LevelManager.Instance.OnStartGame();

        UIManager.Instance.OpenUI<GamePlay>();
        Close(0f);
    }

    public void RankButton()
    {
        UIManager.Instance.OpenUI<Rank>();
        Close(0f);
    }

    public void SettingButton()
    {
        musicPanal.gameObject.SetActive(true);
        //unmute.gameObject.SetActive(false);
    }

    public void ExitSettingButton()
    {
        musicPanal.gameObject.SetActive(false);
    }

    public void MuteButton()
    {
        AudioManager.Instance.ToggleMusic();
        AudioManager.Instance.ToggleSFX();
        mute.gameObject.SetActive(false);
        unmute.gameObject.SetActive(true);
    }

    public void UnmuteButton()
    {
        AudioManager.Instance.ToggleMusic();
        AudioManager.Instance.ToggleSFX();
        mute.gameObject.SetActive(true);
        unmute.gameObject.SetActive(false);
    }




    public void ExitButton()
    {
        Application.Quit();
    }



    
}
