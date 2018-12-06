using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;
using WordpressAutomation.Workflows;

namespace WordpressTests.PostsTests
{
	[TestClass]
	public class AllPostsTests : WordpressTests
	{
		//Added post show up in All Posts
		//Can Trash a post

		[TestMethod]
		public void Added_Posts_ShowUp()
		{
			ListPostsPage.GoTo(PostType.Posts);
			ListPostsPage.StoreCount();

			PostCreator.CreatePost();

			ListPostsPage.GoTo(PostType.Posts);
			Assert.AreEqual(ListPostsPage.PreviousPostCount + 1, ListPostsPage.CurrentPostCount, "Count of posts did not increase");

			Assert.IsTrue(ListPostsPage.DoesPostExistWithTitle(PostCreator.PreviousTitle));

			ListPostsPage.TrashPost(PostCreator.PreviousTitle);
			Assert.AreEqual(ListPostsPage.PreviousPostCount, ListPostsPage.CurrentPostCount, "Could not trash the post");
		}


		//Can Search posts
		[TestMethod]

		public void Can_Search_Posts()
		{

			PostCreator.CreatePost();

			ListPostsPage.SearchForPost(PostCreator.PreviousTitle);

			Assert.IsTrue(ListPostsPage.DoesPostExistWithTitle(PostCreator.PreviousTitle));

		}

	}
}
