using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IEntity
{
    public int Range { get { return 3; } }
    public int MovementSpeed { get; set; }
    public const int DefaultMovementSpeed = 20;
    public Rigidbody rb;
    private void Start() {
        rb = GetComponent<Rigidbody>();
        MovementSpeed = DefaultMovementSpeed;
    }
    private void Update() {
        Vector3 movement = new Vector3();

        if (Input.GetKey(KeyCode.W)) {
            movement += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S)) {
            movement += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A)) {
            movement += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D)) {
            movement += Vector3.right;
        }
        Move(movement);
    }
    public void Move(Vector3 movement) {
        Vector3 Position = transform.position;
        Entity.Move(ref Position, movement, MovementSpeed);
        transform.position = Position;
    }
}