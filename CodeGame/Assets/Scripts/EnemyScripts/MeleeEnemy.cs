using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MeleeEnemy : BaseEnemyScript
{
    public Animator anim;

    private Transform _target;
    private Vector3 _jumpPos;
    private bool _isAttacking = false;

    public override void Start()
    {
        base.Start();
        _target = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (_playerInTheRoom)
        {
            if (_target != null && !_isAttacking)
            {
                if (Vector2.Distance(transform.position, _target.position) < enemyData.range)
                {
                    _jumpPos = _target.position;
                    _isAttacking = true;
                    anim.SetTrigger("Attack");
                }
                else
                {
                    transform.position = Vector2.MoveTowards(transform.position, _target.position, enemyData.speed * Time.deltaTime);
                }
            }
        }
    }

    private void Jump()
    {
        Vector3 jumpDirection = (_jumpPos - transform.position).normalized * 5;

        rb.AddForce(jumpDirection, ForceMode2D.Impulse);
    }

    private void EndAttack()
    {
        _isAttacking = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, enemyData.range);
    }

}
