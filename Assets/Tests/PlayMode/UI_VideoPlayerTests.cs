using System.Collections;
using NUnit.Framework;
using Tests.Tools;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.PlayMode
{
    /// <summary>
    /// Tests for the UI_VideoPlayer component.
    /// </summary>
    public class UI_VideoPlayerTests
    {
        private Canvas _canvas;
        private UI_VideoPlayer _uiVideoPlayer;

        [SetUp]
        public void SetUp()
        {
            _canvas = new GameObject().AddComponent<Canvas>();

            var testReference = TestHelper.GetTestReference();
            _uiVideoPlayer = Object.Instantiate(testReference.UIVideoPlayerPrefab, _canvas.transform);
        }

        [UnityTest]
        public IEnumerator PlayVideo_ShouldStartNewVideo()
        {
            // Act
            _uiVideoPlayer.PlayVideo("test");

            while (!_uiVideoPlayer.videoPlayer.isPrepared)
            {
                yield return null;
            }

            yield return new WaitForSeconds(1f); // Adjust the wait time based on the video duration

            // Assert
            Assert.IsTrue(_uiVideoPlayer.isPlaying);
            Assert.IsTrue(_uiVideoPlayer.mainPanel.activeSelf);
            Assert.AreEqual("test", _uiVideoPlayer.currentVideo);
        }
        
        [UnityTest]
        public IEnumerator PlayVideo_KeepSameVideo_IfVideoIsAlreadyPlaying()
        {
            // Arrange
            _uiVideoPlayer.PlayVideo("test");

            while (!_uiVideoPlayer.videoPlayer.isPrepared)
            {
                yield return null;
            }
            

            // Act
            _uiVideoPlayer.PlayVideo("anotherTest");

            yield return new WaitForSeconds(1f); // Adjust the wait time based on the video duration

            // Assert
            Assert.AreEqual("test", _uiVideoPlayer.currentVideo);
        }

        [UnityTest]
        public IEnumerator Close_ShouldCloseMainPanelAndStopVideoPlayer_IfVideoIsPlaying()
        {
            // Arrange
            _uiVideoPlayer.PlayVideo("test");

            while (!_uiVideoPlayer.videoPlayer.isPrepared)
            {
                yield return null;
            }

            // Act
            _uiVideoPlayer.Close();

            yield return new WaitForSeconds(1f); // Adjust the wait time based on the video duration

            // Assert
            Assert.IsFalse(_uiVideoPlayer.isPlaying);
            Assert.IsFalse(_uiVideoPlayer.mainPanel.activeSelf);
        }
    }
}