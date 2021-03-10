using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movement2D : MonoBehaviour
{ 
    [SerializeField]
    private float moveSpeed = 3.0f;

    [SerializeField]
    private float jumpForce = 5.0f;

    private Rigidbody2D rigidbody;

    [SerializeField]
    private LayerMask groundLayer;
    private BoxCollider2D boxCollider;
    private bool isGrounded;
    private Vector3 footPosition;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public void FixedUpdate()
    {
        Bounds bounds = boxCollider.bounds;

        footPosition = new Vector2(bounds.center.x, bounds.min.y);

        isGrounded = Physics2D.OverlapCircle(footPosition, 0.1f, groundLayer);

    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawSphere(footPosition, 0.1f);

    //}

    public void Move(float x)
    {
        rigidbody.velocity = new Vector2(x * moveSpeed, rigidbody.velocity.y);
    }

    public void Jump()
    {
        if(isGrounded == true)
        {
            rigidbody.velocity = Vector2.up * jumpForce;
        }

    }

}
