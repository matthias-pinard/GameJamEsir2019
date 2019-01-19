using UnityEngine;
using System.Collections;

public class ropeMove : MonoBehaviour {

    public float speed = 1f;
    public float ropeRate = 0.2f;
    public GameObject centerPoint;
    public GameObject secondRope;

    private float nextRope = 0.0f;
    private int countLeft = 0;
    private int countRight = 0;
    private SpriteRenderer ropeSprite;

    void Start()
    {
        ropeSprite = gameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
        
    }

    void Update()
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

        SpriteRenderer ropeSprite = centerPoint.GetComponent<SpriteRenderer>() as SpriteRenderer;
        float centerPointSize = ropeSprite.sprite.bounds.size.x;

        float ropeScale = transform.localScale.x;
        float ropeSize = ropeSprite.sprite.bounds.size.x * ropeScale;

        if (transform.position.x > ropeSize - centerPointSize/4)
        {
            Debug.Log("Right Win !");
            Destroy(secondRope.GetComponent<SpriteRenderer>());
            Destroy(secondRope);
            Destroy(this.GetComponent<SpriteRenderer>());
            Destroy(this);
        }
        else if(transform.position.x < -(ropeSize - centerPointSize / 4))
        {
            Debug.Log("Left Win !");
            Destroy(secondRope.GetComponent<SpriteRenderer>());
            Destroy(secondRope);
            Destroy(this.GetComponent<SpriteRenderer>());
            Destroy(this);
        }

    }
}