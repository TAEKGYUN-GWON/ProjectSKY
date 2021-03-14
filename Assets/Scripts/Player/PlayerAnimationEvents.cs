using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour, AnimationEvent
{
    [SerializeField]
    PlayerBattle playerBattle;

    public void Attack()
    {
        playerBattle.Attack();
    }

    public void AttackEnd()
    {
        playerBattle.AttackEnd();
    }

}
