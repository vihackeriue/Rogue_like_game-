using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public Vector2 moveDir;
    [HideInInspector]
    public Vector2 lastMoveVector;

    Rigidbody2D rb;
    // public CharacterScriptableObject characterData;
    PlayerStats player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();
        lastMoveVector = new Vector2(1, 0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        InputManagement();
    }
    void FixedUpdate(){
        Move();
    }

    void InputManagement(){
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;
        // hướng mặt của nv
        
        // Xoay nhân vật nếu di chuyển sang trái hoặc phải
        if (moveDir.x < 0) // left
        {
            transform.rotation = Quaternion.Euler(0, 180, 0); // Xoay 180 độ khi di chuyển sang trái
            lastMoveVector = new Vector2(-1f, 0f);
        }
        else if (moveDir.x > 0) // Right
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); // Không xoay khi di chuyển sang phải
            lastMoveVector = new Vector2(1f, 0f);
        }
        // Xoay nhân vật nếu di chuyển lên hoặc xuống
            if (moveDir.y > 0)
            {
                lastMoveVector = new Vector2(0f, 1f);
            }
            else if (moveDir.y < 0)
            {
                lastMoveVector = new Vector2(0f, -1f);
            }

        // Di chuyển lên trái
        if (moveDir.x < 0 && moveDir.y > 0)
        {
            lastMoveVector = new Vector2(-1f, 1f);
        }
        // Di chuyển lên phải
        else if (moveDir.x > 0 && moveDir.y > 0)
        {
            lastMoveVector = new Vector2(1f, 1f);
        }
        // Di chuyển xuống trái
        else if (moveDir.x < 0 && moveDir.y < 0)
        {
            lastMoveVector = new Vector2(-1f, -1f);
        }
        // Di chuyển xuống phải
        else if (moveDir.x > 0 && moveDir.y < 0)
        {
            lastMoveVector = new Vector2(1f, -1f);
        }
    } 
    void Move(){
        rb.velocity = new Vector2(moveDir.x* player.currentMoveSpeed, moveDir.y*player.currentMoveSpeed);
    }
}
