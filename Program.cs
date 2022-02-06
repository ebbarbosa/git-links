using System;
using System.Linq;

namespace git_links
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length >= 2)
            {
                var featureLink = args[0];
                var index = featureLink.IndexOf("HUB");
                var hub = featureLink.Substring(index);
                var featureMsg = args[1];

                Console.WriteLine(featureLink);
                Console.WriteLine(GetFeatureBranch(hub, featureMsg));
                Console.WriteLine(GetCommitMessage(hub, featureMsg));
            }
        }

        private static string GetCommitMessage(string hub, string featureMsg)
        {
            return $"{hub} - {featureMsg}";
        }

        private static string GetFeatureBranch(string hub, string featureMsg)
        {
            var featureMsgBranch = string.Join('-', featureMsg.Split(' '));
            return $"{hub}-{featureMsgBranch}";
        }
    }
}
