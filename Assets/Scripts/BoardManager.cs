using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

    public int width = 16;
    public int height = 16;

    public GameObject tile;

    public Vector3[] grid = new Vector3[400];


	// Use this for initialization
	void Start () {
        makeBoard();
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void makeBoard()
    {
        for (int i = 0; i < width; i ++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector3 position = new Vector3(i * 0.2f, j*0.2f, 0);
                grid[i * 20 + j] = position;
                GameObject toPlace = Instantiate(tile, position, Quaternion.identity);
            }
        }
    }
}
