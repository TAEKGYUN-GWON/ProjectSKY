using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEvent : MonoBehaviour, AnimationEvent
{
    [SerializeField]
    EnemyBattle enemyBattle;

    public void Attack()
    {
        if(enemyBattle != null)
            enemyBattle.Attak();
    }
    public void AttackEnd()
    {
        if (enemyBattle != null)
            enemyBattle.AttackDamage();

    }




}
