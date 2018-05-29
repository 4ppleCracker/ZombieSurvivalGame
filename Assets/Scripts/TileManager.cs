using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public enum TileType
{
    [TileSpriteResource("Sprites/Ground/Grass")]
    Grass
}

public class TileManager : MonoBehaviour
{
    public static TileManager singleton;

    public List<List<GameObject>> Map = new List<List<GameObject>>();

    public const int Width = 50;
    public const int Height = 50;
    public const float ppu = 2.5f;

    public static Vector3 Middle {
        get {
            return (new Vector3(Width / 2, 0, Height) / 2) * ppu * Tile.Size;
        }
    }

    private void InitMap() {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/Ground");
        prefab.transform.localScale = new Vector3(Tile.Size, Tile.Size);
        for (int x = 0; x < Width; x++) {
            List<GameObject> mapstrip = new List<GameObject>();
            for (int y = 0; y < Height; y++) {
                GameObject gameObject = Instantiate(prefab);
                SpriteRenderer renderer = prefab.GetComponent<SpriteRenderer>();
                Sprite sprite = renderer.sprite;
                Texture2D texture = sprite.texture;
                gameObject.transform.position += new Vector3(x, 0, y) * ppu * Tile.Size;
                Tile tile = gameObject.GetComponent<Tile>();
                tile.UpdateTile();
                tile.position = new Vector2(x, y);
                mapstrip.Add(gameObject);
            }
            Map.Add(mapstrip);
        }
    }
    void InitTileClass() {
        if (Tile.TileSprites.Count < 1) {
            Type type = typeof(TileType);
            foreach (TileType tiletype in Enum.GetValues(typeof(TileType))) {
                string tiletypestr = tiletype.ToString();

                MemberInfo[] memberInfos = type.GetMember(tiletypestr);
                object[] attributes = memberInfos[0].GetCustomAttributes(false);
                TileSpriteResource resource = (TileSpriteResource)attributes[0];

                Sprite sprite = Resources.Load<Sprite>(resource.location);
                Tile.TileSprites.Add(tiletypestr, sprite);
            }
        }
        if (Tile.TileSprites.Count < 1) {
            throw new Exception("Nothing in TileSprites");
        }
    }
    private void SetCameraPosition() {
        GameObject obj = Camera.main.gameObject;
        Vector3 mid = Middle;
        mid.y = 10;
        obj.transform.position = mid;
    }
    public void UpdateAllTiles() {
        for (int x = 0; x < Width; x++) {
            for (int y = 0; y < Height; y++) {
                Map[x][y].GetComponent<Tile>().UpdateTile();
            }
        }
    }
    private void Start() {
        singleton = GetComponent<TileManager>();
        InitTileClass();
        InitMap();
        SetCameraPosition();
        Debug.Log("Made a grid of size " + Map.Count + "x" + (Map.Count > 0 ? Map[0].Count : 0));
    }
}