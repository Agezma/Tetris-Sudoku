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


    private void Start()
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

    public void DropDownCell(int x, int y)
    {
        List<Cell> drops = new List<Cell>();

        for (int i = y - 1; i > 0; i--)
        {
            drops.Add(_board[x, i]);
        }

        for (int i = 0; i < drops.Count; i++)
        {
            _board[y - i, x] = drops[i];
        }
    }
}
