using System;
using Cocona;

namespace git.links
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cocona parses command-line and executes a command.
            CoconaApp.Run<Program>(args);
        }

        public enum TaskTypes
        {
            Bugfix,
            Feature
        };

        public void Run([Argument] string featureLink, [Argument] string featureMsg, [Argument] TaskTypes taskType)
        {
            var index = featureLink.IndexOf("HUB");
            var typeOfTask = taskType.Equals(TaskTypes.Feature) ? "feature/" : "bugfix/";
            var hub = "HUB" + featureLink.Substring(index + 3).ToLower();

            Console.WriteLine(featureLink);
            Console.WriteLine(GetFeatureBranch(typeOfTask + hub, featureMsg));
            Console.WriteLine(GetCommitMessage(hub, featureMsg));            
        }

        string GetCommitMessage(string hub, string featureMsg)
        {
            return $"{hub} - {featureMsg}";
        }

        string GetFeatureBranch(string hub, string featureMsg)
        {
            var featureMsgBranch = string.Join('-', featureMsg.Split(' '));
            return $"{hub}-{featureMsgBranch.ToLower()}";
        }
    }
}