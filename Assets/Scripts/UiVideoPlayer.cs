using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class UIVideoPlayer : MonoBehaviour
{
    public string videoId;
    public VideoPlayer videoPlayer;
    public GameObject uiPanel; // UI 視窗
    public RawImage rawImage;
    
    public Button closeButton;

    private bool isPlaying = false;

    public VideoData videoData;


    private void Start()
    {
        // 設置按鈕點擊事件
        closeButton.onClick.AddListener(Close);

        // 初始化時隱藏 UI 視窗
        uiPanel.SetActive(false);
    }

    [ContextMenu("TestPlayVideo")]
    public void TestPlayVideo()
    {
        PlayVideo(videoId);
    }
    
    public void PlayVideo(string videoId)
    {
        if (isPlaying)
        {
            return;
        }
        
        // 顯示 UI 視窗
        uiPanel.SetActive(true);
        rawImage.enabled = false;
        
        this.videoId = videoId;
        string videoFileName = GetVideoFileName(videoId);
        if (string.IsNullOrEmpty(videoFileName))
        {
            Debug.LogError("Video file not found for video name: " + videoId);
            return;
        }

        var videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
        Debug.Log(videoPath);
        
        videoPlayer.url = videoPath;
        videoPlayer.Prepare();
        videoPlayer.prepareCompleted += OnVideoPrepared;
        
    }

    private string GetVideoFileName(string videoName)
    {
        foreach (var videoEntry in videoData.videos)
        {
            if (videoEntry.videoId == videoName)
            {
                return videoEntry.fileName;
            }
        }
        return null;
    }


    private void OnVideoPrepared(VideoPlayer source)
    {
        videoPlayer.Play();
        rawImage.enabled = true;
        isPlaying = true;
    }

    private void TogglePlayPause()
    {
        if (isPlaying)
        {
            videoPlayer.Pause();
        }
        else
        {
            videoPlayer.Play();
        }
        isPlaying = !isPlaying;
    }

    private void Stop()
    {
        videoPlayer.Stop();
        isPlaying = false;
    }

    private void Close()
    {
        videoPlayer.Stop();
        isPlaying = false;
        uiPanel.SetActive(false);
    }


}