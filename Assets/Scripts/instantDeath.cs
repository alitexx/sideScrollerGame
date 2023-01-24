using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantDeath : MonoBehaviour
{
    [SerializeField] Canvas loseGUI;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("INSTANT DEATH");
            audioManager.loseGame();
            playerController.playerHealth = 0;
            loseGUI.gameObject.SetActive(!loseGUI.gameObject.activeInHierarchy);
        }
    }
}
