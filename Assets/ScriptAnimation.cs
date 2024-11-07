using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptAnimation : MonoBehaviour
{
    private Animator Anim;
    private Rigidbody2D rb;
    private ScriptCheck scriptCheck;
    private ScriptMovement scriptMovement;
    private Slider healthbar;

    public int state;
    //0: idle, 1:walk, 2: jump, 3: attack

    private void Awake()
    {
        Anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        scriptCheck = GetComponent<ScriptCheck>();
        scriptMovement = GetComponent<ScriptMovement>();
        healthbar = GameObject.Find("Slider").GetComponent<Slider>();
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
                if (scriptMovement.moveX != 0) state = 1; //đang đứng im thành chạy
                if (rb.velocity.y > .1) state = 2; // đang đứng im thì nhảy
                if (Input.GetKeyDown(KeyCode.Z)) // đang đứng, ấm a là đánh
                {
                    state = 3; scriptCheck.canMove = false;
                }
                break;
            case 1:
                if (scriptMovement.moveX == 0) state = 0; //đang chạy thành đứng im
                if (rb.velocity.y > .1) state = 2; //đang chạy thì nhảy hoặc rơi
                if (Input.GetKeyDown(KeyCode.Z)) // đang chạy ấn 3 là đánh
                {
                    state = 3; scriptCheck.canMove = false;
                }



                break;

            case 2:
                if (scriptCheck.isGrounded) state = 0;// đang rơi thành xuống mặt đất

                break;

        }

        if (healthbar.value == 0)
        {
            state = 12; healthbar.value = .1f;
            scriptCheck.canMove = false;
        }

        Anim.SetInteger("state", state);
    }


    public void Attack2Idle()
    {
        state = 0; Anim.SetInteger("state", state);
        scriptCheck.canMove = true;
    }
}
