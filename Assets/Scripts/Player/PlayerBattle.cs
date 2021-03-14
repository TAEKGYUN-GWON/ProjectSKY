using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattle : MonoBehaviour
{
    [SerializeField]
    PlayerInfo playerInfo = null;
    [SerializeField]
    CapsuleCollider2D capsuleCollider2D = null;

    bool isAttacked = false;

    public bool IsAttacked => isAttacked;

    private void Awake()
    {
        capsuleCollider2D.enabled = false;
    }

    public void Attack()
    {
        capsuleCollider2D.enabled = true;
        isAttacked = true;
    }

    public void AttackEnd()
    {
        capsuleCollider2D.enabled = false;
        isAttacked = false;
    }

    public void Hit(LivingEntity _livingEntity)
    {
        if(playerInfo == null)
        {
            Debug.LogError("Player Info Missing");
            return;
        }

        playerInfo.OnDamage(_livingEntity.fAttDamage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            var _entity = collision.GetComponent<EnemyState>();

            if (_entity == null)
                return;

            _entity.OnDamage(playerInfo.fAttDamage);
        }
    }




}
