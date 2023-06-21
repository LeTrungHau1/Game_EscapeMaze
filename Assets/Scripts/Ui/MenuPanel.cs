using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPanel : MonoBehaviour
{
    public void Onstargamebutton()
    {

        if (UiManager.HasInstance)
        {
            
            UiManager.Instance.ActiveMenuPanel(false);        
            SceneManager.LoadScene("Level1");
            UiManager.Instance.ActiveGamePanel(true);
        }
      
    }
    public void onSettingButtonClick()
    {
        if (UiManager.HasInstance)
        {
            UiManager.Instance.ActiveSettingPanel(true);

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
