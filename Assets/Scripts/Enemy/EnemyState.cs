using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : LivingEntity
{

    public float fLastAttTime;
    public EnemyInfo enemydata = null;



    public void changeState(float _Health, float _AttDamage, float _AttSpeed, float _CriticalDMG,float _CriticalPer, int _DefPoint,float _MoveSpeed, float _DashSpeed)
    {
        this.fHealth = _Health;
        this.fPhysicalDamage = _AttDamage;
        this.fAttSpeed = _AttSpeed;
        this.fMoveSpeed = _MoveSpeed;
        this.fDashSpeed = _DashSpeed;
    }

    public void Initialize()
    {
        //changeState(enemydata.Hp,enemydata.Pysical_Dmg,enemydata.Attack_Spd,enemydata.Move_Spd,enemydata.)
 
    }



    private void Awake()
    {
        Initialize();
        

    }





    public override void OnDamage(float _damage,float _Direction)
    {

        base.OnDamage(_damage);
        
        GetComponentInChildren<EnemyBattle>().HitDetect(_Direction);

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
