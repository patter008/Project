﻿using UnityEngine;
using System.Collections;

public class DestroyMe : MonoBehaviour {

    public float aliveTime;


    void Awake()
    {
        Destroy(gameObject, aliveTime);
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
