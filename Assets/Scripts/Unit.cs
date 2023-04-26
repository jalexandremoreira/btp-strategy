using System.Diagnostics;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    public bool selected;
    GameMaster gm;

    public int tileSpeed;
    public bool hasMoved;


    private void Start() {
        gm = FindObjectOfType<GameMaster>();
    }

    private void OnMouseDown()
    {
        if (selected == true)
        {
            selected = false;
            gm.selectedUnit = null;
        }
        else
        {
            if (gm.selectedUnit != null)
            {
                gm.selectedUnit.selected = false;
            }
            selected = true;
            gm.selectedUnit = this;
            GetWalkableTiles();
        }
    }

    private void GetWalkableTiles()
    {
        if (hasMoved == true) {
            return;
        }

        foreach (Tile tile in FindObjectsOfType<Tile>())
        {
            if (Mathf.Abs(transform.position.x - tile.transform.position.x) + Mathf.Abs(transform.position.y - tile.transform.position.y) <= tileSpeed)
            {
                if(tile.IsClear() == true)
                {
                    tile.Highlight();
                }
            }
        }
    }
}