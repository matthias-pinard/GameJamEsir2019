using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Controller : MonoBehaviour
{
    public static Controller instance = null;
 
    private int globalScoreBlue = 0;
    private int globalScoreRed = 0;

    private int roundScoreBlue = 0;
    private int roundScoreRed = 0;

    private int numLevel = 0;


    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }


    private void CheckState()
    {
        if(roundScoreBlue == 3)
        {
            globalScoreBlue++;
            numLevel++;
        }

        if (roundScoreRed == 3)
        {
            globalScoreRed++;
            numLevel++;
        }

        if(globalScoreBlue == 3 || globalScoreRed == 3)
        {
            ChangeLevel();
        }
    }

    public void IncRoundScoreBlue()
    {
        roundScoreBlue++;
        CheckState();
    }

    public void IncRoundScoreRed()
    {
        roundScoreRed++;
        CheckState();
    }

    private void ChangeLevel()
    {
        switch(numLevel) 
        {
            case 1:
                SceneManager.LoadScene("Joute", LoadSceneMode.Single);
                break;
            case 2:
                SceneManager.LoadScene("Rope", LoadSceneMode.Single);
                break;
            case 3:
                SceneManager.LoadScene("Maze", LoadSceneMode.Single);
                break;
            case 4:
                SceneManager.LoadScene("Victory", LoadSceneMode.Single);
                break;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
