using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, IEntity
{
    public int Range { get { return 3; } }
    public int MovementSpeed { get; set; }
    private void Start() {
        MovementSpeed = 25;
    }
}