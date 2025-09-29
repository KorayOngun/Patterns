using System.Text;
using System.Text.Unicode;

internal class Program
{
    private static void Main(string[] args)
    {
        // demo 01 - basit bir pdf dosyası oluşturma
        // PDF spesifikasyonuna göre elle bir PDF dosyası oluşturacağız.
        var memoryStream = new MemoryStream();
        List<string> xrefOffsets = new()
        {
            "0000000000 65535 f\n"
        };

        int index = 0;

        string pdfVersion = "%PDF-1.1\n";
        string[] objects =
        [
            "<< /Type /Catalog /Pages 2 0 R >>\n",
            "<< /Type /Pages /Kids [3 0 R] /Count 1 >>\n",
            "<< /Type /Page /Parent 2 0 R /Resources << /Font << /F1 4 0 R >> >> /MediaBox [0 0 720 1080] /Contents 5 0 R >>\n",
            "<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica >>\n"
        ];

        byte[] bytes = Encoding.ASCII.GetBytes(pdfVersion);
        memoryStream.Write(bytes);
        index += bytes.Length;

        int objIndex = 1;
        foreach (var obj in objects)
        {
            var zeroCount = 10 - index.ToString().Length;
            var xref = $"{xrefOffsets[0].Substring(0, zeroCount)}{index}";
            xrefOffsets.Add($"{xref} 00000 n\n");
            var objStart = $"{objIndex++} 0 obj\n";
            bytes = Encoding.ASCII.GetBytes(objStart);
            memoryStream.Write(bytes);
            index += bytes.Length;

            bytes = Encoding.ASCII.GetBytes(obj);
            memoryStream.Write(bytes);
            index += bytes.Length;

            var objEnd = "endobj\n";
            bytes = Encoding.ASCII.GetBytes(objEnd);
            memoryStream.Write(bytes);
            index += bytes.Length;
        }
        var zeroCountt = 10 - index.ToString().Length;
        var xreff = $"{xrefOffsets[0].Substring(0, zeroCountt)}{index}";
        xrefOffsets.Add($"{xreff} 00000 n\n");



        // string body = "lorem ipsum dolor sit amet";
        string body = "Merhaba Dünya! PDF dosyasına hoş geldiniz.";


        string[] contentObjs =
        [
            "5 0 obj\n",
            $"<< /Length {body.Length} >>\n",
            "stream\n",
            "BT\n",
            "/F1 12 Tf\n",
            "10 1000 Td\n",
            $"({body}) Tj\n",
            "ET\n",
            "endstream\n",
            "endobj\n"
        ];

        foreach (var obj in contentObjs)
        {
            bytes = Encoding.ASCII.GetBytes(obj);
            memoryStream.Write(bytes);
            index += bytes.Length;
        }

        long xrefStartPosition = memoryStream.Length;
        bytes = Encoding.ASCII.GetBytes("xref\n");
        memoryStream.Write(bytes);
        bytes = Encoding.ASCII.GetBytes("0 6\n");
        memoryStream.Write(bytes);


        foreach (var item in xrefOffsets)
        {
            bytes = Encoding.ASCII.GetBytes(item);
            memoryStream.Write(bytes);
        }

        bytes = Encoding.ASCII.GetBytes("trailer\n");
        memoryStream.Write(bytes);
        bytes = Encoding.ASCII.GetBytes("<< /Size 6 /Root 1 0 R >>\n");
        memoryStream.Write(bytes);

        bytes = Encoding.ASCII.GetBytes("startxref\n");
        memoryStream.Write(bytes);

        bytes = Encoding.ASCII.GetBytes($"{xrefStartPosition}\n");
        memoryStream.Write(bytes);

        bytes = Encoding.ASCII.GetBytes("%%EOF\n");
        memoryStream.Write(bytes);

        bytes = memoryStream.ToArray();

        var path = "-";
        var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        fs.Write(bytes);
        fs.Flush();
        fs.Close();
    }
}