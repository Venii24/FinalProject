namespace libs
{
    public class Helper : GameObject
    {
        public Helper() : base()
        {

            Type = GameObjectType.Helper;
            CharRepresentation = '?';
            Color = ConsoleColor.DarkGreen;

             //TODO Import and add those from JSON
                    DialogNode node1 = new DialogNode("Hello, do you need some help?");
                    DialogNode node2 = new DialogNode("Sure, did you already find the key?");
                    DialogNode node3 = new DialogNode("You should look for the key first. It is hidden in the room, then you can open the door.");
                    DialogNode node4 = new DialogNode("Great! Look for the door and open it with the key.");
                    DialogNode node5 = new DialogNode("Goodbye!");

                    // Adding responses to nodes
                    node1.AddResponse("Yes please, I do not know what to do", node2);
                    node1.AddResponse("No everything is fine, thanks", node5);

                    node2.AddResponse("Yes", node4);
                    node2.AddResponse("No", node3);

                    node3.AddResponse("Okay, goodbye.", node5);
                    node4.AddResponse("Thanks!", node5);

                    dialogNodes.Add(node1);
                    dialogNodes.Add(node2);
                    dialogNodes.Add(node3);
                    dialogNodes.Add(node4);
                    dialogNodes.Add(node5);

                    dialog = new Dialog(node1);
        }
    }
}