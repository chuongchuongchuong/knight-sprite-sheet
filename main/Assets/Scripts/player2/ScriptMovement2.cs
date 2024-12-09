using UnityEngine;
using UnityEngine.Serialization;

public class ScriptMovement2 : MonoBehaviour
{
    [SerializeField] private CharactorData dragonData;
    
    [HideInInspector] public Vector2 moveInput;
    public bool blockMove;
    [SerializeField] private bool isFlyin;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private ScriptCheckGrounded scriptCheckGrounded;
    [SerializeField] private Animator anim;
    [FormerlySerializedAs("scriptKnihgtHealth")] [FormerlySerializedAs("scriptHealth1")] [SerializeField] private ScriptKnightHealth scriptKnightHealth;
    [FormerlySerializedAs("scriptHealth2")] [SerializeField] private ScriptDragonHealth scriptDragonHealth;

    private void Reset()
    {
        dragonData = Resources.Load<CharactorData>("Data/Dragon");
        rb = GetComponent<Rigidbody2D>();
        scriptCheckGrounded = GetComponentInChildren<ScriptCheckGrounded>();
        anim = GetComponentInChildren<Animator>();
        scriptKnightHealth = GameObject.Find("Health1").GetComponent<ScriptKnightHealth>(); // lấy component máu của cả 2 player
        scriptDragonHealth = GameObject.Find("Health2").GetComponent<ScriptDragonHealth>();
    }


    // Update is called once per frame
    private void Update()
    {
        if (blockMove) return; // nếu bị khóa di chuyển thì không di chuyển được

        MovenJump();

        if (anim.GetCurrentAnimatorStateInfo(0)
            .IsName("2_BreathFire")) // đây là lệnh check xem có phải là trạng thái 2, đang phun lửa không
        {
            blockMove = true; // nếu đúng thì sẽ khóa si chuyển lại
            Invoke(nameof(UnlockMove), .5f); // nửa giây sau sẽ mở khóa di chuyển
        }

        if (scriptKnightHealth.IsDead() ||
            scriptDragonHealth.IsDead()) // khi 1 trong 2 player chết thì cả 2 sẽ không thể di chuyển được
        {
            blockMove = true;
        }
    }

    void MovenJump()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        if (isFlyin) moveInput.y = Input.GetAxisRaw("Vertical");
        transform.Translate(dragonData.moveSpeed * Time.deltaTime * moveInput); // Di chuyển trái phải
        Flip(); // qQay mặt nhân vật

        if (scriptCheckGrounded.isGrounded && Input.GetKeyDown(KeyCode.UpArrow)) // chỗ này là code nhảy lên
            rb.velocity = Vector2.up * dragonData.jumpForce;
        return;

        void Flip() // Hàm này làm quay mặt player lại
        {
            if ((transform.localScale.x > 0 && moveInput.x > 0) || (transform.localScale.x < 0 && moveInput.x < 0))
            {
                var temp = transform.localScale;
                temp.x *= -1;
                transform.localScale = temp;
            }
        }
    }


    private void UnlockMove() // Hàm này để mở khóa di chuyển
    {
        blockMove = false;
    }
}