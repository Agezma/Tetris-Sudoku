using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceGenerator : MonoBehaviour
{
    public List<Piece> pieces;
    public Piece GeneratePiece(){
        return Instantiate(pieces[Random.Range(0,pieces.Count)] as Piece);
    }

}
