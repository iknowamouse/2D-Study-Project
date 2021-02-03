using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogDeath : MonoBehaviour
{
    public int coinValue = 100;
    public GameObject frog;
    public Animator frogAnim;

    private void OnTriggerEnter2D(Collider2D kill)
    {
        if (kill.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.ChangeScore(coinValue);
            frogAnim.SetBool("IsDead", true);
        }
    }
}
