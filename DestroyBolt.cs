﻿using UnityEngine;
using System.Collections;

public class DestroyBolt : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        
        
            Destroy(other.gameObject);
           
        
       
        
        
        
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
