using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    // Start is called before the first frame update
    public Piece controlledPiece;

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

        GameManager gameManager = FindObjectOfType<GameManager>();
        if(gameManager.holdPiece == null ){

            gameManager.holdPiece = controlledPiece;
            gameManager.holdPiece.transform.position = gameManager.holdPieceTransform.position;
            gameManager.holdPiece.DeactivatePiece();
            gameManager.GeneratePiece();
            return;
        }   
        else {
Piece tempPiece = gameManager.holdPiece;
gameManager.holdPiece = controlledPiece;
controlledPiece = tempPiece;
controlledPiece.DeactivatePiece();
gameManager.holdPiece.ActivatePiece();

        }
    }
    public void Swipe(float a){
        //axis = a;
        //isMoving = !isMoving;
        //Debug.Log("isMoving");
      
        controlledPiece.TryMove(a);

    }


}
