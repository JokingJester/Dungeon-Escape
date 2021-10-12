using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;

    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    public void Move(float input)
    {
        _anim.SetFloat("Speed", Mathf.Abs(input));
    }
}
