using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    protected int x;
    protected int y;
    protected string type;

    public void Init(int xcoord, int ycoord, string peiceType){
        x = xcoord;
        y = ycoord;
        type = peiceType;
    }

    private bool isMoveAllowed(int x, int y){
        return true;
    }
}
