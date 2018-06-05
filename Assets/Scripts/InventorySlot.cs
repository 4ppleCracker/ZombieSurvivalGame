using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot
{
    public Item item;
    public int count;
    public int number;
}

public class InventorySlot : MonoBehaviour
{
    public Slot slot;
    public Slot Slot {
        get {
            return slot;
        }
    }

    public Text UICount {
        get {
            return transform.Find("Count").GetComponent<Text>();
        }
    }
    public Image UIItem {
        get {
            return transform.Find("Item").GetComponent<Image>();
        }
    }

    public bool selected;

    public void Init() {
        UICount.text = "";
        slot = new Slot();
        slot.item = Item.None;
        slot.count = 0;
        UIItem.sprite = slot.item.GetSprite();
    }

    public void UpdateSlot(Slot newslot) {
        slot = newslot;
        UICount.text = slot.count.ToString();
        UIItem.sprite = slot.item.GetSprite();
    }
    public void Update() {
        UIItem.color = (selected ? Color.white : Color.gray);
    }
}