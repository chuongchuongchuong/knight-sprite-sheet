using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBulletWay : MonoBehaviour
{
    public int speed = 10;
    private Rigidbody2D rb;
    private Transform transform2;
    private ScriptHealth1 scriptHealth1;
    //private ScriptMovement2 scriptMovement2;
    private int damage = 10;
    public GameObject boom;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        transform2 = GameObject.Find("Player2: Dragon").transform;
        scriptHealth1 = GameObject.Find("Player1: knight").GetComponentInChildren<ScriptHealth1>();
        //scriptMovement2 = transform2.GetComponent<ScriptMovement2>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (transform2.localScale.x > 0) GetComponent<SpriteRenderer>().flipX = true;
        rb.velocity = Vector2.left * speed * transform2.localScale.x;


        //rb.velocity = Vector2.right * speed;
    }

    public void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (hitInfo.gameObject.name == "Player1: knight")
        {
            Instantiate(boom, transform.position, transform.rotation);
            scriptHealth1.TakeDamage(damage);

            Destroy(gameObject);
        }

        /*private void OnTriggerEnter2D(Collider2D hitInfo)
        {
            Instantiate(boom, transform.position, transform.rotation);
            Destroy(gameObject);
        }*/


    }
}
