using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public Animator frogAnimator;
    public Animator doorAnim;
    public GameObject frogMove;
    
    private void OnTriggerEnter2D(Collider2D power)
    {
        if (power.gameObject.CompareTag("Player"))
        {
            doorAnim.SetBool("AllowToPass", true);
            frogAnimator.SetBool("IfStarCollected", true);
            Destroy(gameObject);
        }
    }
}
