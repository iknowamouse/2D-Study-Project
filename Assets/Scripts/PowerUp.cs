using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public Animator frogAnimator;
    public GameObject frogMove;
    
    private void OnTriggerEnter2D(Collider2D power)
    {
        
        if (power.gameObject.CompareTag("Player"))
        {
           
            GameObject.Find("Frog1_Enemy").GetComponent<FrogMovement>().isFrogMove = true; 
            frogAnimator.SetBool("IfStarCollected", true);

            Destroy(gameObject);
        }
    }
}
