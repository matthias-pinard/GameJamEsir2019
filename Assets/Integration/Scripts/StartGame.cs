using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject textspace;
    
    // Start is called before the first frame update
    void Start()
    {

        
        
    }

    // Update is called once per frame
    void Update()
    {
        if((int)Time.time % 2 < 1)
        {
            textspace.SetActive(true);
        }
        else
        {
            textspace.SetActive(true);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            GlobalController.instance.StartGame();
        }
    }
}
