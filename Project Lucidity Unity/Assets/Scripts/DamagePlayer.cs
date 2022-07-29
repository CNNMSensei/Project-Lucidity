using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DamagePlayer : TileBase
{
    // Start is called before the first frame update
    public void OnCollisionEnter2D()
    {
        Debug.Log("touched a thing");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
