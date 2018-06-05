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
                    Vector3 PlayerPos = PlayerManager.ActivePlayer.transform.position;
                    float Distance = Vector3.Distance(tile.transform.position, PlayerPos);
                    float Range = PlayerManager.ActivePlayer.GetComponent<Player>().Range * TileManager.ppu;
                    if (Distance < Range) {
                        tile.selected = true;
                    } else {
                        ChooseNearestTile();
                    }
                } else
                    Debug.Log("Not a tile");
                TileManager.singleton.UpdateAllTiles();
            }
        }
    }
    public void ChooseNearestTile() {
        Vector3 PlayerPos = PlayerManager.ActivePlayer.transform.position;

        float Range = PlayerManager.ActivePlayer.GetComponent<Player>().Range * TileManager.ppu;

        Vector2 MousePosition = Input.mousePosition;
        Vector2 PlayerOnScreen = Camera.main.WorldToScreenPoint(PlayerPos);
        Vector2 Direction = (MousePosition - PlayerOnScreen).normalized;

        Vector2 TargetPosition = Direction * Range;

        Vector3 TargetPosition3D = new Vector3(PlayerPos.x + TargetPosition.x, 10, PlayerPos.z + TargetPosition.y);

        RaycastHit newhit;
        if (Physics.Raycast(new Ray(TargetPosition3D, Vector3.down), out newhit, 100f)) {
            Tile newtile = newhit.transform.GetComponent<Tile>();
            newtile.selected = true;
        }
    }
}