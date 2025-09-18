namespace git_links.UnitTests
{
    public class GitLinksServiceTests
    {
        private GitLinksService _service;

        [Fact]
        public void GetFeatureBranch_Replaces_ForwardSlash_With_Dash()
        {
            _service = new GitLinksServiceBuilder().WithSeparator("HUB")
                .WithLink("https://blueprism.atlassian.net/browse/HUB-6295")
                .WithDescription("Create release/5.0.0 branch for hub-authenticationserver ")
                .WithType(TaskTypes.Feature)
                .Build();

            var expected = "git checkout -b feature/HUB-6295-create-release-5.0.0-branch-for-hub-authenticationserver";
            var actual = _service.GetFeatureBranch();

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void GetFeatureBranch_WhenSepartorNotInFeatureLink_ThrowsException()
        {

            var actual = Assert.Throws<ArgumentException>(() => new GitLinksServiceBuilder().WithSeparator("BPIAAPPS")
                .WithLink("https://blueprism.atlassian.net/browse/HUB-6295"));

            Assert.Equal(actual.Message, "Separator must be contained in the feature link (Parameter 'BPIAAPPS')");
        }
    }
}