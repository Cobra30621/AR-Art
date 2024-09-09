using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.EditMode
{
    /// <summary>
    /// This class contains tests for the VideoData class in the Tests.EditMode namespace.
    /// </summary>
    public class VideoDataTest
    {
        [Test]
        public void GetVideoFileName_VideoIdCaseSensitive_ReturnsCorrectFileName()
        {
            // Tests if the GetVideoFileName method returns the correct file name for a given video ID (case sensitive).
            VideoData videoData = ScriptableObject.CreateInstance<VideoData>();
            videoData.videos = new VideoEntry[]
            {
                new VideoEntry { videoId = "1", fileName = "video1.mp4" },
                new VideoEntry { videoId = "2", fileName = "video2.mp4" }
            };

            string result = videoData.GetVideoFileName("1");
            Assert.AreEqual("video1.mp4", result);

            result = videoData.GetVideoFileName("2");
            Assert.AreEqual("video2.mp4", result);

            result = videoData.GetVideoFileName("1");
            Assert.AreNotEqual("video2.mp4", result);
        }


        [Test]
        public void GetVideoFileName_VideoIdNotFound_LogsErrorAndReturnsEmptyString()
        {
            // Tests if the GetVideoFileName method logs an error and returns an empty string when the video ID is not found.
            VideoData videoData = ScriptableObject.CreateInstance<VideoData>();
            videoData.videos = new VideoEntry[]
            {
                new VideoEntry { videoId = "1", fileName = "video1.mp4" },
                new VideoEntry { videoId = "2", fileName = "video2.mp4" }
            };

            string result = videoData.GetVideoFileName("3");

            LogAssert.Expect(LogType.Error, new System.Text.RegularExpressions.Regex(".*"));
            Assert.AreEqual("", result);
        }

        [Test]
        public void IsLandscapeVideo_VideoIdExistsAndIsLandscape_ReturnsTrue()
        {
            // Arrange
            VideoData videoData = ScriptableObject.CreateInstance<VideoData>();
            videoData.videos = new VideoEntry[]
            {
                new VideoEntry { videoId = "1", fileName = "video1.mp4", isLandscapeVideo = true },
                new VideoEntry { videoId = "2", fileName = "video2.mp4", isLandscapeVideo = false }
            };

            // Act
            bool result = videoData.IsLandscapeVideo("1");

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsLandscapeVideo_VideoIdExistsButIsNotLandscape_ReturnsFalse()
        {
            // Arrange
            VideoData videoData = ScriptableObject.CreateInstance<VideoData>();
            videoData.videos = new VideoEntry[]
            {
                new VideoEntry { videoId = "1", fileName = "video1.mp4", isLandscapeVideo = false },
                new VideoEntry { videoId = "2", fileName = "video2.mp4", isLandscapeVideo = true }
            };

            // Act
            bool result = videoData.IsLandscapeVideo("1");

            // Assert
            Assert.IsFalse(result);
        }
    }
}