using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    protected int x;
    protected int y;
    protected string type;

    public void Init(int xcoord, int ycoord, string pieceType){
        x = xcoord;
        y = ycoord;
        type = pieceType;
        name = pieceType.ToUpper();
    }

    private bool isMoveAllowed(int x, int y){
        return true;
    }
}
