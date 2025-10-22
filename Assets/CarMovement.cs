using UnityEngine;

public class CarController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input from WASD or arrow keys
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize(); // prevent faster diagonal movement
    }

    void FixedUpdate()
    {
        // Move the car
        rb.linearVelocity = moveInput * moveSpeed;

        // Rotate the car to face movement direction (if moving)
        if (moveInput.sqrMagnitude > 0.01f)
        {
            float angle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }
    }
}

//random exit placement
//light up exit
//candle timer
//victory at exit
//loss at burnout
//instructions before start