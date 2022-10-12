using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 10f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float JumpHeight = 3f;
    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 20f;
        }
        else
        {
            speed = 10f;
        }
    }
}
