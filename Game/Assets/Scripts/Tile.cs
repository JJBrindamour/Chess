using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color primaryCol, secondaryCol;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] public GameObject highlight;
    public int x, y;
    public Piece piece;
	
    public void Init(bool isOffset, int xcoord, int ycoord) {
        spriteRenderer.color = isOffset ? secondaryCol : primaryCol;
        x = xcoord;
        y = ycoord;
    }

    void OnMouseEnter() {
        highlight.SetActive(true);
    }

    void OnMouseExit() {
        highlight.SetActive(false);
    }

    void OnMouseDown() {
		try {
            foreach (Tile tile in piece.legalMoves()) {
                tile.highlight.SetActive(true);
            }
            GameObject.Find("GridManager").GetComponent<GridManager>().selectedPiece = piece;
            Debug.Log(GameObject.Find("GridManager").GetComponent<GridManager>().selectedPiece);
        } catch (NullReferenceException) {}
    }

	void OnMouseUp() {
        try {
            int scale = GameObject.Find("GridManager").GetComponent<GridManager>().scale;
            Piece selectedPiece = GameObject.Find("GridManager").GetComponent<GridManager>().selectedPiece;
            selectedPiece.transform.position = new Vector3(scale * x, scale * y);
            GameObject.Find($"Tile ({selectedPiece.x}, {selectedPiece.y})").GetComponent<Tile>().piece = null;
            selectedPiece.x = x;
            selectedPiece.y = y;
            GameObject.Find("GridManager").GetComponent<GridManager>().selectedPiece = null;
        } catch (NullReferenceException) {}
	}

	void OnMouseDrag() {
		var mousePos = (Input.mousePosition);
        Vector2 pos= new Vector2(Camera.main.ScreenToWorldPoint(mousePos).x, Camera.main.ScreenToWorldPoint(mousePos).y);
		
        try {piece.transform.position = pos;} catch (NullReferenceException) {}
	}
}
