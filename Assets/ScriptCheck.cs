using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptCheck : MonoBehaviour
{
    public bool isGrounded;
    public bool canMove = true;

    private ScriptAnimation scriptAnimation;
    private Slider healthbar;
    //private Animator anim;

    private void Awake()
    {
        scriptAnimation = GetComponent<ScriptAnimation>();
        healthbar = GameObject.Find("Slider").GetComponent<Slider>();
        //anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
            isGrounded = true;

        if (other.gameObject.CompareTag("Enemy"))
            healthbar.value--;



    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
            isGrounded = false;
    }
}
