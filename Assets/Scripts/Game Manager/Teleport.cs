using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    //So We can use "OnCollisionStay" function BUT it doesn't always work
    //I decided to use bool parameter and lateUpdate

    [SerializeField] private Game_Manager _gameManager;
    [SerializeField] private Text textTeleport; //floating text system

    bool collisionEnter = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            collisionEnter = true;
            textTeleport.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            collisionEnter = false;
            textTeleport.gameObject.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && collisionEnter == true)
            _gameManager.LoadLevel();
    }
}
