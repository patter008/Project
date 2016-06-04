using UnityEngine;
using System.Collections;

public class ScreenWarp : MonoBehaviour {

    private void OnBecameInvisible()
    {
        CheckWarp();
    }

    private void CheckWarp()
    {
        Vector3 viewPortPosition = Camera.main.WorldToViewportPoint(transform.position);

        if (viewPortPosition.x > 1 || viewPortPosition.x < 0)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y);

        }
        if (viewPortPosition.y > 1 || viewPortPosition.y < 0)
        {
            transform.position = new Vector3(transform.position.x, -transform.position.y);
        }

    }
}
