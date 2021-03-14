using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookCharacter : MonoBehaviour
{
    public GameObject Player;
    void Update()
    {
        this.gameObject.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, this.gameObject.transform.position.z);
    }
}
