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

private PeopleManager pM;
    
    void Start()
    {
        pM = GetComponent<PeopleManager>();
        input = true;
        speed = 0;
        velocity = new Vector2(0,0);

    }

    
    void Update()
    {   
        if (input)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            if (Input.GetKey(up))
            {
                speed += accel;
                pM.loading = false;
            }

            if (Input.GetKey(down))
            {
                speed -= decel;
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.red;
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


        
        velocity = new Vector2(0,speed); //turn speed into vector 2
        transform.Translate( velocity * Time.deltaTime); //update pos

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "FinishLine")
        {
            pM.UpdateScore(true);
        }
        else
        {
            pM.UpdateScore(false);
        }

        input = false; //input lag
        inputCounter = 0;
        speed = 0; //reset speed
        gameObject.transform.position = spawn.gameObject.transform.position; //rest pos

    }

    IEnumerator SpawnDelay() //not working
    {
        input = false;
        inputCounter = 0;
        yield return new WaitForSeconds(delay);
        gameObject.transform.position = spawn.gameObject.transform.position;
    }
}
