using UnityEngine;
using System.Collections;

public class movingBird : MonoBehaviour {

    public float horizontalSpeed;
    public float verticalSpeed;
    public float amplitude;

    public Vector3 tempPositon;

	// Use this for initialization
	void Start () {

        tempPositon = transform.position;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        tempPositon.x += horizontalSpeed;
        tempPositon.y = Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude;
        transform.position = tempPositon;

	}
}
