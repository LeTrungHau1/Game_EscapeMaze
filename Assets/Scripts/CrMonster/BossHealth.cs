using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : DameEnemy
{
    protected override void Die()
    {
        base.Die();
        GameManager.Instance.Pausegame();
        UiManager.Instance.VictoryPanel.gameObject.SetActive(true);
    }
}
