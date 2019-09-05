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
public float accel;
public float decel;
public float force;
public KeyCode up;
public KeyCode down;

public Vector2 velocity;

public Rigidbody2D rB;

public GameObject Spawn;
public float inputLag;
public bool input = true;
public float inputCounter = 0;
public int score;
public Text scoreText;
    
    void Start()
    {
        input = true;
    }

    
    void Update()
    {
        if (input)
        {
            if (Input.GetKey(up))
            {
                transform.Translate(velocity * Time.deltaTime);
            }

            if (Input.GetKey(down))
            {
                transform.Translate(-velocity * Time.deltaTime);
            }
        }
        else
        {
            print("input = false");
            inputCounter += 1;
            if (inputCounter > inputLag)
            {
                input = true;
                print("Input= true");
            }
        }


        scoreText.text = score.ToString();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "FinishLine")
        {
            score += 1;
        }
        print("Collison");
        input = false;
        inputCounter = 0;
        gameObject.transform.position = Spawn.gameObject.transform.position;
    }
}
