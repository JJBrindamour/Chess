using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
        List<Tile> legalMoves = new List<Tile>();
        string pieceType = type.Remove(0, 1).Remove(2, 1);
        switch (pieceType) {
            case "r":
                int obstNegX = 8;
                int obstPosX = -1;
                int obstNegY = 8;
                int obstPosY = -1;
                bool diffCol = true;
                for (int i=0; i<8; i++) {
                    for (int j=0; j<8; j++) {
                        if (i==x || j==y) {
                            Tile tile = GameObject.Find($"Tile ({i}, {j})").GetComponent<Tile>();
                            if (tile.piece != null) {
                                if (i < x) obstNegX = x;
                                if (j < y) obstNegY = y;
                                if (i > x) obstPosX = x;
                                if (j > y) obstPosY = y;
                                if (tile.piece.type.Remove(1) == GameObject.Find($"GridManager").GetComponent<GridManager>().playerColor) diffCol = false;
                            }
                            if ((i < obstNegX && i > obstPosX || j < obstNegY && j > obstPosY) && diffCol) legalMoves.Add(tile);
                        }
                    }
                }
                break;

            case "b":
                List<int> obstNegPos = new List<int>(){8, 8};
                List<int> obstPosPos = new List<int>(){-1, -1};
                List<int> obstNegNeg = new List<int>(){8, 8};
                List<int> obstPosNeg = new List<int>(){-1, -1};
                for (int i=0; i<8; i++) {
                    for (int j=0; j<8; j++) {
                            if (Math.Abs(x - i) == Math.Abs(y - j)) {
                                Tile tile = GameObject.Find($"Tile ({i}, {j})").GetComponent<Tile>();
                                if (tile.piece != null) {
                                    if (i < x && j < y) obstNegPos = new List<int>(){x, y};
                                    if (j > y && j > y) obstPosPos = new List<int>(){x, y};
                                    if (i > x && j < y) obstNegNeg = new List<int>(){x, y};
                                    if (i < x && j < y) obstNegPos = new List<int>(){x, y};
                                }
                            if (i < obstNegX && i > obstPosX || j < obstNegY && j > obstPosY) legalMoves.Add(tile);
                        }
                    }
                }
                break;
        } 
        return legalMoves;
    }
}
