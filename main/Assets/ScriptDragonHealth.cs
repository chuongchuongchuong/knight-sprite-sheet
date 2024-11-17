using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDragonHealth : MonoBehaviour
{
    public float health = 100;
    private void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Knight Fire"))
            health -= 10;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
