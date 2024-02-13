using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class PDFLoader : MonoBehaviour

{
    public string pdfFileName = "comprovativo.pdf";

    void Start()
    {
        // Attach the OpenPDFOnClick method to the button's onClick event
        Button Pdf = GetComponent<Button>();
        Pdf.onClick.AddListener(OpenPDFOnClick);
    }

    void OpenPDFOnClick()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, pdfFileName);

        // Check if the file exists
        if (File.Exists(filePath))
        {
            // Open the PDF file using platform-specific methods
            #if UNITY_EDITOR
            // For the Unity Editor, open the file using the default application
            UnityEditor.EditorUtility.OpenWithDefaultApp(filePath);
            #elif UNITY_ANDROID
            // For Android, use an intent to open the PDF file
            AndroidOpenPDF(filePath);
            #elif UNITY_IOS
            // For iOS, use native iOS APIs to open the PDF file
            // Add iOS-specific implementation here
            #else
            // For other platforms, you may need to implement platform-specific code
            Debug.LogError("Opening PDF files is not supported on this platform.");
            #endif
        }
        else
        {
            Debug.LogError("PDF file not found at path: " + filePath);
        }
    }

    // Method to open PDF file on Android using intent
    void AndroidOpenPDF(string filePath)
    {
        AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
        AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
        intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_VIEW"));

        AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
        AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + filePath);

        intentObject.Call<AndroidJavaObject>("setDataAndType", uriObject, "application/pdf");
        intentObject.Call<AndroidJavaObject>("addFlags", intentClass.GetStatic<int>("FLAG_ACTIVITY_NEW_TASK"));

        AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivityObject = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject packageManagerObject = unityActivityObject.Call<AndroidJavaObject>("getPackageManager");

        AndroidJavaObject resolveInfoObject = packageManagerObject.Call<AndroidJavaObject>("resolveActivity", intentObject, 0);
        if (resolveInfoObject != null)
        {
            unityActivityObject.Call("startActivity", intentObject);
        }
        else
        {
            Debug.LogError("No PDF viewer application found on the device.");
        }
    }
}
