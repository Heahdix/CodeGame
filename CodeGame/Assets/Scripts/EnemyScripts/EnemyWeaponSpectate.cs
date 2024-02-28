using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponSpectate : MonoBehaviour
{
    public GameObject owner;

    private GameObject _player;

    private void Start()
    {
        _player = GameObject.Find("Player");
    }

    void Update()
    {
        if (_player != null)
        {
            transform.position = owner.transform.position;

            Vector3 Look = gameObject.transform.InverseTransformPoint(GameObject.Find("Player").transform.position);
            float Angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg - 180;

            gameObject.transform.Rotate(0, 0, Angle);
        }
    }
}
