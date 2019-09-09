using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class PeopleManager : MonoBehaviour
{
    private PlayerController pC;

    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public GameObject p5;
    public GameObject p6;

    public bool loading;
    public Text loadingTxt;

    public int loadingInt;
    public Text loadingIntText;
    
    public int score;
    public Text scoreText;

    public KeyCode loadButton;
    public KeyCode unloadButton;
    // Start is called before the first frame update
    void Start()
    {
        loading = true;  //player loads at start of game
        loadingInt = 1;
        ShowPeople();
        pC = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString(); //show score
        
        loadingIntText.text = loadingInt.ToString(); //always show how many people in spaceship
        if (loading) //sets loading text on screen
        {
            loadingTxt.text = "Loading";
            
        }
        else
        {
            loadingTxt.text = "";
        }

        if (Input.GetKeyDown(loadButton) && loadingInt < 6 && loading)
        {
            loadingInt += 1;
        }

        if (Input.GetKeyDown(unloadButton) && loadingInt > 1 && loading)
        {
            loadingInt -= 1;
        }
        
        ShowPeople();
    }

    public void UpdateScore(Boolean success)
    {
        if (success)
        {
            score += loadingInt;
        }
        else
        {
            if (score < loadingInt)
            {
                score = 0;
            }
            else
            {
                score -= loadingInt;
            }
        }

        loadingInt = 1; //reset number of people in spaceship
        loading = true;
    }

    private void ShowPeople()
    {

        if (loadingInt > 5)
        {
            p1.SetActive(true);
            p2.SetActive(true);
            p3.SetActive(true);
            p4.SetActive(true);
            p5.SetActive(true);
            p6.SetActive(true);
        }else if (loadingInt > 4)
        {
            p1.SetActive(true);
            p2.SetActive(true);
            p3.SetActive(true);
            p4.SetActive(true);
            p5.SetActive(true);
            
            p6.SetActive(false);
        }else if (loadingInt > 3)
        {
            p1.SetActive(true);
            p2.SetActive(true);
            p3.SetActive(true);
            p4.SetActive(true);
            
            p5.SetActive(false);
            p6.SetActive(false);
        }else if (loadingInt > 2)
        {
            p1.SetActive(true);
            p2.SetActive(true);
            p3.SetActive(true);
            
            p4.SetActive(false);
            p5.SetActive(false);
            p6.SetActive(false);
        }else if (loadingInt > 1)
        {
            p1.SetActive(true);
            p2.SetActive(true);
            
            p3.SetActive(false);
            p4.SetActive(false);
            p5.SetActive(false);
            p6.SetActive(false);
        }else
        {
            p1.SetActive(true); 
            
            p2.SetActive(false);
            p3.SetActive(false);
            p4.SetActive(false);
            p5.SetActive(false);
            p6.SetActive(false);
        }
    }
    
    
}
