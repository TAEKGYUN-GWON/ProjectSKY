using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

//살아있는 모든 개체의 
public class LivingEntity : ObjectBase
{
    public float fHealth;
    public bool bDead;
    public float fPhysicalDamage;
    public float fMagicalDamage;
    public float fAttSpeed;
    public float fMoveSpeed;
    public float fDashSpeed;
    public float fCriticalDamage;
    public float fCriticalPersentage;
    public E_ELEMENT_TYPE eElementType_Def = E_ELEMENT_TYPE.NONE;
    public E_ELEMENT_TYPE eElementType_Atk = E_ELEMENT_TYPE.NONE;

    //public int item;

    public event Action onDeath;

    protected virtual void OnEnable()
    {
        // 사망하지 않은 상태로 시작
        bDead = false;
    }
    public virtual void OnDamage(float _damage)
    {
        // 데미지만큼 체력 감소
        fHealth -= _damage;

        // 체력이 0 이하 && 아직 죽지 않았다면 사망 처리 실행
        if (fHealth <= 0 && !bDead)
        {
            Die();
        }
    }

    public virtual void RestoreHealth(float _newfHealth)
    {
        if (bDead)
        {
            // 이미 사망한 경우 체력을 회복할 수 없음
            return;
        }

        // 체력 추가
        fHealth += _newfHealth;
    }

    public virtual void Die()
    {
        // onDeath 이벤트에 등록된 메서드가 있다면 실행
        if (onDeath != null)
        {
            onDeath();
        }

        // 사망 상태를 참으로 변경
        bDead = true;
    }

}
