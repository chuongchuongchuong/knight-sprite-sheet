﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptAnimation1 : MonoBehaviour
{
    private Animator Anim;
    private Rigidbody2D rb;
    private ScriptChecknUI1 scriptChecknUI;
    private ScriptMovement1 scriptMovement;
    private ScriptCheckGrounded scriptCheckGrounded;
    private Slider healthbar1;
    private GameObject gameOver;

    public int state;
    //0: idle, 1:walk, 2: jump, 3: attack, 4: hurt, 

    private void Awake()
    {
        Anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        scriptChecknUI = GetComponent<ScriptChecknUI1>();
        scriptMovement = GetComponent<ScriptMovement1>();
        healthbar1 = GameObject.Find("HealthBar1").GetComponent<Slider>();
        scriptCheckGrounded = GetComponentInChildren<ScriptCheckGrounded>();
        gameOver = GameObject.Find("GameOver");
        gameOver.GetComponentInChildren<Button>().onClick.AddListener(PlayAgain);// Onclick cái nút PlayAgain
    }
    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case 0:
                if (scriptMovement.moveX != 0) state = 1; //đang đứng im thành chạy
                if (rb.velocity.y > .1) state = 2; // đang đứng im thì nhảy
                if (Input.GetKeyDown(KeyCode.Z)) // đang đứng, ấm a là đánh
                {
                    Anim.SetTrigger("Attack"); scriptChecknUI.blockMove = true; // đang chém thì ko di chuyển được
                }

                break;
            case 1:// đang chạy
                if (scriptMovement.moveX == 0) state = 0; //đang chạy thành đứng im
                if (rb.velocity.y > .1) state = 2; //đang chạy thì nhảy hoặc rơi

                if (Input.GetKeyDown(KeyCode.Z)) // đang chạy ấn Z là đánh
                {
                    Anim.SetTrigger("Attack");
                    state = 3;
                    scriptChecknUI.blockMove = true;// đang chém thì ko di chuyển được
                }

                if (Input.GetKeyDown(KeyCode.DownArrow)) // đang chạy ấn Z là đánh
                {
                    Anim.SetTrigger("Dash");
                    //scriptCheck.blockMove = true;
                }



                break;

            case 2:// đang nhảy
                if (scriptCheckGrounded.isGrounded && scriptMovement.moveX == 0) state = 0;// đang rơi thành xuống mặt đất
                if (scriptCheckGrounded.isGrounded && scriptMovement.moveX != 0) state = 1;// đang rơi thành chạy

                if (Input.GetKeyDown(KeyCode.Z)) // đang nhảy ấn Z là JumpAttack
                    Anim.SetTrigger("JumpAttack");
                break;

            default: break;

        }



        if (scriptChecknUI.IsDead())// check xem có chết ko
        {
            state = 13;
            scriptChecknUI.blockMove = true;
        }

        Anim.SetInteger("state", state);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy")) // nếu cham vào enemy thì sẽ hurt
            Anim.SetInteger("state", 11);
    }


    //Chuyển từ bị thương sang idle
    public void Hurt2Idle()
    {
        if (scriptChecknUI.healthBar1.value != 0)
            Anim.SetInteger("state", 0);

    }

    //Chuyển từ tấn công sang Idle
    public void Attack2Idle()
    {
        state = 0;
        scriptChecknUI.blockMove = false;// sau khi tấn công xong là lại di chuyển được
    }

    public void UnlockMove()
    {
        scriptChecknUI.blockMove = false;
    }

    //Chết
    public void Die()
    {
        Debug.Log("h");
        gameOver.SetActive(true);
    }
    public void Win()
    {
        gameOver.GetComponentInChildren<Text>().text = "U Won";
        gameOver.SetActive(true);
        Debug.Log("Oke");
    }

    void PlayAgain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Battle");
    }
}