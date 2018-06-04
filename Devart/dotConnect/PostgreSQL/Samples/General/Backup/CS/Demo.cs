using System;
using System.IO;
using System.Data;

namespace Samples
{
  /// <summary>
  /// Summary description for Demo.
  /// </summary>
  abstract public class Demo
  {
    private string name;
    private string descriptionShort;
    private string descriptionFull;
    private string imageResourceName;
    private BaseDemoControl demoControl = null;

    private static string demoPath;

    static Demo() {

      DirectoryInfo demoFolder = Directory.GetParent(Environment.CurrentDirectory);
      demoPath = (demoFolder == null ? "" : demoFolder.FullName + "\\CS");
    }

    public Demo(string name, string descriptionShort, string descriptionFull, string imageResourceName) {

      this.name = name;
      this.descriptionShort = descriptionShort;
      this.descriptionFull = descriptionFull;
      this.imageResourceName = imageResourceName;
    }

    public Demo(string name, string descriptionShort, string descriptionFull) 
      : this (name, descriptionShort, descriptionFull, "") {
    }

    public virtual void GenerateReadMe(string fileName){

      System.IO.TextWriter tw = new System.IO.StreamWriter(fileName);
      try {
        tw.Write(@"<!doctype html public ""-//w3c//dtd html 4.0 Transitional//en"">
        <html>
        <head>
        <title>Samples</title>
        <style> body { margin: 1px; padding: 1px; background: ; color: #000000; font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 70%; width: 100%; } p { margin: .5em; }
        </style>
        </head>
        <BODY  style=""border:none"">
        <div id=""Div1"">
        <!-- begin content -->
        <P><STRONG><FONT size=""2"">");

        tw.Write(this.name);
        tw.Write(@"</FONT></STRONG>
        </P>
        <P><STRONG></STRONG>
        <hr size=""1"">
        <P>");
        tw.Write(this.descriptionFull);
        tw.Write(@"      </P>
        </div>
        </BODY>
        </html>");
      }
      finally {
        tw.Close();
      }
    }
    public BaseDemoControl GetDemo(IDbConnection connection, WriteStatusHandler handler) {

      if (demoControl == null) {
        demoControl = CreateDemoControl(connection);
        demoControl.WriteStatus += handler;
      }

      return demoControl;
    }

    protected abstract BaseDemoControl CreateDemoControl(IDbConnection connection);

    public string Name {
      get {
        return name;
      }
    }

    public string DescriptionShort {
      get {
        return descriptionShort;
      }
    }

    public string DescriptionFull {
      get {
        return descriptionFull;
      }
    }

    public string ImageResourceName {
      get {
        return imageResourceName;
      }
    }

    public string CodeFileName {
      get {
        return Path.Combine(demoPath, name) + "\\" + name + "DemoControl.cs";
      }
    }

    public virtual string CreateSql {
      get {
        return "";
      }
    }

    public virtual string DropSql {
      get {
        return "";
      }
    }
  }
}
