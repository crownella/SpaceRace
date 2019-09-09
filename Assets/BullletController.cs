using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class BullletController : MonoBehaviour
{
    public Vector2 velocity;
    public int direction;
    public float warpPos;

    private Vector2 pos;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        float randomChance = Random.Range(0, 2);
        if (randomChance > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        }
        if (direction < 0)
        {
            warpPos = -warpPos;
        }

        StartCoroutine(Flash());
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

    IEnumerator Flash()
    {
        if (gameObject.GetComponent<SpriteRenderer>().color == Color.white)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.black;
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(Flash());
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(Flash());
        }
        
    }
}
