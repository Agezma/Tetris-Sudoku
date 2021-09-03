using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sudoku : MonoBehaviour
{
    public Cell prefabCell;
    public Canvas canvas;

    Matrix<Cell> _board;

    List<int> nums = new List<int>();


    Matrix<int> _createdMatrix;

    int _smallSideX;
    int _smallSideY;
    int _bigSideX;
    int _bigSideY;


    private void Start()
    {
        CreateEmptyBoard();
        ClearBoard();

        CreateSudoku();
    }

    

    void CreateEmptyBoard()
    {
        float spacing = 68f;
        float startX = -spacing * 4f;
        float startY = spacing * 4f;

        _board = new Matrix<Cell>(_bigSideX, _bigSideY);
        for (int x = 0; x < _board.Width; x++)
        {
            for (int y = 0; y < _board.Height; y++)
            {
                var cell = _board[x, y] = Instantiate(prefabCell);
                cell.transform.SetParent(canvas.transform, false);
                cell.transform.localPosition = new Vector3(startX + x * spacing, startY - y * spacing, 0);
            }
        }
    }

    void CreateSudoku()
    {
        StopAllCoroutines();
        nums = new List<int>();
        ClearBoard();
        List<Matrix<int>> l = new List<Matrix<int>>();     

        TranslateAllValues(_createdMatrix);
  
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
}
