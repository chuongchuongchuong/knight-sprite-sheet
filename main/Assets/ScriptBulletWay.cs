using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBulletWay : MonoBehaviour
{
    public int speed = 10;
    private Rigidbody2D rb;
    private Transform transform2;

    public GameObject boom;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        transform2 = GameObject.Find("Player2: Dragon").transform;
        //spriteRenderer = GameObject.Find("Player1").GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
            rb.velocity = Vector2.left * speed * transform2.localScale.x;


        //rb.velocity = Vector2.right * speed;
    }

    public void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (hitInfo.gameObject.name == "Player1: knight")
        {
            Instantiate(boom, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        /*private void OnTriggerEnter2D(Collider2D hitInfo)
        {
            Instantiate(boom, transform.position, transform.rotation);
            Destroy(gameObject);
        }*/


    }
}
