using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager singleton;

    private static GameObject _ActivePlayer;
    public const string PlayerPrefab = "Prefabs/Player";
    public static GameObject ActivePlayer {
        get {
            if (_ActivePlayer == null) {
                _ActivePlayer = Instantiate(Resources.Load<GameObject>(PlayerPrefab));
            }
            return _ActivePlayer;
        }
    }
    private void Start() {
        singleton = GetComponent<PlayerManager>();
        Vector3 mid = TileManager.Middle;
        mid.y = 3;
        ActivePlayer.transform.position = mid;
        CameraManager.singleton.target = ActivePlayer;
    }
}