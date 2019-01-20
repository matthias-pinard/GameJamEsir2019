using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Camera_position : MonoBehaviour {

    public Maze_generator mazeGenerator;
    public GameObject Wall;
    public Camera myCam;

    /*
     * Centers the camera above the maze, so that all the maze is visible, but not too much empty space
    */
    public void AdjustPosition() {
        myCam = this.GetComponent<Camera>();
        float wallWidth = Wall.transform.lossyScale.x;
        //We need the total width and height of the maze, including the walls width, assuming wall length is 1
        float totalMazeHeight = mazeGenerator.Get_height() + wallWidth;
        float totalMazeWidth = mazeGenerator.Get_width() + wallWidth;

        //If the FOV of the camera is 60° and is centered on the maze, it forms an equilateral triangle with the base beeing the maze
        //We can use the Pythagorean theorem to get the height of the camera
        float maxSize = Math.Max(totalMazeHeight, totalMazeWidth);
        float cameraHeight = (float)Math.Sqrt(Math.Pow(maxSize, 2.0f) - Math.Pow(maxSize / 2.0f, 2.0f));

        //We leave some space for the UI by sliding the camera to the right on the x axis
        myCam.transform.position = new Vector3(mazeGenerator.Get_width() / 2.0f - 0.5f, mazeGenerator.Get_height() / 2.0f - 0.5f, -1.0f);
        myCam.orthographicSize = cameraHeight/2.0f;

        //We need to adjust the FOV if the width is bigger than the height, because the screen ratio is 16:9, and the horizontal FOV isn't 60°
        if (totalMazeHeight <= totalMazeWidth ) {
            myCam.fieldOfView = Math.Max(50.0f, ((totalMazeHeight )/totalMazeWidth) * 60.0f);
        }
        else {
            myCam.fieldOfView = 60.0f;
        }
    }

	// Use this for initialization
	void Start () {
        AdjustPosition();
    }
	
	// Update is called once per frame
	void Update () {

	}
}
