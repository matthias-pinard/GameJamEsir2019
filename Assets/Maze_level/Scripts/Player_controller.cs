using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public GameObject player1_model;
    public GameObject player2_model;
    private GameObject player1;
    private GameObject player2;

    public Maze_generator maze;
    public int speed = 10;
    Rigidbody2D rb_player1;
    Rigidbody2D rb_player2;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 player1pos = new Vector3(0, -0.25f, 0);
        player1 = Instantiate(player1_model, player1pos, Quaternion.identity) as GameObject;

        int height = maze.Get_height();
        int width = maze.Get_width();
        Vector3 player2pos = new Vector3(-0.25f, 0, 0);
        player2 = Instantiate(player2_model, player2pos, Quaternion.identity) as GameObject;

        rb_player1 = player1.GetComponent<Rigidbody2D>();
        rb_player2 = player2.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal_p1 = Input.GetAxisRaw("Horizontal2");
        float vertical_p1 = Input.GetAxisRaw("Vertical2");
        Vector2 fVelocity_p1 = new Vector2(horizontal_p1, vertical_p1) * speed;
        rb_player1.velocity = fVelocity_p1;

        float horizontal_p2 = Input.GetAxisRaw("Horizontal");
        float vertical_p2 = Input.GetAxisRaw("Vertical");
        Vector2 fVelocity_p2 = new Vector2(horizontal_p2, vertical_p2) * speed;
        rb_player2.velocity = fVelocity_p2;

        //if(Input.GetKey(KeyCode.))
    }
}
