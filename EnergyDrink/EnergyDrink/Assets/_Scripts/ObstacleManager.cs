using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{   
    //needed for all objects
    private Transform obstaclePosition;

    //these bools check what type of obstacle it is, so we dont need a script for every type of obstacle
    public bool isMovingObstacle;

    //needed for moving obstacle
    public bool reachedHighestPoint;
    public bool reachedLowestPoint;

    public float highestPoint;
    public float lowestPoint;



    void Start()
    {
        reachedHighestPoint = true;
        obstaclePosition = GetComponent<Transform>();
    }

    void Update()
    {
        if (isMovingObstacle)
        {
            movingObstacle();
        }
    }

    public void movingObstacle()
    {
        if (obstaclePosition.position.y >= highestPoint)
        {
            reachedHighestPoint = true;
            reachedLowestPoint = false;
        }

        if (obstaclePosition.position.y <= lowestPoint)
        {
            reachedHighestPoint = false;
            reachedLowestPoint = true;
        }

        if (reachedHighestPoint)
        {
            transform.position += -transform.up * 5 * Time.deltaTime;
        }  

        if (reachedLowestPoint)
        {
            transform.position += transform.up * 5 * Time.deltaTime;
        }
    }
}
