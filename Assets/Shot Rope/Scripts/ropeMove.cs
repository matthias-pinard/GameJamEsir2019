using UnityEngine;
using System.Collections;

public class ropeMove : MonoBehaviour {

    public float speed = 0.18f;
    public float ropeRate = 1.0f;
    private float nextRope = 0.0f;
    private int countLeft = 0;
    private int countRight = 0;

    void Start()
    {

    }

    void Update()
    {

        Vector3 dp = new Vector3();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            countLeft++;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            countRight++;
        }

        if (Time.time > nextRope)
        {
            nextRope = Time.time + ropeRate;
            if (countLeft > countRight)
            {
                dp.x -= speed;
            }
            else if (countLeft < countRight)
            {
                dp.x += speed;
            }

            transform.position += dp;

            countLeft = 0;
            countRight = 0;
        }

    }
}