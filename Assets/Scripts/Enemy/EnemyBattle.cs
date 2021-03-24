using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattle : MonoBehaviour
{
    [SerializeField]
    public CapsuleCollider2D attackZone;
    [SerializeField]
    public CapsuleCollider2D capsuleCollider2D;

    public Animator animator;
    public EnemyState enemyState;


    public EnemyMovement enemyMove;
    bool bIsAttacked;
    bool bPlayerIn;
    bool bA;
    float fLastAttTime;
    int nPlayerLayer;
    int distance;


    private void Awake()
    {

        enemyState = GetComponentInParent<EnemyState>();
        enemyMove = GetComponentInParent<EnemyMovement>();
        capsuleCollider2D.enabled = true;
        bIsAttacked = false;
        bPlayerIn = false;
        bA = false;
        fLastAttTime = 0f;
        nPlayerLayer = LayerMask.NameToLayer("Player");
    }


    public void HitDetect(float x)
    {

        animator.SetTrigger("Hit");
        StartCoroutine(WaitHit());
        //enemyMove.Hit(-1);
    }

    private IEnumerator WaitHit()
    {
        if (enemyState.bDead)
            yield break;
        enemyMove.bCanMove = false;
        yield return new WaitForSeconds(0.2f);
        enemyMove.bCanMove = true;
    }



    public void Attak()
    {
        attackZone.enabled = true;
    }

    public void AttackDamage()
    {
        attackZone.enabled = false;
        Debug.Log("attON");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag != "Player")
            return;
        if (collision.tag == "Player" && Time.time >= fLastAttTime + 3)
        {
            animator.SetTrigger("Attack");
            fLastAttTime = Time.time;
        }


    }

    



}
