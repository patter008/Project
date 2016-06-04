using UnityEngine;
using System.Collections;

public class Player_shoot : MonoBehaviour {

    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    private Transform gunPos;

    private Rigidbody2D myRigidbody;

    private Animator myAnimator;

    [SerializeField]
    private float shotCD;

    private float timeSinceShot;
    
    private bool canShoot = true;

    // Use this for initialization
    void Start() {

        this.myRigidbody = GetComponent<Rigidbody2D>();
        this.myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

        Vector3 newRotation = transform.rotation.eulerAngles;

        newRotation.z -= Input.GetAxis("Horizontal") * rotationSpeed;

        transform.rotation = Quaternion.Euler(newRotation);

        if (!canShoot)
        {
            timeSinceShot += Time.deltaTime;
            if (timeSinceShot >= shotCD)
           {
                canShoot = true;
           }
        }

        if (Input.GetMouseButton(0))
        {
            Shoot();
        }

    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            myRigidbody.AddForce(transform.right * movementSpeed);
            myRigidbody.velocity = Vector2.ClampMagnitude(myRigidbody.velocity, 10);
            myAnimator.SetBool("Thrust", true);

        }
        else
        {
            myRigidbody.velocity = Vector2.Lerp(myRigidbody.velocity, Vector2.zero, 0.01f);
            myAnimator.SetBool("Thrust", false);
        }
    }

    
    private void Shoot()
    {

        if (canShoot)
        {
            canShoot = false;
            timeSinceShot = 0;
            Instantiate(projectilePrefab, gunPos.position, transform.rotation);
        }
        

    }

    
}
