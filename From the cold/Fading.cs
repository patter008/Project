﻿using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour {

    public Texture2D fadeOutTexture; // texture จะทับบนหน้าจอ. สามารถใช้ภาพสีดำ หรือภาพโหลดดิ่งได้
        public float fadeSpeed = 0.8f; // ความเร็วในการเฟด

    public int drawDepth = -1000; // ลำดับการวาด texture
    private float alpha = 1.0f; // ค่าอัลฟ่า มีค่าระหว่าง 0 และ 1
    private int fadeDir = -1; // ทิศทางการเฟส  เข้า คือ -1  หรือ ออกคือ 1

    void OnGui()
    {
        // ทิศทางการเฟด เข้าหรือออก จะใช้ค่า Dir ความเร็วและเวลาจะทำให้อยู่ในรูปของต่อวินาที
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        // force(clamp) the number between 0 and 1 because GUI.color uses alpha values between 0 and 1
        alpha = Mathf.Clamp01(alpha);

        //set color of our GUI( in this case our texture). All color values remain the same & the Alpha is set to the alpha variable
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);    //set alpha value
        GUI.depth = drawDepth;                                                  // make the black texture render on top (dranw last)
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);// draw the texture to fit the entire screen area


    }

    //sets fadeDir to the direction parameter making the scene fade in if -1 and out if 1
    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return (fadeSpeed); // return the fadeSpeed variable so it's easy to time the Application.LoadLevel();
    }

    // OnLevelWasLoaded is called when a level is loaded. It takes loaded level index (int) as a parameter so you can litmite the fade in to certain scenes
    void OnLevelWasLoaded()
    {
        //alpha =1;     // use this if the alpha is not set to 1 by default
        BeginFade(-1);
    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
