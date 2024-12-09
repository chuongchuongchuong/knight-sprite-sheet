using System;
using UnityEngine;
using UnityEngine.Serialization;

public class ScriptMovement1 : MonoBehaviour
{
    [SerializeField] private CharactorData knightData;
    [HideInInspector] public float moveX;
    public bool blockMove;


    [SerializeField] private ScriptAnimation1 scriptAnimation;
    [SerializeField] private ScriptCheckGrounded scriptCheckGrounded;
    [SerializeField] private Rigidbody2D rb;
    [FormerlySerializedAs("scriptKnihgtHealth")] [FormerlySerializedAs("scriptHealth1")] [SerializeField] private ScriptKnightHealth scriptKnightHealth;
    [FormerlySerializedAs("scriptHealth2")] [SerializeField] private ScriptDragonHealth scriptDragonHealth;

    private void Reset()
    {
        knightData = Resources.Load<CharactorData>("Data/Knight");
        scriptAnimation = GetComponentInChildren<ScriptAnimation1>();
        scriptCheckGrounded = GetComponentInChildren<ScriptCheckGrounded>();
        rb = GetComponent<Rigidbody2D>();
        scriptKnightHealth = GameObject.Find("Health1").GetComponent<ScriptKnightHealth>(); // lấy component máu của cả 2 player
        scriptDragonHealth = GameObject.Find("Health2").GetComponent<ScriptDragonHealth>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (blockMove) return; // nếu blockMove thì sẽ không di chuyển được nữa

        MovenJump(); // di chuyển và nhảy

        if (scriptAnimation.state == 1 && Input.GetKeyDown(KeyCode.DownArrow)) // đây là hành động dash
        {
            rb.velocity = (float)knightData.jumpForce * 2 / 3 * new Vector2(moveX, 0);
        }

        if (scriptKnightHealth.IsDead() || scriptDragonHealth.IsDead()) // nếu 1 trong 2 đối thủ hết máu
        {
            blockMove = true;
        }
    }


    private void MovenJump()
    {
        moveX = Input.GetAxisRaw("Horizontal2");
        transform.Translate(moveX * knightData.moveSpeed * Time.deltaTime, 0, 0);
        Flip(); // // Hàm này làm quay mặt player lại

        if (scriptCheckGrounded.isGrounded && Input.GetKeyDown(KeyCode.W)) // đây là code nhảy lên
            rb.velocity = Vector2.up * knightData.jumpForce;
        return;

        void Flip()
        {
            if ((transform.localScale.x > 0 && moveX < 0) || (transform.localScale.x < 0 && moveX > 0))
            {
                var temp = transform.localScale;
                temp.x *= -1;
                transform.localScale = temp;
            }
        }
    }
}