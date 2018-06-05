using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public const int SlotCount = 9;
    public static GameObject[] inventorySlots = new GameObject[SlotCount];

    public static int selectedNumber = 0;

    public static Slot SelectedSlot {
        get {
            GameObject obj = inventorySlots[selectedNumber];
            return obj.GetComponent<InventorySlot>().slot;
        }
    }

    public void FillSlots() {
        for(int i = 0; i < inventorySlots.Length; i++) {
            Slot slot = new Slot() { item = Item.Wood, count = 0, number = i };
            GameObject gameObject = Instantiate(Resources.Load<GameObject>("Prefabs/InventorySlot"), GameObject.Find("Canvas").transform);
            Vector3 pos = gameObject.transform.position;
            pos.x += i * 100;
            gameObject.transform.position = pos;
            InventorySlot invslotcomp = gameObject.GetComponent<InventorySlot>();
            invslotcomp.Init();
            invslotcomp.UpdateSlot(slot);
            inventorySlots[i] = gameObject;
        }
    }
    public void InitItemSprites() {
        string[] names = Enum.GetNames(typeof(Item.Types));
        foreach (string spritename in names) {
            Texture2D sprite = Resources.Load<Texture2D>("Textures/Items/" + spritename.ToLower());
            if (sprite != null)
                Item.Textures.Add(spritename.ToLower(), sprite);
            else
                Debug.Log("Couldn't find texture for " + spritename.ToLower());
        }
    }

    public void Start() {
        FillSlots();
        InitItemSprites();
    }
    public void Update() {
        int selected = -1;
        for (int i = 0; i < inventorySlots.Length; i++) {
            InventorySlot slot = inventorySlots[i].GetComponent<InventorySlot>();
            if (Input.GetKeyDown((i+1).ToString())) {
                slot.selected = true;
                selectedNumber = i;
                selected = i;
            }
        }
        if(selected >= 0) {
            for (int i = 0; i < inventorySlots.Length; i++) {
                if (i != selected) {
                    InventorySlot slot = inventorySlots[i].GetComponent<InventorySlot>();
                    slot.selected = false;
                }
            }
        }

        if(Input.GetKey("g")) {
            InventorySlot invslot = inventorySlots[0].GetComponent<InventorySlot>();
            Slot slot = invslot.slot;
            slot.item = Item.Wood;
            slot.count += 1;
            invslot.UpdateSlot(slot);
        }
    }
}

/*
 * 
 * TODO: Correctly render sprites!
 * 
 */