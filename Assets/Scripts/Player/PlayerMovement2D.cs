using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement2D : MonoBehaviour
{
    //Dash
    [SerializeField]
    private float fDashTime = 0f;
    [SerializeField]
    private float fStartDashTime = 0f;
    private int nDashCount = 0;
    private float nDashCooldownTimer = 0;
    private bool isTryDash = false;
    bool isDashCooldown = false;
    private float fDashDirection = 0;

    //Jump
    public int nJumpCount = 1;
    [SerializeField]
    private bool isGrounded;
    public bool IsGrounded => isGrounded;
    [SerializeField]
    private bool isFlatformer;
    public bool IsFlatformer => isFlatformer;
    public bool isDownJump = false;
    public float fDownJumpTimer = 0;

    [SerializeField]
    float fDownJumpTime;

    float fOriginGravityScale;

    private Rigidbody2D rigidbody;
    
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private LayerMask platformLayer;
    [SerializeField]
    private BoxCollider2D boxCollider;
    private Vector3 footPosition;

    [SerializeField]
    GameObject shadow;

    [SerializeField]
    Transform rootTransform;

    [SerializeField]
    PlayerBattle playerBattle;

    [SerializeField]
    PlayerInfo playerInfo;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        fDashTime = fStartDashTime;
        fOriginGravityScale = rigidbody.gravityScale;
    }

    public void FixedUpdate()
    {

        CheckDash();
        CheckJump();

    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawSphere(footPosition, 0.05f);

    //}

    public void Move(float _x)
    {
        rigidbody.velocity = new Vector2(_x * playerInfo.fMoveSpeed, rigidbody.velocity.y);
    }
    private void CheckJump()
    {
        if(isDownJump)
        {
            fDownJumpTimer += Time.deltaTime;
            if(fDownJumpTimer >= fDownJumpTime)
            {
                fDownJumpTimer = 0f;
                isDownJump = false;
                boxCollider.isTrigger = false;
            }
        }

        Bounds bounds = boxCollider.bounds;

        footPosition = new Vector2(bounds.center.x, bounds.min.y);

        isGrounded = Physics2D.OverlapCircle(footPosition, 0.05f, groundLayer);
        isFlatformer = Physics2D.OverlapCircle(footPosition, 0.05f, platformLayer);

        if (!isGrounded)
        {
            isGrounded = Physics2D.OverlapCircle(footPosition, 0.05f, platformLayer);
        }

        if(isGrounded || isFlatformer)
        {
            nJumpCount = 1;
            shadow.SetActive(true);
        }
        else if(!isGrounded && !isFlatformer)
        {
            shadow.SetActive(false);
        }
    }
    public void Jump()
    {
        if(isGrounded == true || nJumpCount < playerInfo.nMaxJumpCount)
        {
            nJumpCount++;
            rigidbody.velocity = Vector2.up * playerInfo.JumpForce;
        }

    }

    public void DownJump()
    {
        if (isDownJump)
            return;
        isDownJump = true;
        boxCollider.isTrigger = true;
        rigidbody.velocity = Vector2.down * (playerInfo.JumpForce / 2);
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

        if (nDashCount >= playerInfo.MaxDashCount)
        {
            nDashCount = playerInfo.MaxDashCount;
            nDashCooldownTimer = playerInfo.DashCooldown;
            isDashCooldown = true;
            return;
        }

        isTryDash = true;
        fDashDirection = _fDir;

        nDashCount++;
        nDashCooldownTimer = playerInfo.DashCooldown;
        EffectManager.Instance.CameraAnimEffect("Shake", E_CAMERA_ANIM_EFFECT_TYPE.TRIGGER);

    }

    private void Dash()
    {
        rigidbody.velocity = new Vector2(fDashDirection * playerInfo.fDashSpeed, rigidbody.velocity.y);
        rigidbody.gravityScale = 0f;
    }
}
