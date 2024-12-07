﻿using UnityEngine;

public class ScriptMovement1 : MonoBehaviour
{
    [SerializeField] private int speed = 5;
    [SerializeField] private int jumpForce = 5;
    [HideInInspector] public float moveX;
    public bool blockMove;


    [SerializeField] private ScriptAnimation1 scriptAnimation;
    [SerializeField] private ScriptCheckGrounded scriptCheckGrounded;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private ScriptHealth1 scriptHealth1;
    [SerializeField] private ScriptHealth2 scriptHealth2;

    private void Reset()
    {
        scriptAnimation = GetComponentInChildren<ScriptAnimation1>();
        scriptCheckGrounded = GetComponentInChildren<ScriptCheckGrounded>();
        rb = GetComponent<Rigidbody2D>();
        scriptHealth1 = GameObject.Find("Health1").GetComponent<ScriptHealth1>(); // lấy component máu của cả 2 player
        scriptHealth2 = GameObject.Find("Health2").GetComponent<ScriptHealth2>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (blockMove) return; // nếu blockMove thì sẽ không di chuyển được nữa

        MovenJump(); // di chuyển và nhảy

        if (scriptAnimation.state == 1 && Input.GetKeyDown(KeyCode.DownArrow)) // đây là hành động dash
        {
            rb.velocity = (float)jumpForce * 2 / 3 * new Vector2(moveX, 0);
        }

        if (scriptHealth1.IsDead() || scriptHealth2.IsDead()) // nếu 1 trong 2 đối thủ hết máu
        {
            blockMove = true;
        }
    }


    void MovenJump()
    {
        moveX = Input.GetAxisRaw("Horizontal2");
        transform.Translate(moveX * speed * Time.deltaTime, 0, 0);
        Flip(); // // Hàm này làm quay mặt player lại

        if (scriptCheckGrounded.isGrounded && Input.GetKeyDown(KeyCode.W)) // đây là code nhảy lên
            rb.velocity = Vector2.up * jumpForce;
        return;

        void Flip()
        {
            if ((transform.localScale.x > 0 && moveX < 0) || (transform.localScale.x < 0 && moveX > 0))
            {
                var temp = transform.localScale;
                temp.x *= -1;
                transform.localScale = temp;
            }
        }
    }
}