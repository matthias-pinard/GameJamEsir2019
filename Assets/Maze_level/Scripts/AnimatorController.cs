using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{

    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sprite;
    Quaternion lastRota;

    //public AudioClip stepSound;
    //private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        Quaternion lastRota = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        //source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate() {

        //Debug.Log("Velocity : " + rb.velocity);
        if (rb.velocity.x == 0 && rb.velocity.y == 0) {
            anim.SetBool("isWalking", false);
            sprite.transform.rotation = lastRota;
            //source.mute = true;
        }
        else {
            anim.SetBool("isWalking", true);
            float vol = Random.Range(0.5f, 1.0f);
            //source.mute = false;
            //if(!source.isPlaying) source.PlayOneShot(stepSound, vol);
            
            if (rb.velocity.x == 0 && rb.velocity.y > 0) {
                sprite.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                lastRota = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            }
            else if (rb.velocity.x > 0 && rb.velocity.y > 0) {
                sprite.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -45.0f);
                lastRota = Quaternion.Euler(0.0f, 0.0f, -45.0f);
            }
            else if (rb.velocity.x > 0 && rb.velocity.y == 0) {
                sprite.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);
                lastRota = Quaternion.Euler(0.0f, 0.0f, -90.0f);
            }
            else if (rb.velocity.x > 0 && rb.velocity.y < 0) {
                sprite.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -135.0f);
                lastRota = Quaternion.Euler(0.0f, 0.0f, -135.0f);
            }
            else if (rb.velocity.x == 0 && rb.velocity.y < 0) { 
                sprite.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
                lastRota = Quaternion.Euler(0.0f, 0.0f, 180.0f);
            }
            else if (rb.velocity.x < 0 && rb.velocity.y < 0) { 
            sprite.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 135.0f);
            lastRota = Quaternion.Euler(0.0f, 0.0f, 135.0f);
            }
            else if (rb.velocity.x < 0 && rb.velocity.y == 0) {
                sprite.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
                lastRota = Quaternion.Euler(0.0f, 0.0f, 90.0f);
            }
            else if (rb.velocity.x < 0 && rb.velocity.y > 0) {
                sprite.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 45.0f);
                lastRota = Quaternion.Euler(0.0f, 0.0f, 45.0f);
            }

        }
    }
}
