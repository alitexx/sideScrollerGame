using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleWInLose : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] GameObject Enemies;
    [SerializeField] Canvas winScreen;
    public AudioSource win1;
    public AudioSource win2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerController player = collision.gameObject.GetComponent<playerController>();
        if (player != null)
        {
            win1.Play();
            playWinScreen();
        }
    }

    private void playWinScreen()
    {
        Enemies.SetActive(!Enemies.activeInHierarchy);
        player.SetActive(!player.activeInHierarchy);
        winScreen.enabled = !winScreen.enabled;
        win2.Play();
    }
}
