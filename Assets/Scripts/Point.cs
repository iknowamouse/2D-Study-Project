using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{

    public int coinValue = 10;
    
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            Debug.Log(other);
            ScoreManager.instance.ChangeScore(coinValue);
            Destroy(gameObject);
        }
    }
}
