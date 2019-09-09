using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTrail : MonoBehaviour
{
    private PlayerController pC;

    public float speed1;
    public float speed2;
    public float speed3;

    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    // Start is called before the first frame update
    void Start()
    {
        pC = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pC.speed > speed3)
        {
            s1.SetActive(true);
            s2.SetActive(true);
            s3.SetActive(true);
        }else if (pC.speed > speed2)
        {
            s1.SetActive(true);
            s2.SetActive(true);
            
            s3.SetActive(false);
        }else if (pC.speed > speed1)
        {
            s1.SetActive(true);
            
            s2.SetActive(false);
            s3.SetActive(false);
        }else if (pC. speed < .001)
        {
            s1.SetActive(false);
            s2.SetActive(false);
            s3.SetActive(false);
        }
    }
}
