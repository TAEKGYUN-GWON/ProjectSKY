using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DownJumpCommand : ICommand
{
    [SerializeField]
    private PlayerMovement2D playerMovement = null;

    public DownJumpCommand(PlayerMovement2D playerMovement)
    {
        this.playerMovement = playerMovement;
    }
    public void Execute()
    {
        playerMovement.DownJump();
    }
}