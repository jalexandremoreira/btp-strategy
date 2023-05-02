using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;

public class Tile : MonoBehaviour {
    private SpriteRenderer rend;
    public Sprite[] tileGraphics;
    
    public float hoverAmount;

    public LayerMask obstacleLayer;


    public Color highlightedColor;
    public bool isWalkable;
    GameMaster gm;

    private void Start() {
        rend = GetComponent<SpriteRenderer>();
        int randTile = Random.Range(0, tileGraphics.Length);
        rend.sprite = tileGraphics[randTile];

        gm = FindObjectOfType<GameMaster>();
    }

    private void OnMouseEnter() {
        transform.localScale += Vector3.one * hoverAmount;
    }

    private void OnMouseExit() {
        transform.localScale -= Vector3.one * hoverAmount;
    }

    public bool IsClear() {
        Collider2D obstacle = Physics2D.OverlapCircle(transform.position, 0.2f, obstacleLayer);
        if (obstacle != null) {
            return false;
        } else {
            return true;
        }
    }

    public void Highlight() {
        rend.color = highlightedColor;
        isWalkable = true;
    }

    public void Reset() {
        rend.color = Color.white;
        isWalkable = false;
    }

    private void OnMouseDown()
    {
        if (isWalkable == true && gm.selectedUnit != null)
        {
            gm.selectedUnit.Move(this.transform.position);
        }
    }
}