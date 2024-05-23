/*
 * Author: [Dorey, Dylan]
 * Last Updated: [02/27/2024]
 * [A Command that makes the bike controller turn left]
 */

public class TurnLeft : Command
{
    //reference to the bike controller class
    private BikeController _controller;

    //need a constructor - will need to pass a BikeController object to make a TurnLeft
    public TurnLeft(BikeController controller)
    {
        _controller = controller;
    }

    /// <summary>
    /// Implements Execute for turning left
    /// </summary>
    public override void Execute()
    {
        //throw new System.NotImplementedException();

        _controller.Turn(BikeController.Direction.Left);
    }
}
