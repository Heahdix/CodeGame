using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehavior : MonoBehaviour
{
    public Animator anim;

    private void OnEnable()
    {
        anim.SetTrigger("Attack");
    }

    public void DisableElement()
    {
        gameObject.SetActive(false);
    }
}
