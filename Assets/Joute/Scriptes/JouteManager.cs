using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JouteManager : MonoBehaviour
{
    public static JouteManager instance = null;
    public GameObject player1;
    public GameObject player2;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Win(PlayerController winner, PlayerController loser)
    {
        Destroy(loser);
    }
}
