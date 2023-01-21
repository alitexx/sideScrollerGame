using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFire : MonoBehaviour
{
    public Transform firePoint;
    private Animator m_Animator;
    public GameObject bulletPrefab;
    private bool debounce;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        debounce = false;
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && debounce == false)
        {
            debounce = true;
            StartCoroutine(Debounced());
        }
    }
    private IEnumerator Debounced()
    {
        if (playerJump.grounded == true && m_Animator.GetBool("notShooting"))
        {
            m_Animator.SetBool("notShooting", false);
            // if the player is moving in any direction
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.001)
            {
                m_Animator.SetTrigger("shootingRun");
            } else
            {
                m_Animator.SetTrigger("shooting");
            }
            Shoot();
            yield return new WaitForSeconds(0.5f);
            m_Animator.ResetTrigger("shootingRun");
            m_Animator.ResetTrigger("shooting");
        }
        m_Animator.SetBool("notShooting", true);
        debounce = false;
    }
    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
