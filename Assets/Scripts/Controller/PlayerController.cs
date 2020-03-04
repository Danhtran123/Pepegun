using UnityEngine;

// Ideas and code come from list of videos from https://www.youtube.com/watch?v=h2d9Wc3Hhi0&list=PLiyfvmtjWC_V_H-VMGGAZi7n5E0gyhc37&index=1
// https://www.youtube.com/watch?v=JxFKTFgRYLg
public class PlayerController : MonoBehaviour
{

    public float baseMoveSpeed;
    private float moveSpeed;
    public float itemSpeedMod;

    public float jumpForce;
    public float itemJumpMod;
    public CharacterController controller;

    public GameManager g1;

    public Transform target;
    private float rotateSpeed;

    private Vector3 moveDirection;
    public float gravityScale;

    NewCameraController cam;

    public float slopeForce;
    public float slopeForceRayLength;
    private float characterHeight;

    // Take input sensitivity from camera so it stays the same,
    // automatically grab player model that contains the CharacterController script
    void Start()
    {
        controller = GetComponent<CharacterController>();
        characterHeight = controller.transform.position.y;

        GameObject camObj = GameObject.Find("CameraBase");
        cam = camObj.GetComponent<NewCameraController>();
        rotateSpeed = cam.inputSensitivity;

        g1 = g1.GetComponent<GameManager>();
    }

    // Updates player rotation based on horizontal mouse movement
    // Player movement based on "WASD"
    void Update()
    {
        itemSpeedMod = g1.currentSpeedItem;
        itemJumpMod = g1.currentJumpItem;
        Run();

        float yStore = moveDirection.y;

        float vertInput = Input.GetAxis("Vertical");
        float horizInput = Input.GetAxis("Horizontal");
        moveDirection = (transform.forward * vertInput) + (transform.right * horizInput);
        moveDirection = Vector3.ClampMagnitude(moveDirection, 1) * (moveSpeed+itemSpeedMod);
        moveDirection.y = yStore;

        //If on slope push player down
        if((vertInput != 0 || horizInput != 0) && onSlope())
        {
            controller.Move(Vector3.down * characterHeight / 2 * slopeForce * Time.deltaTime);
        }

        Jump();

        controller.Move(moveDirection * Time.deltaTime);

        //get x position of mouse and rotate target
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.Rotate(0, horizontal, 0);
    }

    private bool onSlope()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, characterHeight/2 * slopeForceRayLength))
        {
            Debug.Log("before slope");
            if(hit.normal != Vector3.up)
            {
                return true;
            }
        }
        return false;
    }

    void Jump()
    {
        if (controller.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce+itemJumpMod;
            }
        }
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
    }

    void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 1.5f * baseMoveSpeed;
        }
        else { moveSpeed = baseMoveSpeed; }
    }

}
