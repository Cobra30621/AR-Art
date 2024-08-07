using UnityEngine;

/// <summary>
/// A scriptable object that stores video data.
/// </summary>
[CreateAssetMenu(fileName = "VideoData", menuName = "ScriptableObjects/VideoData", order = 1)]
public class VideoData : ScriptableObject
{
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
}

/// <summary>
/// Represents a video entry in the VideoData scriptable object.
/// </summary>
[System.Serializable]
public class VideoEntry
{
    public string videoId; // The ID of the video
    public string fileName; // The file name of the video
}