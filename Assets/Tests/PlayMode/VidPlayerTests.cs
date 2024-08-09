using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.Video;

namespace Tests.PlayMode
{
    /// <summary>
    /// This class contains tests for the VidPlayer component.
    /// </summary>
    public class VidPlayerTests
    {
        private VidPlayer _vidPlayer;

        [SetUp]
        public void Setup()
        {
            // Setup a new GameObject with VidPlayer and VideoPlayer components for each test.
            GameObject go = new GameObject();
            _vidPlayer = go.AddComponent<VidPlayer>();
            _vidPlayer.videoPlayer = go.AddComponent<VideoPlayer>();
        }

        [TearDown]
        public void TearDown()
        {
            // Destroy the GameObject after each test.
            Object.Destroy(_vidPlayer.gameObject);
        }

        [UnityTest]
        public IEnumerator VideoIsPrepared_WhenFileExistsInStreamingAssets()
        {
            // Test if the video is prepared when the file exists in StreamingAssets.
            string videoFileName = "test.mp4";
            _vidPlayer.Prepare(videoFileName);

            while (!_vidPlayer.videoPlayer.isPrepared)
            {
                yield return null;
            }

            Assert.IsTrue(_vidPlayer.IsPrepared);
        }

        [Test]
        public void VideoIsNotPrepared_WhenFileDoesNotExistInStreamingAssets()
        {
            // Test if the video is not prepared when the file does not exist in StreamingAssets.
            _vidPlayer.Prepare("valid_file_path.mp4"); // Replace with a valid video file path

            LogAssert.Expect(LogType.Error, new System.Text.RegularExpressions.Regex(".*"));

            Assert.IsFalse(_vidPlayer.IsPrepared);
        }

        [UnityTest]
        public IEnumerator VideoPlaysSuccessfully_WhenFileExistsInStreamingAssets()
        {
            // Test if the video plays successfully when the file exists in StreamingAssets.
            _vidPlayer.Prepare("light.mp4");

            while (!_vidPlayer.videoPlayer.isPrepared)
            {
                yield return null;
            }

            _vidPlayer.Play();

            yield return new WaitForSeconds(1f); // Adjust the wait time based on the video duration

            Assert.IsTrue(_vidPlayer.videoPlayer.isPlaying);
        }

        [UnityTest]
        public IEnumerator VideoDoesNotPlay_WhenNotPrepared()
        {
            // Test if the video does not play when not prepared.
            _vidPlayer.Play();

            yield return new WaitForSeconds(1f); // Adjust the wait time based on the video duration

            Assert.IsFalse(_vidPlayer.videoPlayer.isPlaying);
        }
    }
}