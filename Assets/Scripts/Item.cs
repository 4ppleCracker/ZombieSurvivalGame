using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Item
{
    public enum Types
    {
        NONE,
        WOOD,
        STONE
    }
    Types type = Types.NONE;
    public static Item None = new Item();
    public static Item Wood = new Item(Types.WOOD);
    public static Item Stone = new Item(Types.STONE);

    public static Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();

    public string Name {
        get {
            return Enum.GetName(typeof(Types), type).ToLower();
        }
    }

    public Item(Types type) {
        this.type = type;
    }
    public Item() {

    }

    public Sprite GetSprite() {
        Texture2D texture;
        if (!Textures.ContainsKey(Name)) {
            texture = new Texture2D(100, 100);
        } else
            texture = Textures[Name];
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0));
    }
}