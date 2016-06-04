using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Physics))]
public class PlayerController1 : Entity
{
    //Player Handling
    public float gravity = 20;
    public float walkSpeed = 8;
    public float runSpeed = 12;
    public float acceleration = 30;
    public float jumpHeight = 12;
    public float slideDeceleration = 10;

    private float initiateSlideThreshold = 9;

    //ระบบ
    private float animationSpeed;
    private float currentSpeed;
    private float targetSpeed;
    private Vector2 amoutToMove;
    private float moveDirX;

    // สถานะ
    private bool jumping;
    private bool sliding;
    private bool wallHolding;
    private bool stopSliding;

    //Component
    private PlayerPhysics playerPhysics;
    private Animator animator;
    private GameManager manager;
	private Instructions instruction;





    // Use this for initialization
    void Start()
    {
        playerPhysics = GetComponent<PlayerPhysics>();
        animator = GetComponent<Animator>();
        manager = Camera.main.GetComponent<GameManager>();
		instruction = Camera.main.GetComponent<Instructions> ();
	

        animator.SetLayerWeight(1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPhysics.movementStopped)
        {
            currentSpeed = 0;
            targetSpeed = 0;
        }


        // ถ้า player สัมผัสกับพื้น
        if (playerPhysics.grounded)
        {
            amoutToMove.y = 0;

            if (wallHolding)
            {
                wallHolding = false;
                animator.SetBool("Wall Hold", false);
            }
            //Jump logic
            if (jumping)
            {
                jumping = false;
                animator.SetBool("Jumping", false);
            }

            //Slide logic
            if (sliding)
            {
                if (Mathf.Abs(currentSpeed) < .25f || stopSliding)
                {
                    stopSliding = false;
                    sliding = false;
                    animator.SetBool("Sliding", false);
                    playerPhysics.ResetCollider();
                    
                }
            }

            //Slide Input
            if (Input.GetButtonDown("Slide"))
            {
                if (Mathf.Abs(currentSpeed )> initiateSlideThreshold)
                {
                    sliding = true;
                    animator.SetBool("Sliding", true);
                    targetSpeed = 0;

                    playerPhysics.SetCollider(new Vector3(10.2f, 1.5f, 3), new Vector3(.3f, .75f, 0));
                }
            }
        }
        else
        {
            if (playerPhysics.canWallHold)
            {
                wallHolding = true;
                animator.SetBool("Wall Hold", true);
            }
        }

        //Input Jump
        if (Input.GetButtonDown("Jump"))
        {
            if (sliding)
            {
                stopSliding = true;
            }
            else if (playerPhysics.grounded || wallHolding)
            {
                amoutToMove.y = jumpHeight;
                jumping = true;
                animator.SetBool("Jumping", true);

                if (wallHolding)
                {
                    wallHolding = false;
                    animator.SetBool("Wall Hold", false);
                }
            }

        }

        // Set ตัวพารามิเตอร์ ของ animator
        animationSpeed = IncrementTowards(animationSpeed, Mathf.Abs(targetSpeed), acceleration);
        animator.SetFloat("Speed", animationSpeed);
        // Input 
        moveDirX = Input.GetAxisRaw("Horizontal");
        if (!sliding)
        {
            float speed = (Input.GetButton("Run")) ? runSpeed : walkSpeed;
            targetSpeed = Input.GetAxisRaw("Horizontal") * speed;
            currentSpeed = IncrementTowards(currentSpeed, targetSpeed, acceleration);

            // ทิศทางการหันหน้าของตัวละครนะครับ
           
            if (moveDirX != 0 && !wallHolding)
            {
                transform.eulerAngles = (moveDirX > 0) ? Vector3.up * 180 : Vector3.zero;
            }
        }
        else
        {
            currentSpeed = IncrementTowards(currentSpeed, targetSpeed, slideDeceleration);
        }
        amoutToMove.x = currentSpeed;

        if (wallHolding)
        {
            amoutToMove.x = 0;
            if(Input.GetAxisRaw("Vertical")!= -1)
            {
                amoutToMove.y = 0;
            }
        }
        amoutToMove.y -= gravity * Time.deltaTime;

        playerPhysics.Move(amoutToMove * Time.deltaTime,moveDirX);


    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Checkpoint")
        {
            manager.SetCheckpoint(c.transform.position);
        }
        if (c.tag == "Finish")
        {
            manager.EndLevel();
        }
		if (c.tag == "Move") 
		{
			instruction.Move ();
		}
		if (c.tag == "NoMove") 
		{
			instruction.Unshow ();
		}
    }

    //Increse n towards target by speed
    private float IncrementTowards(float n, float target, float a)
    {
        if (n == target)
        {
            return n;
        }
        else
        {
            float dir = Mathf.Sign(target - n); // n must be increased or decreased to get closer to target
            n += a * Time.deltaTime * dir;
            return (dir == Mathf.Sign(target - n)) ? n : target; // if n has passed then return target ,otherwise return n
        }
    }
}
