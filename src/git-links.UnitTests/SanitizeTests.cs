using git.links;

namespace git_links.UnitTests
{
    public class SanitizeTests
    {
        [Fact]
        public void Sanitize_Replaces_BackSlash_With_Dash()
        {
            var actual = @"Create release\5.0.0 branch for hub-authenticationserver#$%&".Sanitize();

            var expected = "Create-release-5.0.0-branch-for-hub-authenticationserver";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Sanitize_Replaces_ForwardSlash_With_Dash()
        {
            var actual = "Create release/5.0.0 branch for hub-authenticationserver".Sanitize();

            var expected = "Create-release-5.0.0-branch-for-hub-authenticationserver";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Sanitize_Replaces_DuplicatedDashes_With_SingleDash()
        {
            var actual = "Create release/5.0.0 //----branch for hub-authenticationserver".Sanitize();

            var expected = "Create-release-5.0.0-branch-for-hub-authenticationserver";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Sanitize_Replaces_Parameters_And_Apostrophes()
        {
            var actual = "Create release/5.0.0 //----don´t replace;: - [{,{replace this}}]} don´t do it, don`t do it, don't do it- branch name".Sanitize();

            var expected = "Create-release-5.0.0-don-t-replace-replace-this-don-t-do-it-don-t-do-it-don-t-do-it-branch-name";

            Assert.Equal(expected, actual);

            actual = @"don\´t don\`t don\'t don\ t".Sanitize();

            expected = "don-t-don-t-don-t-don-t";

            Assert.Equal(expected, actual);
        }
    }
}