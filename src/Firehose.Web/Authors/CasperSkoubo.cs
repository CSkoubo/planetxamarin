using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using Firehose.Web.Infrastructure;

namespace Firehose.Web
{
	public class CasperSkoubo : IAmACommunityMember, IFilterMyBlogPosts
	{
		public string FirstName => "Casper";
		public string LastName => "Skoubo";
		public string EmailAddress => "casper@pockets.dk";
		public string StateOrRegion => "Copenhagen, Denmark";
		public GeoPosition Position => new GeoPosition(55.6712474, 12.4907997);

		public string GitHubHandle => "CSkoubo";
		public string GravatarHash => "01081bfb9e67b20744e5b0bca6dc9b3e";
		public string TwitterHandle => "CSkoubo";
		public Uri WebSite => new Uri("http://www.pockets.dk");

		public string ShortBioOrTagLine => "Xamarin consultant @ Pocket Development. Presenter and organizer/group leader of the 'Xamarin developers in Denmark' user group.";

		public bool Filter(SyndicationItem item)
			=> item.Title.Text.ToLowerInvariant().Contains("xamarin") ||
			   item.Categories.Any(c => c.Name.Equals("xamarin", StringComparison.OrdinalIgnoreCase));

		public IEnumerable<Uri> FeedUris
		{
			get { yield return new Uri("http://pockets.dk/blog/feed/"); }
		}
	}
}
