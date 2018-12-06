using System;
using System.Text;

namespace WordpressAutomation.Workflows
{
	public class PostCreator
	{
		public static void CreatePost()
		{
			NewPostPage.GoTo();

			PreviousTitle = CreateTitle();
			PreviousBody = CreateBody();

			NewPostPage.CreatePost(PreviousTitle).WithBody(PreviousBody).Publish();
		}

		public static string PreviousBody { get; set; }
		public static string PreviousTitle { get; set; }
		private static string CreateBody()
		{
			return CreateRandomString() + ", body";
		}

		private static string CreateRandomString()
		{
			var s = new StringBuilder();

			var random = new Random();
			var cycles = random.Next(5 + 1);

			for (int i = 0; i < cycles; i++)
			{
				s.Append(Words[random.Next(Words.Length)]);
				s.Append(" ");
				s.Append(Articles[random.Next(Articles.Length)]);
				s.Append(" ");
				s.Append(Words[random.Next(Words.Length)]);
				s.Append(" ");
			}

			return s.ToString();
		}

		private static string[] Words = new[]
		{
		"apple", "banana", "celery", "eggplant", "watermelon", "eat", "juice", "chop", "grow","yummy"
		};

		private static string[] Articles = new[]
		{
		"the", "an", "and", "a", "of", "to", "it", "as", "in", "on", "at"
		};

		private static string CreateTitle()
		{
			return CreateRandomString() + ", title";
		}

		public static void Initialize()
		{
			PreviousTitle = null;
			PreviousBody = null;
		}

		public static void Cleanup()
		{
			if (CreatedAPost)
				TrashPost();
		}

		private static void TrashPost()
		{
			ListPostsPage.TrashPost(PreviousTitle);
			Initialize();
		}

		protected static bool CreatedAPost 
		{  
		get { return !String.IsNullOrEmpty(PreviousTitle); }
		}

	}
}
