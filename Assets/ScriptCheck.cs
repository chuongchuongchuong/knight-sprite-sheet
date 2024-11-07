using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCheck : MonoBehaviour
{
    public bool isGrounded;

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
