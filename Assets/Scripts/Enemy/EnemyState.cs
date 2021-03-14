﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : LivingEntity
{

    public float fLastAttTime;



    public void changeState(float _Health, float _AttDamage, float _AttSpeed, float _MoveSpeed, float _DashSpeed)
    {
        this.fHealth = _Health;
        this.fAttDamage = _AttDamage;
        this.fAttSpeed = _AttSpeed;
        this.fMoveSpeed = _MoveSpeed;
        this.fDashSpeed = _DashSpeed;
    }
    public void Initialize()
    {
        changeState(100, 10, 1, 5, 3);   //체력, 공격력, 공속, 이동속도, 대쉬스피드
 
    }



    private void Awake()
    {
        Initialize();


    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            if (!bDead && Time.time >= fLastAttTime + fAttSpeed)
            {

                LivingEntity target = other.GetComponent<LivingEntity>();


                target.OnDamage(fAttDamage);
                fLastAttTime = Time.time;
                //PlayerState.Instance.HitDetect(GetComponent<Rigidbody2D>().velocity.x);
                
            }
        }
    }










    public override void OnDamage(float _damage)
    {
        base.OnDamage(_damage);
        
    }
    public override void RestoreHealth(float _newfHealth)
    {
        base.RestoreHealth(_newfHealth);
    }
    public override void Die()
    {
        base.Die();
    }






}