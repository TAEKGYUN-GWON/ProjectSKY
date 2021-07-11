using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DashCommand : ICommand
{
    [SerializeField]
    private PlayerMovement2D playerMovement = null;

    public DashCommand(PlayerMovement2D playerMovement)
    {
        this.playerMovement = playerMovement;
    }
    public void Execute()
    {
        playerMovement.TryDash();
    }
}
