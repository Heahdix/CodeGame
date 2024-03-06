using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MeleeEnemy : BaseEnemyScript
{
    public Animator anim;

    private Transform _target;
    private Vector3 _jumpPos;

    private enum _State
    {
        Attacking,
        Jumping,
    }

    private _State _state = _State.Attacking;

    public override void Start()
    {
        base.Start();
        _target = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (_playerInTheRoom)
        {
            if (_target != null && _state == _State.Attacking)
            {
                if (Vector2.Distance(transform.position, _target.position) < enemyData.range)
                {
                    _jumpPos = _target.position;
                    _state = _State.Jumping;
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
        StartCoroutine(Resting());
    }

    IEnumerator Resting()
    {
        float curRestingTime = 0;

        while (curRestingTime < 1.0f)
        {
            curRestingTime += Time.deltaTime;
            yield return null;
        }

        _state = _State.Attacking;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, enemyData.range);
    }
}
