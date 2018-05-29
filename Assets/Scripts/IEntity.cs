using UnityEngine;

public interface IEntity
{
    int Range { get; }
    int MovementSpeed { get; set; }
    void Move(Vector3 direction);
}
