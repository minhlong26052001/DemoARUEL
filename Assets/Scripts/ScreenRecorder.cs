using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Protection level: dangerous permissions 2015/11/25
// http://developer.android.com/intl/ja/reference/android/Manifest.permission.html
public enum AndroidPermission
{
    ACCESS_COARSE_LOCATION,
    ACCESS_FINE_LOCATION,
    ADD_VOICEMAIL,
    BODY_SENSORS,
    CALL_PHONE,
    CAMERA,
    GET_ACCOUNTS,
    PROCESS_OUTGOING_CALLS,
    READ_CALENDAR,
    READ_CALL_LOG,
    READ_CONTACTS,
    READ_EXTERNAL_STORAGE,
    READ_PHONE_STATE,
    READ_SMS,
    RECEIVE_MMS,
    RECEIVE_SMS,
    RECEIVE_WAP_PUSH,
    RECORD_AUDIO,
    SEND_SMS,
    USE_SIP,
    WRITE_CALENDAR,
    WRITE_CALL_LOG,
    WRITE_CONTACTS,
    WRITE_EXTERNAL_STORAGE
}

namespace Recorder
{
    public class ScreenRecorder : MonoBehaviour
    {
        private const float SCREEN_WIDTH = 720f;
        private const string VIDEO_NAME = "Record", GALLERY_PATH = "/../../../../DCIM/VideoRecorders";
        public static UnityAction onAllowCallback, onDenyCallback, onDenyAndNeverAskAgainCallback;
#if UNITY_ANDROID && !UNITY_EDITOR
    private AndroidJavaObject androidRecorder;
#endif
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
#if UNITY_ANDROID && !UNITY_EDITOR
        using (AndroidJavaClass unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            androidRecorder = unityClass.GetStatic<AndroidJavaObject>("currentActivity");
            int width = (int)(Screen.width > SCREEN_WIDTH ? SCREEN_WIDTH : Screen.width);
            int height = Screen.width > SCREEN_WIDTH ? (int)(Screen.height * SCREEN_WIDTH / Screen.width) : Screen.height;
            androidRecorder.Call("setupVideo", width, height,(int)(1f * width * height / 100 * 240 * 7), 30);
            androidRecorder.Call("setCallback","AndroidUtils","VideoRecorderCallback");
        }
#endif
        }
        private void OnDestroy()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
    androidRecorder.Call("cleanUpRecorder");
#endif
        }
        #region Android Recorder
        //Call this func before you start record video
        public void PrepareRecorder()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
        //RECORD_AUDIO is declared inside plugin manifest but we need to request it manualy
        if (!ScreenRecorder.IsPermitted(AndroidPermission.RECORD_AUDIO))//request this permission to record audio for screen record
        {
            ScreenRecorder.RequestPermission(AndroidPermission.RECORD_AUDIO);
            onAllowCallback = () =>
            {
                androidRecorder.Call("setFileName", VIDEO_NAME);
                androidRecorder.Call("prepareRecorder");
            };
            onDenyCallback = () => { ShowToast("Need microphone to record voice");};
            onDenyAndNeverAskAgainCallback = () => { ShowToast("Need microphone to record voice");};
        }
        else
        {
            androidRecorder.Call("setFileName", VIDEO_NAME);
            androidRecorder.Call("prepareRecorder");
        }
#endif
        }
        public void StartRecording()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
    androidRecorder.Call("startRecording");
#endif
        }
        public void StopRecording()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
    androidRecorder.Call("stopRecording");
#endif
        }
        //this function will be call when record status change
        public void VideoRecorderCallback(string message)
        {
            switch (message)
            {
                case "init_record_error":
                    break;
                case "init_record_success":
                    break;
                case "start_record":
                    break;
                case "stop_record":
                    break;
            }
        }
        public void SaveVideoToGallery()
        {
            //RECORD_AUDIO is declared inside plugin manifest but we need to request it manualy.Use call back to handle when user didn't accept the permsission
            if (!ScreenRecorder.IsPermitted(AndroidPermission.WRITE_EXTERNAL_STORAGE))//request this permission to write recorded file to disk
            {
                ScreenRecorder.RequestPermission(AndroidPermission.WRITE_EXTERNAL_STORAGE);
                onAllowCallback = () => { StartCoroutine(_SaveVideoToGallery()); };
                onDenyCallback = () => { ShowToast("Need WRITE_EXTERNAL_STORAGE to save video"); };
                onDenyAndNeverAskAgainCallback = () => { ShowToast("Need WRITE_EXTERNAL_STORAGE to save video"); };
            }
            else
                StartCoroutine(_SaveVideoToGallery());
        }
        private IEnumerator _SaveVideoToGallery()
        {
            yield return null;
#if UNITY_ANDROID && !UNITY_EDITOR
        System.DateTime now = System.DateTime.Now;
        string fileName = "Video_" + now.Year + "_" + now.Month + "_" + now.Day + "_" + now.Hour + "_" + now.Minute + "_" + now.Second + ".mp4";
        while (!System.IO.File.Exists(Application.persistentDataPath + "/" + VIDEO_NAME + ".mp4"))
            yield return null;
        if (!System.IO.Directory.Exists(Application.persistentDataPath + GALLERY_PATH))
            System.IO.Directory.CreateDirectory(Application.persistentDataPath + GALLERY_PATH);
        System.IO.File.Copy(Application.persistentDataPath + "/" + VIDEO_NAME + ".mp4", Application.persistentDataPath + GALLERY_PATH + "/" + fileName);
        ShowToast("Video is saved to Gallery");
        yield return null;
        RefreshGallery(Application.persistentDataPath + GALLERY_PATH + "/" + fileName);
#endif
        }
        #endregion
        #region Android Permissions
        //this function will be called when the permission has been approved
        private void OnAllow()
        {
            if (onAllowCallback != null)
                onAllowCallback();
            ResetAllCallBacks();
        }
        //this function will be called when the permission has been denied
        private void OnDeny()
        {
            if (onDenyCallback != null)
                onDenyCallback();
            ResetAllCallBacks();
        }
        //this function will be called when the permission has been denied and user tick to checkbox never ask again
        private void OnDenyAndNeverAskAgain()
        {
            if (onDenyAndNeverAskAgainCallback != null)
                onDenyAndNeverAskAgainCallback();
            ResetAllCallBacks();
        }
        private void ResetAllCallBacks()
        {
            onAllowCallback = null;
            onDenyCallback = null;
            onDenyAndNeverAskAgainCallback = null;
        }
        public static bool IsPermitted(AndroidPermission permission)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
        using (var androidUtils = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            return androidUtils.GetStatic<AndroidJavaObject>("currentActivity").Call<bool>("hasPermission", GetPermissionStrr(permission));
        }
#endif
            return true;
        }
        public static void RequestPermission(AndroidPermission permission, UnityAction onAllow = null, UnityAction onDeny = null, UnityAction onDenyAndNeverAskAgain = null)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
        onAllowCallback = onAllow;
        onDenyCallback = onDeny;
        onDenyAndNeverAskAgainCallback = onDenyAndNeverAskAgain;
        using (var androidUtils = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            androidUtils.GetStatic<AndroidJavaObject>("currentActivity").Call("requestPermission", GetPermissionStrr(permission));
        }
#endif
        }
        private static string GetPermissionStrr(AndroidPermission permission)
        {
            return "android.permission." + permission.ToString();
        }
        #endregion
        public static void RefreshGallery(string path)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
        using(AndroidJavaClass javaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer")){
        javaClass.GetStatic<AndroidJavaObject>("currentActivity").Call("refreshGallery", path);
        }
#endif
        }
        public static void OpenGallery()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
       using(AndroidJavaClass javaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer")){
        javaClass.GetStatic<AndroidJavaObject>("currentActivity").Call("openGallery");
       }
#endif
        }
        public static void ShowToast(string message)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
        AndroidJavaObject currentActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
        {
            new AndroidJavaClass("android.widget.Toast").CallStatic<AndroidJavaObject>("makeText", currentActivity.Call<AndroidJavaObject>("getApplicationContext"), new AndroidJavaObject("java.lang.String", message), 0).Call("show");
        }));
#endif
        }
        public static void ShareAndroid(string body, string subject, string url, string filePath, string mimeType, bool chooser, string chooserText)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
        using (AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent"))
        using (AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent"))
        {
            using (intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND")))
            { }
            using (intentObject.Call<AndroidJavaObject>("setType", mimeType))
            { }
            using (intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), subject))
            { }
            using (intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), body))
            { }
            if (!string.IsNullOrEmpty(url))
            {
                using (AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri"))
                using (AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", url))
                using (intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject))
                { }
            }
            else if (filePath != null)
            {
                using (AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri"))
                using (AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + filePath))
                using (intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject))
                { }
            }
            using (AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            using (AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity"))
            {
                if (chooser)
                {
                    AndroidJavaObject jChooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, chooserText);
                    currentActivity.Call("startActivity", jChooser);
                }
                else
                    currentActivity.Call("startActivity", intentObject);
            }
        }
#endif
        }
    }

}
