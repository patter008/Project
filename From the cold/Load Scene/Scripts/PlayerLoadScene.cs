using UnityEngine;
using System.Collections;

public class PlayerLoadScene : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        HandleMovement();
	}

    private void HandleMovement()
    {
        float translation = speed * Time.deltaTime;
        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * translation, 0, Input.GetAxis("Vertical") * translation));
    }

    public void OnTriggerEnter(Collider other)
    {
        switch (other.name)
        {
            case "Next":
                LevelHandler.Instance.LoadNextLevel();
                break;
            case "Reload":
                LevelHandler.Instance.ReloadLevel();
                break;
            case "Specific":
                LevelHandler.Instance.LoadSpecific(0);
                break;

        }
    }
}
