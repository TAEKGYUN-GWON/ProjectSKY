using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEvent : MonoBehaviour, AnimationEvent
{
    EnemyBattle enemyBattle;
    private void Awake()
    {
        enemyBattle = GetComponentInChildren<EnemyBattle>();
    }

    public void Attack()
    {
        enemyBattle.Attak();
    }
    public void AttackEnd()
    {
        enemyBattle.AttackDamage();

    }




}
