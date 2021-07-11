using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class JumpCommand : ICommand
{
    [SerializeField]
    private PlayerMovement2D playerMovement = null;

    public JumpCommand(PlayerMovement2D playerMovement)
    {
        this.playerMovement = playerMovement;
    }
    public void Execute()
    {
        playerMovement.Jump();
    }
}