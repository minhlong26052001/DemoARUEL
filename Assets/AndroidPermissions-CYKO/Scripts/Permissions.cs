using UnityEngine;
using UnityEngine.UI;
#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif
using UnityEngine.SceneManagement;

public class Permissions : MonoBehaviour
{
        public Image cam;
        public Image phone;
        public Image location;
        public Image mic;
        public Image storage;
	public Image contacts;
	public Image All;
	public Sprite done;
	public GameObject AllowPopup;
	string permissionType;
	public Text msg;


        public void PermissionStorage()
	{
		AndroidRuntimePermissions.Permission result = AndroidRuntimePermissions.RequestPermission ("android.permission.WRITE_EXTERNAL_STORAGE");
		if (result == AndroidRuntimePermissions.Permission.Granted) {
			storage.sprite = done;
		} else {
			Debug.Log ("Permission state: " + result);
		}
	}

	public void PermissionMicrophone ()
	{
		AndroidRuntimePermissions.Permission result = AndroidRuntimePermissions.RequestPermission ("android.permission.RECORD_AUDIO");
		if (result == AndroidRuntimePermissions.Permission.Granted) {
			mic.sprite = done;
		} else {
			Debug.Log ("Permission state: " + result);
		}

	}

	public void PermissionLocation ()
	{
		AndroidRuntimePermissions.Permission result = AndroidRuntimePermissions.RequestPermission ("android.permission.ACCESS_FINE_LOCATION");
		if (result == AndroidRuntimePermissions.Permission.Granted) {
			location.sprite = done;
		} else {
			Debug.Log ("Permission state: " + result);
		}

	}

	public void PermissionPhone ()
	{
		AndroidRuntimePermissions.Permission result = AndroidRuntimePermissions.RequestPermission ("android.permission.READ_PHONE_STATE");
		if (result == AndroidRuntimePermissions.Permission.Granted) {
			phone.sprite = done;
		} else {
			Debug.Log ("Permission state: " + result);
		}

	}

	public void PermissionCamera ()
	{
		AndroidRuntimePermissions.Permission result = AndroidRuntimePermissions.RequestPermission ("android.permission.CAMERA");
		if (result == AndroidRuntimePermissions.Permission.Granted) {
			cam.sprite = done;
		} else {
			Debug.Log ("Permission state: " + result);
		}

	}

	public void PermissionContacts ()
	{
		AndroidRuntimePermissions.Permission result = AndroidRuntimePermissions.RequestPermission ("android.permission.READ_CONTACTS");
		if (result == AndroidRuntimePermissions.Permission.Granted) {
			contacts.sprite = done;
		} else {
			Debug.Log ("Permission state: " + result);
		}

	}

	public void AllowAll()
	{

		AndroidRuntimePermissions.Permission [] result = AndroidRuntimePermissions.RequestPermissions ("android.permission.WRITE_EXTERNAL_STORAGE", "android.permission.RECORD_AUDIO", "android.permission.ACCESS_FINE_LOCATION", "android.permission.READ_PHONE_STATE", "android.permission.CAMERA", "android.permission.READ_CONTACTS");
		if (result [0] == AndroidRuntimePermissions.Permission.Granted && result [1] == AndroidRuntimePermissions.Permission.Granted && result [2] == AndroidRuntimePermissions.Permission.Granted && result [3] == AndroidRuntimePermissions.Permission.Granted && result [4] == AndroidRuntimePermissions.Permission.Granted && result [5] == AndroidRuntimePermissions.Permission.Granted)
			
		{
			storage.sprite = done;
			mic.sprite = done;
			location.sprite = done;
			phone.sprite = done;
			cam.sprite = done;
			contacts.sprite = done;
			All.sprite = done;
		}
		else
		{
			Debug.Log ("Some permission(s) are not granted...");
		}
			
	}

	public void PermissionTypeButton(string type)
	{
		permissionType = type;

		if(permissionType == "camera") { msg.text = "This PERMISSION is used to open camera for taking photos. This is the essential permission for our app. Please allow it."; }
		else if (permissionType == "phone") { msg.text = "This PERMISSION is used by Unity to run App in Background. This is the essential permission for our app. Please allow it."; }
		else if (permissionType == "location") { msg.text = "This PERMISSION is used to record the location information. This is the essential permission for our app. Please allow it."; }
		else if (permissionType == "mic") { msg.text = "This PERMISSION is used to Record Audio. This is the essential permission for our app. Please allow it."; }
		else if (permissionType == "storage") { msg.text = "This PERMISSION is used to store captured photos on the smartphone or SD card. This is the essential permission for our app. Please allow it."; }
		else if (permissionType == "contacts") { msg.text = "This PERMISSION is used to take access of Contacts. Please allow it."; }
		else if (permissionType == "all") { msg.text = "Please allow All Permissions: Camera, Phone State, Location, Microphone, Storage and Contacts"; }

		AllowPopup.SetActive (true);
	}

	public void AllowPermissionButton ()
	{
		AllowPopup.SetActive (false);

		if (permissionType == "camera") { PermissionCamera (); }
		else if (permissionType == "phone") { PermissionPhone (); }
		else if (permissionType == "location") { PermissionLocation (); }
		else if (permissionType == "mic") { PermissionMicrophone (); }
		else if (permissionType == "storage") { PermissionStorage (); }
		else if (permissionType == "contacts") { PermissionContacts (); }
		else if (permissionType == "all") { AllowAll (); }
	}
}