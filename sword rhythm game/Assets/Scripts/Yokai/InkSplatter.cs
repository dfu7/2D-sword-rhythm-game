using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InkSplatter : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Disappear()
    {
        Destroy(gameObject);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void AttackOver()
    {
        animator.SetBool("AttackLeft", false);
        animator.SetBool("AttackUp", false);
        animator.SetBool("AttackRight", false);
    }

    void FixedUpdate()
    {
        if(animator.GetBool("AttackLeft") == true && animator.GetBool("AttackUp") == true && animator.GetBool("AttackRight") == true)
        {
            animator.SetBool("AttackLeft", false);
            animator.SetBool("AttackUp", false);
            animator.SetBool("AttackRight", false);
        }
    }
}
