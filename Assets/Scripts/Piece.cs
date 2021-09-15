using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public List<Cell> cellList;
    public float speed;

    public Sudoku sudoku;
    Vector2Int currentIndex;
    
    public InfoDict gridData;

    Vector2 initialVec;

    int currentRotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentIndex.x = Mathf.RoundToInt(sudoku._bigSideX / 2f);
        currentIndex.y= 0;

        transform.position = sudoku._board[currentIndex.x, 0].transform.position + new Vector3(38,10,0);
        initialVec = transform.position;

        foreach (var c in cellList)
        {
            int n = Random.Range(1, 10);
            c.number = n;

            Vector2 aux = GetPosInGrid(c);
            c.transform.position = new Vector3(sudoku._board[(int)(currentIndex.x + aux.x), 0].transform.position.x, transform.position.y + aux.y * sudoku.spacing, 0);
        }
    }

    Vector2Int GetPosInGrid(Cell c)
    {
        return gridData.gridInfo[c.positionsInGrid[currentRotation]];
    }

    void Update()
    {
        foreach (var item in cellList)
        {
            if (item.locked) return;
        }
        if (CanMoveDown())
            MoveDown();

    }

    public void Move(float dir)
    {     
        foreach (var c in cellList)
        {
            float auxIndex = currentIndex.x + GetPosInGrid(c).x;
            //Debug.Log(gridData.gridInfo[c.positionsInGrid[currentRotation]].x);
            //Debug.Log("Pieza: "+ c+ " ---" + auxIndex);
            if ( auxIndex + dir < 0 || auxIndex + dir >= sudoku._bigSideX)
                return;
        }

        currentIndex.x += Mathf.RoundToInt(dir);
        foreach (var c in cellList)
        {
            c.transform.position = new Vector3(sudoku._board[(int)(currentIndex.x + GetPosInGrid(c).x), 0].transform.position.x, c.transform.position.y, 0);
        }
        //transform.position = new Vector3(sudoku._board[currentIndex.x, 0].transform.position.x + 38, transform.position.y, transform.position.z);
    }

    public void MoveDown()
    {
        transform.position += speed * Vector3.down;



    }

    public void Rotate()
    {
        int a = currentRotation + 1;
        if (a >= 4) a = 0;

        foreach (var c in cellList)
        {
            Vector2 aux = gridData.gridInfo[c.positionsInGrid[a]];
            //Si alguna de las celdas pasa los limites
            if (currentIndex.x + aux.x >= sudoku._bigSideX)
            {
                Move(-1);
                break;
            }
            else if (currentIndex.x + aux.x < 0)
            {
                Move(1);
                break;
            }
        }

        currentRotation++;
        if (currentRotation >= 4) currentRotation = 0;
        foreach (var c in cellList)
        {
            Vector2 aux = GetPosInGrid(c);
            c.transform.position = new Vector3(sudoku._board[(int)(currentIndex.x + aux.x), 0].transform.position.x, transform.position.y + aux.y * sudoku.spacing, 0);
        }
    }


    public bool CanMoveDown()
    {
        foreach (var c in cellList)
        {
            Debug.Log(currentIndex + "---" + GetPosInGrid(c));
            if(currentIndex.y - GetPosInGrid(c).y + 1 >= sudoku._board.Height)
            {
                Debug.Log("ABAJO");

                foreach (var ce in cellList)
                {
                    sudoku.TranslateCurrentPiece(currentIndex.x + GetPosInGrid(ce).x, currentIndex.y - GetPosInGrid(ce).y, ce);
                }
                EventManager.instance.TriggerEvent(EventNames.OnFichaArrived);

                Destroy(gameObject);
                return false;
            }
            else if( sudoku._board[currentIndex.x + GetPosInGrid(c).x, currentIndex.y - GetPosInGrid(c).y + 1].locked)
            {
                Debug.Log("LOCKED");

                foreach (var ce in cellList)
                {
                    sudoku.TranslateCurrentPiece(currentIndex.x + GetPosInGrid(ce).x, currentIndex.y - GetPosInGrid(ce).y, ce);
                }
                EventManager.instance.TriggerEvent(EventNames.OnFichaArrived);

                Destroy(gameObject);
                return false;
            }
        }


        if(currentIndex.y + 1 >= sudoku._board.Height)
        {
            Debug.Log("FALLA");
        }
        else if (transform.position.y <= sudoku._board[currentIndex.x, currentIndex.y + 1].transform.position.y)
        {
            currentIndex.y++;
            initialVec = sudoku._board[currentIndex.x, currentIndex.y].transform.position;
        }

        return true;
    }

   
}
