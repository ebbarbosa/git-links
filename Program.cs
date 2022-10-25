using System;
using Cocona;
using git_links;

namespace git.links
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cocona parses command-line and executes a command.
            CoconaApp.Run<Program>(args);
        }

        public void Run([Argument] string featureLink, [Argument] string featureMsg, [Argument] TaskTypes taskType)
        {
            var gitLinksService = new GitLinksService(featureLink, featureMsg, taskType);

            Console.WriteLine(gitLinksService.FeatureLink);
            Console.WriteLine(gitLinksService.GetFeatureBranch());
            Console.WriteLine(gitLinksService.GetCommitMessage());
        }        
    }
}