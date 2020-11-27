using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script to add collider to trigger when player misses platforms to create lose event
public class ScreenCollide : MonoBehaviour
{
    [Header ("detection for fall zone")]
    public GameObject bottomOfCamera;
    public GameObject gameOverPanel;
    public AudioSource fall;
    //control bool for game flow
    public static bool gameOver = false;

    //if detect a collide with player tag, set control bools accordinly
    //play fall sound SFX
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            fall.Play();
            gameOver = true;
            gameOverPanel.SetActive(true);
        }
    }
}
