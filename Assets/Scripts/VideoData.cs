using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "VideoData", menuName = "ScriptableObjects/VideoData", order = 1)]
public class VideoData : ScriptableObject
{
    public VideoEntry[] videos;
}

[System.Serializable]
public class VideoEntry
{
    public string videoId; // 使用字串來指定影片名稱
    public string fileName; // 影片檔案名稱
}