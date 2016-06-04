using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class fireFireBall : MonoBehaviour
{

    [SerializeField]
    private Stat magic;

    

    public float timeBetweenFireBall = 0.15f;
    //public float timeBetweenFireBall ;
    public GameObject projectile;
    // public GameObject projectile1;

    //fireBall info
    public int maxRounds;
    public int startingRounds;
    int remainingRounds;






    float nextFireBall;

    //audio info
    AudioSource fireMuzzleAS;
    public AudioClip shootSound;
    public AudioClip reloadSound;

    void Awake()
    {
        magic.Initialize();
        nextFireBall = 0f;


        fireMuzzleAS = GetComponent<AudioSource>();

        
    }


    // Use this for initialization
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        playerController myPlayer = transform.root.GetComponent<playerController>();

        if (Input.GetAxisRaw("Fire1") > 0 && nextFireBall < Time.time && magic.CurrentVal >0)
        {
            nextFireBall = Time.time + timeBetweenFireBall;
            Vector3 rot;
            if (myPlayer.GetFacing() == -1f)
            {
                rot = new Vector3(0, -90, 0);
            }
            else
            {
                rot = new Vector3(0, 90, 0);
            }
            Instantiate(projectile, transform.position, Quaternion.Euler(rot));
            //Instantiate(projectile1, transform.position, Quaternion.Euler(rot));

            playASound(shootSound);

            //fireMuzzleAS.clip = shootSound;
           // fireMuzzleAS.Play();

            magic.CurrentVal -= 1;
            
            
            
            

        }

    }

    public void reload(float ammo)
    {
        //magic.CurrentVal = magic.MaxVal;
        magic.CurrentVal += ammo;
        if (magic.CurrentVal > magic.MaxVal)
        {
            magic.CurrentVal = magic.MaxVal;
        }
        magic.CurrentVal = magic.CurrentVal;

        playASound(reloadSound);

    }

    void playASound(AudioClip playTheSound)
    {
        fireMuzzleAS.clip = playTheSound;
        fireMuzzleAS.Play();
    }
}
