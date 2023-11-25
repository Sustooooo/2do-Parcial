using UnityEngine;

public class MiCharacterController : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;
    [SerializeField]
    private Animator anim;
    private Vector3 playerVelocity;
    [SerializeField] private bool groundedPlayer;
    private float playerSpeed = 3.0f;
    private float jumpHeight = 6.0f;
    private float gravityValue = -9.81f;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        move = move.normalized;

        anim.SetFloat("SpeedX",move.x);
        anim.SetFloat("SpeedZ",move.z);
        anim.SetFloat("SpeedMag",move.magnitude);

        controller.Move(move * Time.deltaTime * playerSpeed);

       // if (move != Vector3.zero)
        //{
         // gameObject.transform.forward = move;
        //}

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -.3f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}