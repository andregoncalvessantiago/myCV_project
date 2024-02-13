using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PDFButton : MonoBehaviour
{
    public PDFDownloader pdfDownloader;

    private Button button;

    private void Start()
    {
        // Get reference to the button component
        button = GetComponent<Button>();

        // Add listener to the button click event
        if (button != null)
        {
            button.onClick.AddListener(DownloadPDF);
        }

        // Check if pdfDownloader is null
        if (pdfDownloader == null)
        {
            Debug.LogError("PDFDownloader reference is not assigned to PDFButton.");
        }
    }

    private void DownloadPDF()
    {
        // Check if pdfDownloader is not null before calling DownloadPDF
        if (pdfDownloader != null)
        {
            pdfDownloader.DownloadPDF();
        }
        else
        {
            Debug.LogError("PDFDownloader reference is null.");
        }
    }
}
