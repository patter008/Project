using UnityEngine;
using System.Collections;

public class FireBolt : MonoBehaviour {


    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;



    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        playerController myPlayer = transform.root.GetComponent<playerController>();

        if (Input.GetAxisRaw("Fire1") > 0 && nextFire < Time.time)
        {
            nextFire = Time.time + fireRate;
            Vector3 rot;
            if (myPlayer.GetFacing() == -1f)
            {
                rot = new Vector3(0, -90, 0);
            }
            else
            {
                rot = new Vector3(0, 90, 0);
            }
            Instantiate(shot, shotSpawn.position, Quaternion.Euler(rot));
            
        }

    }
}

