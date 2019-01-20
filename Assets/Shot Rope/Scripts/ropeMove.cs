using UnityEngine;
using System.Collections;

public class ropeMove : MonoBehaviour {

    public float speed = 1f;
    public float ropeRate = 0.2f;
    public GameObject centerPoint;
    public GameObject secondRope;

    public InterfaceScript scoreInterface;

    private float nextRope = 0.0f;
    private int countLeft = 0;
    private int countRight = 0;
    private BoxCollider2D ropeCollider;
    private BoxCollider2D centerpointCollider;

    void Start()
    {
        ropeCollider = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;
        centerpointCollider = centerPoint.GetComponent<BoxCollider2D>() as BoxCollider2D;
    }

    void Update()
    {
        if(scoreInterface.Started())
        {
            Vector3 dp = new Vector3();

            if (Input.GetKeyDown(KeyCode.Q))
            {
                countLeft++;
            }

            if (Input.GetKeyDown(KeyCode.M))
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

            float centerPointSize = centerpointCollider.size.x;

            float ropeScale = transform.localScale.x;
            float ropeSize = ropeCollider.size.x;

            if (transform.position.x > (centerPointSize + ropeSize) / 2)
            {
                GlobalController.instance.IncRoundScoreRed();
                //Debug.Log("Right Win !");
                //Destroy(secondRope.GetComponent<SpriteRenderer>());
                //Destroy(secondRope);
                //Destroy(this.GetComponent<SpriteRenderer>());
                //Destroy(this);
            }
            else if (transform.position.x < -(centerPointSize + ropeSize) / 2)
            {
                GlobalController.instance.IncRoundScoreBlue();
                //Debug.Log("Left Win !");
                //Destroy(secondRope.GetComponent<SpriteRenderer>());
                //Destroy(secondRope);
                //Destroy(this.GetComponent<SpriteRenderer>());
                //Destroy(this);
            }
        }
 

    }
}