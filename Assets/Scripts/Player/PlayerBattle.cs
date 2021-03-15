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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            var _entity = collision.GetComponent<LivingEntity>();

            if (_entity == null)
                return;

            _entity.OnDamage(playerInfo.fAttDamage);
        }
    }




}
