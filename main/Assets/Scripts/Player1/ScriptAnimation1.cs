using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptAnimation1 : MonoBehaviour
{
    private Animator Anim;
    private Rigidbody2D rb;

    private ScriptMovement1 scriptMovement1;
    private ScriptCheckGrounded scriptCheckGrounded;
    private ScriptHealth1 scriptHealth1;

    private GameObject gameOver;

    public int state;
    //0: idle, 1:walk, 2: jump, 3: attack, 4: hurt, 

    private void Awake()
    {
        Anim = GetComponent<Animator>();
        rb = GetComponentInParent<Rigidbody2D>();

        scriptMovement1 = GetComponentInParent<ScriptMovement1>();
        scriptHealth1 = transform.parent.GetComponentInChildren<ScriptHealth1>();

        scriptCheckGrounded = transform.parent.GetComponentInChildren<ScriptCheckGrounded>();
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
                if (scriptMovement1.moveX != 0) state = 1; //đang đứng im thành chạy
                if (Mathf.Abs(rb.velocity.y) > .1) state = 2; // đang đứng im thì nhảy
                if (Input.GetKeyDown(KeyCode.J)) // đang đứng, ấm a là đánh
                {
                    Anim.SetTrigger("Attack");
                    state = 3;
                    scriptMovement1.blockMove = true; // đang chém thì ko di chuyển được
                }

                break;
            case 1:// đang chạy
                if (scriptMovement1.moveX == 0) state = 0; //đang chạy thành đứng im
                if (Mathf.Abs(rb.velocity.y) > .1) state = 2; //đang chạy thì nhảy hoặc rơi

                if (Input.GetKeyDown(KeyCode.J)) // đang chạy ấn Z là đánh
                {
                    Anim.SetTrigger("Attack");
                    state = 3;
                    scriptMovement1.blockMove = true;// đang chém thì ko di chuyển được
                }

                if (Input.GetKeyDown(KeyCode.DownArrow)) // đang chạy ấn xuống là dash
                {
                    Anim.SetTrigger("Dash");
                    //scriptCheck.blockMove = true;
                }



                break;

            case 2:// đang nhảy
                if (scriptCheckGrounded.isGrounded && scriptMovement1.moveX == 0) state = 0;// đang rơi thành xuống mặt đất
                if (scriptCheckGrounded.isGrounded && scriptMovement1.moveX != 0) state = 1;// đang rơi thành chạy

                if (Input.GetKeyDown(KeyCode.J)) // đang nhảy ấn Z là JumpAttack
                    Anim.SetTrigger("JumpAttack");
                break;

            default: break;

        }



        if (scriptHealth1.isDead())// check xem có chết ko
        {
            state = 12;
            scriptMovement1.blockMove = true;
        }

        Anim.SetInteger("state", state);
    }

    public void Attack2Idle()
    {
        state = 0;
        scriptMovement1.blockMove = false;
        transform.parent.GetComponentInChildren<ScriptSlash>().Slash();
    }


    //Chuyển từ bị thương sang idle
    public void Hurt2Idle()
    {
        //if (scriptChecknUI.healthBar1.value != 0)
        Anim.SetInteger("state", 0);

    }


    public void UnlockMove()
    {
        scriptMovement1.blockMove = false;
    }

    //Chết
    public void Die()
    {
        //Debug.Log("h");
        gameOver.GetComponentInChildren<Text>().text = "Dragon Won";
        gameOver.SetActive(true);
    }
    public void Win()
    {
        gameOver.GetComponentInChildren<Text>().text = "U Won";
        gameOver.SetActive(true);
        //Debug.Log("Oke");
    }

    void PlayAgain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Battle");
    }
}
