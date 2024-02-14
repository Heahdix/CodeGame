using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehavior : MonoBehaviour
{
    public Animator anim;
    private BoxCollider2D coll;

    private void Awake()
    {
        coll = gameObject.GetComponentInChildren<BoxCollider2D>();
        coll.enabled = false;
    }

    private void OnEnable()
    {
        anim.SetTrigger("Attack");
        coll.enabled = true;
    }

    public void DisableElement()
    {
        gameObject.SetActive(false);
        coll.enabled = false;
    }
}
