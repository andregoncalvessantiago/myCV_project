using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;


public class PDFDownloader : MonoBehaviour
{
    public string pdfUrl = "https://drive.usercontent.google.com/u/0/uc?id=10u2MJ8CH7tRMVByr1IsEMTvPeeo4_STB&export=download";

    public void DownloadPDF()
    {
        StartCoroutine(DownloadPDFRoutine());
    }

    private IEnumerator DownloadPDFRoutine()
    {
        UnityWebRequest request = UnityWebRequest.Get(pdfUrl);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Failed to download PDF: " + request.error);
        }
        else
        {
            string filePath = Path.Combine(Application.persistentDataPath, "file.pdf");
            File.WriteAllBytes(filePath, request.downloadHandler.data);
            Debug.Log("PDF downloaded to: " + filePath);
        }
    }
}
