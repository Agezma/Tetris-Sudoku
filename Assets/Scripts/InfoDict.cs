using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GridPosInfo", order = 1)]
public class InfoDict : ScriptableObject
{
    public Dictionary<int, Vector2Int> gridInfo = new Dictionary<int, Vector2Int>(){
        { 0, new Vector2Int(-1, 1)},
        { 1, new Vector2Int(0, 1)},
        { 2, new Vector2Int(1, 1)},
        { 3, new Vector2Int(-1, 0)},
        { 4, new Vector2Int(0, 0)},
        { 5, new Vector2Int(1, 0)},
        { 6, new Vector2Int(-1, -1)},
        { 7, new Vector2Int(0, -1)},
        { 8, new Vector2Int(1, -1)},
    };
}
