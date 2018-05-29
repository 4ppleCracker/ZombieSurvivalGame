using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public static MouseManager singleton;

    private void Start() {
        singleton = GetComponent<MouseManager>();
    }

    private void Update() {
        if (Input.GetMouseButton(0)) {
            Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray ray = new Ray(point, Vector3.down);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f)) {
                if (hit.transform != null) {
                    for (int x = 0; x < TileManager.Width; x++) {
                        for (int y = 0; y < TileManager.Height; y++) {
                            TileManager.singleton.Map[x][y].GetComponent<Tile>().selected = false;
                        }
                    }
                    Tile tile = hit.transform.GetComponent<Tile>();
                    if (tile != null) {
                        float Distance = Vector3.Distance(tile.transform.position, PlayerManager.ActivePlayer.transform.position);
                        float Range = PlayerManager.ActivePlayer.GetComponent<Player>().Range * TileManager.ppu;
                        if (Distance < Range)
                            tile.selected = true;
                    } else
                        Debug.Log("Not a tile");
                    TileManager.singleton.UpdateAllTiles();
                }
            }
        }
    }
}