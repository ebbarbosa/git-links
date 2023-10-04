using git.links;

namespace git_links
{
    public class GitLinksService
    {
        private string featureLink;
        private string featureMsg;
        private int index;
        private string typeOfTask;
        private string hub;

        public string FeatureLink => featureLink;

        public GitLinksService(string featureLink, string featureMsg, TaskTypes taskType)
        {
            this.featureLink = featureLink.Trim();
            this.featureMsg = featureMsg.Trim();

            this.index = featureLink.IndexOf("HUB");
            this.typeOfTask = taskType.ToString().ToLower() + "/";
            this.hub = "HUB" + featureLink.Substring(index + 3).ToLower();
        }

        public string GetCommitMessage()
        {
            return $"git commit -am \"{this.hub} - {this.featureMsg}\"";
        }

        public string GetFeatureBranch()
        {
            var featureMsgBranch = string.Join('-', this.featureMsg.Split(' '));
            return $"git checkout -b {this.typeOfTask}{this.hub.Sanitize()}-{featureMsgBranch.ToLower().Sanitize()}";
        }
    }


    
}
