using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenuManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Canvas pauseMenu;
    [SerializeField] GameObject Enemies;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            togglePause();
        }
    }
    public void togglePause()
    {
        Enemies.SetActive(!Enemies.activeInHierarchy);
        player.SetActive(!player.activeInHierarchy);
        pauseMenu.enabled = !pauseMenu.enabled;
    }
}
