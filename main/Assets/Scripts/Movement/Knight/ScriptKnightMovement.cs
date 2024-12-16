using System;
using UnityEngine;
using UnityEngine.Serialization;

public class ScriptKnightMovement : BaseMovement<ScriptKnightMovement>
{
    protected override void GetScriptableDataValue()
    {
        takeData = Resources.Load<CharactorData>("Data/Knight");
        base.GetScriptableDataValue();
    }
    
    protected override void Move()
    {
        moveX = InputManagement.Instance.knightKeyMap.input_MoveX;
        base.Move();
    }
    
    protected override void Jump()
    {
        if (!InputManagement.Instance.knightKeyMap.intput_Jump) return;
        isGrounded = ScriptCheckKnightGrounded.Instance.isGrounded;
        if (!isGrounded) return;
        rb.velocity = Vector2.up * _jumpForce;
    }

    protected override void Update()
    {
        base.Update();
        Dash(); // Knight thì có thêm hành động dash
    }

    private void Dash()
    {
        if (!Input.GetKeyDown(KeyCode.DownArrow)) return;
        if (ScriptKnightAnimation.Instance.state != 1) return;
        rb.velocity = (float)_jumpForce * 2 / 3 * new Vector2(moveX, 0);
    }
}