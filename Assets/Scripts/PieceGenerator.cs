using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceGenerator : MonoBehaviour
{
    public List<Piece> pieces;
    public Transform canvas;
    public Piece GeneratePiece(){
        Debug.Log("Piece Generated");
        Piece p =
        Instantiate(pieces[0],transform);
        return p;
    }

}
