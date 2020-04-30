using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Ideas and code come from list of videos from https://www.youtube.com/watch?v=h2d9Wc3Hhi0&list=PLiyfvmtjWC_V_H-VMGGAZi7n5E0gyhc37&index=1
// https://www.youtube.com/watch?v=JxFKTFgRYLg
public class PlayerController : PlayerStatus
{

    public float baseMoveSpeed;
    private float moveSpeed;
    public float itemSpeedMod;

    public float teleportDistance;
    public float teleportCooldown;
    private float teleportTime = 0;
    public Image teleportBar;

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

    Health health;
    int hp;

    public float iFrame;
    Animator anim;

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

        anim = GetComponent<Animator>();
        health = FindObjectOfType<Health>();

        teleportTime = 0;
        hasTeleported = false;
        iFrameTimer = 0;
        invincible = false;

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

        //If on slope push player down, also allows for players to jump while running downhill
        if((vertInput != 0 || horizInput != 0) && onSlope())
        {
            controller.Move(Vector3.down * characterHeight / 2 * slopeForce * Time.deltaTime);
        }

        Jump();
        Teleport();

        controller.Move(moveDirection * Time.deltaTime);

        //get x position of mouse and rotate target
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.Rotate(0, horizontal, 0);

        resetIFrame();
    }

    //to fix jittery downhill, check to see if player is on slope
    private bool onSlope()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, characterHeight/2 * slopeForceRayLength))
        {
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

    void Teleport()
    {
        //when infinite teleport item is grabbed we start subtracting the timer
        if (itemTeleportTimer > 0)
        {
            itemTeleportTimer -= Time.deltaTime;
        }
        //fix for teleport cooldown since itemTeleportTimer would be below 0 it would not activate the cooldown timer.
        if (itemTeleportTimer < 0)
        {
            itemTeleportTimer = 0;
        }
        //GetKeyDown is used because teleport would go crazy when item was activated on GetKey
        if (Input.GetKeyDown(KeyCode.C) || Input.GetMouseButtonDown(1)){
            if (!hasTeleported || itemTeleportTimer > 0)
            {
                Debug.Log("Is teleporting!");
                moveDirection.y = 0;
                controller.Move(moveDirection * teleportDistance * Time.deltaTime);
                //think this is a fix for super teleporting
                moveDirection.x = 0;
                moveDirection.z = 0;
                hasTeleported = true;
            }
        }
        //when teleported and item timer is 0 start a cooldown timer.
        if (hasTeleported && itemTeleportTimer == 0)
        {
            Debug.Log("Teleport cooldown is coming back in " + (teleportTime));
            teleportBar.fillAmount = teleportTime / teleportCooldown;
            teleportTime += Time.deltaTime;
            if(teleportTime >= teleportCooldown)
            {
                Debug.Log("Teleport is off cooldown!");
                teleportTime = 0;
                hasTeleported = false;
            }
        }
    }

    public void TakeDamage(int amount)
    {
        hp = health.GetHealth();
        if (!invincible)
        {
            invincible = true;
            Debug.Log(amount + " damage and hp " + hp);
            hp -= amount;
            health.setHealth(hp);
        }
    }
    
    //referenced by InvincibleItem, animates the flashing effect of player on damage taken or invincible 
    public void resetIFrame()
    {
        if (invincible)
        {
            anim.SetTrigger("isDamaged");
            iFrameTimer += Time.deltaTime;
            Debug.Log(iFrameTimer);
            if (iFrameTimer >= iFrame)
            {
                Debug.Log("iFrame over with");
                anim.ResetTrigger("isDamaged");
                iFrameTimer = 0;
                invincible = false;
            }
        }
    }

}
