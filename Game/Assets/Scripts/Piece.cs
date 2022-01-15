using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Piece : MonoBehaviour
{
    public int x;
    public int y;
    public string type;
    public string col;

    public void Init(int xcoord, int ycoord, string pieceType){
        x = xcoord;
        y = ycoord;
        type = pieceType;
        name = pieceType.ToUpper();
        col = type.Remove(1);
    }

    public List<Tile> legalMoves() {
        List<Tile> legalMoves = new List<Tile>();
        string pieceType = type.Remove(0, 1).Remove(1, 1);
        bool diffCol = true;
        string playerCol = GameObject.Find("GridManager").GetComponent<GridManager>().playerColor;
        switch (pieceType) {
            case "r":
                int obstNegX = 8;
                int obstPosX = -1;
                int obstNegY = 8;
                int obstPosY = -1;
                for (int i=0; i<8; i++) {
                    for (int j=0; j<8; j++) {
                        if (i==x || j==y) {
                            Tile tile = GameObject.Find($"Tile ({i}, {j})").GetComponent<Tile>();
                            if (tile.piece != null) {
                                if (i < x) obstNegX = x;
                                if (j < y) obstNegY = y;
                                if (i > x) obstPosX = x;
                                if (j > y) obstPosY = y;
                                if (tile.piece.col == playerCol) diffCol = false;
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
									if (tile.piece.col == playerCol) diffCol = false;
                                }
                            if (i > obstNegPos[0] && j > obstNegPos[1] || i < obstPosPos[0] && j < obstPosPos[1] || i < obstNegNeg[0] && j > obstNegNeg[1] || i > obstPosNeg[0] && j < obstPosNeg[1] && diffCol) legalMoves.Add(tile);
                        }
                    }
                }
                break;

			case "n":
                for (int i=0; i<8; i++) {
                    for (int j=0; j<8; j++) {
						Tile tile = GameObject.Find($"Tile ({i}, {j})").GetComponent<Tile>();
                        if (i != 0 && j != 0 && Math.Abs(i) + Math.Abs(j) == 3 && tile.piece.type.Remove(1) != GameObject.Find("GridManager").GetComponent<GridManager>().playerColor) {
							legalMoves.Add(tile);
						}
                    }
                }
                break;

			case "q":
                obstNegPos = new List<int>(){8, 8};
                obstPosPos = new List<int>(){-1, -1};
                obstNegNeg = new List<int>(){8, 8};
                obstPosNeg = new List<int>(){-1, -1};
				obstNegX = 8;
                obstPosX = -1;
                obstNegY = 8;
                obstPosY = -1;;
                for (int i=0; i<8; i++) {
                    for (int j=0; j<8; j++) {
						Tile tile = GameObject.Find($"Tile ({i}, {j})").GetComponent<Tile>();
                        if (Math.Abs(x - i) == Math.Abs(y - j)) {
                            if (tile.piece != null) {
                                if (i < x && j < y) obstNegPos = new List<int>(){x, y};
                                if (j > y && j > y) obstPosPos = new List<int>(){x, y};
                                if (i > x && j < y) obstNegNeg = new List<int>(){x, y};
                                if (i < x && j < y) obstNegPos = new List<int>(){x, y};
								if (tile.piece.col == playerCol) diffCol = false;
                            }
                         	if (i > obstNegPos[0] && j > obstNegPos[1] || i < obstPosPos[0] && j < obstPosPos[1] || i < obstNegNeg[0] && j > obstNegNeg[1] || i > obstPosNeg[0] && j < obstPosNeg[1] && diffCol) legalMoves.Add(tile);
							}
							
						diffCol = true;
						if (i==x || j==y) {
							if (tile.piece != null) {
								if (i < x) obstNegX = x;
								if (j < y) obstNegY = y;
								if (i > x) obstPosX = x;
								if (j > y) obstPosY = y;
								if (tile.piece.col == playerCol) diffCol = false;
							}
                           	if ((i > obstNegX && i < obstPosX || j > obstNegY && j < obstPosY) && diffCol) legalMoves.Add(tile);
                        }
                    }
                }
                break;

			case "k":
				for (int i=0; i<8; i++) {
                    for (int j=0; j<8; j++) {
						Tile tile = GameObject.Find($"Tile ({i}, {j})").GetComponent<Tile>();
						if (Math.Abs(x - i) <= 1 && Math.Abs(y - j) <= 1 && tile.piece.col == playerCol) {
							legalMoves.Add(tile);
						}
					}
				}
				break;

			case "p":
				for (int i=0; i<8; i++) {
                    for (int j=0; j<8; j++) {
						Tile tile = GameObject.Find($"Tile ({i}, {j})").GetComponent<Tile>();
						if (i == x + 1 && y == j || i == x + 1 && Math.Abs(j - y) == 1 && tile.piece != null && tile.piece.col == playerCol) {
							legalMoves.Add(tile);
						}
					}
				}
                break;
        } 
        return legalMoves;
    }
}
