using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptCheck : MonoBehaviour
{
    public bool isGrounded; // biến để check xem có chạm đất ko
    public bool canMove = true; // biến để khóa không cho di chuyển

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
        {
            healthbar.value--;
            healthbar.GetComponentInChildren<Text>().text = "máu: " + healthbar.value + "/3";
        }

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
            isGrounded = false;
    }
}
