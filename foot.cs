using UnityEngine;
using System.Collections;

public class foot : MonoBehaviour {

   


    //audio info
    AudioSource footStepAS;
    public AudioClip footStep;
    public AudioClip footsk;

   
    GameObject pp;
    playerController PCT;
    ///
    void Awake()
    {
        footStepAS = GetComponentInChildren<AudioSource>();
        pp = GameObject.FindGameObjectWithTag("Player");
        PCT = pp.GetComponent<playerController>();

    }


    // Use this for initialization
    void Start()
    {
        

    }



    // Update is called once per frame
    void FixedUpdate()
    {


        if(PCT.grounded ==true && (PCT.movement > 0 || PCT.movement < 0) && footStepAS.isPlaying == false)
        {
            //footStepAS.Play();
            playASound(footStep);
            if(PCT.sneak > 0)
            {
                
                //footStepAS.Play();
                playASound(footsk);
            }
        }


    }
    void playASound(AudioClip playTheSound)
    {
        footStepAS.clip = playTheSound;
        footStepAS.Play();
    }
    
}

