using System.IO;
using UnityEngine;

public class PDFDownload : _InteractiveObject
{
    public override void Interective()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "TheC#Bible.pdf");
        System.Diagnostics.Process.Start(filePath);
    }
}
