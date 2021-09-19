using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PieceGenerator pieceGenerator;
    public PlayerModel playerModel;
    public Piece nextPiece;
    public Transform nextPieceTransform;
    public Piece holdPiece;
    public Transform holdPieceTransform;

    // Start is called before the first frame update
    void Start()
    {
        GeneratePiece();

        EventManager.instance.SubscribeEvent(EventNames.OnFichaArrived, GeneratePiece);
    }

    public void GeneratePiece()
    {
if (nextPiece == null){
    nextPiece = pieceGenerator.GeneratePiece();

    nextPiece.transform.position = nextPieceTransform.position;
    nextPiece.transform.position = nextPieceTransform.transform.position;

    foreach (var c in nextPiece.cellList)
        {
            int n = Random.Range(1, 10);
            c.number = n;
        }
    }

        nextPiece.currentIndex.x = Mathf.RoundToInt(nextPiece.sudoku._bigSideX / 2f);
        nextPiece.currentIndex.y = 0;

        nextPiece.transform.position = nextPiece.sudoku._board[nextPiece.currentIndex.x, 0].transform.position + new Vector3(38, 10, 0);
        nextPiece.initialVec = nextPiece.transform.position;

        foreach (var c in nextPiece.cellList)
        {        
            Vector2 aux = nextPiece.GetPosInGrid(c);
            c.transform.position = new Vector3(nextPiece.sudoku._board[(int)(nextPiece.currentIndex.x + aux.x), 0].transform.position.x, nextPiece.transform.position.y + aux.y * nextPiece.sudoku.spacing, 0);
        }

        nextPiece.ActivatePiece();
        playerModel.controlledPiece = nextPiece;

        nextPiece = pieceGenerator.GeneratePiece();
        nextPiece.transform.position = nextPieceTransform.transform.position;
        foreach (var c in nextPiece.cellList)
        {
            int n = Random.Range(1, 10);
            c.number = n;
        }

       // playerModel.controlledPiece = pieceGenerator.GeneratePiece();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
