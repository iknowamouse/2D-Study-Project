using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{

   
    public Animator animatorFrog;
    public float rightDistance = 10;
    public float rightMoveSpeed = 0.17f;
    public bool returnWhenInitial;

    private Vector3 InitialPosition;
    private float currerntMagnitude;
    public bool isFrogMove = false;
    //private bool isFacingRight;
    
   
    // Start is called before the first frame update
    void Start()
    {
        
        InitialPosition = transform.position;
        isFrogMove = false;
    }


    private void Update()
    {
      
            if(isFrogMove == true)
        {
                
                transform.localPosition += (transform.right) * rightMoveSpeed;
                currerntMagnitude = (transform.localPosition - InitialPosition).magnitude;
           
                if (currerntMagnitude > rightDistance)
                {
                
                    rightMoveSpeed *= (-1);
                
            }

                if (returnWhenInitial)
                {
                    if (transform.localPosition.x < InitialPosition.x)
                    {
                        rightMoveSpeed *= (-1);
                    }
                }
                    

        }
            
        
    }
            // transform.rotation = Quaternion.Euler(0, 180, 0);
          
    
   

}

