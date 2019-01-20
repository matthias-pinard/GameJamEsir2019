using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceScript : MonoBehaviour
{
    public GameObject cpt3;
    public GameObject cpt2;
    public GameObject cpt1;
    public GameObject cptGo;

    public GameObject scoreBlue2;
    public GameObject scoreBlue1;
    public GameObject scoreBlue0;

    public GameObject scoreRed2;
    public GameObject scoreRed1;
    public GameObject scoreRed0;

    public GameObject scoreTiret;



    private bool started = false;
    private float timeleft = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        cpt2.SetActive(false);
        cpt1.SetActive(false);
        cptGo.SetActive(false);

        int roundScoreBlue = GlobalController.instance.GetRoundScoreBlue();
        int roundScoreRed = GlobalController.instance.GetRoundScoreRed();

        //Affiche score round blue
        if (roundScoreBlue == 0)
        {
            scoreBlue0.SetActive(true);
            scoreBlue1.SetActive(false);
            scoreBlue2.SetActive(false);
        }
        else if(roundScoreBlue == 1)
        {
            scoreBlue0.SetActive(false);
            scoreBlue1.SetActive(true);
            scoreBlue2.SetActive(false);
        }
        else if(roundScoreBlue == 2)
        {
            scoreBlue0.SetActive(false);
            scoreBlue1.SetActive(false);
            scoreBlue2.SetActive(true);
        }

        //Affiche score round red
        if (roundScoreRed == 0)
        {
            scoreRed0.SetActive(true);
            scoreRed1.SetActive(false);
            scoreRed2.SetActive(false);
        }
        else if (roundScoreRed== 1)
        {
            scoreRed0.SetActive(false);
            scoreRed1.SetActive(true);
            scoreRed2.SetActive(false);
        }
        else if (roundScoreRed == 2)
        {
            scoreRed0.SetActive(false);
            scoreRed1.SetActive(false);
            scoreRed2.SetActive(true);
        }
     

        
    }

    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;
        if(timeleft < 1)
        {
            cpt1.SetActive(false);
            cptGo.SetActive(true);
            started = true;
        }
        else if(timeleft < 2)
        {
            cpt2.SetActive(false);
            cpt1.SetActive(true);
        }
        else if (timeleft < 3)
        {
            cpt3.SetActive(false);
            cpt2.SetActive(true);
        }

    }

    public bool Started()
    {
        return started;
    }
}
