
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    public Image imgHP;
    public Image imgMB;

    private float maxHealthPlayer;
    private float currentHealthPlayer;

    private void Start()
    {
        maxHealthPlayer = 300f;
        currentHealthPlayer= maxHealthPlayer;
        imgHP.fillAmount = currentHealthPlayer/maxHealthPlayer;
    }

    private void OnEnable()
    {
        DamePlayer.playerTakeDamageDelegate += OnPlayerTakeDamage;
        DamePlayer.playerHealingHBPlayerDelegate += OnHealingPlayer;
        //DamePlayer.playerTakeDamageDelegate += OnHealingPlayer;
        currentHealthPlayer = maxHealthPlayer;
        imgHP.fillAmount = currentHealthPlayer / maxHealthPlayer;
    }
    
    private void OnDisable()
    {
        DamePlayer.playerTakeDamageDelegate -= OnPlayerTakeDamage;
        DamePlayer.playerHealingHBPlayerDelegate -= OnHealingPlayer;
        //DamePlayer.playerTakeDamageDelegate -= OnHealingPlayer;
    }

    public void onPauseButtonClick()
    {
        if (UiManager.HasInstance)
        {
            UiManager.Instance.ActivePausePanel(true);
           
        }
    }


    private void OnPlayerTakeDamage(float Damage)
    {
        currentHealthPlayer -= Damage;
        imgHP.fillAmount = currentHealthPlayer / maxHealthPlayer;
    }

    private void OnHealingPlayer(float healingPlayer)
    {
        if (currentHealthPlayer + healingPlayer >= maxHealthPlayer)
        {
            currentHealthPlayer = maxHealthPlayer;
            imgHP.fillAmount = currentHealthPlayer / maxHealthPlayer;
        }
        else
        {
            currentHealthPlayer += healingPlayer;
            imgHP.fillAmount = currentHealthPlayer / maxHealthPlayer;
        }
       
    }
}
