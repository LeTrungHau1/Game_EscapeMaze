using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : MonoBehaviour
{
    public void onSettingButtonClick()
    {
        if (UiManager.HasInstance)
        {
            UiManager.Instance.ActiveSettingPanel(true);
           
        }
    }
}
