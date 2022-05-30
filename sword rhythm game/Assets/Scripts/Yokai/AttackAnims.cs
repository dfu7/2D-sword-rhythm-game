using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnims : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void AttackOver()
    {
        animator.SetBool("AttackLeft", false);
        animator.SetBool("AttackUp", false);
        animator.SetBool("AttackRight", false);
    }

    void Update()
    {
        if (animator.GetBool("AttackLeft") == true && animator.GetBool("AttackUp") == true && animator.GetBool("AttackRight") == true)
        {
            animator.SetBool("AttackLeft", false);
            animator.SetBool("AttackUp", false);
            animator.SetBool("AttackRight", false);
        }
    }
}
