using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    // Start is called before the first frame update
    public Piece controlledPiece;
    bool isMoving;
    float axis;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving){

        controlledPiece.transform.position += controlledPiece.speed * Vector3.right * axis;
        }
    }
    public void Rotate(){
        controlledPiece.Rotate();
    }
    public void Hold(){

    }
    public void Swipe(float a){
        //axis = a;
        //isMoving = !isMoving;
        //Debug.Log("isMoving");
      
        controlledPiece.Move(a);

    }


}
