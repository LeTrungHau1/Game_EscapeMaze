using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToturialPanel : MonoBehaviour
{
    public void OnclickedBackButton()
    {
        if (UiManager.HasInstance)
        {

            UiManager.Instance.ActiveToturialPanel(false);
        }
    }
}
