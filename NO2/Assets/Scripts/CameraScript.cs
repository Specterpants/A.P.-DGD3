using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Player;
    public Transform Playery;
    public float offset;
    public float offsetSmoothing;
    private Vector3 playerPosition;
    public GameObject Self;
    private void Start()
    {
        
    }

    private void Update()
    {
        //Camera X
        playerPosition = new Vector3(Player.transform.position.x, base.transform.position.y, base.transform.position.z);
        if (Player.transform.localScale.x > 0f)
        {
            playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
        }
        else
        {
            playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
        }
        base.transform.position = Vector3.Lerp(base.transform.position, playerPosition, offsetSmoothing * Time.deltaTime);//Should be smooth regardless of framerate.
        
        //Camera Y. It just works!
        transform.position = new Vector3(transform.position.x, Playery.position.y, -10);
    }
}
