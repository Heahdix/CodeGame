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
    private GameManager _gameManager;

    private void Start()
    {
        _collider2D = GetComponent<Collider2D>();
        _gameManager = GameManager.instance;
    }

    private void Update()
    {
        ContactFilter2D contactFilter = new ContactFilter2D();
        int elemCount = _collider2D.OverlapCollider(contactFilter.NoFilter(), results);

        if (!results.Where(x => x.CompareTag("Enemy")).Any())
        {
            foreach (GameObject door in doors)
            {
                door.SetActive(false);
            }
            if(results.Where(x => x.CompareTag("Player")).Any())
            {
                _gameManager.isInBattle = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mainCamera.GetComponent<CameraMover>().target = transform.position;

            if (results.Where(x => x.CompareTag("Enemy")).Any())
            {
                OnPlayerEntered?.Invoke();

                foreach (GameObject door in doors)
                {
                    door.SetActive(true);
                }

                _gameManager.isInBattle = true;
            }
        }
    }
}
