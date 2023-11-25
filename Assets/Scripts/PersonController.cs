using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    public float speed = 5.0f;
    public float sensitivity = 2.0f;

    private CharacterController characterController;
    private Camera playerCamera;
    private float rotationX = 0;

    private float jumpHeight = 6.0f;
    private bool groundedPlayer;
    private float gravityValue = -9.81f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        if (Time.timeScale > 0)
        {
            HandleMovement();
            HandleMouseLook();

            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            move = move.normalized;

            anim.SetFloat("SpeedX", move.x);
            anim.SetFloat("SpeedZ", move.z);
            anim.SetFloat("SpeedMag", move.magnitude);


        }
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float jump = transform.position.y;

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            jump += Mathf.Sqrt(jumpHeight * -0.3f * gravityValue);
        }

        jump += gravityValue * Time.deltaTime;

        Vector3 moveDirection = new Vector3(horizontal, jump, vertical);

        characterController.Move(moveDirection * Time.deltaTime);

        // Optional: Apply gravity if needed
        // characterController.SimpleMove(Vector3.down * 9.8f);
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, 0, 0);

        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, mouseX, 0);
    }


}