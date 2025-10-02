using System.Reflection;
namespace PdfBuilder.Models;


public class Pdf
{
    public string Name { get; set; }
    public Page Page { get; set; }
}


public class Page
{
    public string Header { get; set; }
    public string Body { get; set; }
    public Rotation Rotation { get; set; }

}


public enum Rotation
{
    Vertical,
    Horizontal
}