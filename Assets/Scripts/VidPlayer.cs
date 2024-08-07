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

    private void Awake()
    {
        var videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
        Debug.Log(videoPath);

        videoPlayer.url = videoPath;
        videoPlayer.Prepare();
    }

    /// <summary>
    /// Plays the video.
    /// </summary>
    public void Play()
    {
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