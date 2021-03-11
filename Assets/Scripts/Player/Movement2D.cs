using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movement2D : MonoBehaviour
{ 
    [SerializeField]
    private float moveSpeed = 6.0f;

    //dash
    [SerializeField]
    private float dashSpeed = 3.0f;
    [SerializeField]
    private float dashTime = 0f;
    [SerializeField]
    private float startDashTime = 0f;
    private bool isTryDash = false;
    private float dashDirection = 0;

    [SerializeField]
    private int maxDashCount = 0;
    private int dashCount = 0;

    [SerializeField]
    private float dashCooldown = 0;
    private float dashCooldownTimer = 0;
    bool isDashCooldown = false;

    float originGravityScale;

    [SerializeField]
    private float jumpForce = 5.0f;

    private Rigidbody2D rigidbody;

    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private LayerMask platformLayer;
    private BoxCollider2D boxCollider;
    private bool isGrounded;
    private Vector3 footPosition;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();

        dashTime = startDashTime;
        originGravityScale = rigidbody.gravityScale;
    }

    public void FixedUpdate()
    {
        Bounds bounds = boxCollider.bounds;

        footPosition = new Vector2(bounds.center.x, bounds.min.y);

        isGrounded = Physics2D.OverlapCircle(footPosition, 0.1f, groundLayer);

        if(!isGrounded)
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
        rigidbody.velocity = new Vector2(_x * moveSpeed, rigidbody.velocity.y);
    }

    public void Jump()
    {
        if(isGrounded == true)
        {
            rigidbody.velocity = Vector2.up * jumpForce;
        }

    }

    private void CheckDash()
    {
        if (dashCooldownTimer <= 0)
        {
            dashCount = 0;
            dashCooldownTimer = 0f;
            rigidbody.gravityScale = originGravityScale;
        }
        else
        {
            dashCooldownTimer -= Time.deltaTime;
        }

        if (isDashCooldown)
        {
            if (dashCooldownTimer <= 0)
            {
                isDashCooldown = false;
            }
        }
        else
        {
            if (isTryDash)
            {
                if (dashTime <= 0)
                {
                    dashTime = startDashTime;
                    rigidbody.velocity = Vector2.zero;
                    isTryDash = false;
                    rigidbody.gravityScale = originGravityScale;
                }
                else
                {
                    dashTime -= Time.deltaTime;
                    Dash();
                }
            }
        }

    }

    public void TryDash(float _dir)
    {
        if (isDashCooldown)
            return;

        if (dashCount >= maxDashCount)
        {
            dashCount = maxDashCount;
            dashCooldownTimer = dashCooldown;
            isDashCooldown = true;
            return;
        }

        isTryDash = true;
        dashDirection = _dir;

        dashCount++;
        dashCooldownTimer = dashCooldown;
    }

    private void Dash()
    {
        rigidbody.velocity = new Vector2(dashDirection * dashSpeed, rigidbody.velocity.y);
        rigidbody.gravityScale = 0f;
    }
}
