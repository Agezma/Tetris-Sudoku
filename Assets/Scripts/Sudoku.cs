using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sudoku : MonoBehaviour
{
    public Cell prefabCell;
    public Canvas canvas;

    [HideInInspector] public Matrix<Cell> _board;

    List<int> nums = new List<int>();


    Matrix<int> _createdMatrix;

    public int _smallSideX;
    public int _smallSideY;
    public int _bigSideX;
    public int _bigSideY;


    private void Awake()
    {
        CreateEmptyBoard();
        ClearBoard();

        CreateSudoku();
    }

    private void Update()
    {
        
       
    }

    [HideInInspector] public float spacing = 68f;
    [HideInInspector] public float startX;
    [HideInInspector] public float startY;
    void CreateEmptyBoard()
    {
        startX = -spacing * (_bigSideX - 1) / 2f;
        startY = spacing * (_bigSideY - 1) / 2f;

        _board = new Matrix<Cell>(_bigSideX, _bigSideY);
        for (int x = 0; x < _board.Width; x++)
        {
            for (int y = 0; y < _board.Height; y++)
            {
                var cell = _board[x, y] = Instantiate(prefabCell);
                cell.transform.SetParent(transform, false);
                cell.transform.localPosition = new Vector3(startX + x * spacing, startY - y * spacing, 0);             
            }
        }
    }

    public void TranslateCurrentPiece(int x, int y, Cell value)
    {
        _board[x, y].number = value.number;
        _board[x, y].locked = true;
    }

    float cellSize = 64f;
    public Cell CurrentCell(Vector3 toCheck)
    {
        Cell closest = _board[0, 0];
        float minDist = Vector3.Distance(closest.transform.position, toCheck);

        for (int i = 0; i < _board.Width; i++)
        {
            for (int j = 0; j < _board.Height; j++)
            {
                float newDist = Vector3.Distance(_board[i,j].transform.position, toCheck);
                if (newDist < minDist)
                {
                    minDist = newDist;
                    closest = _board[i, j];
                }
            }
        }
        return closest;
    }
    
    void CreateSudoku()
    {
        StopAllCoroutines();
        nums = new List<int>(); 
        ClearBoard();

        _createdMatrix = new Matrix<int>(_bigSideX,_bigSideY);
        TranslateAllValues(_createdMatrix);

        // EventManager.instance.TriggerEvent(EventNames.OnCreatedSudoku);
    }

    void TranslateAllValues(Matrix<int> matrix)
    {
        for (int y = 0; y < _board.Height; y++)
        {
            for (int x = 0; x < _board.Width; x++)
            {
                _board[x, y].number = matrix[x, y];

                if (!_board[x, y].isEmpty) _board[x, y].locked = true;
            }
        }
    }

    void ClearBoard()
    {
        _createdMatrix = new Matrix<int>(_bigSideX, _bigSideY);
        foreach (var cell in _board)
        {
            cell.number = 0;
            cell.locked = cell.invalid = false;
        }
    }

    public bool CheckFullRow(int x, int y)
    {
        Debug.Log("CHECK ROW");
        for (int i = 0; i < _board.Width ; i++)
        {
            if (_board[i, y].isEmpty)
            {
                Debug.Log("FILE NOT FULL");
                return false;
            }
        }

        List<int> allInts = new List<int>();
        for (int i = 1; i <= _board.Width; i++)
        {
            allInts.Add(i);
        }
        for (int i = 0; i < _board.Width; i++)
        {
            if (!allInts.Contains(_board[i, y].number))
            {
                Debug.Log("NUMERO REPETIDO");
                return false;
            }
            allInts.Remove(_board[i, y].number);
        }
        return true;
    }

    public void DropDownRow(int y)
    {
        Matrix<int> droppedMatrix = new Matrix<int>(_bigSideX, _bigSideY);

        int QuedanIgual = 0;
        int Bajan = 0;

        for (int i = 0; i < droppedMatrix.Width ; i++)
        {
            for (int j = 0; j < droppedMatrix.Height; j++)
            {                
                if (_board[i, j].isEmpty) continue;
                if (j > y)
                {
                    droppedMatrix[i, j] = _board[i, j].number;
                    QuedanIgual++;
                }
                else if( j > 0)
                {
                    Bajan++;
                    droppedMatrix[i,j] = _board[i, j - 1].number;
                }
            }
        }

        Debug.Log("Quedan: " + QuedanIgual + "--- Bajan: " + Bajan);

        ClearBoard();
        TranslateAllValues(droppedMatrix);
    }
}
