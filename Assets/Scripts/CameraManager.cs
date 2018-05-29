using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager singleton;

    public GameObject target;
    private new Camera camera;

    private void Start() {
        singleton = GetComponent<CameraManager>();
        camera = GetComponent<Camera>();
    }
    private void Update() {
        Move();
    }
    public void Move() {
        Vector3 targetpos = target.transform.position;
        camera.transform.position = new Vector3(targetpos.x, camera.transform.position.y, targetpos.z);
    }
}