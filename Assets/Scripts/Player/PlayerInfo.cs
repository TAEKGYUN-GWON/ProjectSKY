using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : LivingEntity
{
    [SerializeField]
    PlayerController playerController;
    [SerializeField]
    PlayerMovement2D playerMovement2D;

    //dash
    [SerializeField]
    private int nMaxDashCount = 0;
    public int MaxDashCount => nMaxDashCount;

    [SerializeField]
    private float nDashCooldown = 0;
    public float DashCooldown => nDashCooldown;


    //jump
    [SerializeField]
    private float fJumpForce = 5.0f;
    public float JumpForce => fJumpForce;
    public int nMaxJumpCount;

    private void Awake()
    {
        
    }

}
