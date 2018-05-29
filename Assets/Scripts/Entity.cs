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

    public void Move(Vector3 movement) {
        Vector3 Position = transform.position;
        Move(ref Position, movement, MovementSpeed);
        transform.position = Position;
    }

    public static void Move(ref Vector3 Position, Vector3 movement, int MovementSpeed) {
        movement.Normalize();
        movement *= MovementSpeed;
        movement *= Time.deltaTime;

        Vector3 newposition = Vector3.Lerp(Position, Position + movement, 100 * Time.deltaTime);
        if (Physics.Raycast(newposition, Vector3.down))
            Position = newposition;
    }
}