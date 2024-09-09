using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

/// <summary>
/// A scriptable object that stores video data.
/// </summary>
[CreateAssetMenu(fileName = "VideoData", menuName = "ScriptableObjects/VideoData", order = 1)]
public class VideoData : ScriptableObject
{
    [LabelText("影片清單")]
    [ValidateInput("VideoIdNotMultiple")]
    [InfoBox("影片檔案要放在 StreamingAssets 資料夾\n" +
             "影片 Id 要跟 ImageTracker 中 ImageTargets 的 id 相同")]
    public VideoEntry[] videos; // Array of video entries
    
    /// <summary>
    /// Gets the video file name for the given video id.
    /// </summary>
    /// <param name="videoId">The id of the video.</param>
    /// <returns>The file name of the video.</returns>
    public string GetVideoFileName(string videoId)
    {
        foreach (var videoEntry in videos)
        {
            if (videoEntry.videoId == videoId)
            {
                return videoEntry.fileName;
            }
        }
        
        Debug.LogError($"Video with name {videoId} not found.");
        return "";
    }

    /// <summary>
    /// Checks if the video is landscape.
    /// </summary>
    /// <param name="videoId">The id of the video.</param>
    /// <returns>True if the video is landscape, false otherwise.</returns>
    public bool IsLandscapeVideo(string videoId)
    {
        foreach (var video in videos)
        {
            if (video.videoId == videoId)
            {
                return video.isLandscapeVideo;
            }
        }

        Debug.LogError($"Video with name {videoId} not found.");
        return false;
    }

    /// <summary>
    /// Validates that video ids are not duplicated.
    /// </summary>
    /// <param name="videoEntries">Array of video entries.</param>
    /// <param name="errorMessage">Error message if validation fails.</param>
    /// <returns>True if validation passes, false otherwise.</returns>
    private bool VideoIdNotMultiple(VideoEntry[] videoEntries, ref string errorMessage)
    {
        HashSet<string> set = new HashSet<string>();
        
        foreach (var videoEntry in videoEntries)
        {
            if (set.Contains(videoEntry.videoId))
            {
                errorMessage = $"影片 ID '{videoEntry.videoId}' 重複";
                return false;
            }
            else
            {
                set.Add(videoEntry.videoId);
            }
        }
        
        return true;
    }
}

/// <summary>
/// Represents a video entry in the VideoData scriptable object.
/// </summary>
[System.Serializable]
public class VideoEntry
{
    [LabelText("影片 Id")]
    [ValidateInput("NotNull", 
        "Video ID cannot be null or empty.")]
    public string videoId; // The ID of the video
    
    [LabelText("影片檔案名稱")]
    [ValidateInput("NotNull", 
        "File name cannot be null or empty.")]
    public string fileName; // The file name of the video
    
    [LabelText("是橫向播放的影片")]
    public bool isLandscapeVideo;

    /// <summary>
    /// Validates that a string is not null or empty.
    /// </summary>
    /// <param name="info">The string to validate.</param>
    /// <returns>True if the string is not null or empty, false otherwise.</returns>
    private bool NotNull(string info)
    {
        return !string.IsNullOrEmpty(info);
    }
}