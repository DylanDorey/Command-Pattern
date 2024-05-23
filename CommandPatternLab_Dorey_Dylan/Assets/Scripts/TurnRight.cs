/*
 * Author: [Dorey, Dylan]
 * Last Updated: [02/27/2024]
 * [A Command that makes the bike controller turn right]
 */

public class TurnRight : Command
{
    //reference to the bike controller class
    private BikeController _controller;

    //need a constructor - will need to pass a BikeController object to make a TurnRight
    public TurnRight(BikeController controller)
    {
        _controller = controller;
    }

    /// <summary>
    /// Implements Execute for turning right
    /// </summary>
    public override void Execute()
    {
        //throw new System.NotImplementedException();

        _controller.Turn(BikeController.Direction.Right);
    }
}
