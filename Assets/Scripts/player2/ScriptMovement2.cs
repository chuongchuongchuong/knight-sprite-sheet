using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMovement2 : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public int speed;
    public Vector2 moveInput;
    public bool blockMove = false;

    public bool isFlyin = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (blockMove) return;// nếu bị khóa di chuyển thì không di chuyển được
        
        moveInput.x = Input.GetAxisRaw("Horizontal2");
        if (isFlyin) moveInput.y = Input.GetAxisRaw("Vertical2");
        transform.Translate(speed * Time.deltaTime * moveInput);

        if (moveInput.x > 0) spriteRenderer.flipX = false;
        if (moveInput.x < 0) spriteRenderer.flipX = true;
    }
}
