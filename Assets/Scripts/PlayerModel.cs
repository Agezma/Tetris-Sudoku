using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    // Start is called before the first frame update
    public Piece controlledPiece;
    bool isMoving;
    float axis;
    bool pressed = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Rotate(){
        controlledPiece.Rotate();
    }
    public void Hold(){
if (pressed)
{
    
     GameManager gameManager = FindObjectOfType<GameManager>();

        if(gameManager.holdPiece == null ){

            gameManager.holdPiece = controlledPiece;
            gameManager.holdPiece.transform.position = gameManager.holdPieceTransform.position;
            gameManager.holdPiece.DeactivatePiece();
            gameManager.GeneratePiece();
            
        } 

        else {
            Piece p = gameManager.holdPiece;
            gameManager.holdPiece = controlledPiece;
            gameManager.holdPiece.transform.position = gameManager.holdPieceTransform.position;
            gameManager.holdPiece.DeactivatePiece();
        
            p.currentIndex.x = Mathf.RoundToInt(p.sudoku._bigSideX / 2f);
        p.currentIndex.y = 0;

        p.transform.position = p.sudoku._board[p.currentIndex.x, 0].transform.position + new Vector3(38, 10, 0);
        p.initialVec = p.transform.position;

        foreach (var c in p.cellList)
        {        
            Vector2 aux = p.GetPosInGrid(c);
            c.transform.position = new Vector3(p.sudoku._board[(int)(p.currentIndex.x + aux.x), 0].transform.position.x, p.transform.position.y + aux.y * p.sudoku.spacing, 0);
        }
            controlledPiece = p;
            controlledPiece.ActivatePiece();



        }
        pressed = false;
} 

} 
public void Unhold(){
        Debug.Log(pressed);
    pressed = true;
    }
    public void Swipe(float a){
        //axis = a;
        //isMoving = !isMoving;
        //Debug.Log("isMoving");
      
        controlledPiece.TryMove(a);

    }


}
