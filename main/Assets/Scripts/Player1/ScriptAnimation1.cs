using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptAnimation1 : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private ScriptMovement1 scriptMovement1;
    [SerializeField] private ScriptCheckGrounded scriptCheckGrounded;
    [SerializeField] private ScriptHealth1 scriptHealth1;

    public int state;
    //0: idle, 1:walk, 2: jump, 3: attack, 4: hurt, 

    private void Reset()
    {
        anim = GetComponent<Animator>();
        rb = GetComponentInParent<Rigidbody2D>();

        scriptMovement1 = GetComponentInParent<ScriptMovement1>();
        scriptHealth1 = transform.parent.GetComponentInChildren<ScriptHealth1>();

        scriptCheckGrounded = transform.parent.GetComponentInChildren<ScriptCheckGrounded>();

    }
    // Start is called before the first frame update
    void Start()
    {

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
                    anim.SetTrigger("Attack");
                    state = 3;
                    scriptMovement1.blockMove = true; // đang chém thì ko di chuyển được
                }

                break;
            case 1:// đang chạy
                if (scriptMovement1.moveX == 0) state = 0; //đang chạy thành đứng im
                if (Mathf.Abs(rb.velocity.y) > .1) state = 2; //đang chạy thì nhảy hoặc rơi

                if (Input.GetKeyDown(KeyCode.J)) // đang chạy ấn Z là đánh
                {
                    anim.SetTrigger("Attack");
                    state = 3;
                    scriptMovement1.blockMove = true;// đang chém thì ko di chuyển được
                }

                if (Input.GetKeyDown(KeyCode.DownArrow)) // đang chạy ấn xuống là dash
                {
                    anim.SetTrigger("Dash");
                    //scriptCheck.blockMove = true;
                }



                break;

            case 2:// đang nhảy
                if (scriptCheckGrounded.isGrounded && scriptMovement1.moveX == 0) state = 0;// đang rơi thành xuống mặt đất
                if (scriptCheckGrounded.isGrounded && scriptMovement1.moveX != 0) state = 1;// đang rơi thành chạy

                if (Input.GetKeyDown(KeyCode.J)) // đang nhảy ấn Z là JumpAttack
                    anim.SetTrigger("JumpAttack");
                break;

            default: break;

        }



        if (scriptHealth1.isDead())// check xem có chết ko
        {
            state = 12;
            scriptMovement1.blockMove = true;
        }

        anim.SetInteger("state", state);
    }

    public void Attack2Idle()
    {
        state = 0;
        scriptMovement1.blockMove = false;// không tấn công nữa thì có thể di chuyển được
        transform.parent.GetComponentInChildren<ScriptSlash>().Attack();// kích hoạt tấn công
    }


    //Chuyển từ bị thương sang idle
    public void Hurt2Idle()
    {
        //if (scriptChecknUI.healthBar1.value != 0)
        anim.SetInteger("state", 0);

    }


    public void UnlockMove()
    {
        scriptMovement1.blockMove = false;
    }
}
