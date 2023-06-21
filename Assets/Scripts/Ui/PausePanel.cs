using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    public void OnclickedSettingButton()
    {
        if (UiManager.HasInstance)
        {
            UiManager.Instance.ActiveSettingPanel(true);
            UiManager.Instance.ActivePausePanel(false);
        }
    }
    public void OnclickedResumeButton()
    {
        if (GameManager.HasInstance && UiManager.HasInstance)
        {
            GameManager.Instance.Resumegame();
            UiManager.Instance.ActivePausePanel(false);
        }
    }
    public void OnclickedQuitButton()
    {
        if (GameManager.HasInstance)
        {
            GameManager.Instance.EndGame();
        }
    }
}
