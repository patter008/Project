using UnityEngine;
using System.Collections;

public class Move2D : MonoBehaviour {

    
    public float moveSpeed;
    public float jumpHeight;
    private Rigidbody rigid;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        Movement();
        
        
	}

    void Movement()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
             transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

             transform.eulerAngles= new Vector2(0,180);
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
           transform.eulerAngles = new Vector2(0, 0);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            //rigidbody.velocity = new Vector3(0, jumpHeight, transform.position.z);
           
            rigid.velocity = new Vector3(rigid.velocity.x, jumpHeight,0);
            
        }
    }
}
