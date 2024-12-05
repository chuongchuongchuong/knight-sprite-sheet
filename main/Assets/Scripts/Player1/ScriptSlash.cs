using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSlash : MonoBehaviour
{
    int damage = 10;

    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private ScriptHealth2 scriptHealth2;
    [SerializeField] private ScriptAnimation1 scriptAnimation1;

    private void Reset()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        scriptHealth2 = GameObject.Find("Player2: Dragon").GetComponentInChildren<ScriptHealth2>();
        //scriptAnimation1 = transform.parent.GetComponentInChildren<ScriptAnimation1>();
    }

    private void Start()
    {
        boxCollider.enabled = false;
    }

    public void Slash()
    {
        boxCollider.enabled = true;
    }
    public void UnSlash()
    {
        boxCollider.enabled = false;
    }

    public void Attack()
    {
        Slash(); // bật vùng tấn công lên
        Invoke(nameof(UnSlash), .5f); // tắt vùng tấn công đi

    }
    private void Update()
    {

    }

    // Update is called once per frame
    public void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (hitInfo.gameObject.name == "Player2: Dragon")
        {
            scriptHealth2.TakeDamage(damage);
        }

    }

}
