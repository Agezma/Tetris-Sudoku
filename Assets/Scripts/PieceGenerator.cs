using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceGenerator : MonoBehaviour
{
    public List<Piece> pieces;
    public Sudoku sudoku;

    public void Start()
    {
    }

    public Piece GeneratePiece()
    {
        //Debug.Log("Piece Generated");
        Piece p = Instantiate(pieces[0],transform);
        p.sudoku = sudoku;
        return p;
    }

}
