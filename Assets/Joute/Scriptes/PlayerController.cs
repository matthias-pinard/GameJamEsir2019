using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public float speed;
    public LayerMask layerMask;
    public KeyCode keyCode;

    private bool swapped;
    private bool isAttacking;

    public enum Color { blue, red};
    public Color color;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
            Flip();
            swapped = true;
        }
        if(swapped && GetComponent<Renderer>().isVisible)
        {
            swapped = false;
        }
    }

    IEnumerator DeploySpear()
    {
        animator.SetBool("SpearDeployed", true);
        
        yield return new WaitForSeconds(0.4f);
        Attack();
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("SpearDeployed", false);
    }

    private void Attack()
    {
        Vector2 direction = new Vector2(speed, 0).normalized;
        print(direction);
        float capsuleSize = GetComponent<CapsuleCollider2D>().size.x;

        float posX = rb.position.x + (capsuleSize / 2 + 0.3f) * direction.x;
        Vector2 position = new Vector2(posX, rb.position.y);
        RaycastHit2D hit = Physics2D.Raycast(position, direction, 0, layerMask);
        if (hit.collider != null)
        {
            if (color == Color.blue)
            {
                GlobalController.instance.IncRoundScoreBlue();
            }
            else if (color == Color.red)
            {
                GlobalController.instance.IncRoundScoreRed();
            }
        }
    }

    private void Flip()
    {
        rb.transform.localScale = new Vector2(-rb.transform.localScale.x, rb.transform.localScale.y);
    }

}
