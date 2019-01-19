using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GlobalController : MonoBehaviour
{
    public static GlobalController instance = null;
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
        if (roundScoreBlue == 3)
        {
            globalScoreBlue++;
            numLevel++;
        }

        if (roundScoreRed == 3)
        {
            globalScoreRed++;
            numLevel++;
        }

        if (globalScoreBlue == 3 || globalScoreRed == 3)
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
        SceneManager.LoadScene(numLevel, LoadSceneMode.Single);
   
    }

    public void StartGame()
    {
        numLevel++;
        ChangeLevel();
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
