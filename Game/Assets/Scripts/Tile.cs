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
}
