using Cocona;
using System;

namespace git_links
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Cocona parses command-line and executes a command.
            CoconaApp.Run<Program>(args);
        }

        [Command]
        public void Run([Argument] string separator, [Argument] string taskLink, [Argument] string taskDesc, [Argument] TaskTypes taskType)
        {
            var gitLinksService = new GitLinksServiceBuilder().WithSeparator(separator)
                .WithLink(taskLink)
                .WithDescription(taskDesc)
                .WithType(taskType)
                .Build();

            Console.WriteLine(gitLinksService.FeatureLink);
            Console.WriteLine(gitLinksService.GetFeatureBranch());
            Console.WriteLine(gitLinksService.GetCommitMessage());
        }
    }
}