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

    int currentRotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentIndex.x = Mathf.RoundToInt(sudoku._bigSideX / 2f);
        currentIndex.y= 0;

        transform.position = sudoku._board[currentIndex.x, 0].transform.position + new Vector3(38,0,0);

        foreach (var c in cellList)
        {
            int n = Random.Range(1, 10);
            c.number = n;
        }
    }

    void Update()
    {
        foreach (var item in cellList)
        {
            if (item.locked) return;
        }
        if (!CheckBorder())
            transform.position += speed * Vector3.down;
    }

    public void Move(float dir)
    {
        foreach (var c in cellList)
        {
            float auxIndex = currentIndex.x + gridData.gridInfo[c.positionsInGrid[currentRotation]].x;
            //Debug.Log(gridData.gridInfo[c.positionsInGrid[currentRotation]].x);
            Debug.Log("Pieza: "+ c+ " ---" + auxIndex);
            if ( auxIndex + dir < 0 || auxIndex + dir >= sudoku._bigSideX)
                return;

        }

        currentIndex.x += Mathf.RoundToInt(dir);
        transform.position = new Vector3(sudoku._board[currentIndex.x, 0].transform.position.x + 38, transform.position.y, transform.position.z);
    }

    public void Rotate()
    {
        if (CanRotate())
        {
            foreach (var c in cellList)
            {
                Vector2 aux = gridData.gridInfo[c.positionsInGrid[currentRotation]];
                c.transform.position = transform.position + new Vector3(aux.x, aux.y, 0) * sudoku.spacing;
            }


            currentRotation++;
            if (currentRotation >= 4) currentRotation = 0;
        }
        //if (CanRotate()){
        //    transform.RotateAround(transform.position,Vector3.forward,-90);
        //    foreach(var c in cellList){
        //        c.transform.RotateAround(c.transform.position,-Vector3.forward,-90);
        //    }
        //}

    }

    bool CanRotate()
    {
        int a = currentRotation + 1;
        if (a >= 4) a = 0;

        foreach (var c in cellList)
        {
            Vector2 aux = gridData.gridInfo[c.positionsInGrid[a]];
            //Si alguna de las celdas pasa los limites
            if (currentIndex.x + aux.x > sudoku._bigSideX || currentIndex.x + aux.x < 0)
            {
                return false;
            }
        }

        return true;
    }
 

    public bool CheckBorder()
    {
        int aux = 0;
        for (int i = 0; i < cellList.Count; i++)
        {
            var a = sudoku.CurrentCell(cellList[i].transform.position + Vector3.down * sudoku.spacing);

            if (a.locked || a.transform.position.y > transform.position.y + speed)
            {
                //sudoku.TranslateCurrentPiece(currentIndex.x, sudoku._bigSideY-1, a);
                


                //EventManager.instance.TriggerEvent(EventNames.OnFichaArrived);

                return true;
            }
        }
        return false;
    }

   
}
