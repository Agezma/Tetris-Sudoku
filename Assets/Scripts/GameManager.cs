﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PieceGenerator pieceGenerator;
    public PlayerModel playerModel;
    // Start is called before the first frame update
    void Start()
    {
        GeneratePiece();

        EventManager.instance.SubscribeEvent(EventNames.OnFichaArrived, GeneratePiece);
    }

    void GeneratePiece()
    {
        playerModel.controlledPiece = pieceGenerator.GeneratePiece();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}