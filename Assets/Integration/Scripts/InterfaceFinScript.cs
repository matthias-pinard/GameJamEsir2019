using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceFinScript : MonoBehaviour
{
    

    public GameObject joueurBleu;
    public GameObject joueurRed;

    public GameObject textBleu;
    public GameObject textRed;

    // Start is called before the first frame update
    void Start()
    {
        int globalScoreBlue = GlobalController.instance.GetGlobalScoreBlue();
        int globalScoreRed = GlobalController.instance.GetGlobalScoreRed();
        Debug.Log(globalScoreBlue);
        Debug.Log(globalScoreRed);
        if (globalScoreBlue > globalScoreRed)
        {
            joueurBleu.SetActive(true);
            joueurRed.SetActive(false);

            textBleu.SetActive(true);
            textRed.SetActive(false);
        }
        else
        {
            joueurBleu.SetActive(false);
            joueurRed.SetActive(true);

            textBleu.SetActive(false);
            textRed.SetActive(true);
        }

}
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
