using UnityEngine;

public class ScriptDragonMovement : BaseMovement<ScriptDragonMovement>
{
    protected bool canFly;

    protected override void GetScriptableDataValue()
    {
        takeData = Resources.Load<CharactorData>("Data/Dragon");
        base.GetScriptableDataValue();
    }
    
    protected override void Move()
    {
        moveX = InputManagement.Instance.dragonKeyMap.input_MoveX;
        moveY = InputManagement.Instance.dragonKeyMap.input_MoveY;
        if (canFly) moveY = Input.GetAxisRaw("Vertical");
        base.Move();
    }

    protected override void Jump()
    {
        if (!InputManagement.Instance.dragonKeyMap.intput_Jump) return;
        isGrounded = ScriptCheckDragonGrounded.Instance.isGrounded;
        if (!isGrounded) return;
        rb.velocity = Vector2.up * _jumpForce;
    }


    /*private void Update()
    {
        if (blockMove) return; // nếu bị khóa di chuyển thì không di chuyển được

        MovenJump();

        if (anim.GetCurrentAnimatorStateInfo(0)
            .IsName("2_BreathFire")) // đây là lệnh check xem có phải là trạng thái 2, đang phun lửa không
        {
            blockMove = true; // nếu đúng thì sẽ khóa si chuyển lại
            Invoke(nameof(UnlockMove), .5f); // nửa giây sau sẽ mở khóa di chuyển
        }

        if (KnightHealth.Instance.IsDead() || DragonHealth.Instance.IsDead()) // khi 1 trong 2 player chết thì cả 2 sẽ không thể di chuyển được
        {
            blockMove = true;
        }
    }*/

    private void UnlockMove() // Hàm này để mở khóa di chuyển
    {
        blockMove = false;
    }
}