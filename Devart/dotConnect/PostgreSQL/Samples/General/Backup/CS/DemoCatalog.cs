using System.Collections;
using System.Data;
using System.IO;

namespace Samples
{
  /// <summary>
  /// Summary description for DemoCatalog.
  /// </summary>
  public class DemoCatalog : Demo {

    public DemoCatalog(string name, ArrayList list) : base(name, "", "") {

      sampleList = list;
    }

    public override void GenerateReadMe(string fileName) {

      TextWriter tw = new StreamWriter(fileName);
      try {
        tw.Write(@"<!doctype html public ""-//w3c//dtd html 4.0 Transitional//en"">
        <html>
        <head>
        <title>Samples</title>
        <style> body { margin: 1px; padding: 1px; background: ; color: #000000; font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 70%; width: 100%; } p { margin: .5em; }
        table.xmldoctable { width: 95%; margin-top: .6em; margin-bottom: .3em; border-width: 1px 1px 0px 0px; border-style: solid; border-color: #999999; background-color: ; font-size: 100%; border-collapse:collapse; margin-left: 5px; }
        table.xmldoctable th, table.xmldoctable td { border-width: 0px 0px 1px 1px; border-style: solid; border-color: #999999; padding: 4px 6px; text-align: left; vertical-align: top; }
        table.xmldoctable th { background: #cccccc; vertical-align: bottom; }
        table.xmldoctable td { background-color: ; vertical-align: top;}
        </style>
        </head>
        <BODY style=""border:none"">
        <div id=""pagebody"">
        <!-- begin content -->");

        if (sampleList.Count > 0) {
          if (sampleList[0] is DemoCatalog) {
            foreach (DemoCatalog catalog in sampleList)
              GenerateSampleTable(tw, catalog.sampleList, catalog.Name);
          }
          else {
            GenerateSampleTable(tw, sampleList, this.Name);
          }
        }
          tw.Write(@"
        </div>
        </BODY>
        </html>");
      }
      finally {
        tw.Close();
      }
    }

    protected override BaseDemoControl CreateDemoControl(IDbConnection connection) {

      return null;
    }

    private void GenerateSampleTable (TextWriter writer, ArrayList tableList, string tableTitle) {

      writer.Write(@"<P><STRONG><FONT size=""2"">");
      writer.Write(tableTitle);
      writer.Write(@"</FONT></STRONG>
      <table class=""xmldoctable"" cellSpacing=""0"">
        <tr>
          <th> Sample</th>
          <th>Description</th>
        </tr>");

      foreach(Demo demoInfo in tableList) {
        string sampleName = demoInfo.Name;
        writer.Write(@"<tr><td><b><A href=" + sampleName +">" + sampleName + "</A></b></td>");
        writer.Write("<td>" + demoInfo.DescriptionShort + "</td></tr>");
      }

      writer.Write(@"</table>");
    }

    private ArrayList sampleList;

    public ICollection SampleList {
      get {
        return sampleList;
      }
    }
  }
}
