using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : LivingEntity
{

    public float fLastAttTime;
    public EnemyInfo enemydata;



    public void changeState(float _Health, float _AttDamage, float _AttSpeed, float _CriticalDMG,float _CriticalPer, float _DefPoint,float _MoveSpeed)
    {
        this.fHealth = _Health;
        this.fPhysicalDamage = _AttDamage;
        this.fAttSpeed = _AttSpeed;
        this.fCriticalDamage = _CriticalDMG;
        this.fCriticalPersentage = _CriticalPer;
        this.fDeffencePoint = _DefPoint;
        this.fMoveSpeed = _MoveSpeed;
    }

    public void Initialize()
    {
        changeState(enemydata.Hp, enemydata.Pysical_Dmg, enemydata.Attack_Spd, enemydata.Critical_Dmg, enemydata.Critical_Per, enemydata.Def_Point, enemydata.Move_Spd);
        //changeState(100, 10, 1, 100, 0, 10, 5);
        
    }

    


    private void Start()
    {

        if(enemydata != null)
        {
            Initialize();
        }


    }





    public override void OnDamage(float _damage,float _Direction)
    {

        base.OnDamage(_damage);                                     
        
        GetComponentInChildren<EnemyBattle>().HitDetect(_Direction);        //플레이어가 때린 방향을 전달

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
