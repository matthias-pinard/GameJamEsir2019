using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public float speed;
    public float spearRange;
    public LayerMask layerMask;
    public KeyCode keyCode;

    private bool swapped;
    private bool isAttacking;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.velocity = new Vector2(speed, 0);
        Physics2D.IgnoreLayerCollision(8, 8);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float posx = rb.position.x + (speed * Time.deltaTime);
        float posy = rb.position.y;
        rb.position = new Vector2(posx , posy);
        if (Input.GetKey(keyCode))
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
        if(animator.GetBool("SpearDeployed"))
        {
            Attack();
        }
    }

    IEnumerator DeploySpear()
    {
        animator.SetBool("SpearDeployed", true);
        yield return new WaitForSeconds(1);
        animator.SetBool("SpearDeployed", false);   
    }

    private void Attack()
    {
        Vector2 direction = new Vector2(speed, 0).normalized;
        Vector2 position = new Vector2(rb.position.x + (GetComponent<CapsuleCollider2D>().size.x / 2 + 1) * direction.x, rb.position.y);
        RaycastHit2D hit = Physics2D.Raycast(position, direction, spearRange, layerMask);
        if(hit.collider != null)
        {
            JouteManager.instance.Win(this, hit.collider.GetComponent<PlayerController>());
            print("hit!");
        }
    }
}
