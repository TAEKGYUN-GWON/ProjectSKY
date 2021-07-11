using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SwordAttackCommand : ICommand
{
    [SerializeField]
    private PlayerBattle playerBattle = null;
    private Animator animator = null;

    public SwordAttackCommand(PlayerBattle playerBattle, Animator animator)
    {
        this.playerBattle = playerBattle;
        this.animator = animator;
    }
    public void Execute()
    {
        animator.SetTrigger("Attack");
    }
}
