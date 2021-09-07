using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public List<Cell> cellList;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        foreach( var c in cellList){
            int n = Random.Range(0,9);
            c.number = n;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Vector3.down;
    }
}
