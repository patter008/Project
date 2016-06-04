using UnityEngine;
using System.Collections;

public class ammoPickupController : MonoBehaviour {


    public float ammoAmount;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponentInChildren<fireFireBall>().reload(ammoAmount);
            Destroy(transform.root.gameObject);
        }
    }
    
}
