using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantDeath : MonoBehaviour
{
    [SerializeField] Canvas loseGUI;
    public AudioSource lose1;
    public AudioSource lose2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("INSTANT DEATH");
            playerController.playerHealth = 0;
            loseGUI.gameObject.SetActive(!loseGUI.gameObject.activeInHierarchy);
            lose1.Play();
            lose2.Play();
        }
    }
}
