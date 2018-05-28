using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public static TileManager singleton;

    public List<List<GameObject>> Map = new List<List<GameObject>>();

    public const int Width = 10;
    public const int Height = 10;
    public const float ppu = 2.5f;

    private void InitMap() {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/Ground");
        for (int x = 0; x < Width; x++) {
            List<GameObject> mapstrip = new List<GameObject>();
            for (int y = 0; y < Width; y++) {
                GameObject gameObject = Instantiate(prefab);
                Texture2D texture = prefab.GetComponent<SpriteRenderer>().sprite.texture;
                gameObject.transform.position += new Vector3(x * ppu, 0, y * ppu);
                mapstrip.Add(gameObject);
            }
            Map.Add(mapstrip);
        }
    }
    private void SetCameraPosition() {
        GameObject obj = GameObject.Find("Main Camera").GetComponent<Camera>().gameObject;
        obj.transform.position = new Vector3((Width / 2) * ppu, 10, (Height / 2) * ppu);
    }
    private void Start() {
        singleton = GetComponent<TileManager>();
        InitMap();
        SetCameraPosition();
        Debug.Log("Made a grid of size " + Map.Count + "x" + (Map.Count > 0 ? Map[0].Count : 0));
    }
}