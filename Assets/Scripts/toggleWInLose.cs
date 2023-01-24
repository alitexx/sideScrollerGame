using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleWInLose : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] GameObject Enemies;
    [SerializeField] Canvas winScreen;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioManager.winGame();
            playWinScreen();
        }
    }

    private void playWinScreen()
    {
        Enemies.SetActive(!Enemies.activeInHierarchy);
        player.SetActive(!player.activeInHierarchy);
        winScreen.gameObject.SetActive(!winScreen.gameObject.activeInHierarchy);
    }
}
