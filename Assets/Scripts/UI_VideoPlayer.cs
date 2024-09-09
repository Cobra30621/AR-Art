using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

/// <summary>
/// A class for controlling a video player UI in a Unity game.
/// </summary>
public class UI_VideoPlayer : MonoBehaviour
{
    /// <summary>
    /// The VideoPlayer component for playing videos.
    /// </summary>
    [Required] public VideoPlayer videoPlayer;

    /// <summary>
    /// The GameObject for the main panel UI.
    /// </summary>
    [Required] public GameObject mainPanel;

    /// <summary>
    /// The RawImage component for displaying the video.
    /// </summary>
    [Required] public RawImage videoView;

    /// <summary>
    /// The Button component for closing the video player.
    /// </summary>
    [Required] public Button closeButton;

    /// <summary>
    /// A flag indicating whether a video is currently playing.
    /// </summary>
    public bool isPlaying { get; private set; }

    public string currentVideo { get; private set; }

    /// <summary>
    /// The VideoData scriptable object containing video data.
    /// </summary>
    [Required] [InlineEditor] public VideoData videoData;


    // Start is called before the first frame update
    private void Start()
    {
        // Add a listener to the close button
        closeButton.onClick.AddListener(Close);

        // Hide the main panel at the start
        mainPanel.SetActive(false);
    }

    /// <summary>
    /// Plays a video with the given video ID.
    /// </summary>
    /// <param name="videoId">The ID of the video to play.</param>
    [Button]
    public void PlayVideo(string videoId)
    {
        // Start the coroutine to prepare and play the video
        StartCoroutine(PrepareVideoCoroutine(videoId));
    }


    /// <summary>
    /// Coroutine to prepare and play the video.
    /// </summary>
    /// <param name="videoId">The ID of the video to prepare.</param>
    private IEnumerator PrepareVideoCoroutine(string videoId)
    {
        currentVideo = videoId;

        // Show the main panel
        mainPanel.SetActive(true);
        // Disable the video view until the video is prepared
        videoView.enabled = false;

        // Get the video path
        videoPlayer.url = GetVideoPath(videoId);
        // Prepare the video
        videoPlayer.Prepare();

        // Wait until the video is prepared
        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }

        // Set the aspect ratio based on the video type
        SetAspectRatio(videoData.IsLandscapeVideo(videoId));

        // Play the video
        videoPlayer.Play();
        // Enable the video view
        videoView.enabled = true;
        // Set the playing state
        isPlaying = true;
    }

    /// <summary>
    /// Gets the video path for the given video ID.
    /// </summary>
    /// <param name="videoId">The ID of the video.</param>
    /// <returns>The path of the video file.</returns>
    private string GetVideoPath(string videoId)
    {
        // Get the video file name from the VideoData
        string videoFileName = videoData.GetVideoFileName(videoId);

        // Combine the streaming assets path and the video file name to get the video path
        var videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
        Debug.Log(videoPath);

        return videoPath;
    }

    /// <summary>
    /// Sets the aspect ratio of the video player based on the video type.
    /// </summary>
    /// <param name="isLandscapeVideo">A flag indicating whether the video is landscape.</param>
    private void SetAspectRatio(bool isLandscapeVideo)
    {
        if (isLandscapeVideo)
        {
            videoPlayer.aspectRatio = VideoAspectRatio.FitVertically;
        }
        else
        {
            videoPlayer.aspectRatio = VideoAspectRatio.FitHorizontally;
        }
    }

    /// <summary>
    /// Closes the video player.
    /// </summary>
    public void Close()
    {
        // Stop the video
        videoPlayer.Stop();
        // Set the playing state
        isPlaying = false;
        // Hide the main panel
        mainPanel.SetActive(false);
    }
}