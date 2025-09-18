using System;

namespace git_links
{
    public class GitLinksServiceBuilder : IAddLinkGitLinksServiceBuilder, IAddDescriptionGitLinksServiceBuilder, IAddTypeGitLinksServiceBuilder
    {
        private string separator;
        private string link;
        private int index;
        private string description;
        private TaskTypes taskType;

        public GitLinksServiceBuilder() { }

        public IAddLinkGitLinksServiceBuilder WithSeparator(string separator)
        {
            this.separator = separator;
            return this;
        }

        public IAddDescriptionGitLinksServiceBuilder WithLink(string link)
        {
            this.link = link;

            index = link.IndexOf(separator);

            if (index < 0)
            {
                throw new ArgumentException("Separator must be contained in the feature link", separator);
            }

            return this;
        }

        public IAddTypeGitLinksServiceBuilder WithDescription(string description)
        {
            this.description = description;
            return this;
        }

        public GitLinksServiceBuilder WithType(TaskTypes taskType)
        {
            this.taskType = taskType;
            return this;
        }

        public GitLinksService Build()
        {
            return new GitLinksService(separator, link, description, taskType, index);
        }
    }


}
