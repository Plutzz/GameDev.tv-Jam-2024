using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigateSensor : MonoBehaviour
{
    /// <summary>
    /// How close this enemy needs to be in order to be concidered "at" a navigation point
    /// </summary>
    [SerializeField] private float arrivedThreshold = 0.1f;

    /// <summary>
    /// Holds references to all of the points that this enemy will navigate through
    /// </summary>
    public Transform[] points;

    /// <summary>
    /// Current point this enemy is trying to navigate to
    /// </summary>
    public int currentPoint = 0;


    public bool IsAtPoint()
    {
        if(Mathf.Abs(transform.position.x - points[currentPoint].position.x) <= arrivedThreshold)
        {
            return true;
        }

        return false;
    }


}
