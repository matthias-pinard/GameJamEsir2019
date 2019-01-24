using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartScript : MonoBehaviour
{
    public GameObject textspace;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time % 2 < 1)
        {
            textspace.SetActive(true);
        }
        else
        {
            textspace.SetActive(false);
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
            GlobalController.instance.RestartGame();
        }

    }
}
