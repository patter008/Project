﻿using UnityEngine;
using System.Collections;
using System;

public class LevelHandler : MonoBehaviour {

    private static LevelHandler instance;

    public  GUITexture overlay;


    public float fadeTime;

    public MovieTexture movieTexture;

    private AudioSource audioSource;
    



    public static LevelHandler Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<LevelHandler>();
            }
            return instance;
        }

       
    }


    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = movieTexture.audioClip;


        overlay.pixelInset = new Rect(0, 0, Screen.width, Screen.height);

        StartCoroutine(FadeToClear());
        //Fade to clear

        if (movieTexture != null)
        {
            movieTexture.Play();
            audioSource.Play();
            Screen.fullScreen = true;
        }
    }


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.N))
        {
            LoadNextLevel();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadLevel();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            LoadSpecific("MainMenu");
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            LoadSpecific(2);
        }


        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Screen.fullScreen = false;
            audioSource.Stop();
            movieTexture.Stop();
            
        }


    }

    public void LoadNextLevel()
    {
        if(Application.loadedLevel<Application.levelCount-1)
        {

            StartCoroutine(FadeToBlack(() => Application.LoadLevel(Application.loadedLevel)));
            
        }

    }

    public void ReloadLevel()
    {
        StartCoroutine(FadeToBlack(() => Application.LoadLevel(Application.loadedLevel)));

        
    }

    public void LoadSpecific(int index)
    {
        StartCoroutine(FadeToBlack(() => Application.LoadLevel(index)));

        Application.LoadLevel(index);
    }

    public void LoadSpecific(string name)
    {
        StartCoroutine(FadeToBlack(() => Application.LoadLevel(name)));

        Application.LoadLevel(name);
    }

    private IEnumerator FadeToClear()
    {
        overlay.gameObject.SetActive(true);
        overlay.color = Color.black;

        float rate = 1.0f / fadeTime;

        float progress = 0.0f;

        while (progress < 1.0f)
        {
            overlay.color = Color.Lerp(Color.black, Color.clear, progress);

            progress += rate * Time.deltaTime;

            yield return null;

        }

        overlay.color = Color.clear;
        overlay.gameObject.SetActive(false);



    }
    private IEnumerator FadeToBlack(Action levelMethod)
    {
        overlay.gameObject.SetActive(true);
        overlay.color = Color.clear;

        float rate = 1.0f / fadeTime;

        float progress = 0.0f;

        while (progress < 1.0f)
        {
            overlay.color = Color.Lerp(Color.clear, Color.black, progress);

            progress += rate * Time.deltaTime;

            yield return null;

        }

        overlay.color = Color.black;

        levelMethod();


    }

    void OnGUI()
    {
        if(movieTexture != null && movieTexture.isPlaying)
        {
            GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),movieTexture,ScaleMode.StretchToFill);
        }
    }

}
