using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    [SerializeField]
    private float speed;
    // [SerializeField]
    //private float maxSpeed;
    [SerializeField]
    private float lifetime;

    private Rigidbody2D myRigidbody;

    private void Awake()
    {
        this.myRigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(DestroyMe());
    }


    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(transform.right * speed * Time.deltaTime,Space.World);
        //myRigidbody.AddForce(transform.right * speed);
       // myRigidbody.velocity = Vector2.ClampMagnitude(myRigidbody.velocity, 10);
    }
	
    private IEnumerator DestroyMe()
    {
        yield return new WaitForSeconds(lifetime);

        Destroy(gameObject);
    }


}
