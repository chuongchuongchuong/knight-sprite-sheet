using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMovement2 : MonoBehaviour
{
    public int speed;
    public int jumpForce;
    public Vector2 moveInput;
    public bool blockMove = false;
    public bool isFlyin = false;

    private Rigidbody2D rb;
    private ScriptCheckGrounded scriptCheckGrounded;
    private Animator anim;
    private ScriptHealth1 scriptHealth1;
    private ScriptHealth2 scriptHealth2;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        scriptCheckGrounded = GetComponentInChildren<ScriptCheckGrounded>();
        anim = GetComponentInChildren<Animator>();
        scriptHealth1 = GameObject.Find("Health1").GetComponent<ScriptHealth1>(); // lấy component máu của cả 2 player
        scriptHealth2 = GameObject.Find("Health2").GetComponent<ScriptHealth2>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (blockMove) return;// nếu bị khóa di chuyển thì không di chuyển được

        moveInput.x = Input.GetAxisRaw("Horizontal");
        if (isFlyin) moveInput.y = Input.GetAxisRaw("Vertical");
        transform.Translate(moveInput * speed * Time.deltaTime);// Di chuyển trái phải
        Flip(); // qQay mặt nhân vật

        if (scriptCheckGrounded.isGrounded && Input.GetKeyDown(KeyCode.UpArrow))// chỗ này là code nhảy lên
            rb.velocity = Vector2.up * jumpForce;

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("2_BreathFire"))// đây là lệnh check xem có phải là trạng thái 2, đang phun lửa không
        {
            blockMove = true;// nếu đúng thì sẽ khóa si chuyển lại
            Invoke("UnlockMove", .5f);// nửa giây sau sẽ mở khóa di chuyển
        }

        if(scriptHealth1.isDead() || scriptHealth2.isDead())// khi 1 trong 2 player chết thì cả 2 sẽ không thể di chuyển được
        {
            blockMove = true;
        }    
    }

    void Flip() // Hàm này là việc quay mặt player lại
    {
        if ((transform.localScale.x > 0 && moveInput.x > 0) || (transform.localScale.x < 0 && moveInput.x < 0))
        {
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
        }
    }

    void UnlockMove() // Hàm này để mở khóa di chuyển
    {
        blockMove = false;
    }
}
