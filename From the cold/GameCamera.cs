﻿using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour
{
    
    private Transform target;
    private float trackSpeed = 10;
    public void SetTarget(Transform t)
    {
        target = t;
       transform.position = new Vector3(t.position.x, t.position.y, transform.position.z);
       // transform.position = new Vector3(0, 50, transform.position.z);
    }

    void LateUpdate()
    {
        if (target)
        {
            float x = IncrementTowards(transform.position.x, target.position.x, trackSpeed);
            float y = IncrementTowards(transform.position.y, target.position.y, trackSpeed);
            transform.position = new Vector3(x,y, transform.position.z);
            
           // transform.eulerAngles = new Vector2(20, 0);
        }
    }

    //Increse n towards target by speed
    private float IncrementTowards(float n, float target, float a)
    {
        if (n == target)
        {
            return n;
        }
        else
        {
            float dir = Mathf.Sign(target - n); // n must be increased or decreased to get closer to target
            n += a * Time.deltaTime * dir;
            return (dir == Mathf.Sign(target - n)) ? n : target; // if n has passed then return target ,otherwise return n
        }
    }
}
