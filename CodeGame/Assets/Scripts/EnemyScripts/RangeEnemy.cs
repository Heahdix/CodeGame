using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : BaseEnemyScript
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 1f;
    public float shootSpeed = 1f;
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
        if (_target != null)
        {
            if (Vector2.Distance(transform.position, _target.position) < enemyData.range * 0.3f)
            {
                transform.position = Vector2.MoveTowards(transform.position, _target.position, -enemyData.speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, _target.position) < enemyData.range)
            {
                if (_canShoot)
                {
                    GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, bulletPrefab.transform.rotation);
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

                    rb.AddForce(_target.transform.position - bulletSpawnPoint.transform.position * bulletSpeed, ForceMode2D.Impulse);

                    StartCoroutine(ShootInterval());
                }
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, _target.position, enemyData.speed * Time.deltaTime);
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
