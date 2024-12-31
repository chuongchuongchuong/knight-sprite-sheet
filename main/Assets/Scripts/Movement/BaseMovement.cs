using UnityEngine;

public class BaseMovement<T> : ChuongMonoSingleton<T> where T : BaseMovement<T>
{
    protected int _moveSpeed;
    protected int _jumpForce;

    public float moveX { get; protected set; }
    public float moveY { get; protected set; }
    public bool blockMove;
    public bool isGrounded;

    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected Animator animator;

    protected CharactorData takeData;

    protected override void LoadComponent()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
        animator = transform.parent.GetComponentInChildren<Animator>();
    }

    protected override void GetScriptableDataValue()
    {
        // parameter takeData to get the original value
        _moveSpeed = takeData.moveSpeed;
        _jumpForce = takeData.jumpForce;
    }

    protected virtual void Update()
    {
        if (blockMove) return; // if blockMove, cant move
        Move();
        Jump();
    }

    protected virtual void Move()
    {
        //moveX = Input.GetAxisRaw("Horizontal"); moveY=Input.GetAxisRaw("Vertical");
        transform.parent.Translate(_moveSpeed * Time.deltaTime * new Vector2(moveX, moveY));
        Flip(); // Hàm này làm quay mặt player lại
        return;

        void Flip()
        {
            if (transform.parent.localScale.x * moveX >= 0) return;
            var temp = transform.parent.localScale;
            temp.x *= -1;
            transform.parent.localScale = temp;
        }
    }

    protected virtual void Jump(){}
}