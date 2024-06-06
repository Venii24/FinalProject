using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace libs
{
    public class Helper : GameObject
    {
        public Helper() : base()
        {
            Type = GameObjectType.Helper;
            CharRepresentation = '?';
            Color = ConsoleColor.DarkGreen;
            HasDialogText = true;

            // Load dialog from JSON
            string jsonFilePath = Path.Combine("..", "libs", "dialog.json");
            string jsonString = File.ReadAllText(jsonFilePath);
            List<DialogNode> dialogNodes = JsonConvert.DeserializeObject<List<DialogNode>>(jsonString);

            // Initialize dialog
            if (dialogNodes != null && dialogNodes.Count > 0)
            {
                dialog = new Dialog(dialogNodes[0]); // Assuming the first node is the starting point
            }
            else
            {
                throw new Exception("Failed to load dialog from JSON.");
                Console.WriteLine("Failed to load dialog from JSON.");
            }


        }

        public Dialog dialog { get; private set; }

        // Override the HasDialog method
        public override bool HasDialog()
        {
            return dialog != null;
        }
    }
}