using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCheckGrounded : MonoBehaviour
{
    public bool isGrounded;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }
}
