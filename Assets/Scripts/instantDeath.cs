using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantDeath : MonoBehaviour
{
    [SerializeField] Canvas loseGUI;
    public AudioSource lose1;
    public AudioSource lose2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerController player = collision.GetComponent<playerController>();
        if (player != null)
        {
            playerController.playerHealth = 0;
            loseGUI.enabled = !loseGUI.enabled;
            lose1.Play();
            lose2.Play();
        }
    }
}
