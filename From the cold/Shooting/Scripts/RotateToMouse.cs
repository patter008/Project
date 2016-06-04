using UnityEngine;
using System.Collections;

public class RotateToMouse : MonoBehaviour {

    public enum SpriteRotation
    {
        Up = -90,
        Right = 0,
        Down = 90,
        Left = 180
    }

    public Camera currentCamera;
    public SpriteRotation initialRotation;

    public Vector2 _direction;
    private Vector2 _mousePostion;
    private Transform _transform;

    private float _angle;

	// Use this for initialization
	void Start () {

        _transform = transform;

        if (!currentCamera)
        {
            currentCamera = Camera.main;
        }

	}
	
	// Update is called once per frame
	void Update () {

        _mousePostion = currentCamera.ScreenToWorldPoint(Input.mousePosition);
        _direction = (_mousePostion - (Vector2)_transform.position).normalized;

        _angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg + (int)initialRotation;
        _transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);

	}
}
