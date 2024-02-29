using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject[] doors;
    public event Action OnPlayerEntered;
    public Camera mainCamera;

    private List<Collider2D> results = new List<Collider2D>();
    private Collider2D _collider2D;

    private void Start()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        ContactFilter2D contactFilter = new ContactFilter2D();
        int elemCount = _collider2D.OverlapCollider(contactFilter.NoFilter(), results);

        if (!results.Where(x=> x.CompareTag("Enemy")).Any())
        {
            foreach (GameObject door in doors)
            {
                door.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnPlayerEntered?.Invoke();
            mainCamera.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, mainCamera.transform.position.z);
            foreach (GameObject door in doors)
            {
                door.SetActive(true);
            }
        }
    }
}
