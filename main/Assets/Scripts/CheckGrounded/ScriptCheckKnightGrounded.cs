using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCheckKnightGrounded : ChuongMono<ScriptCheckKnightGrounded>
{
    public bool isGrounded;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }
}
