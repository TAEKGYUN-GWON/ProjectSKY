using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattle : MonoBehaviour
{
    public Animator animator;
    public EnemyState enemyState;
    public CapsuleCollider2D capsuleCollider2D;
    bool bIsAttacked;
    bool bPlayerIn;
    bool bA;
    float fLastAttTime;

    private void Awake()
    {
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        enemyState = GetComponentInParent<EnemyState>();
        animator = GetComponentInParent<Animator>();
        capsuleCollider2D.enabled = true;
        bIsAttacked = false;
        bPlayerIn = false;
        bA = false;
        fLastAttTime = 0f;
    }


    public void Attak()
    {
        capsuleCollider2D.enabled = true;
        
}

    public void AttackDamage()
    {
        if (bPlayerIn == true)
            bIsAttacked = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (bPlayerIn == false)
            bPlayerIn = true;




    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (bPlayerIn == false)
            bPlayerIn = true;
        if (collision.tag == "Player"&& Time.time>= fLastAttTime +2 )
        {
            animator.SetTrigger("Attack");
            fLastAttTime = Time.time;

        }
        if (bIsAttacked)
        {
            //collision.GetComponent<LivingEntity>().OnDamage(enemyState.fAttDamage);
            Debug.Log("플레이어때림");
            bIsAttacked = false;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (bPlayerIn == true)
            bPlayerIn = false;

    }




}
