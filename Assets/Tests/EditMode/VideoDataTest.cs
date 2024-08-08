using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.EditMode
{
    public class VideoDataTest
    {
        [Test]
        public void GetVideoFileName_VideoIdCaseSensitive_ReturnsCorrectFileName()
        {
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
    }
}