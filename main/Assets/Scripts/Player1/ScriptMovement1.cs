using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMovement1 : MonoBehaviour
{
    public int speed;
    public int jumpForce;
    [HideInInspector] public float moveX;
    public bool blockMove = false;


    private ScriptAnimation1 scriptAnimation;
    private ScriptCheckGrounded scriptCheckGrounded;
    private Rigidbody2D rb;


    private void Awake()
    {
        scriptAnimation = GetComponentInChildren<ScriptAnimation1>();
        scriptCheckGrounded = GetComponentInChildren<ScriptCheckGrounded>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (blockMove) return;

        moveX = Input.GetAxisRaw("Horizontal");
        transform.Translate(moveX * speed * Time.fixedDeltaTime, 0, 0);

        if (transform.localScale.x == 1 && moveX < 0) Flip(); // quay mặt nhân vật
        if (transform.localScale.x == -1 && moveX > 0) Flip();

        if (scriptCheckGrounded.isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
            rb.velocity = Vector2.up * jumpForce;

        if (scriptAnimation.state == 1 && Input.GetKeyDown(KeyCode.DownArrow))// đây là hành động dash
        {
            rb.velocity = new Vector2(moveX, 0) * jumpForce * 2 / 3;
        }

    }

    void Flip()
    {
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;
    }
}
