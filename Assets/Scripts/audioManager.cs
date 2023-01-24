using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public static AudioSource win;
    public static AudioSource lose;
    public static AudioSource levelBGM;
    public static AudioSource jump;
    public static AudioSource death;
    public static AudioSource winSFX;

    public static AudioSource bulletSFX;
    public static AudioSource takeDamageSFX;


    private void Start()
    {
        win = this.transform.GetChild(0).GetComponent<AudioSource>();
        lose = this.transform.GetChild(1).GetComponent<AudioSource>();
        levelBGM = this.transform.GetChild(2).GetComponent<AudioSource>();
        jump = this.transform.GetChild(4).GetComponent<AudioSource>();
        winSFX = this.transform.GetChild(5).GetComponent<AudioSource>();
        death = this.transform.GetChild(3).GetComponent<AudioSource>();
        bulletSFX = this.transform.GetChild(6).GetComponent<AudioSource>();
        takeDamageSFX = this.transform.GetChild(7).GetComponent<AudioSource>();

        startGame();
    }


    public static void startGame()
    {
        levelBGM.Play();
    }

    public static void playerJump()
    {
        jump.Play();
    }

    public static void playerShoot()
    {
        bulletSFX.Play();
    }

    public static void takeDamage()
    {
        takeDamageSFX.Play();
    }

    public static void winGame()
    {
        levelBGM.Stop();
        Destroy(levelBGM);
        winSFX.Play();
        win.Play();
    }

    public static void loseGame()
    {
        levelBGM.Stop();
        Destroy(levelBGM);
        death.Play();
        lose.Play();
    }
}
