using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [02/27/2024]
 * [Handles all player input]
 */

public class InputHandler : MonoBehaviour
{
    //reference to the invoker component that gets added on start
    private Invoker invoker;

    //determine when the invoker is replaying, or is recording
    private bool isReplaying;
    private bool isRecording;

    //reference to the bike controller component
    private BikeController bikeController;

    //the various commands that can be recorded and replayed by the invoker (toggle turbo, turn left, and turn right)
    private Command buttonA, buttonD, buttonW;

    // Start is called before the first frame update
    void Start()
    {
        //add the invoker class
        invoker = gameObject.AddComponent<Invoker>();

        //set the bike controller reference
        bikeController = FindAnyObjectByType<BikeController>();

        //initialize the commands to the various bike controller actions
        buttonA = new TurnLeft(bikeController);
        buttonD = new TurnRight(bikeController);
        buttonW = new ToggleTurbo(bikeController);
    }

    // Update is called once per frame
    void Update()
    {
        //OLD INPUT SYSTEM USED FOR DEMONSTRATION ONLY 

        //if not replaying and is recording
        if(!isReplaying && isRecording)
        {
            //if A is pressed
            if (Input.GetKeyUp(KeyCode.A))
            {
                //execute the turn left command from the invoker and store it in the recorded commands
                invoker.ExecuteCommand(buttonA);
            }

            //if D is pressed
            if (Input.GetKeyUp(KeyCode.D))
            {
                //execute the turn right command from the invoker and store it in the recorded commands
                invoker.ExecuteCommand(buttonD);
            }

            //if W is pressed
            if (Input.GetKeyUp(KeyCode.W))
            {
                //execute the toggle turbo command from the invoker and store it in the recorded commands
                invoker.ExecuteCommand(buttonW);
            }
        }
    }

    /// <summary>
    /// TESTING PURPOSES ONLY ( DO NOT USE IN PRODUCTION CODE ) EXTREMELY INEFFICIENT
    /// </summary>
    private void OnGUI()
    {
        //create a start recording button
        if (GUILayout.Button("Start Recording"))
        {
            //if pressed reset the bikes position, set is replaying to false, set is recording to true, and start recording via the Invoker class
            bikeController.ResetPosition();
            isReplaying = false;
            isRecording = true;
            invoker.Record();
        }

        //create a stop recording button
        if (GUILayout.Button("Stop Recording"))
        {
            //if pressed reset the bikes position and set is recording to false
            bikeController.ResetPosition();
            isRecording = false;
        }

        //if we are currently not recording
        if (!isRecording)
        {
            //enable and create the start replay button
            if (GUILayout.Button("Start Replay"))
            {
                //if pressed reset the bikes position, set is recording to false, set is replaying to true, and start the replay via the Invoker class
                bikeController.ResetPosition();
                isRecording = false;
                isReplaying = true;
                invoker.Replay();
            }
        }
    }
}
