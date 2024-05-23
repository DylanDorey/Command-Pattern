using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
//to use a sorted list we need the Linq library

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [02/27/2024]
 * [Records and replays user commands when desired at runtime]
 */

public class Invoker : MonoBehaviour
{
    //determines if the user is recording, and replaying commands
    private bool isRecording;
    private bool isReplaying;

    //the time the command was replayed upon replay
    private float replayTime;

    //the time the commands were recorded at runtime
    private float recordingTime;

    //A sorted list of commands that decrements to index 0 when a command is removed/played
    private SortedList<float, Command> recordedCommands = new SortedList<float, Command>();

    /// <summary>
    /// Takes in a command, executes it, then stores it into the sorted list if the user is recording
    /// </summary>
    /// <param name="command"> the users input action </param>
    public void ExecuteCommand(Command command)
    {
        //execute/perform whatever command is passed in
        command.Execute();

        //if the user is recording
        if(isRecording)
        {
            //add that command to the sorted list with a time stamp
            recordedCommands.Add(recordingTime, command);
        }

        //Display the recorded time and command recorded
        Debug.Log("Recorded Time: " + recordingTime);
        Debug.Log("Recorded Command: " + command);
    }

    /// <summary>
    /// Starts the recording process
    /// </summary>
    public void Record()
    {
        //set the recording time to 0
        recordingTime = 0.0f;

        //set is recording to true
        isRecording = true;
    }

    /// <summary>
    /// Starts the replay process
    /// </summary>
    public void Replay()
    {
        //set the replay time to 0
        replayTime = 0.0f;

        //set is replaying to true
        isReplaying = true;

        //if the sorted list of commands is empty
        if(recordedCommands.Count <= 0)
        {
            //Display that there are no commands to replay
            Debug.LogError("No commands to replay!");
        }

        //reverse the sorted list so the first command recorded is at index 0
        recordedCommands.Reverse();
    }

    private void FixedUpdate()
    {
        //if we are recording
        if (isRecording)
        {
            //add the fixed time to the recording time
            recordingTime += Time.fixedDeltaTime;
        }

        //if we are replaying
        if (isReplaying)
        {
            //add the fixed time to the replay time
            replayTime += Time.fixedDeltaTime;

            //if there are any commands in the sorted list
            if(recordedCommands.Any())
            {
                //get the first element's time stamp key in the sorted list at the approximate replay time
                if (Mathf.Approximately(replayTime, recordedCommands.Keys[0]))
                {
                    //Display the replay time stamp and the command
                    Debug.Log("Replay Time: " + replayTime);
                    Debug.Log("Replay Command: " + recordedCommands.Values[0]);

                    //execute (replay) that command
                    recordedCommands.Values[0].Execute();

                    //As I remove things the remaining elements just move towards the front - sorted lists
                    recordedCommands.RemoveAt(0);
                }
            }
            else
            {
                //otherwise if there aren't any commands, set is replaying to false
                isReplaying = false;
            }
        }
    }
}
