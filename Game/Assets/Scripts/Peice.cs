using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peice : MonoBehaviour
{
    private int x;
    private int y;

    public void Init(int xcoord, int ycoord){
        x = xcoord;
        y = ycoord;
    }

    private void OnMouseDown() {
        
    }

    private bool isMoveAllowed(int x, int y){
        return true;
    }
}
