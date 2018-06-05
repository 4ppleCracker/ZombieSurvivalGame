using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager singleton;

    public GameObject Target;
    private Camera Camera;

    private void Start() {
        singleton = GetComponent<CameraManager>();
        Camera = GetComponent<Camera>();
    }
    private void Update() {
        Move();
    }
    public void Move() {
        Vector3 targetpos = Target.transform.position;
        Camera.transform.position = new Vector3(targetpos.x, Camera.transform.position.y, targetpos.z);
    }
}