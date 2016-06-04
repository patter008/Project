﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public GameObject player;
    private GameObject currentPlayer;
    private GameCamera cam;
    private Vector3 checkpoint;



    public Text wintText;

    public static int levelCount = 2;
    public static int currentLevel = 1;

	void Start()
    {

        wintText = GameObject.Find("Win").GetComponent<Text>();


        cam = GetComponent<GameCamera>();
        if (GameObject.FindGameObjectWithTag("Spawn"))
        {
            checkpoint = GameObject.FindGameObjectWithTag("Spawn").transform.position;
        }
        //SpawnPlayer(checkpoint);
		//if (GameObject.FindGameObjectsWithTag ("Player")) 
		{
			player = GameObject.FindGameObjectWithTag ("Player");
			cam.SetTarget (player.transform);
		}
    }

   // private void SpawnPlayer(Vector3 spawnPos)
   // {
   //     currentPlayer = Instantiate(player,spawnPos, Quaternion.identity)as GameObject;
   //     cam.SetTarget(currentPlayer.transform);
  //  }

    private void Update()
    {
        if (!currentPlayer)
        {
            if (Input.GetButtonDown("Respawn"))
            {

               ////////////////////////////////////////////////// SpawnPlayer(checkpoint);
            }
        }
    }

    public void SetCheckpoint(Vector3 cp)
    {
        checkpoint = cp;
    }

    public void EndLevel()
    {
        if(currentLevel < levelCount)
        {
            currentLevel++;
            Application.LoadLevel("Level " + currentLevel);
        }
        else
        {
            wintText.text = ("Victory");
        }
    }


}
