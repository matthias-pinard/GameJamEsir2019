using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JouteManager : MonoBehaviour
{
    public static JouteManager instance = null;

    enum Color  {blue, red};
    public SpriteRenderer now;
    public SpriteRenderer wait;

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

    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PrintNow(bool b)
    {
        now.enabled = b;
        wait.enabled = !b;
    }
    //public void Win(PlayerController winner, PlayerController loser)
    //{
    //    Destroy(loser.GetComponent<SpriteRenderer>());
    //    Destroy(loser);
    //}
}
