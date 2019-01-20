using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBlue : MonoBehaviour
{
    private Transform tr;
    private Animator animator;
    public float speed;
    public KeyCode keyCode;

    private bool swapped;
    private bool isAttacking;
    private bool canAttack;
    private bool attackFailed;
    public GameObject enemi;
    public InterfaceScript interf;

    public enum Color { blue, red};
    public Color color;


    // Start is called before the first frame update
    void Start()
    {
        JouteManager.instance.PrintNow(true);
        tr = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        JouteManager.instance.PrintNow(false);
        canAttack = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float posx = tr.position.x + (speed * Time.deltaTime);
        float posy = tr.position.y;
        tr.position = new Vector2(posx , posy);
        if (Input.GetKeyDown(keyCode) && interf.Started())
        {
            if(canAttack && ! attackFailed)
            {
                StartCoroutine("Win");
            }
            else
            {
                StartCoroutine("FailAttack");
            }
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
        print("" + color);
        animator.SetBool("SpearDeployed", true);
        yield return new WaitForSeconds(0.6f);
        animator.SetBool("SpearDeployed", false);
    }

    IEnumerator FailAttack()
    {
        StartCoroutine("DeploySpear");
        attackFailed = true;
        yield return new WaitForSeconds(3.0f);
        attackFailed = false;
    }

    IEnumerator Win()
    {
        StartCoroutine("DeploySpear");
        GetComponent<AudioSource>().Play();     
        Destroy(enemi.gameObject);
        GetComponent<Collider2D>().isTrigger = false;
        yield return new WaitForSeconds(3.0f);
        if (color == Color.blue)
        {
            GlobalController.instance.IncRoundScoreBlue();
        }
        else
        {
            GlobalController.instance.IncRoundScoreRed();
        }
    }
    private void Flip()
    {
        tr.transform.localScale = new Vector2(-tr.transform.localScale.x, tr.transform.localScale.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canAttack = true;
        if (interf.Started())
        {
            JouteManager.instance.PrintNow(true);

         }
}

    private void OnTriggerExit2D(Collider2D collision)
    {
        canAttack = false;
        JouteManager.instance.PrintNow(false);
    }

}
