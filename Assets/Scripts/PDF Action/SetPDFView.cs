using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetPDFView : MonoBehaviour
{
    [SerializeField] TextMeshPro docName;

    public void SetPDF()
    {
        Paroxe.PdfRenderer.PDFViewer.pdfName = docName.text + ".pdf";
    }
}
