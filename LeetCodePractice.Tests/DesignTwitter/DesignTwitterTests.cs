using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class DesignTwitterTests
{
    [Fact]
    public void Twitter_Example1_Works()
    {
        var twitter = new DesignTwitter();
        twitter.PostTweet(1, 5);
        var feed = twitter.GetNewsFeed(1);
        Assert.Equal(new List<int> { 5 }, feed);

        twitter.Follow(1, 2);
        twitter.PostTweet(2, 6);
        feed = twitter.GetNewsFeed(1);
        Assert.Equal(new List<int> { 6, 5 }, feed);

        twitter.Unfollow(1, 2);
        feed = twitter.GetNewsFeed(1);
        Assert.Equal(new List<int> { 5 }, feed);
    }

    [Fact]
    public void Twitter_MultipleUsers_FeedIsChronological()
    {
        var twitter = new DesignTwitter();
        twitter.PostTweet(1, 1);
        twitter.PostTweet(2, 2);
        twitter.PostTweet(1, 3);
        twitter.Follow(1, 2);
        var feed = twitter.GetNewsFeed(1);
        Assert.Equal(3, feed.Count);
        Assert.Equal(3, feed[0]); // newest first
        Assert.Equal(2, feed[1]);
        Assert.Equal(1, feed[2]);
    }

    [Fact]
    public void Twitter_Unfollow_RemovesFromFeed()
    {
        var twitter = new DesignTwitter();
        twitter.PostTweet(1, 10);
        twitter.Follow(2, 1);
        twitter.PostTweet(1, 20);
        twitter.Unfollow(2, 1);
        var feed = twitter.GetNewsFeed(2);
        Assert.Empty(feed);
    }
}


