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

public enum TileType
{
    [TileSpriteResource("Sprites/Ground/Grass")]
    Grass
}

public class Tile : MonoBehaviour {
    public GameObject TileObject = null;
    private Dictionary<string, Sprite> TileSprites = new Dictionary<string, Sprite>();
    public TileType Type;
    public string TypeName {
        get {
            return Enum.GetName(typeof(TileType), Type);
        }
    }
    public Sprite GetSprite() {
        return TileSprites[TypeName];
    }
    public void UpdateTile() {
        gameObject.GetComponent<SpriteRenderer>().sprite = GetSprite();
    }

    private void Start() {
        Type type = typeof(TileType);
        foreach (TileType tiletype in Enum.GetValues(typeof(TileType))) {
            string tiletypestr = tiletype.ToString();

            MemberInfo[] memberInfos = type.GetMember(tiletypestr);
            object[] attributes = memberInfos[0].GetCustomAttributes(false);
            TileSpriteResource resource = (TileSpriteResource)attributes[0];

            Sprite sprite = Resources.Load<Sprite>(resource.location);
            TileSprites.Add(tiletypestr, sprite);
        }
    }
}
