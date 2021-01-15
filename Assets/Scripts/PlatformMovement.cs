using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [Header("Up Movement Parameters")]

    public float upDistance = 10;
    public float upMoveSpeed = 0.17f;
    public bool returnWhenInitial;
    public bool vertical = false;

    [Header("Side Movement Parameters")]

    public float rightDistance = 10;
    public float rightMoveSpeed = 0.17f;
    public bool horizontal = false;

    private Vector3 InitialPosition;
    private Vector3 upMagnitude;
    private float currerntMagnitude;





    // Start is called before the first frame update
    void Start()
    {
        InitialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // up down

       if (!horizontal)

        { 
        transform.localPosition += transform.up * upMoveSpeed;
        currerntMagnitude = (transform.localPosition - InitialPosition).magnitude;

        if (currerntMagnitude > upDistance)
        {
            upMoveSpeed *= (-1);
        }

        if (returnWhenInitial)
        {
            if (transform.localPosition.y < InitialPosition.y)
            {
                upMoveSpeed *= (-1);
            }
        }

       }

        // left right

        if (!vertical)

        {

            transform.localPosition += transform.right * rightMoveSpeed;
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
}
