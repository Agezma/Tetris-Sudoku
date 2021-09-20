using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public InputMaster controller;
    public PlayerModel playerModel;
    public void Start(){
        StartController();
    }
    public void StartController()
    { //Llamada por el EventManager
        controller.Player.Rotate.performed += _rotate => playerModel.Rotate();
        controller.Player.Hold.performed += _hold => playerModel.Hold();
        controller.Player.Hold.canceled += _canceled => playerModel.Unhold();
        controller.Player.Swipe.performed += _swipe => playerModel.Swipe(_swipe.ReadValue<float>());
        //controller.Player.Swipe.canceled += _s => playerModel.Swipe(_s.ReadValue<float>());
        controller.Player.SpaceBar.performed += _debug => Debug.Log("tratando de mover");
    }

    private void OnEnable()
    {
        controller.Enable();
    }
    private void OnDisable()
    {
        controller.Disable();
    }

    private void Awake()
    {
        controller = new InputMaster();
        //Debug.Log("Created");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
