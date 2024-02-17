using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : UICanvas
{
    [SerializeField] Transform musicPanal;
    [SerializeField] Button mute;
    [SerializeField] Button unmute;
    public override void Open()
    {
        Time.timeScale = 0;
        base.Open();
    }

    public override void Close(float delayTime)
    {
        Time.timeScale = 1;
        base.Close(0f);
    }

    public void ContinueButton()
    {
        Close(0f);
    }

    public void MenuButton()
    {
        LevelManager.Instance.OnMenu();
        Close(0f);
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
}
