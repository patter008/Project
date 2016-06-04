using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class playerController : MonoBehaviour {
    //public float speed;
    //public float tilt;
    //public Boundary boundary;
    bool running;


    //audio info
     AudioSource footStepAS;
    public AudioClip footStep;

  public  float movement;
    public float sneak;



    //movement variables
    public float runSpeed;
    public float walkSpeed;



    Rigidbody myRB;
    Animator myAnim;

    bool facingRight;

    //for jumping
    public bool grounded = false ;
    Collider[] groundCollisions;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;
    ///
    void Awake()
    {
        footStepAS = GetComponent<AudioSource>();
    }


	// Use this for initialization
	void Start () {
        myRB = GetComponent<Rigidbody>();
        myAnim = GetComponent<Animator>();
        facingRight = true;
	}

    

    // Update is called once per frame
    void Update() {
        




    }

    void FixedUpdate()
    {













        running = false;

        float jump = Input.GetAxis("Jump");
       //myAnim.SetFloat("verticalSpeed", Mathf.Abs(Input.GetAxis("Jump")));
        myAnim.SetFloat("verticalSpeed", Mathf.Abs(jump));

        // if (grounded && Input.GetAxis("Jump") > 0)
        if ((grounded && jump > 0))
        {

            grounded = false;
            myAnim.SetBool("grounded", grounded);
            myRB.AddForce(new Vector3(0, jumpHeight, 0));


        }




        groundCollisions = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundLayer);
        if (groundCollisions.Length > 0)
        {
            
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        myAnim.SetBool("grounded", grounded);




        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(move));

       
        float sneaking = Input.GetAxisRaw("Fire3");
        myAnim.SetFloat("sneaking", sneaking);

        float firing = Input.GetAxis("Fire1");
        myAnim.SetFloat("shooting", firing);

        /////
        movement = move;
        sneak = sneaking;


        if ((sneaking>0 || firing >0)&& grounded)
        {
            
            myRB.velocity = new Vector3(move * walkSpeed, myRB.velocity.y, 0);
            if(grounded == true)
            {
                //PlayASound(footStep);
            }
            

        }
        else
        {
            myRB.velocity = new Vector3(move * runSpeed, myRB.velocity.y, 0);
            if (grounded == true)
            {
               // PlayASound(footStep);
            }

            if (Mathf.Abs(move) > 0)
            {
                running = true;
            }
        }
        

        if (move > 0 && facingRight != true)
        {
            Flip();
        }
        else if(move <0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.z *= -1;
        transform.localScale = theScale;
    }

    public float GetFacing()
    {
        if (facingRight)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }

    public bool getRunning()
    {
        return (running);
    }

 public void PlayASound(AudioClip playTheSound)
    {
        footStepAS.clip = playTheSound;
        if (grounded == true && (movement > 0 || movement < 0)&& footStepAS.isPlaying == false)
        {
            footStepAS.volume = Random.Range(0.1f, 0.2f);
            //footStepAS.pitch = Random.Range(0.8f, 1.1f);
            footStepAS.Play();
            
            
        }

    }
}
