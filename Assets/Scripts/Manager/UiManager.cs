using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : BaseManager<UiManager>
{
    [SerializeField]
    private MenuPanel menupanel;
    public MenuPanel Menupanel => menupanel;

    [SerializeField]
    private GamePanel gamepanel;
    public GamePanel Gamepanel => gamepanel;

    [SerializeField]
    private SettingPanel settingPanel;
    public SettingPanel SettingPanel => settingPanel;

    [SerializeField]
    private LosePanel losePanel;
    public LosePanel LosePanel => losePanel;


    [SerializeField]
    private VictoryPanel victoryPanel;
    public VictoryPanel VictoryPanel => victoryPanel;

    [SerializeField]
    private PausePanel pausePanel;
    public PausePanel PausePanel => pausePanel;

    [SerializeField]
    private ToturialPanel toturialPanel;
    public ToturialPanel ToturialPanel => toturialPanel;






    void Start()
    {

        ActiveMenuPanel(true);
        ActiveGamePanel(false);
        ActiveSettingPanel(false);
        ActiveLosePanel(false);
        ActiveVectoryPanel(false);
        ActivePausePanel(false);
       ActiveToturialPanel(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.HasInstance && GameManager.Instance.Isplaying)
            {
                GameManager.Instance.Pausegame();
                ActivePausePanel(true);
            }
        }
    }


    public void ActiveMenuPanel(bool active)
    {
        menupanel.gameObject.SetActive(active);
    }
    public void ActiveGamePanel(bool active)
    {
        gamepanel.gameObject.SetActive(active);
    }
    public void ActiveSettingPanel(bool active)
    {
        settingPanel.gameObject.SetActive(active);
    }
    public void ActiveLosePanel(bool active)
    {
        losePanel.gameObject.SetActive(active);
    }
    public void ActiveVectoryPanel(bool active)
    {
        victoryPanel.gameObject.SetActive(active);
    }
    public void ActivePausePanel(bool active)
    {
        pausePanel.gameObject.SetActive(active);
    } 
    public void ActiveToturialPanel(bool active)
    {
        toturialPanel.gameObject.SetActive(active);
    }
   

}
