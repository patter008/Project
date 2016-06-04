using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour {

	public Canvas movePic;
	public Canvas jumpPic;
	public Canvas slidePic;
	public Canvas attackPic;

	// Use this for initialization
	void Start () {
		movePic = movePic.GetComponent<Canvas> ();
		jumpPic = jumpPic.GetComponent<Canvas> ();
		slidePic = slidePic.GetComponent<Canvas> ();
		attackPic = attackPic.GetComponent<Canvas> ();

		movePic.enabled = false;
		jumpPic.enabled = false;
		slidePic.enabled = false;
		attackPic.enabled = false;
	}

	public void Move()
	{
		movePic.enabled = true;
		jumpPic.enabled = true;
		slidePic.enabled = true;
		attackPic.enabled = true;

	}

	public void Unshow()
	{
		movePic.enabled = false;
		jumpPic.enabled = false;
		slidePic.enabled = false;
		attackPic.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
