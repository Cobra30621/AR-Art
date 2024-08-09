# AR 藝術品專案

Cilab 與曹松清畫家合作設計的互動式畫展，使用手機拍攝藝術後，撥放對應的影片。

[Demo 影片](https://youtube.com/shorts/cEkPMk3ohgw?feature=share)

## 相關資訊

### 使用套件
- [Imagine WebAR - Image Tracker](https://assetstore.unity.com/packages/tools/camera/imagine-webar-image-tracker-240128)
  - 負責 AR 功能實作
  - 使用實驗室的 Google 帳號購買，如果要更新套件，請跟助理要帳號，然後用該 Google 帳號登入 Unity
- [Odin Inspector](https://assetstore.unity.com/packages/tools/utilities/odin-inspector-and-serializer-89041)
  - 提供 Unity 編輯器(Inspector)許多方便的功能，如讓變數顯示中文、資料格式驗證等等


### 上架平台
- itch.io: https://cobra3279.itch.io/art-ar
- 專案 QR Code :

![qrcode-generator](https://hackmd.io/_uploads/rJLNINAFC.png)

- [使用者文件](https://hackmd.io/@Cobra3279/SkG_wSQ5C)
- [README 用圖片放置區](https://hackmd.io/@Cobra3279/r1uxNBQ50)



## 內容說明

### 場景
- Video Player.scene: 相機掃描圖片後，顯示全螢幕的影片
  - 現在是用這個
- Object Tracker.scene: 相機掃描圖片後，在畫作上顯示影片


### 新增影片
1. 在 Assets/StreamingAssets 資料夾中放入影片檔案
2. 在 Assets/ScriptableObject/VideoData 檔案中，加入對應的 `影片 Id` 與影片檔案名稱
 ![image](https://hackmd.io/_uploads/BJmcyHm9C.png)
3. 在 Assets/Imagine/ImageTracker/Resources/ImageTrackerGlobalSettings.asset 中，將 `影片 Id` 與對應的圖片放入 ImageTarget Infos 中
![image](https://hackmd.io/_uploads/SJLlgSm5A.png)
4. 在場景的 ImageTracker 中，將 `影片 Id` 加入 ImageTargets 中
 ![image](https://hackmd.io/_uploads/ryxueSQ50.png)

### 輸入前驗證

點擊 Tools/Odin/Validator 可以打開驗證頁面

![image](https://hackmd.io/_uploads/Bkt3gBmcA.png)

點擊執行，可以檢查專案有沒有錯誤。
如下圖最後兩個為忘記把物件建立參考

![image](https://hackmd.io/_uploads/H1eEWS75C.png)

- [詳情可參考](https://odininspector.com/tutorials/odin-validator/getting-started-with-odin-validator)

## 相關教學
- 在 WebGL 撥放影片
  - [How to Play a Video in Unity WebGL (Simple)](https://www.youtube.com/watch?v=9UE3hLSHMTE)
- [【教學】Unity 學習方向指引](https://hackmd.io/t8psZwSOQo29LwPkpmLcDA?view)
  


