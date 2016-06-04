using UnityEngine;
using System.Collections;

public class shootBullet: MonoBehaviour {

    public float range = 10f;
    public float damage = 5f;

    

    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    LineRenderer fireBallLine;
    LineRenderer fireBoltLine;
    

    void Awake()
    {
        
        shootableMask = LayerMask.GetMask("Shootable");
        fireBallLine = GetComponent<LineRenderer>();
        fireBoltLine = GetComponent<LineRenderer>();
       
        

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
         fireBallLine.SetPosition(0, transform.position);
        fireBoltLine.SetPosition(0, transform.position);
        
       

        if(Physics.Raycast(shootRay,out shootHit, range, shootableMask))
        {
            //hit an enemy goes here
            fireBallLine.SetPosition(1, shootHit.point);

            fireBoltLine.SetPosition(1, shootHit.point);
            
            
            //Destroy(GameObject.FindGameObjectWithTag("fireball"),life);
            

        }
        else
        {
            fireBallLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
            fireBoltLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }
    


    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
}
