using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    private GameObject _player;
    private Vector3 _offset;

    void Start()
    {
        _player = GameObject.Find("Player");
        _offset = transform.position - _player.transform.position;
    }

    void LateUpdate()
    {
        if (_player != null)
        {
            transform.position = _player.transform.position + _offset;
        }
    }
}
