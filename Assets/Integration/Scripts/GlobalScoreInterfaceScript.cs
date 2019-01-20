using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalScoreInterfaceScript : MonoBehaviour
{
    public GameObject coupeB;
    public GameObject coupe2B;
    public GameObject coupe3B;
    public GameObject coupeR;
    public GameObject coupe2R;
    public GameObject coupe3R;



    private float timeleft = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        int globalScoreBlue = GlobalController.instance.GetGlobalScoreBlue();
        int globalScoreRed = GlobalController.instance.GetGlobalScoreRed();

        //Affiche score round blue
        if (globalScoreBlue == 0)
        {
            coupeB.SetActive(false);
            coupe2B.SetActive(false);
            coupe3B.SetActive(false);
        }
        if (globalScoreBlue == 1)
        {
            coupeB.SetActive(true);
            coupe2B.SetActive(false);
            coupe3B.SetActive(false);
        }
        else if (globalScoreBlue == 2)
        {
            coupeB.SetActive(false);
            coupe2B.SetActive(true);
            coupe3B.SetActive(false);
        }
        else if (globalScoreBlue == 3)
        {
            coupeB.SetActive(false);
            coupe2B.SetActive(false);
            coupe3B.SetActive(true);
        }

        //Affiche score round red
        if (globalScoreRed == 0)
        {
            coupeR.SetActive(false);
            coupe2R.SetActive(false);
            coupe3R.SetActive(false);
        }
        if (globalScoreRed == 1)
        {
            coupeR.SetActive(true);
            coupe2R.SetActive(false);
            coupe3R.SetActive(false);
        }
        else if (globalScoreRed == 2)
        {
            coupeR.SetActive(false);
            coupe2R.SetActive(true);
            coupe3R.SetActive(false);
        }
        else if (globalScoreRed == 3)
        {
            coupeR.SetActive(false);
            coupe2R.SetActive(false);
            coupe3R.SetActive(true);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;

        if(timeleft < 1)
        {
            GlobalController.instance.ChangeLevel();
        }
    }
}
