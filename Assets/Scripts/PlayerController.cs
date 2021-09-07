using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public InputMaster controller;
    public PlayerModel playerModel;
    public void StartController(){ //Llamada por el EventManager
controller.Player.Rotate.performed += _rotate => playerModel.Rotate();
controller.Player.Rotate.performed += _hold => playerModel.Hold();
controller.Player.Rotate.performed += _swipe => playerModel.Swipe();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
