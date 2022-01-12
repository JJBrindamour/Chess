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

    List<Tile> legalMoves() {
        List<Tile> posibleMoves = new List<Tile>();
        List<Tile> legalMoves = new List<Tile>();
        string pieceType = type.Remove(0, 1).Remove(2, 1);
        switch (pieceType) {
            case "r":
                int obstNegX = -1;
                int obstPosX = -1;
                int obstNegY = -1;
                int obstPosY = -1;
                for (int i=0; i < 8; i++) {
                    for (int j=0; j<8; j++) {
                        if (i==x || j==y) {
                            Tile tile = GameObject.Find($"Tile ({i}, {j})").GetComponent<Tile>();
                            posibleMoves.Add(tile);
                        }
                    }
                }
                break;
        } 
        return legalMoves;
    }
}
