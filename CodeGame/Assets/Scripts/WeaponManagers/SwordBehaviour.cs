using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehaviour : MonoBehaviour
{
    public Animator anim;

    private BoxCollider2D _coll;

    private void Awake()
    {
        _coll = gameObject.GetComponentInChildren<BoxCollider2D>();
        _coll.enabled = false;
    }

    private void OnEnable()
    {
        anim.SetTrigger("Attack");
        _coll.enabled = true;
    }

    public void DisableElement()
    {
        gameObject.SetActive(false);
        _coll.enabled = false;
    }
}
