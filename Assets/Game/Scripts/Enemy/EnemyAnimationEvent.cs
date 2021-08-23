using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEvent : MonoBehaviour, AnimationEvent
{
    [SerializeField]
    EnemyAI enemyAI;

    public void Attack()
    {
        if(enemyAI != null)
            enemyAI.Attack();
    }
    public void AttackEnd()
    {
        if (enemyAI != null)
            enemyAI.AttackDamage();

    }




}
