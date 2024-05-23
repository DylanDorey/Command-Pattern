/*
 * Author: [Dorey, Dylan]
 * Last Updated: [02/27/2024]
 * [A Command that toggles the turbo mode of the bike controller]
 */

public class ToggleTurbo : Command
{
    //reference to the bike controller class
    private BikeController _controller;

    //need a constructor - will need to pass a BikeController object to make a ToggleTurbo
    public ToggleTurbo(BikeController controller)
    {
        _controller = controller;
    }

    /// <summary>
    /// Implements Execute for toggling the turbo
    /// </summary>
    public override void Execute()
    {
        //throw new System.NotImplementedException();
        _controller.ToggleTurbo();
    }
}
