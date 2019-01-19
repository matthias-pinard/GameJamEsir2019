using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze_generator : MonoBehaviour
{

    [System.Serializable]
    public class Cell {
        public bool visited;
        public GameObject northWall;
        public GameObject eastWall;
        public GameObject southWall;
        public GameObject westWall;
    }

    public GameObject wall;
    public GameObject floor;

    public Cell[,] maze_grid;
    private GameObject allWalls;
    private GameObject allFloorTiles;

    public int m_width;
    public int m_height;
    private int oldHeight;
    private int oldWidth;

    public int Get_height() {
        return m_height;
    }
    public void Set_height(int value) {
        m_height = value;
    }
    public int Get_width() {
        return m_width;
    }
    public void Set_width(int value) {
        m_width = value;
    }


    public void Generate() {

        Create_matrix();

        oldHeight = m_height;
        oldWidth = m_width;

        int computedCells = 0;
        int nbCells = m_height * m_width;

        Stack<int[]> cellStack = new Stack<int[]>();

        int current_i = Random.Range(0, m_height);
        int current_j = Random.Range(0, m_width);
        maze_grid[current_i, current_j].visited = true;
        computedCells++;
        
        while (computedCells < nbCells) {
            int[] chosenNeighbour = ComputeNeighbours(current_i, current_j);
            if (chosenNeighbour[0] != -1) {
              
                maze_grid[chosenNeighbour[0], chosenNeighbour[1]].visited = true;
                computedCells++;

                cellStack.Push(new int[] { current_i, current_j });

                current_i = chosenNeighbour[0];
                current_j = chosenNeighbour[1];
            }
            else if (cellStack.Count > 0) {
                int[] newCell = cellStack.Pop();
                current_i = newCell[0];
                current_j = newCell[1];
            }
        }

    }

    void Create_matrix() {

        //Stores the walls
        allWalls = new GameObject {
            name = "Maze"
        };
        allFloorTiles = new GameObject {
            name = "Floor"
        };

        //m_height : nb of lines, m_width : nb of columns
        maze_grid = new Cell[m_height, m_width];

        for (int i = 0; i < m_height; i++) {
            for (int j = 0; j < m_width; j++) {

                maze_grid[i, j] = new Cell() {
                    visited = false
                };

                Vector3 eastPosition = new Vector3(j + 0.5f, i, 0.0f);
                maze_grid[i, j].eastWall = Instantiate(wall, eastPosition, Quaternion.identity) as GameObject;
                maze_grid[i, j].eastWall.transform.parent = allWalls.transform;
                
                Vector3 northPosition = new Vector3(j, i + 0.5f, 0.0f);
                maze_grid[i, j].northWall = Instantiate(wall, northPosition, Quaternion.Euler(0.0f, 0.0f, 90.0f)) as GameObject;
                maze_grid[i, j].northWall.transform.parent = allWalls.transform;

                if (j == 0) {
                    Vector3 westPosition = new Vector3(-0.5f, i, 0.0f);
                    maze_grid[i, j].westWall = Instantiate(wall, westPosition, Quaternion.identity) as GameObject;
                    maze_grid[i, j].westWall.transform.parent = allWalls.transform;
                }
                else {
                    maze_grid[i, j].westWall = maze_grid[i, j - 1].eastWall;
                }

                if (i == 0) {
                    Vector3 southPosition = new Vector3(j, -0.5f, 0.0f);
                    maze_grid[i, j].southWall = Instantiate(wall, southPosition, Quaternion.Euler(0.0f, 0.0f, 90.0f)) as GameObject;
                    maze_grid[i, j].southWall.transform.parent = allWalls.transform;
                }
                else {
                    maze_grid[i, j].southWall = maze_grid[i - 1, j].northWall;
                }

                
                Vector3 floorPos = new Vector3(j, i, 0.5f);
                GameObject tempFloor = Instantiate(floor, floorPos, Quaternion.identity) as GameObject;
                tempFloor.transform.parent = allFloorTiles.transform;
               
            }
        }
    }

    int[] ComputeNeighbours(int i, int j) {

        List<string> neighbours = new List<string>();

        if (i < m_height - 1 && !maze_grid[i + 1, j].visited) {
            neighbours.Add("North");
        }

        if (j < m_width - 1 && !maze_grid[i, j + 1].visited) {
            neighbours.Add("East");
        }

        if (i > 0 && !maze_grid[i - 1, j].visited) {
            neighbours.Add("South");
        }

        if (j > 0 && !maze_grid[i, j - 1].visited) {
            neighbours.Add("West");
        }

        int nbNeighbours = neighbours.Count;
        if (nbNeighbours > 0) {
            int rand = Random.Range(0, nbNeighbours);
            switch (neighbours[rand]) {
                case "North": {
                    Destroy(maze_grid[i, j].northWall);
                    return new int[] { i + 1, j };
                }
                case "East": {
                    Destroy(maze_grid[i, j].eastWall);
                    return new int[] { i, j + 1 };
                }
                case "South": {
                    Destroy(maze_grid[i, j].southWall);
                    return new int[] { i - 1, j };
                }
                case "West": {
                    Destroy(maze_grid[i, j].westWall);
                    return new int[] { i, j - 1 };
                }
            }
        }
        return new int[] { -1 };
    }

    public void DeleteAllWalls() {
        for (int i = 0; i < oldHeight; i++) {
            for (int j = 0; j < oldWidth; j++) {
                Destroy(maze_grid[i, j].northWall);
                Destroy(maze_grid[i, j].eastWall);
                Destroy(maze_grid[i, j].southWall);
                Destroy(maze_grid[i, j].westWall);

            }
        }
        Destroy(allFloorTiles);
        Destroy(allWalls);
    }

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
