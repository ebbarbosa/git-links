namespace git_links;

public class GitLinksService
{
    private readonly string featureLink;
    private readonly string featureMsg;
    private readonly string typeOfTask;
    private readonly string hub;

    public string FeatureLink => featureLink;

    public GitLinksService(string separator, string featureLink, string featureMsg, TaskTypes taskType, int index)
    {
        this.featureLink = featureLink.Trim();
        this.featureMsg = featureMsg.Trim();
        typeOfTask = taskType.ToString().ToLower() + "/";
        hub = separator + featureLink[(index + separator.Length)..].ToLower();
    }

    public string GetCommitMessage()
    {
        return $"git commit -am \"{hub} - {featureMsg}\"";
    }

    public string GetFeatureBranch()
    {
        var featureMsgBranch = string.Join('-', featureMsg.Split(' '));
        return $"git checkout -b {typeOfTask}{hub.Sanitize()}-{featureMsgBranch.ToLower().Sanitize()}";
    }
}
