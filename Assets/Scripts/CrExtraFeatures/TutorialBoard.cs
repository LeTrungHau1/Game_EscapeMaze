using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBoard : MonoBehaviour
{
    public GameObject txtboard;
    //public GameObject pointBoard;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        txtboard.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        txtboard.SetActive(false);
    }
}
