using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScene : MonoBehaviour
{
    private Animator ani;
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (AudioManager.HasInstance)
            {
                AudioManager.Instance.PlaySE("ThroughDoor", 0f);
            }
            ani.SetBool("BoolScene2", true);
           
        }
    }
    public void ThroughScene2()
    {
        SceneManager.LoadScene("Level2");
    }
}
