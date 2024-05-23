using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [02/27/2024]
 * [A bike that is controllable by the user with a turbo mode and turning capability]
 */

public class BikeController : MonoBehaviour
{
    //The different turn directions that can be used
    public enum Direction
    {
        Left = -1,
        Right = 1
    }

    //determines when the turbo has been activated
    private bool isTurboOn;

    //the distance traversed after each turn
    private float distance = 1.0f;

    /// <summary>
    /// Turns the turbo on and off when called
    /// </summary>
    public void ToggleTurbo()
    {
        isTurboOn = !isTurboOn;
    }

    /// <summary>
    /// Turns the bike the passed in direction
    /// </summary>
    /// <param name="direction"> the turning direction </param>
    public void Turn(Direction direction)
    {
        //if the passed in direction is left
        if(direction == Direction.Left)
        {
            //translate left times the distance
            transform.Translate(Vector3.left * distance);
        }

        //if the passed in direction is right
        if (direction == Direction.Right)
        {
            //translate right times the distance
            transform.Translate(Vector3.right * distance);
        }
    }

    /// <summary>
    /// Sets the bike controller back to the start
    /// </summary>
    public void ResetPosition()
    {
        //set the position back to 0, 0, 0
        transform.position = new Vector3(0, 0, 0);
    }
}
