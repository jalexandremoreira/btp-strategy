using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
    public Unit selectedUnit;

    public int playerTurn = 1; 

    public GameObject selectedUnitSquare;

    public void ResetTiles() {
        foreach (Tile tile in FindObjectsOfType<Tile>()) {
            tile.Reset();
        }
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            EndTurn();
        }

        if(selectedUnit != null) {
            selectedUnitSquare.SetActive(true);
            selectedUnitSquare.transform.position = selectedUnit.transform.position;
        } else {
            selectedUnitSquare.SetActive(false);
        }
    }

    public void EndTurn() {
        if(playerTurn == 1) {
            playerTurn = 2;
        } else if(playerTurn == 2) {
            playerTurn = 1;
        }

        if(selectedUnit != null) {
            selectedUnit.selected = false;
            selectedUnit = null;
        }

        ResetTiles();

        foreach(Unit unit in FindObjectsOfType<Unit>()) {
            unit.hasMoved = false;
        }
    }
}