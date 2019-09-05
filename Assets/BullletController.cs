using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullletController : MonoBehaviour
{
    public Vector2 velocity;
    public int direction;
    public float warpPos;

    private Vector2 pos;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (direction < 0)
        {
            warpPos = -warpPos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        pos = gameObject.transform.position;
        transform.Translate(velocity * Time.deltaTime * direction);
        if (Math.Abs(pos.x - warpPos) < .05) 
        {
            pos.x = -warpPos;
            transform.position = pos;
        }
    }
}
