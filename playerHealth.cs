using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {
    //
    [SerializeField]
    Stat health;
    // [SerializeField]
    // private Stat magic;

    public float fullHealth;
    float currentHealth;

    public GameObject playerDeathFX;

    //HUD
    public Image damageScreen;
    Color flashColor = new Color(255f, 255f, 255f, 1f);
    float flashSpeed = 5f;
    bool damaged = false;

    AudioSource playerAS;
    public AudioClip playerHurt;
    public AudioClip foot;



    //
    GameObject footS;
    playerController footCT;

    public bool died = false;

    //
    void Awake()
    {
        health.Initialize();

        // magic.Initialize();
    }

    // Use this for initialization
    void Start() {
        //currentHealth = fullHealth;
        playerAS = GetComponent<AudioSource>();
        footS = GameObject.FindGameObjectWithTag("Player");
        footCT = footS.GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update() {
        //are we hurt?
        if (damaged)
        {
            damageScreen.color = flashColor;
        }
        else
        {
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }


    public void addDamage(float damage)
    {
        health.CurrentVal -= damage;

        // magic.CurrentVal -= damage;
        damaged = true;
        //currentHealth -= damage;
        //if(currentHealth <= 0)
        // if(magic.CurrentVal <= 0)
        // {
        //     makeDead();
        //} 
       
        playASound(playerHurt);
       





        if (health.CurrentVal <= 0)
        {

            makeDead();

        }
    }

    public void addHealth(float healths)
    {
        health.CurrentVal += healths;
        if (health.CurrentVal > health.MaxVal)
        {
            health.CurrentVal = health.MaxVal;
        }
        health.CurrentVal = health.CurrentVal;
    }

    public void makeDead()
    {
        died = true;
        Instantiate(playerDeathFX, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
        damageScreen.color = flashColor;
        Destroy(gameObject);


    }

    void playASound(AudioClip playTheSound)
    {
        playerAS.clip = playTheSound;
        if ((footCT.grounded == true || footCT.grounded == false) && playerAS.isPlaying == false)
        {

            playerAS.Play();
            

        }

    }

    
}
