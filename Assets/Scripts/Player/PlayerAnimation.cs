using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    private Animator _swordArcAnim;

    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _swordArcAnim = transform.GetChild(1).GetComponent<Animator>();
    }

    public void Move(float input)
    {
        _anim.SetFloat("Speed", Mathf.Abs(input));
    }

    public void Jump(bool jumping)
    {
        _anim.SetBool("Jumping", jumping);
    }

    public void Attack(bool hasFireSword)
    {
        _anim.SetBool("HasFireSword", hasFireSword);
        _anim.SetTrigger("Attack");
        _swordArcAnim.SetTrigger("SwordAnimation");
    }
}
