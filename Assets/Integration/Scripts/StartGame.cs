using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject textspace;
    public GameObject texttitle;
    public float limitSize = 7.0f;

    // Start is called before the first frame update
    void Start()
    {

        texttitle.transform.localScale = new Vector3(0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        int time = (int)Time.time;

        if (texttitle.transform.localScale.x < limitSize)
        {
            texttitle.transform.localScale += new Vector3(0.1f, 0.1f, 0);
        }


        if (time % 2 < 1)
        {
            textspace.SetActive(true);
        }
        else
        {
            textspace.SetActive(false);
        }

        

        if(Input.GetKey(KeyCode.Space))
        {
            GlobalController.instance.StartGame();
        }
    }
}
