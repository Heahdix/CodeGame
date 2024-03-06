using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : BaseEnemyScript
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 100f;
    public float shootSpeed = 5f;
    public GameObject bulletSpawnPoint;

    private Transform _target;

    private bool _canShoot = true;

    public override void Start()
    {
        base.Start();
        _target = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (_playerInTheRoom)
        {
            if (_target != null)
            {
                if (_target.transform.position.x < gameObject.transform.position.x)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 180f, 0);
                }

                if (Vector2.Distance(transform.position, _target.position) < enemyData.range * 0.3f)
                {
                    transform.position = Vector2.MoveTowards(transform.position, _target.position, -enemyData.speed * Time.deltaTime);
                }
                else if (Vector2.Distance(transform.position, _target.position) < enemyData.range)
                {
                    if (_canShoot)
                    {
                        Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);

                        StartCoroutine(ShootInterval());
                    }
                }
                else
                {
                    transform.position = Vector2.MoveTowards(transform.position, _target.position, enemyData.speed * Time.deltaTime);
                }
            }
        }
    }

    IEnumerator ShootInterval()
    {
        _canShoot = false;
        float timer = 0;
        while (timer < shootSpeed)
        {
            yield return null;
            timer += Time.deltaTime;
        }
        _canShoot = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, enemyData.range);
        Gizmos.DrawWireSphere(transform.position, enemyData.range * 0.3f);
    }
}
