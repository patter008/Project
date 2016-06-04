using UnityEngine;
using System.Collections;

public class soundController : MonoBehaviour {

    public AudioSource playerDie;
    public AudioClip playerdie;

    GameObject PCT;
    playerHealth playerCT;

	// Use this for initialization
	void Start () {
        PCT = GameObject.FindGameObjectWithTag("Player");
        playerCT = PCT.GetComponent<playerHealth>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        //playerDie.clip = playerdie;
       
            playerdied(playerdie);
            
    }

    void playerdied(AudioClip playerSound)
    {
        playerDie.clip = playerSound;
        
    if (playerCT.died == true)
        {
        playerDie.Play();
        }

    }
}
