namespace git_links.UnitTests
{
    public class GitLinksServiceTests
    {
        private GitLinksService _service;

        [Fact]
        public void GetFeatureBranch_Replaces_ForwardSlash_With_Dash()
        {
            _service = new GitLinksService("https://blueprism.atlassian.net/browse/HUB-6295", "Create release/5.0.0 branch for hub-authenticationserver ", TaskTypes.Feature);
            var expected = "git checkout -b feature/HUB-6295-create-release-5.0.0-branch-for-hub-authenticationserver";
            var actual = _service.GetFeatureBranch();

            Assert.Equal(expected, actual);
        }
    }
}