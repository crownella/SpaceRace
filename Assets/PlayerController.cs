using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    public float delay;
public float accel;
public float decel;
public float force;
public float startingSpeed;
public float maxSpeed;
public KeyCode up;
public KeyCode down;

private Vector2 velocity;
public float speed;

private Vector2 baseVelocity;

public Rigidbody2D rB;

public GameObject spawn;
public float inputLag;
public bool input = true;
public float inputCounter = 0;
public int score;
public Text scoreText;
    
    void Start()
    {
        input = true;
        speed = 0;
        velocity = new Vector2(0,0);

    }

    
    void Update()
    {   
        if (input)
        {
            if (Input.GetKey(up))
            {
                speed += accel;
            }

            if (Input.GetKey(down))
            {
                speed -= decel;
            }
        }
        else
        {
            inputCounter += 1;
            if (inputCounter > inputLag)
            {
                input = true;
            }
        }
        //print("Speed b4 force: " + speed);

        if (speed < force )
        {
            speed = 0;
        }
        else 
        {
            if (speed > 0)
            {
                speed -= force;
                if (speed > maxSpeed)
                {
                    speed = maxSpeed;
                }
            }
        }
        //print("Speed after force: " + speed);


        scoreText.text = score.ToString();
        velocity = new Vector2(0,speed);
        transform.Translate( velocity * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "FinishLine")
        {
            score += 1;
        }

        input = false;
        inputCounter = 0;
        speed = 0;
        gameObject.transform.position = spawn.gameObject.transform.position;
    }

    IEnumerator SpawnDelay()
    {
        input = false;
        inputCounter = 0;
        yield return new WaitForSeconds(delay);
        gameObject.transform.position = spawn.gameObject.transform.position;
    }
}
