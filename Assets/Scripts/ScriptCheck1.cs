using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptCheck1 : MonoBehaviour
{
    public bool isGrounded; // biến để check xem có chạm đất ko
    public bool blockMove = false; // biến để khóa không cho di chuyển
    public bool checkWin = false;

    private ScriptAnimation1 scriptAnimation;
    public Slider healthBar1;
    //private Animator anim;

    private void Awake()
    {
        scriptAnimation = GetComponent<ScriptAnimation1>();
        healthBar1 = GameObject.Find("HealthBar1").GetComponent<Slider>();
        //anim = GetComponent<Animator>();
    }

    // Hàm check grounded
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
            isGrounded = false;
    }
}
