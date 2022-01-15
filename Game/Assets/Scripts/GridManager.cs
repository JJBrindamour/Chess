using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] public int width, height, scale;
    [SerializeField] private Tile tile;
    [SerializeField] private Transform cam;
    [SerializeField] private Piece blackRook;
    [SerializeField] private Piece blackKnight;
    [SerializeField] private Piece blackBishop;
    [SerializeField] private Piece blackKing;
    [SerializeField] private Piece blackQueen;
    [SerializeField] private Piece blackPawn;
    [SerializeField] private Piece whiteRook;
    [SerializeField] private Piece whiteKnight;
    [SerializeField] private Piece whiteBishop;
    [SerializeField] private Piece whiteKing;
    [SerializeField] private Piece whiteQueen;
    [SerializeField] private Piece whitePawn;
    
    public string playerColor = "w";
    public Piece selectedPiece;


    void Start() {
        GenerateGrid();
    }

    void GenerateGrid() {
        for (int x = 0; x < width; x++){
            for (int y = 0; y < height; y++)
            {
                var spawnedTile = Instantiate(tile, new Vector3(scale * x, scale * y), Quaternion.identity);
                spawnedTile.name = $"Tile ({x}, {y})";
                spawnedTile.transform.localScale = new Vector3(scale, scale, 1);

                Vector3 scaleVector = new Vector3(scale * 2, scale * 2, 1);
                bool isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);

                if (x == 0 && y == 0){
                    var piece = Instantiate(whiteRook, new Vector3(scale * x, scale * y), Quaternion.identity);
                    piece.transform.localScale = scaleVector;
                    piece.Init(x, y, "wrl");
                    spawnedTile.Init(isOffset, x, y);
                    spawnedTile.piece = piece;
                } else if (x == 1 && y == 0) {
                    var piece = Instantiate(whiteKnight, new Vector3(scale * x, scale * y), Quaternion.identity);
                    piece.transform.localScale = scaleVector;
                    piece.Init(x, y, "wnl");
                    spawnedTile.Init(isOffset, x, y);
                    spawnedTile.piece = piece;
                } else if (x == 2 && y == 0) {
                    var piece = Instantiate(whiteBishop, new Vector3(scale * x, scale * y), Quaternion.identity);
                    piece.transform.localScale = scaleVector;
                    piece.Init(x, y, "wbl");
                    spawnedTile.Init(isOffset, x, y);
                    spawnedTile.piece = piece;
                } else if (x == 3 && y == 0) {
                    var piece = Instantiate(whiteQueen, new Vector3(scale * x, scale * y), Quaternion.identity);
                    piece.transform.localScale = scaleVector;
                    piece.Init(x, y, "wq_");
                    spawnedTile.Init(isOffset, x, y);
                    spawnedTile.piece = piece;
                } else if (x == 4 && y == 0) {
                    var piece = Instantiate(whiteKing, new Vector3(scale * x, scale * y), Quaternion.identity);
                    piece.transform.localScale = scaleVector;
                    piece.Init(x, y, "wk_");
                    spawnedTile.Init(isOffset, x, y);
                    spawnedTile.piece = piece;
                } else if (x == 5 && y == 0) {
                    var piece = Instantiate(whiteBishop, new Vector3(scale * x, scale * y), Quaternion.identity);
                    piece.transform.localScale = scaleVector;
                    piece.Init(x, y, "wbr");
                    spawnedTile.Init(isOffset, x, y);
                    spawnedTile.piece = piece;
                } else if (x == 6 && y == 0) {
                    var piece = Instantiate(whiteKnight, new Vector3(scale * x, scale * y), Quaternion.identity);
                    piece.transform.localScale = scaleVector;
                    piece.Init(x, y, "wnl");
                    spawnedTile.Init(isOffset, x, y);
                    spawnedTile.piece = piece;
                } else if (x == 7 && y == 0) {
                    var piece = Instantiate(whiteRook, new Vector3(scale * x, scale * y), Quaternion.identity);
                    piece.transform.localScale = scaleVector;
                    piece.Init(x, y, "wrl");
                    spawnedTile.Init(isOffset, x, y);
                    spawnedTile.piece = piece;
                } else if (y == 1) {
                    var piece = Instantiate(whitePawn, new Vector3(scale * x, scale * y), Quaternion.identity);
                    piece.transform.localScale = scaleVector;
                    piece.Init(x, y, "wp" + (x + 1).ToString());
                    spawnedTile.Init(isOffset, x, y);
                    spawnedTile.piece = piece;
                } else if (x == 0 && y == 7){
                    var piece = Instantiate(blackRook, new Vector3(scale * x, scale * y), Quaternion.identity);
                    piece.transform.localScale = scaleVector;
                    piece.Init(x, y, "brl");
                    spawnedTile.Init(isOffset, x, y);
                    spawnedTile.piece = piece;
                } else if (x == 1 && y == 7) {
                    var piece = Instantiate(blackKnight, new Vector3(scale * x, scale * y), Quaternion.identity);
                    piece.transform.localScale = scaleVector;
                    piece.Init(x, y, "bkl");
                    spawnedTile.Init(isOffset, x, y);
                    spawnedTile.piece = piece;
                } else if (x == 2 && y == 7) {
                    var piece = Instantiate(blackBishop, new Vector3(scale * x, scale * y), Quaternion.identity);
                    piece.transform.localScale = scaleVector;
                    piece.Init(x, y, "bbl");
                    spawnedTile.Init(isOffset, x, y);
                    spawnedTile.piece = piece;
                } else if (x == 3 && y == 7) {
                    var piece = Instantiate(blackQueen, new Vector3(scale * x, scale * y), Quaternion.identity);
                    piece.transform.localScale = scaleVector;
                    piece.Init(x, y, "bq_");
                    spawnedTile.Init(isOffset, x, y);
                    spawnedTile.piece = piece;
                } else if (x == 4 && y == 7) {
                    var piece = Instantiate(blackKing, new Vector3(scale * x, scale * y), Quaternion.identity);
                    piece.transform.localScale = scaleVector;
                    piece.Init(x, y, "bk_");
                    spawnedTile.Init(isOffset, x, y);
                    spawnedTile.piece = piece;
                } else if (x == 5 && y == 7) {
                    var piece = Instantiate(blackBishop, new Vector3(scale * x, scale * y), Quaternion.identity);
                    piece.transform.localScale = scaleVector;
                    piece.Init(x, y, "bbr");
                    spawnedTile.Init(isOffset, x, y);
                    spawnedTile.piece = piece;
                } else if (x == 6 && y == 7) {
                    var piece = Instantiate(blackKnight, new Vector3(scale * x, scale * y), Quaternion.identity);
                    piece.transform.localScale = scaleVector;
                    piece.Init(x, y, "bnr");
                    spawnedTile.Init(isOffset, x, y);
                    spawnedTile.piece = piece;
                } else if (x == 7 && y == 7) {
                    var piece = Instantiate(blackRook, new Vector3(scale * x, scale * y), Quaternion.identity);
                    piece.transform.localScale = scaleVector;
                    piece.Init(x, y, "brr");
                    spawnedTile.Init(isOffset, x, y);
                    spawnedTile.piece = piece;
                } else if (y == 6) {
                    var piece = Instantiate(blackPawn, new Vector3(scale * x, scale * y), Quaternion.identity);
                    piece.transform.localScale = scaleVector;
                    piece.Init(x, y, "bp" + (x + 1).ToString());
                    spawnedTile.Init(isOffset, x, y);
                    spawnedTile.piece = piece;
                } else {
                    spawnedTile.Init(isOffset, x, y);
                }
            }
        }

        cam.transform.position = new Vector3((float) width/2 - 0.5f, (float) height/2 - 0.5f, -10);
    }
}
