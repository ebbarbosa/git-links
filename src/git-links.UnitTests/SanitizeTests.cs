using git.links;

namespace git_links.UnitTests
{
    public class SanitizeTests
    {
        [Fact]
        public void Sanitize_Replaces_BackSlash_With_Dash()
        {
            var actual = @"Create release\5.0.0 branch for hub-authenticationserver#$%&".Sanitize();

            var expected = "Create-release-5.0.0-branch-for-hub-authenticationserver----";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Sanitize_Replaces_ForwardSlash_With_Dash()
        {
            var actual = "Create release/5.0.0 branch for hub-authenticationserver".Sanitize();

            var expected = "Create-release-5.0.0-branch-for-hub-authenticationserver";

            Assert.Equal(expected, actual);
        }
    }
}