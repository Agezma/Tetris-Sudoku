using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public List<Cell> cellList;
    public float speed;

    public Sudoku sudoku;
    int currentIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentIndex = Mathf.RoundToInt(sudoku._bigSideX / 2f);

        transform.position = sudoku._board[currentIndex, 0].transform.position;

        foreach (var c in cellList)
        {
            int n = Random.Range(0, 9);
            c.number = n;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Vector3.down;

        Debug.Log(currentIndex);
    }

    public void Move(float dir)
    {
        if (currentIndex + dir < 0 || currentIndex + dir >= sudoku._bigSideX)
            return;
        
        currentIndex += Mathf.RoundToInt(dir);
        transform.position = new Vector3(sudoku._board[currentIndex, 0].transform.position.x, transform.position.y, transform.position.z);


    }
}
