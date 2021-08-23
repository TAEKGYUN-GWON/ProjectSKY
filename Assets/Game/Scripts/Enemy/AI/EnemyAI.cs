using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    EnemyMovement enemyMovement;
    [SerializeField]
    EnemyState EnemyState;
    [SerializeField]
    public int selectPattern;
    [SerializeField]
    Animator enemyAnimator;

    public BoxCollider2D Tracer;
    int nPlayerLayer;
    LayerMask playerMask;
    private float fLastMoveTime;
    private float fDelay;
    private int nParameter;
    private bool bInPlayer;
    Vector3 playerTransform;
    Transform Target;
    LivingEntity player;
    WaitForSeconds checkTime;
    bool bisIdle;
    bool bisTrace;
    bool bisAttack;

    TraceState trace;
    AttState attack;
    IdleState idle;
    NullState ns;

    private StateMachine stateMachine;

    


    private void Start()
    {
        enemyMovement = GetComponentInParent<EnemyMovement>();
        nPlayerLayer = LayerMask.NameToLayer("Player");
        fLastMoveTime = 0;
        bInPlayer = false;
        bisIdle = true;
        bisTrace = false;
        bisAttack = false;
        checkTime = new WaitForSeconds(1f);


        ns = new NullState();
        idle = new IdleState(enemyMovement);
        trace = new TraceState(enemyMovement);
        attack = new AttState(enemyMovement, enemyAnimator);

        stateMachine = new StateMachine(ns);
        StartCoroutine(StartPattern());
        




    }

    private void Update()
    {
        stateMachine.DoOperateUpdate();
    }


    IEnumerator StartPattern()
    {

        Debug.Log("test");

        CheckState();
    
        yield return checkTime;
        StartCoroutine(StartPattern());
    }

    void CheckState()
    {
        if(!bisTrace && !bisAttack)
        {
            stateMachine.SetState(idle);
            Debug.Log("setstateidle");
        }
        //if(bisTrace)
        //{
        //    stateMachine.SetState(trace);
        //}

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            bInPlayer = true;
            if (!trace.isTarget())
            {
                Target = collision.transform;
                trace.GetTarget(Target,transform);
                player = collision.GetComponent<LivingEntity>();
            }
            bisTrace = true;
            stateMachine.SetState(trace);
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(Vector2.Distance(Target.position,transform.position) <5.0f)
            {
                bisAttack = true;
                stateMachine.SetState(attack);

            }

        }



    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            bInPlayer = false;
            bisTrace = false;
            stateMachine.SetState(idle);
        }
    }

    public void Attack()
    {
        
    }
    public void AttackDamage()
    {
        Debug.Log("데미지");
        if(Vector2.Distance(Target.position,transform.position) <3.0f)
        {
            player.OnDamage(EnemyState.fPhysicalDamage);
            Debug.Log("데미지줌");
        }
        else
        {
            Debug.Log("거리");
            return;
        }
    }



    public void Pattern1()
    {
        fDelay = Random.Range(1.5f, 3.0f);

        if (!bInPlayer && enemyMovement.bCanMove)
        {
            if (Time.time > fLastMoveTime + 3f)
            {
                nParameter = Random.Range(1, 10);

                if (nParameter <= 4)
                {
                    enemyMovement.Move(0.7f);
                }
                else if (nParameter > 5 && nParameter <= 8)
                {
                    enemyMovement.Move(-0.7f);
                }
                else
                {
                    enemyMovement.Move(0);

                }
                fLastMoveTime = Time.time;
            }

        }

    }

    public void Pattern2()
    {



    }




}
