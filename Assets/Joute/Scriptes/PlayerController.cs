using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public float speed;
    private bool swapped;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, 0);
        if (Input.GetKey(KeyCode.S))
        {
            StartCoroutine(DeploySpear());
        }
        if(!swapped && !GetComponent<Renderer>().isVisible)
        {
            speed = -speed;
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
            swapped = true;
        }
        if(swapped && GetComponent<Renderer>().isVisible)
        {
            swapped = false;
        }
        print(rb.velocity.x);
    }

    IEnumerator DeploySpear()
    {
        animator.SetBool("SpearDeployed", true);
        GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(1);
        GetComponent<BoxCollider2D>().enabled = false;
        animator.SetBool("SpearDeployed", false);   
    }
}
