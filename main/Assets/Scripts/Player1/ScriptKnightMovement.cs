using System;
using UnityEngine;
using UnityEngine.Serialization;

public class ScriptKnightMovement : BaseMovement<ScriptKnightMovement>
{
    [SerializeField] private ScriptAnimation1 scriptAnimation;
    [SerializeField] private ScriptCheckGrounded scriptCheckGrounded;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        scriptAnimation = transform.parent.GetComponentInChildren<ScriptAnimation1>();
        scriptCheckGrounded = transform.parent.GetComponentInChildren<ScriptCheckGrounded>();
    }

    protected override void GetScriptableDataValue()
    {
        var takeData = Resources.Load<CharactorData>("Data/Knight");
        base.GetScriptableDataValue();
    }


    protected override void Move()
    {
        moveX = Input.GetAxisRaw("Horizontal2");
        base.Move();
    }

    protected override void Update()
    {
        base.Update();
        Dash(); // Knight thì có thêm hành động dash
    }

    private void Dash()
    {
        if (!Input.GetKeyDown(KeyCode.DownArrow)) return;
        if (scriptAnimation.state != 1) return;
        rb.velocity = (float)_jumpForce * 2 / 3 * new Vector2(moveX, 0);
    }
}