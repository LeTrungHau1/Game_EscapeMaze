using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class DamePlayer : MonoBehaviour
{
    public static DamePlayer instance;
    public delegate void PlayerTakeDamage(float damage); //dịnh nghĩa hàm delegate
    public static PlayerTakeDamage playerTakeDamageDelegate; //khai báo hàm delegate

    public delegate void HealingHBPlayer(float healing);
    public static HealingHBPlayer playerHealingHBPlayerDelegate;


    [SerializeField] public DameEnemy dameEnemy;
    [SerializeField] public float maxHealthPlayer = 300f;
    [SerializeField] public float currentHealthPlayer;
    [SerializeField] public float damePlayer = 10f;
   
    private void Awake()
    {
        instance = this;
        dameEnemy = GetComponent<DameEnemy>();
        currentHealthPlayer = maxHealthPlayer;
    }
    void Start()
    {
       
       //image.fillAmount = currentHealthPlayer/maxHealthPlayer;
    }
    public void TakeDamePlayer(float damaEnemy)
    {
        currentHealthPlayer -= damaEnemy;
        playerTakeDamageDelegate(damaEnemy);
        if (currentHealthPlayer <= 0)
        {
            Die(); 
        }
    }
    public void HealingHB(float healingPlayer)
    {
        if(currentHealthPlayer + healingPlayer >= maxHealthPlayer)
        {
            currentHealthPlayer = maxHealthPlayer;
            playerHealingHBPlayerDelegate(healingPlayer);
        }
        else
        {
            currentHealthPlayer += healingPlayer;
            playerHealingHBPlayerDelegate(healingPlayer);
        }
    }


    private void Die()
    {
        // Xử lý logic khi Enemy bị tiêu diệt
        Debug.Log("player die.");
        gameObject.SetActive(false);
        //hiện thua
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE("PlayerLoss");

        }
        if (UiManager.HasInstance)
        {
            Time.timeScale = 0f;
            UiManager.Instance.ActiveLosePanel(true);
        }
    }



}
