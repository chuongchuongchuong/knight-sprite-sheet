using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAnimation : MonoBehaviour
{
    private Animator Anim;
    private Rigidbody2D rb;
    private ScriptCheck scriptCheck;
    private ScriptMovement scriptMovement;

    private int state;
    //0: idle, 1:walk, 2: jump,

    private void Awake()
    {
        Anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        scriptCheck = GetComponent<ScriptCheck>();
        scriptMovement = GetComponent<ScriptMovement>();
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
                if (rb.velocity.y != 0) state = 2; // đang đứng im thì nhảy
                if (Input.GetKeyDown(KeyCode.Z)) state = 3;// đang đứng, ấm a là đánh

                    break;
            case 1:
                if (scriptMovement.moveX == 0) state = 0; //đang chạy thành đứng im
                if (rb.velocity.y != 0) state = 2; //đang chạy thì nhảy hoặc rơi
                if (Input.GetKeyDown(KeyCode.Z)) state = 3;// đang chạy ấn 3 là đánh



                break;

            case 2:
                if (scriptCheck.isGrounded) state = 0;

                break;

        }

        Anim.SetInteger("state", state);
    }
}
