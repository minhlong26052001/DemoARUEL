using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Google;
using TMPro;
using Firebase;
using Firebase.Auth;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// using Vuforia;

public class GoogleSignInDemo : MonoBehaviour
{
    public Text infoText;
    // public Text infoTextMenu;
    [SerializeField] GameObject thongBaoDangnhap;
    public Text emailTest;
    public Text emailAfterTest;
    [SerializeField] GameObject cameraBeforeLogIn;
    [SerializeField] GameObject cameraAfterLogIn;
    private string webClientId = "494825749238-ooob1j6l6e5k0qrdbmatg7fg9d88ml9d.apps.googleusercontent.com";
    // public System.Uri profilepic;
    private FirebaseAuth auth;
    private GoogleSignInConfiguration configuration;

    private void Awake()
    {
        configuration = new GoogleSignInConfiguration { WebClientId = webClientId, RequestEmail = true, RequestIdToken = true };
        CheckFirebaseDependencies();
        // emailTest.text=PlayerPrefs.GetString("EmailDaDangNhap");
        // if(PlayerPrefs.GetString("EmailDaDangNhap")!=""){
        //     cameraBeforeLogIn.SetActive(false);
        //     cameraAfterLogIn.SetActive(true);
        // }
        // else{
        //     cameraBeforeLogIn.SetActive(true);
        //     cameraAfterLogIn.SetActive(false);
        // }
    }

    private void CheckFirebaseDependencies()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                if (task.Result == DependencyStatus.Available)
                    auth = FirebaseAuth.DefaultInstance;
                else
                    AddToInformation("Could not resolve all Firebase dependencies: " + task.Result.ToString());
            }
            else
            {
                AddToInformation("Dependency check was not completed. Error : " + task.Exception.Message);
            }
        });
    }

    public void SignInWithGoogle() { OnSignIn(); }
    public void SignOutFromGoogle() { OnSignOut(); }

    private void OnSignIn()
    {
        // GoogleSignIn.DefaultInstance.SignOut();
        GoogleSignIn.Configuration = configuration;
        GoogleSignIn.Configuration.UseGameSignIn = false;
        GoogleSignIn.Configuration.RequestIdToken = true;
        // AddToInformation("Calling SignIn");

        GoogleSignIn.DefaultInstance.SignIn().ContinueWith(OnAuthenticationFinished);
    }
    
    // [SerializeField] GameObject TatCaARObject;
    private void OnSignOut()
    {
        AddToInformation("Calling SignOut");
        GoogleSignIn.DefaultInstance.SignOut();
        // PlayerPrefs.SetString("EmailDaDangNhap", "");
        // infoTextMenu.text="";
        emailTest.text="";
        thongBaoDangnhap.SetActive(false);
        cameraBeforeLogIn.SetActive(true);
        cameraAfterLogIn.SetActive(false);
        // TatCaARObject.SetActive(false);
        // CameraDevice.Instance.SetFlashTorchMode(false);
    }

    public void OnDisconnect()
    {
        AddToInformation("Calling Disconnect");
        GoogleSignIn.DefaultInstance.Disconnect();
    }
    public Image avatar;
    // public Renderer thisrenderer;

    // public Text textMesh;
    // private void Updatetime()
    // {
    //     while(true)
    //     {
    //         var today = DateTime.Now;
    //         textMesh.text = today.ToString("dd-MM-yyyy HH:mm:ss");
    //         // yield WaitForSeconds(0.2f); 
    //     }
    // }

    internal void OnAuthenticationFinished(Task<GoogleSignInUser> task)
    {
        if (task.IsFaulted)
        {
            using (IEnumerator<Exception> enumerator = task.Exception.InnerExceptions.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    GoogleSignIn.SignInException error = (GoogleSignIn.SignInException)enumerator.Current;
                    AddToInformation("Got Error: " + error.Status + " " + error.Message);
                }
                else
                {
                    AddToInformation("Got Unexpected Exception?!?" + task.Exception);
                }
            }
        }
        else if (task.IsCanceled)
        {
            AddToInformation("Canceled");
        }
        else
        {
            if (task.Result.Email.Contains("@st.uel.edu.vn") == true || task.Result.Email.Contains("@uel.edu.vn") == true)
            {
                thongBaoDangnhap.SetActive(false);
                cameraBeforeLogIn.SetActive(false);
                cameraAfterLogIn.SetActive(true);
                // TatCaARObject.SetActive(true);

                

                // var timeInPhone = DateTime.Now;
                // var hourInPhoneInDateTime = new DateTime(timeInPhone.Hour);
                // int hourInPhone = int(hourInPhoneInDateTime);
                
                // https://forum.unity.com/threads/convert-string-to-int-in-c.58867/
                // int.Parse, or TryParse.      int.Parse(tempString);
                //What's interesting is the fastest way isn't using any of the native C# methods Convert.ToInt32(), int.TryParse(), or int.Parse().
                //int value = Convert.ToInt32(no);
                // int myConvertedInt = int.Parse(<yourstringhere>,System.Globalization.NumberStyles.Integer);
                // Convert.ToInt16(tempString );
                // Convert.ToInt32(tempString );
                // Convert.ToInt64(tempString );
                // string hourInPhoneString = System.DateTime.UtcNow.ToString("HH");
                string hourInPhoneString = DateTime.Now.ToString("HH");
                int hourInPhone = Convert.ToInt32(hourInPhoneString);
                // int.TryParse(hourInPhoneString, out hourInPhone);

                // string sillyMeme = "9001";
                // int memeValue;
                // int.TryParse(sillyMeme, out memeValue);
                // Debug.Log(memeValue);//9001

                string chaoNguoiDung = "";
                // Good morning (12am-12pm)
                // Good after noon (12pm-6pm)
                // Good evening (6pm-10pm)
                // Good night (10pm-12am)
                if(0<=hourInPhone && hourInPhone<12)
                {
                    chaoNguoiDung = "Good morning,\n";
                }
                else if(12<=hourInPhone && hourInPhone<18)
                {
                    chaoNguoiDung = "Good afternoon,\n";
                }
                else if(18 <=hourInPhone && hourInPhone<22)
                {
                    chaoNguoiDung = "Good evening,\n";
                }
                else if(22<= hourInPhone && hourInPhone <= 24)
                {
                    chaoNguoiDung = "Good night,\n";
                }

                System.Uri avatarurl=task.Result.ImageUrl;
                string avatarurlstring = avatarurl.ToString();
                // avatarurlstring+="-br100-rg-mo";
                // avatar.TextureURL=avatarurlstring;
                if(task.Result.Email.Contains("@st.uel.edu.vn") == true)
                {
                    AddToInformation(chaoNguoiDung + task.Result.FamilyName + " " + task.Result.GivenName);
                }
                else if(task.Result.Email.Contains("@uel.edu.vn") == true)
                {
                    AddToInformation(chaoNguoiDung + task.Result.DisplayName + "!");
                }
                // emailTest.text=task.Result.Email;
                // emailAfterTest.text=task.Result.Email;
                // AddToInformation("Xin chào " + task.Result.DisplayName + "!");
                // AddToInformation("Email = " + task.Result.Email);
                // AddToInformation("hình ava = " + task.Result.ImageUrl);
                // PlayerPrefs.SetString("EmailDaDangNhap", task.Result.Email);
                StartCoroutine(DownloadImage(avatarurlstring));
                // bool macDinh=true;
                // while(macDinh)
                // {
                //     var today = DateTime.Now;
                //     textMesh.text = today.ToString("dd-MM-yyyy HH:mm:ss");
                //     // yield WaitForSeconds(0.2f); 
                // }


            }
            else
            {
                GoogleSignIn.DefaultInstance.SignOut();
                // infoTextMenu.text="Chỉ có email UEL cấp mới đăng nhập được!";
                thongBaoDangnhap.SetActive(true);
                // PlayerPrefs.SetString("EmailDaDangNhap", "");
            }
        }
    }

    IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else{
			Texture2D webTexture = ((DownloadHandlerTexture)request.downloadHandler).texture as Texture2D;
			Sprite webSprite = SpriteFromTexture2D(webTexture);
			// gameObject.GetComponent<Image>().sprite = webSprite;
			avatar.sprite = webSprite;
		}
    }
	
	Sprite SpriteFromTexture2D(Texture2D texture) {
		return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
    }

    // private IEnumerator LoadFromLikeCoroutine(string avatarurlstring)
    // {
    //     Debug.Log("Loading.....");
    //     WWW wwwLoader = new WWW(avatarurlstring);
    //     yield return wwwLoader;

    //     Debug.Log("Loaded");
    //     thisrenderer.material.color=Color.blue;
    //     thisrenderer.material.mainTexture=wwwLoader.texture;
    // } 

    // private IEnumerator LoadImage(string _avatarurl)
    // {
    //     UnityWebRequest request = UnityWebRequestTexture.GetTexture(_avatarurl);
    //     yield return request.SendWebRequest();
    //     if(request.error!=null)
    //     {
    //         // string output = "Unknown Error! Try again!";

    //         // if(request.isHttpError)
    //         if(request.result != UnityWebRequest.Result.Success)
    //         {
    //             // output="Image Type Not Supported! Please Try Another Image.";
    //         }
    //     }
    //     else
    //     {
    //         Texture2D image=((DownloadHandlerTexture)request.downloadHandler).texture;

    //         avatar.sprite=Sprite.Create(image,new Rect(0,0,image.width,image.height),Vector2.zero);
    //     }
    // } 

    private void SignInWithGoogleOnFirebase(string idToken)
    {
        Credential credential = GoogleAuthProvider.GetCredential(idToken, null);

        auth.SignInWithCredentialAsync(credential).ContinueWith(task =>
        {
            AggregateException ex = task.Exception;
            if (ex != null)
            {
                if (ex.InnerExceptions[0] is FirebaseException inner && (inner.ErrorCode != 0))
                    AddToInformation("\nError code = " + inner.ErrorCode + " Message = " + inner.Message);
            }
            else
            {
                AddToInformation("Sign In Successful.");
            }
        });
    }

    public void OnSignInSilently()
    {
        GoogleSignIn.Configuration = configuration;
        GoogleSignIn.Configuration.UseGameSignIn = false;
        GoogleSignIn.Configuration.RequestIdToken = true;
        AddToInformation("Calling SignIn Silently");

        GoogleSignIn.DefaultInstance.SignInSilently().ContinueWith(OnAuthenticationFinished);
    }

    public void OnGamesSignIn()
    {
        GoogleSignIn.Configuration = configuration;
        GoogleSignIn.Configuration.UseGameSignIn = true;
        GoogleSignIn.Configuration.RequestIdToken = false;

        AddToInformation("Calling Games SignIn");

        GoogleSignIn.DefaultInstance.SignIn().ContinueWith(OnAuthenticationFinished);
    }

    private void AddToInformation(string str) { infoText.text = str; }
    // private void AddToInformation(string str) { infoText.text += "\n" + str; }

    public void QuitTheARApp ()
    {
        GoogleSignIn.DefaultInstance.SignOut();
        thongBaoDangnhap.SetActive(false);
        Application.Quit();        
    }

    // void Update() {
    //     if (Input.GetKey("escape"))
    //     {
    //         // OnSignOut();
    //         GoogleSignIn.DefaultInstance.SignOut();
    //         Application.Quit();
    //     }
        
    
}

    