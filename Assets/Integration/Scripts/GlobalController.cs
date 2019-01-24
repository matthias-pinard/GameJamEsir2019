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

    public int GetRoundScoreBlue()
    {
        return roundScoreBlue;
    }

    public int GetRoundScoreRed()
    {
        return roundScoreRed;
    }

    public int GetGlobalScoreBlue()
    {
        return globalScoreBlue;
    }

    public int GetGlobalScoreRed()
    {
        return globalScoreRed;
    }

    public int GetNumLevel()
    {
        return numLevel;
    }

    private void CheckState()
    {
        Debug.Log(roundScoreBlue);
        Debug.Log(roundScoreRed);
        if (roundScoreBlue == 3)
        {
            globalScoreBlue++;
            numLevel++;
            roundScoreBlue = 0;
            roundScoreRed = 0;

            GoTransition();
            return;
        }

        if (roundScoreRed == 3)
        {
            globalScoreRed++;
            numLevel++;
            roundScoreRed = 0;
            roundScoreBlue = 0;
            GoTransition();
            return;
        }

        ChangeLevel();

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

    public void ChangeLevel()
    {
        SceneManager.LoadScene(numLevel, LoadSceneMode.Single);
   
    }

    private void GoTransition()
    {
        SceneManager.LoadScene(5, LoadSceneMode.Single);
    }

    public void StartGame()
    {
        globalScoreBlue = 0;
        globalScoreRed = 0;
        roundScoreBlue = 0;
        roundScoreRed = 0;

        numLevel = 1;
        ChangeLevel();
    }

    public void RestartGame()
    {
        globalScoreBlue = 0;
        globalScoreRed = 0;
        roundScoreBlue = 0;
        roundScoreRed = 0;

        numLevel = 0;
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
