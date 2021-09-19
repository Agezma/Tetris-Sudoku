using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public List<Cell> cellList;
    public float speed;

    public Sudoku sudoku;
    public Vector2Int currentIndex;

    public InfoDict gridData;

    public Vector2 initialVec;

    int currentRotation = 0;
     bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    public Vector2Int GetPosInGrid(Cell c)
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

    public void TryMove(float dir)
    {
        foreach (var c in cellList)
        {
            float auxIndex = currentIndex.x + GetPosInGrid(c).x;

            if (auxIndex + dir < 0 || auxIndex + dir >= sudoku._bigSideX ||                        //Si me paso de los bordes 
                sudoku._board[(int)auxIndex + (int)dir, currentIndex.y + GetPosInGrid(c).y].locked  //o si la celda a la que intento moverme esta lockeada
                || sudoku._board[(int)auxIndex + (int)dir, currentIndex.y + GetPosInGrid(c).y + 1].locked)
                return;
        }

        currentIndex.x += Mathf.RoundToInt(dir);
        foreach (var c in cellList)
        {
            c.transform.position = new Vector3(sudoku._board[(int)(currentIndex.x + GetPosInGrid(c).x), 0].transform.position.x, c.transform.position.y, 0);
        }
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

            if (sudoku._board[currentIndex.x + (int)aux.x, currentIndex.y + (int)aux.y].locked ||
                sudoku._board[currentIndex.x + (int)aux.x, currentIndex.y + (int)aux.y + 1].locked)
            {
                TryMove(GetPosInGrid(c).x - aux.x);
                break;
            }

            //Si alguna de las celdas pasa los limites
            if (currentIndex.x + aux.x >= sudoku._bigSideX)
            {
                TryMove(-1);
                break;
            }
            else if (currentIndex.x + aux.x < 0)
            {
                TryMove(1);
                break;
            }
        }

        currentRotation++;
        if (currentRotation >= 4) currentRotation = 0;
        foreach (var c in cellList)
        {
            Vector2 aux = GetPosInGrid(c);
            c.transform.position = new Vector3(sudoku._board[(int)(currentIndex.x + aux.x), 0].transform.position.x, transform.position.y - aux.y * sudoku.spacing, 0);
        }
    }


    public bool CanMoveDown()
    {
        Debug.Log(isActive);
        if (isActive == false)
        {
            return false;
        }
        foreach (var c in cellList)
        {
            if (currentIndex.y + GetPosInGrid(c).y + 1 >= sudoku._board.Height)
            {
                Debug.Log("ABAJO");

                foreach (var ce in cellList)
                {
                    sudoku.TranslateCurrentPiece(currentIndex.x + GetPosInGrid(ce).x, currentIndex.y + GetPosInGrid(ce).y, ce);
                }
                EventManager.instance.TriggerEvent(EventNames.OnFichaArrived);

                Destroy(gameObject);
                return false;
            }
            else if (sudoku._board[currentIndex.x + GetPosInGrid(c).x, currentIndex.y + GetPosInGrid(c).y + 1].locked)
            {
                Debug.Log("LOCKED");

                foreach (var ce in cellList)
                {
                    sudoku.TranslateCurrentPiece(currentIndex.x + GetPosInGrid(ce).x, currentIndex.y + GetPosInGrid(ce).y, ce);
                    
                }
                EventManager.instance.TriggerEvent(EventNames.OnFichaArrived);

                Destroy(gameObject);
                return false;
            }
        }


        if (currentIndex.y + 1 >= sudoku._board.Height)
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
    public void ActivatePiece(){
        isActive = true;
        Debug.Log("IsTrue");
    }
    public void DeactivatePiece(){
        isActive = false;
    }


}
