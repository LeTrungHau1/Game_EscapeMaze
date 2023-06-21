using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryPanel : MonoBehaviour
{
    public void OnClickRestarButton()
    {
        if (GameManager.HasInstance)
        {
            GameManager.Instance.RestartGame();
        }
    }
    public void OnClickExitButton()
    {
        if (GameManager.HasInstance)
        {
            GameManager.Instance.EndGame();
        }
    }
}
