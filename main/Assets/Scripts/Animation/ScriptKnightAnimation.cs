using UnityEngine;
using UnityEngine.Serialization;

public class ScriptKnightAnimation : ChuongMonoSingleton<ScriptKnightAnimation>
{
    
    public int state;
    //0: idle, 1:walk, 2: jump, 3: attack, 4: hurt, 
    
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    
    protected override void LoadComponent()
    {
        anim = GetComponent<Animator>();
        rb = GetComponentInParent<Rigidbody2D>();
    }
    
    private void Update()
    {
        switch (state)
        {
            case 0:
                if (ScriptKnightMovement.Instance.moveX != 0) state = 1; //đang đứng im thành chạy
                if (Mathf.Abs(rb.velocity.y) > .1) state = 2; // đang đứng im thì nhảy
                if (Input.GetKeyDown(KeyCode.J)) // đang đứng, ấm a là đánh
                {
                    anim.SetTrigger("Attack");
                    state = 3;
                    ScriptKnightMovement.Instance.blockMove = true; // đang chém thì ko di chuyển được
                }

                break;
            case 1: // đang chạy
                if (ScriptKnightMovement.Instance.moveX == 0) state = 0; //đang chạy thành đứng im
                if (Mathf.Abs(rb.velocity.y) > .1) state = 2; //đang chạy thì nhảy hoặc rơi

                if (Input.GetKeyDown(KeyCode.J)) // đang chạy ấn Z là đánh
                {
                    anim.SetTrigger("Attack");
                    state = 3;
                    ScriptKnightMovement.Instance.blockMove = true; // đang chém thì ko di chuyển được
                }

                if (Input.GetKeyDown(KeyCode.DownArrow)) // đang chạy ấn xuống là dash
                {
                    anim.SetTrigger("Dash");
                    //scriptCheck.blockMove = true;
                }


                break;

            case 2: // đang nhảy
                if (ScriptCheckKnightGrounded.Instance.isGrounded && ScriptKnightMovement.Instance.moveX == 0)
                    state = 0; // đang rơi thành xuống mặt đất
                if (ScriptCheckKnightGrounded.Instance.isGrounded && ScriptKnightMovement.Instance.moveX != 0) state = 1; // đang rơi thành chạy

                if (Input.GetKeyDown(KeyCode.J)) // đang nhảy ấn Z là JumpAttack
                    anim.SetTrigger("JumpAttack");
                break;
        }


        if (KnightHealth.Instance.IsDead()) // check xem có chết ko
        {
            state = 12;
            ScriptKnightMovement.Instance.blockMove = true;
        }

        anim.SetInteger("state", state);
    }

    public void Attack2Idle()
    {
        state = 0;
        ScriptKnightMovement.Instance.blockMove = false; // không tấn công nữa thì có thể di chuyển được
        transform.parent.GetComponentInChildren<ScriptSlash>().Attack(); // kích hoạt tấn công
    }


    //Chuyển từ bị thương sang idle
    public void Hurt2Idle()
    {
        //if (scriptChecknUI.healthBar1.value != 0)
        anim.SetInteger("state", 0);
    }


    public void UnlockMove()
    {
        ScriptKnightMovement.Instance.blockMove = false;
    }
}