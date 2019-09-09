using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float timer;
    public float timerD;
    public float timerMax;
    public Slider slider;

    public Text endtxt;


    // Start is called before the first frame update
    void Start()
    {
        timer = timerMax;
        slider.maxValue = timerMax;
        slider.value = timer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= timerD * Time.deltaTime;
        slider.value = timer;

        if (timer <= 0)
        {
            Time.timeScale = 0;
            endtxt.text = "The End";
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("SpaceRaceScene");
        }
    }
}
