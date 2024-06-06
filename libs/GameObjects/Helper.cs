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

            // Load dialog from JSON
            string jsonFilePath = @"C:\Users\stefa\OneDrive\Dokumente\FH StPoelten BCC\4. Semester\CD\FinalProject\FinalProject\libs\dialog.json";
            string jsonString = File.ReadAllText(jsonFilePath);
            List<DialogNode> dialogNodes = JsonConvert.DeserializeObject<List<DialogNode>>(jsonString);

            // Initialize dialog
            if (dialogNodes != null && dialogNodes.Count > 0)
            {
                Dialog = new Dialog(dialogNodes[0]);
            }
            else
            {
                throw new Exception("Failed to load dialog from JSON.");
            }
        }

        public Dialog Dialog { get; private set; }

        public virtual bool HasDialog()
        {
            return Dialog != null;

        }
    }
}