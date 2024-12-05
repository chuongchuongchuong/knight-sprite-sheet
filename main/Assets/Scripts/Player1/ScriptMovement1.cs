using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMovement1 : MonoBehaviour
{
    public int speed;
    public int jumpForce;
    [HideInInspector] public float moveX;
    public bool blockMove = false;


    [SerializeField] private ScriptAnimation1 scriptAnimation;
    [SerializeField] private ScriptCheckGrounded scriptCheckGrounded;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private ScriptHealth1 scriptHealth1;
    [SerializeField] private ScriptHealth2 scriptHealth2;

    private void Reset()
    {
        speed = 5;
        jumpForce = 5;

        scriptAnimation = GetComponentInChildren<ScriptAnimation1>();
        scriptCheckGrounded = GetComponentInChildren<ScriptCheckGrounded>();
        rb = GetComponent<Rigidbody2D>();
        scriptHealth1 = GameObject.Find("Health1").GetComponent<ScriptHealth1>(); // lấy component máu của cả 2 player
        scriptHealth2 = GameObject.Find("Health2").GetComponent<ScriptHealth2>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (blockMove) return;// nếu blockMove thì sẽ không di chuyển được nữa

        MovenJump();// di chuyển và nhảy

        if (scriptAnimation.state == 1 && Input.GetKeyDown(KeyCode.DownArrow))// đây là hành động dash
        {
            rb.velocity = new Vector2(moveX, 0) * jumpForce * 2 / 3;
        }

        if (scriptHealth1.isDead() || scriptHealth2.isDead())// nếu 1 trong 2 đối thủ hết máu
        {
            blockMove = true;
        }

    }


    void MovenJump()
    {
        moveX = Input.GetAxisRaw("Horizontal2");
        transform.Translate(moveX * speed * Time.deltaTime, 0, 0);
        Flip();// // Hàm này làm quay mặt player lại

        if (scriptCheckGrounded.isGrounded && Input.GetKeyDown(KeyCode.W))// đây là code nhảy lên
            rb.velocity = Vector2.up * jumpForce;

        void Flip()
        {
            if ((transform.localScale.x > 0 && moveX < 0) || (transform.localScale.x < 0 && moveX > 0))
            {
                Vector3 temp = transform.localScale;
                temp.x *= -1;
                transform.localScale = temp;
            }
        }
    }

}
