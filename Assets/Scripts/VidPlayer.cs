using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

/// <summary>
/// A class for controlling a video player in a Unity game.
/// </summary>
public class VidPlayer : MonoBehaviour
{
    /// <summary>
    /// The name of the video file to play.
    /// </summary>
    public string videoFileName;

    /// <summary>
    /// The VideoPlayer component for playing the video.
    /// </summary>
    public VideoPlayer videoPlayer;

    public bool preparedOnAwake;

    public bool IsPrepared { get; private set; }


    private void Awake()
    {
        IsPrepared = false;

        if (preparedOnAwake)
            Prepare(videoFileName);
    }

    public void Prepare(string fileName)
    {
        var videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, fileName);
        Debug.Log(videoPath);

        // Check if the video file exists
        if (System.IO.File.Exists(videoPath))
        {
            videoPlayer.url = videoPath;
            videoPlayer.Prepare();

            IsPrepared = true;
        }
        else
        {
            Debug.LogError($"Video file not found: {videoPath}");
            IsPrepared = false;
        }
    }

    /// <summary>
    /// Plays the video.
    /// </summary>
    public void Play()
    {
        if (!IsPrepared)
            videoPlayer.Play();
    }

    /// <summary>
    /// Pauses the video.
    /// </summary>
    public void Pause()
    {
        videoPlayer.Pause();
    }
}