using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSlash : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private ScriptHealth2 scriptHealth2;

    int damage = 10;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        scriptHealth2 = GameObject.Find("Player2: Dragon").GetComponentInChildren<ScriptHealth2>();
    }

    private void Start()
    {
        boxCollider.enabled = false;
    }

    public void Slash()
    {
        boxCollider.enabled = true;
    }

    // Update is called once per frame
    public void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (hitInfo.gameObject.name == "Player2: Dragon")
            scriptHealth2.TakeDamage(damage);
        boxCollider.enabled = false;
        Debug.Log("yes");
    }

}
