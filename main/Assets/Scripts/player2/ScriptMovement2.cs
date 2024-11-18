using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMovement2 : MonoBehaviour
{
    public int speed;
    public int jumpForce;
    public Vector2 moveInput;
    public bool blockMove = false;
    public bool isFlyin = false;

    private Rigidbody2D rb;
    private ScriptCheckGrounded scriptCheckGrounded;
    //private

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        scriptCheckGrounded = GetComponentInChildren<ScriptCheckGrounded>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (blockMove) return;// nếu bị khóa di chuyển thì không di chuyển được

        moveInput.x = Input.GetAxisRaw("Horizontal");
        if (isFlyin) moveInput.y = Input.GetAxisRaw("Vertical");
        transform.Translate(moveInput * speed * Time.deltaTime);
        Flip(); // quay mặt nhân vật

        if (scriptCheckGrounded.isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
            rb.velocity = Vector2.up * jumpForce;
    }

    void Flip()
    {
        if ((transform.localScale.x > 0 && moveInput.x > 0) || (transform.localScale.x < 0 && moveInput.x < 0))
        {
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
        }
    }
}
