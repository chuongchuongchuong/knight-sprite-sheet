using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBulletWay : MonoBehaviour
{
    public int speed = 10;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    public GameObject boom;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GameObject.Find("Player1").GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Player1").transform.localScale.x == 1) rb.velocity = Vector2.right * speed;
        if (GameObject.Find("Player1").transform.localScale.x == -1) rb.velocity = Vector2.left * speed;

    }

    public void OnCollisionEnter2D(Collision2D other)
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
