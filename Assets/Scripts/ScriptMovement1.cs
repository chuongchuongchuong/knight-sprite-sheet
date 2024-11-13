using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMovement1 : MonoBehaviour
{
    public int speed;
    public int jumpForce;
    public float moveX;


    private ScriptAnimation1 scriptAnimation;
    private SpriteRenderer spriteRenderer;
    private ScriptChecknUI1 scriptCheck1;
    private Rigidbody2D rb;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        scriptCheck1 = GetComponent<ScriptChecknUI1>();
        scriptAnimation = GetComponent<ScriptAnimation1>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (scriptCheck1.blockMove) return;

        moveX = Input.GetAxisRaw("Horizontal");
        transform.Translate(moveX * speed * Time.deltaTime, 0, 0);

        if (moveX > 0) spriteRenderer.flipX = false;
        if (moveX < 0) spriteRenderer.flipX = true;


        if (scriptCheck1.isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
            rb.velocity = Vector2.up * jumpForce;

        if (scriptAnimation.state == 1 && Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.velocity = new Vector2(moveX, 0) * jumpForce * 2 / 3;
        }



    }

    //Khi di chuyển vào quái thì sẽ bị đẩy lùi
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (moveX >= 0) rb.velocity = new Vector2(-1, 1) * jumpForce / 2;
            else if (moveX < 0) rb.velocity = new Vector2(1, 1) * jumpForce / 2;

        }

    }
}
