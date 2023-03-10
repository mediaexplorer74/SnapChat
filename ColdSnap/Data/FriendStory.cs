using SnapDotNet.Data.ApiResponses;
using System;
using System.Diagnostics.Contracts;

namespace SnapDotNet.Data
{
	/// <summary>
	/// Represents a story posted by a friend.
	/// </summary>
	public class FriendStory
		: Story
	{
		internal FriendStory() { }

		/// <summary>
		/// Gets a boolean value indicating whether the user has viewed this story.
		/// </summary>
		public bool Viewed
		{
			get { return _viewed; }
			private set { SetValue(ref _viewed, value); }
		}
		private bool _viewed;

		/// <summary>
		/// Gets the friend that posted this story.
		/// </summary>
		public Friend Owner
		{
			get { return _owner; }
			private set { SetValue(ref _owner, value); }
		}
		private Friend _owner;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="response"></param>
		/// <returns></returns>
		[Pure]
		internal static FriendStory CreateFromResponse(Friend owner, StoryMetadataResponse response)
		{
			//Contract.Requires<ArgumentNullException>(response != null);

			var friendStory = new FriendStory();
			friendStory.UpdateFromResponse(response);
			friendStory.Owner = owner;
			return friendStory;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="response"></param>
		internal void UpdateFromResponse(StoryMetadataResponse response)
		{
			//Contract.Requires<ArgumentNullException>(response != null);

			Viewed = response.Viewed;
			base.UpdateFromResponse(response.Story);
		}
	}
}
