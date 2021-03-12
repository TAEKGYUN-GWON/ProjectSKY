﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement2D : MonoBehaviour
{ 
    [SerializeField]
    private float fMoveSpeed = 6.0f;

    //dash
    [SerializeField]
    private float fDashSpeed = 3.0f;
    [SerializeField]
    private float fDashTime = 0f;
    [SerializeField]
    private float fStartDashTime = 0f;
    private bool isTryDash = false;
    private float fDashDirection = 0;

    [SerializeField]
    private int nMaxDashCount = 0;
    private int nDashCount = 0;

    [SerializeField]
    private float nDashCooldown = 0;
    private float nDashCooldownTimer = 0;
    bool isDashCooldown = false;

    float fOriginGravityScale;

    [SerializeField]
    private float fJumpForce = 5.0f;

    private Rigidbody2D rigidbody;

    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private LayerMask platformLayer;
    [SerializeField]
    private BoxCollider2D boxColliderFoot;
    private bool isGrounded;
    private Vector3 footPosition;

    [SerializeField]
    Transform rootTransform;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        fDashTime = fStartDashTime;
        fOriginGravityScale = rigidbody.gravityScale;
    }

    public void FixedUpdate()
    {
        Bounds bounds = boxColliderFoot.bounds;

        footPosition = new Vector2(bounds.center.x, bounds.min.y);

        isGrounded = Physics2D.OverlapCircle(footPosition, 0.1f, groundLayer);

        if(rigidbody.velocity.y > 0)
        {
            boxColliderFoot.isTrigger = true;
        }
        else
        {
            boxColliderFoot.isTrigger = false;
        }

        if (!isGrounded)
        {
            isGrounded = Physics2D.OverlapCircle(footPosition, 0.1f, platformLayer);
        }

        CheckDash();

    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawSphere(footPosition, 0.1f);

    //}

    public void Move(float _x)
    {
        rigidbody.velocity = new Vector2(_x * fMoveSpeed, rigidbody.velocity.y);
    }

    public void Jump()
    {
        if(isGrounded == true)
        {
            rigidbody.velocity = Vector2.up * fJumpForce;
        }

    }

    private void CheckDash()
    {
        if (nDashCooldownTimer <= 0)
        {
            nDashCount = 0;
            nDashCooldownTimer = 0f;
            rigidbody.gravityScale = fOriginGravityScale;
        }
        else
        {
            nDashCooldownTimer -= Time.deltaTime;
        }

        if (isDashCooldown)
        {
            if (nDashCooldownTimer <= 0)
            {
                isDashCooldown = false;
            }
        }
        else
        {
            if (isTryDash)
            {
                if (fDashTime <= 0)
                {
                    fDashTime = fStartDashTime;
                    rigidbody.velocity = Vector2.zero;
                    isTryDash = false;
                    rigidbody.gravityScale = fOriginGravityScale;

                    var dashEffect = EffectManager.Instance.GetEffectToString("DashDefault");

                    if (dashEffect != null)
                    {
                        dashEffect.transform.position = rootTransform.position + (Vector3.up * 0.3f);
                        dashEffect.transform.rotation = Quaternion.Euler(dashEffect.transform.rotation.x, -fDashDirection * 90, dashEffect.transform.rotation.z);
                        dashEffect.startColor = Color.white;
                        dashEffect.Play();
                    }
                }
                else
                {
                    fDashTime -= Time.deltaTime;
                    Dash();
                }
            }
        }

    }

    public void TryDash(float _fDir)
    {
        if (isDashCooldown)
            return;

        if (nDashCount >= nMaxDashCount)
        {
            nDashCount = nMaxDashCount;
            nDashCooldownTimer = nDashCooldown;
            isDashCooldown = true;
            return;
        }

        isTryDash = true;
        fDashDirection = _fDir;

        nDashCount++;
        nDashCooldownTimer = nDashCooldown;

    }

    private void Dash()
    {
        rigidbody.velocity = new Vector2(fDashDirection * fDashSpeed, rigidbody.velocity.y);
        rigidbody.gravityScale = 0f;
    }
}