using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

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
    public void VaoGoogleDrive ()
    {
        Application.OpenURL("https://drive.google.com/file/d/1fL_xI4mEwSlK4OzDTvMPrULVUfWLC4Zy/view?usp=sharing"); 
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
	}

	IEnumerator CaptureIt()
	{
		// string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
		string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
		string fileName = "Screenshot-" + timeStamp + ".png";
		// string pathToSave = Application.persistentDataPath+"/"+fileName;
		string pathToSave = fileName;
		ScreenCapture.CaptureScreenshot(pathToSave);
		yield return new WaitForEndOfFrame();
		Instantiate (blink, new Vector2(0f, 0f), Quaternion.identity);
	}
    
    
}
