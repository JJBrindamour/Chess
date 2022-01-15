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
		foreach (tile in piece.legalMoves()) {
			tile.highlight.SetActive(true)
		}
    }

	void OnMouseUp() {
		
	}

	void OnMouseDrag() {
		mousePos = (Input.mousePosition);
        Vector2 pos= new Vector2(Camera.main.ScreenToWorldPoint(mousePos).x, Camera.main.ScreenToWorldPoint(mousePos).y);
		
		piece.transform.mousePosition = pos;
	}
}
