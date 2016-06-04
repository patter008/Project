using UnityEngine;
using System.Collections;

public class elevatorController : MonoBehaviour {

    public float resetTime;

    Animator elevAnim;
    AudioSource elevAS;

    float downTime;
    bool elevIsUp = false;



	// Use this for initialization
	void Start () {

        elevAnim = GetComponent<Animator>();
        elevAS = GetComponent<AudioSource>();
	
	}
	
	// Update is called once per frame
	void Update () {
	if(downTime <=Time.time && elevIsUp)
        {
            elevAnim.SetTrigger("activateElevator");
            elevIsUp = false;
            elevAS.Play();
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            elevAnim.SetTrigger("activateElevator");
            downTime = Time.time + resetTime;
            elevIsUp = true;
            elevAS.Play();
        }
    }
}
