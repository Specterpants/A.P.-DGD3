using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public GameObject Player;
    public float offset;
    public float offsetSmoothing;
    private Vector3 playerPosition;
    //public TextMeshPro GameOverText;

    private void Start()
    {
    }

    private void Update()
    {
        PlayerControllerScript playerScript = Object.FindObjectOfType<PlayerControllerScript>();
        playerPosition = new Vector3(Player.transform.position.x, base.transform.position.y, base.transform.position.z);
        if (Player.transform.localScale.x > 0f)
        {
            playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
        }
        else
        {
            playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
        }
        base.transform.position = Vector3.Lerp(base.transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
        if (!playerScript.Alive)
        {
            //((Behaviour)(object)GameOverText).enabled = true;
        }
    }
}
