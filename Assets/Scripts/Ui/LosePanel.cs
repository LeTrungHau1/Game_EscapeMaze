using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePanel : MonoBehaviour
{
    public void OnClickRestarButton()
    {
        if (GameManager.HasInstance)
        {
            GameManager.Instance.RestartGame();
            //SceneManager.LoadScene("Level1");
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
