using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public InputMaster controller;
    public PlayerModel playerModel;
    public void StartController()
    { //Llamada por el EventManager
        controller.Player.Rotate.performed += _rotate => playerModel.Rotate();
        controller.Player.Rotate.performed += _hold => playerModel.Hold();
        controller.Player.Rotate.performed += _swipe => playerModel.Swipe();
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
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
