using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height, scale;
    [SerializeField] private Tile tile;
    [SerializeField] private Transform cam;
    [SerializeField] private Peice blackRook;
    [SerializeField] private Peice blackKnight;
    [SerializeField] private Peice blackBishop;
    [SerializeField] private Peice blackKing;
    [SerializeField] private Peice blackQueen;
    [SerializeField] private Peice blackPawn;
    [SerializeField] private Peice whiteRook;
    [SerializeField] private Peice whiteKnight;
    [SerializeField] private Peice whiteBishop;
    [SerializeField] private Peice whiteKing;
    [SerializeField] private Peice whiteQueen;
    [SerializeField] private Peice whitePawn;


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

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset, x, y);

                Vector3 scaleVector = new Vector3(scale * 2, scale * 2, 1);

                if (x == 0 && y == 0){
                    var peice= Instantiate(whiteRook, new Vector3(scale * x, scale * y), Quaternion.identity);
                    peice.transform.localScale = scaleVector;
                    peice.Init(x, y);
                } else if (x == 1 && y == 0) {
                    var peice= Instantiate(whiteKnight, new Vector3(scale * x, scale * y), Quaternion.identity);
                    peice.transform.localScale = scaleVector;
                    peice.Init(x, y);
                } else if (x == 2 && y == 0) {
                    var peice= Instantiate(whiteBishop, new Vector3(scale * x, scale * y), Quaternion.identity);
                    peice.transform.localScale = scaleVector;
                    peice.Init(x, y);
                } else if (x == 3 && y == 0) {
                    var peice= Instantiate(whiteQueen, new Vector3(scale * x, scale * y), Quaternion.identity);
                    peice.transform.localScale = scaleVector;
                    peice.Init(x, y);
                } else if (x == 4 && y == 0) {
                    var peice= Instantiate(whiteKing, new Vector3(scale * x, scale * y), Quaternion.identity);
                    peice.transform.localScale = scaleVector;
                    peice.Init(x, y);
                } else if (x == 5 && y == 0) {
                    var peice= Instantiate(whiteBishop, new Vector3(scale * x, scale * y), Quaternion.identity);
                    peice.transform.localScale = scaleVector;
                    peice.Init(x, y);
                } else if (x == 6 && y == 0) {
                    var peice= Instantiate(whiteKnight, new Vector3(scale * x, scale * y), Quaternion.identity);
                    peice.transform.localScale = scaleVector;
                    peice.Init(x, y);
                } else if (x == 7 && y == 0) {
                    var peice= Instantiate(whiteRook, new Vector3(scale * x, scale * y), Quaternion.identity);
                    peice.transform.localScale = scaleVector;
                    peice.Init(x, y);
                } else if (y == 1) {
                    var peice= Instantiate(whitePawn, new Vector3(scale * x, scale * y), Quaternion.identity);
                    peice.transform.localScale = scaleVector;
                    peice.Init(x, y);
                } else if (x == 0 && y == 7){
                    var peice= Instantiate(blackRook, new Vector3(scale * x, scale * y), Quaternion.identity);
                    peice.transform.localScale = scaleVector;
                    peice.Init(x, y);
                } else if (x == 1 && y == 7) {
                    var peice= Instantiate(blackKnight, new Vector3(scale * x, scale * y), Quaternion.identity);
                    peice.transform.localScale = scaleVector;
                    peice.Init(x, y);
                } else if (x == 2 && y == 7) {
                    var peice= Instantiate(blackBishop, new Vector3(scale * x, scale * y), Quaternion.identity);
                    peice.transform.localScale = scaleVector;
                    peice.Init(x, y);
                } else if (x == 3 && y == 7) {
                    var peice= Instantiate(blackQueen, new Vector3(scale * x, scale * y), Quaternion.identity);
                    peice.transform.localScale = scaleVector;
                    peice.Init(x, y);
                } else if (x == 4 && y == 7) {
                    var peice= Instantiate(blackKing, new Vector3(scale * x, scale * y), Quaternion.identity);
                    peice.transform.localScale = scaleVector;
                    peice.Init(x, y);
                } else if (x == 5 && y == 7) {
                    var peice= Instantiate(blackBishop, new Vector3(scale * x, scale * y), Quaternion.identity);
                    peice.transform.localScale = scaleVector;
                    peice.Init(x, y);
                } else if (x == 6 && y == 7) {
                    var peice= Instantiate(blackKnight, new Vector3(scale * x, scale * y), Quaternion.identity);
                    peice.transform.localScale = scaleVector;
                    peice.Init(x, y);
                } else if (x == 7 && y == 7) {
                    var peice= Instantiate(blackRook, new Vector3(scale * x, scale * y), Quaternion.identity);
                    peice.transform.localScale = scaleVector;
                    peice.Init(x, y);
                } else if (y == 6) {
                    var peice= Instantiate(blackPawn, new Vector3(scale * x, scale * y), Quaternion.identity);
                    peice.transform.localScale = scaleVector;
                    peice.Init(x, y);
                } 
            }
        }

        cam.transform.position = new Vector3((float) width/2 - 0.5f, (float) height/2 - 0.5f, -10);
    }
}
