using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : DameEnemy
{
   
    protected override void Die()
    {
        //base.Die();
        //ani.SetInteger("State",(int) 5);
        gameObject.SetActive(false);
        GameManager.Instance.Pausegame();

        UiManager.Instance.VictoryPanel.gameObject.SetActive(true);
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE("PlayerWin");

        }
       
    }
    private void SoundBossAttack()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE("EnemyAttack");

        }
    }
}
