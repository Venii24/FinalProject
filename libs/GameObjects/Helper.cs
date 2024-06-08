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

            // Load dialog texts from JSON
            string jsonFilePath = Path.Combine("..", "libs", "dialog.json");
            string jsonString = File.ReadAllText(jsonFilePath);
            DialogTexts dialogTexts = JsonConvert.DeserializeObject<DialogTexts>(jsonString);

            // Initialize dialog nodes
            Dictionary<string, DialogNode> nodesDict = new Dictionary<string, DialogNode>();
            foreach (var nodeData in dialogTexts.Nodes)
            {
                nodesDict[nodeData.DialogID] = new DialogNode(nodeData.Text);
            }

            // Adding responses to nodes
            foreach (var nodeData in dialogTexts.Nodes)
            {
                DialogNode currentNode = nodesDict[nodeData.DialogID];
                foreach (var response in nodeData.Responses)
                {
                    currentNode.AddResponse(response.ResponseText, nodesDict[response.NextNodeID]);
                }
            }

            List<DialogNode> dialogNodes = new List<DialogNode>(nodesDict.Values);

            dialog = new Dialog(nodesDict["1"]); // Start dialog
        }
    }

    public class DialogTexts
    {
        public List<DialogTextNode> Nodes { get; set; }
    }

    public class DialogTextNode
    {
        public string DialogID { get; set; }
        public string Text { get; set; }
        public List<ResponseData> Responses { get; set; }
    }

    public class ResponseData
    {
        public string ResponseText { get; set; }
        public string NextNodeID { get; set; }
    }
}