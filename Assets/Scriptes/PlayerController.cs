using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movementHorizontal = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector2(movementHorizontal, 0);
        if(Input.GetKey(KeyCode.S))
        {
            StartCoroutine(DeploySpear());
        }
    }

    IEnumerator DeploySpear()
    {
        animator.SetBool("SpearDeployed", true);
        yield return new WaitForSeconds(1);
        animator.SetBool("SpearDeployed", false);   
    }
}
