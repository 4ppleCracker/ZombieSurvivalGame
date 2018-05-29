using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public class TileSpriteResource : Attribute
{
    public string location;
    public TileSpriteResource(string location) {
        this.location = location;
    }
}

public class Tile : MonoBehaviour {
    public const float Size = .75f;
    public static Dictionary<string, Sprite> TileSprites = new Dictionary<string, Sprite>();
    public TileType Type;
    public bool selected = false;
    public Vector2 position;
    public string TypeName {
        get {
            return Enum.GetName(typeof(TileType), Type);
        }
    }
    public Sprite GetSprite() {
        if (TileSprites.ContainsKey(TypeName))
            return TileSprites[TypeName];
        else
            throw new Exception("No such key as " + TypeName + " in TileSprites");
    }
    public void UpdateTile() {
        Sprite sprite = GetSprite();
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.sprite = sprite;
        renderer.color = (selected ? Color.red : Color.white);
    }
}
