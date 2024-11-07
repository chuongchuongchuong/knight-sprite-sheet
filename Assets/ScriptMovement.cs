using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMovement : MonoBehaviour
{
    public int speed;
    public int jumpForce;
    public float moveX;


    private ScriptAnimation scriptAnimation;
    private SpriteRenderer spriteRenderer;
    private ScriptCheck scriptCheck;
    private Rigidbody2D rb;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        scriptCheck = GetComponent<ScriptCheck>();
        scriptAnimation = GetComponent<ScriptAnimation>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!scriptCheck.canMove) return;

        moveX = Input.GetAxisRaw("Horizontal");
        transform.Translate(moveX * speed * Time.deltaTime, 0, 0);

        if (moveX > 0) spriteRenderer.flipX = false;
        if (moveX < 0) spriteRenderer.flipX = true;


        if (scriptCheck.isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
            rb.velocity = Vector2.up * jumpForce;



    }
}
