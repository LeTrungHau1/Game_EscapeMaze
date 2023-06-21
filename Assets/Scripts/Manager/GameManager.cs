using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : BaseManager<GameManager> 
{
    //public static gamemanage instance;

    //private const string Cherrykey = "Cherry";
    //private int cherries = 0;
    //public int Cherries => cherries;

    private bool isPlaying = false;
    public bool Isplaying => isPlaying;




    protected override void Awake()
    {
        base.Awake();
        //cherries = PlayerPrefs.GetInt(Cherrykey, 0);

    }
   
    private void Start()
    {

    }
    //public void updatacherries(int value)
    //{
    //    cherries = value;
    //}
    public void Startgame()
    {
        isPlaying = true;
        Time.timeScale = 1f;
    }
    public void Pausegame()
    {

        if (isPlaying)
        {
            isPlaying = false;
            Time.timeScale = 0f;
        }
    }
    public void Resumegame()
    {
        if (!isPlaying)
        {
            isPlaying = true;
            Time.timeScale = 1f;
        }
    }
    public void RestartGame()
    {
        ChangeScene("StartMenu");
        if (UiManager.HasInstance)
        {
            UiManager.Instance.ActiveMenuPanel(true);
            UiManager.Instance.ActiveGamePanel(false);
            UiManager.Instance.ActiveVectoryPanel(false);
            UiManager.Instance.ActiveLosePanel(false);



        }
    }
    public void EndGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;//chỉ chạy trên editor (nếu k build game nó sẻ lỗi)
#endif
        Application.Quit();
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    //private void OnApplicationQuit()
    //{
    //    PlayerPrefs.SetInt(Cherrykey, cherries);
    //}
}
