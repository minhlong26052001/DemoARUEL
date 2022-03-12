using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;
using UnityEngine.Events;
using UnityEditor;

public class exitscript : MonoBehaviour
{
    // public void QuitTheARApp ()
    // {
    //     Application.Quit();        
    // }
    public void VaoFacebookPage ()
    {
        Application.OpenURL("fb://page/449549088478520");   
        // Application.OpenURL("fb://profile/100040182245866");   
    }
    public void GoiDienThoai ()
    {
        Application.OpenURL("tel:+84852197589"); 
    }
    public void VaoCHPLAY()
    {
        Application.OpenURL("https://play.google.com/store/search?q=lien%20minh%20toc%20chien&hl=vi&gl=VN");

        // dòng dưới cũng được nhỉ?
        // Application.OpenURL("https://play.google.com/store/apps/details?id=com.riotgames.league.wildriftvn");
    }
    public void VaoGoogleDrive ()
    {
        // Application.OpenURL("https://drive.google.com/file/d/1fL_xI4mEwSlK4OzDTvMPrULVUfWLC4Zy/view?usp=sharing");

        // Application.OpenURL("https://bit.ly/35ePwZb");
        // Application.OpenURL("https://drive.google.com/file/d/1WIPHwxGwsZ6wBgp14BUsJTlw7q9PrTZE/view");
        Application.OpenURL("https://drive.google.com/file/d/1WIPHwxGwsZ6wBgp14BUsJTlw7q9PrTZE/view?usp=sharing");
    }
    public void VaoZalo ()
    {
        // Application.OpenURL("https://zalo.me/0852197589"); 
        Application.OpenURL("https://zalo.me/380144590661625516?src=qr"); 
    }
    public void VaoInstagram ()
    {
        Application.OpenURL("https://www.instagram.com/youth.uel/"); 
    }
    public void VaoCNSV ()
    {
        Application.OpenURL("https://ctsv.uel.edu.vn/Resources/Docs/SubDomain/ctsv/Ho%20so%20-%20Bieu%20mau/STSV%202021%20v3.pdf"); 
    }
    public void VaoYoutube ()
    {
        Application.OpenURL("https://www.youtube.com/c/UELChannel"); 
    }
    public void VaoVideoYoutube ()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=4ngZfTM6psY&ab_channel=SuperTeo"); 
    }
    public void VaoFacebookVideo ()
    {
        Application.OpenURL("https://www.facebook.com/157253694313645/videos/1740263899493054"); 
    }
    public void VaoFacebookPost ()
    {
        Application.OpenURL("https://www.facebook.com/20531316728/posts/10154009990506729"); 
    }
    public void VaoUELEDUVNCAMNANGSINHVIEN ()
    {
        Application.OpenURL("https://uel.edu.vn/sotaysinhvien/"); 
    }
    public void VaoTikTok ()
    {
        Application.OpenURL("https://www.tiktok.com/@uelofficial"); 
    }
    public void VaoMessengerUEL ()
    {
        Application.OpenURL("https://m.me/uel.edu.vn"); 
    }
    public void VaoTrangWebTrangChuUEL ()
    {
        Application.OpenURL("https://www.uel.edu.vn"); 
    }
    public void BatFlashLight ()
    {
        CameraDevice.Instance.SetFlashTorchMode(true);
    }
    public void TatFlashLight ()
    {
        CameraDevice.Instance.SetFlashTorchMode(false);
    }
    // public CapTureAndSave captureAndSave;
    // public void chupTamHinh ()
    // {
    //     // string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
	// 	// string fileName = "Screenshot " + timeStamp + ".png";
	// 	// string pathToSave = Application.persistentDataPath+"/"+fileName;
	// 	// ScreenCapture.CaptureScreenshot(pathToSave);

    //     // captureAndSave.CapTureAndSaveToAlbum();

    //     // StartCoroutine(TakeAndSaveScreenshot());

    //     // string folderPath = Directory.GetCurrentDirectory() + "/Screenshots/";
    //     string folderPath = "/Screenshots/";
 
    //     if (!System.IO.Directory.Exists(folderPath))
    //     {
    //         System.IO.Directory.CreateDirectory(folderPath);
    //     }

    //     var screenshotName ="Screenshot_" + System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ".png";
    //     ScreenCapture.CaptureScreenshot(System.IO.Path.Combine(folderPath, screenshotName));
    // }
    // IEnumerator TakeAndSaveScreenshot()
    // {

    //     yield return new WaitForEndOfFrame();

    //     Texture2D screenImage = new Texture2D(Screen.width, Screen.height);
    //     //Get Image from screen
    //     screenImage.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
    //     screenImage.Apply();
    //     //Convert to png
    //     byte[] imageBytes = screenImage.EncodeToPNG();

    //     //Save image to gallery
    //     string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
	// 	string fileName = "Screenshot " + timeStamp + ".png";
    //     NativeGallery.SaveImageToGallery(imageBytes, "Pictures", fileName, null);
    // }
    [SerializeField]
	GameObject blink;

	public void TakeAShot()
	{
		StartCoroutine ("CaptureIt");
        // string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
		// string fileName = "Screenshot-" + timeStamp + ".png";
        // // AndroidJavaClass jc = new AndroidJavaClass("android.os.Environment") ;
        // // string pathName = jc.CallStatic<AndroidJavaObject>("getExternalStorageDirectory").Call<string>("DIRECTORY_DCIM");
		// // string pathName = Environment.getExternalStorageDirectory() + "/" + Environment.DIRECTORY_DCIM + "/";
        // // Environment.getExternalStorageDirectory() + "/" + Environment.DIRECTORY_DCIM + "/"
		// // string pathName = "/Bộ nhớ trong/DCIM/Screenshots/";
		// // string pathName = "DCIM/Screenshots/";
		// // string pathName = "/Internal storage/DCIM/Screenshots/";
		// string pathName = "/storage/emulated/0/DCIM/Screenshot/";
		// // string pathName = GetAndroidExternalStoragePath();
        
        // ScreenCapture.CaptureScreenshot(pathName+fileName);
        // // ScreenCapture.CaptureScreenshot(pathName+"/Camera/"+fileName);
        // // Debug.Log(pathName);

        
	}

	IEnumerator CaptureIt()
	{
		// string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
		string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
		string fileName = "Screenshot-" + timeStamp + ".png";
		// string pathToSave = Application.persistentDataPath+"/"+fileName;
        string GALLERY_PATH = "/../../../../DCIM/Camera";
		// string pathToSave = GALLERY_PATH;

        // if (!System.IO.Directory.Exists(Application.persistentDataPath + GALLERY_PATH))
            // System.IO.Directory.CreateDirectory(Application.persistentDataPath + GALLERY_PATH);
            
		string pathToSave = Application.persistentDataPath + GALLERY_PATH;
		ScreenCapture.CaptureScreenshot(pathToSave + "/" + fileName);

		// ScreenCapture.CaptureScreenshot(Application.persistentDataPath + "/LastImage.png");
        // System.IO.File.Copy(Application.persistentDataPath + "/LastImage.png", Application.persistentDataPath + GALLERY_PATH + "/" + fileName);

        // ShowToast("Ảnh đã được lưu thành công!");
		yield return new WaitForEndOfFrame();
		Instantiate (blink, new Vector2(0f, 0f), Quaternion.identity);
        // RefreshGallery(Application.persistentDataPath + GALLERY_PATH + "/" + fileName);


        // System.DateTime now = System.DateTime.Now;
        // string fileName = "Video_" + now.Year + "_" + now.Month + "_" + now.Day + "_" + now.Hour + "_" + now.Minute + "_" + now.Second + ".mp4";
        // while (!System.IO.File.Exists(Application.persistentDataPath + "/" + VIDEO_NAME + ".mp4"))
        //     yield return null;
        // if (!System.IO.Directory.Exists(Application.persistentDataPath + GALLERY_PATH))
        //     System.IO.Directory.CreateDirectory(Application.persistentDataPath + GALLERY_PATH);
        // System.IO.File.Copy(Application.persistentDataPath + "/" + VIDEO_NAME + ".mp4", Application.persistentDataPath + GALLERY_PATH + "/" + fileName);
        // ShowToast("Video is saved to Gallery");
        // yield return null;
        // RefreshGallery(Application.persistentDataPath + GALLERY_PATH + "/" + fileName);

        // Debug.Log(pathToSave);
        // FileUtil.MoveFileOrDirectory(pathToSave, "/storage/emulated/0/DCIM/Screenshots/"+fileName);
        // MoveSomething(pathToSave, "/storage/emulated/0/DCIM/Screenshots/"+fileName);
	}
    // public static void ShowToast(string message)
    // {
    //     AndroidJavaObject currentActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
    //     currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
    //     {
    //         new AndroidJavaClass("android.widget.Toast").CallStatic<AndroidJavaObject>("makeText", currentActivity.Call<AndroidJavaObject>("getApplicationContext"), new AndroidJavaObject("java.lang.String", message), 0).Call("show");
    //     }));
    // }
    // public static void RefreshGallery(string path)
    // {
    //     using(AndroidJavaClass javaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer")){
    //     javaClass.GetStatic<AndroidJavaObject>("currentActivity").Call("refreshGallery", path);
    // }
    // [MenuItem("Example/Move Something")]
    // static void MoveSomething(string a, string b)
    // {
    //     FileUtil.MoveFileOrDirectory(a, b);
    // }
    // private string GetAndroidExternalStoragePath()
    // {
    //     if (Application.platform != RuntimePlatform.Android)
    //         return Application.persistentDataPath;

    //     var jc = new AndroidJavaClass("android.os.Environment");
    //     var path = jc.CallStatic<AndroidJavaObject>("getExternalStoragePublicDirectory", 
    //         jc.GetStatic<string>("DIRECTORY_DCIM"))
    //         .Call<string>("getAbsolutePath");
    //     return path;
    // }
}
