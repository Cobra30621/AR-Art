using System.Collections;
using NUnit.Framework;
using Tests.Tools;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.PlayMode
{
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
        public IEnumerator PlayVideo_ShouldStartNewVideo_IfNoVideoIsPlaying()
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
        }
    }
}