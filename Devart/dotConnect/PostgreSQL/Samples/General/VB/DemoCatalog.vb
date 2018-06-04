Imports System
Imports System.Collections
Imports System.Data
Imports System.IO

Namespace Samples
  Public Class DemoCatalog
    Inherits Demo

    ' Fields
    Private fieldSampleList As ArrayList

    ' Methods
    Public Sub New(ByVal name As String, ByVal list As ArrayList)
      MyBase.New(name, "", "")
      Me.fieldSampleList = list
    End Sub

    ' Properties
    Public ReadOnly Property SampleList() As ICollection
      Get
        Return Me.fieldSampleList
      End Get
    End Property

    ' Methods
    Protected Overrides Function CreateDemoControl(ByVal connection As IDbConnection) As BaseDemoControl
      Return Nothing
    End Function

    Public Overrides Sub GenerateReadMe(ByVal fileName As String)
      Dim tw As TextWriter = New StreamWriter(fileName)
      Try
        tw.Write("<!doctype html public ""-//w3c//dtd html 4.0 Transitional//en"">" & ChrW(13) & ChrW(10) & "        <html>" & ChrW(13) & ChrW(10) & "        <head>" & ChrW(13) & ChrW(10) & "        <title>Samples</title>" & ChrW(13) & ChrW(10) & "        <style> body { margin: 1px; padding: 1px; background: ; color: #000000; font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 70%; width: 100%; } p { margin: .5em; }" & ChrW(13) & ChrW(10) & "        table.xmldoctable { width: 95%; margin-top: .6em; margin-bottom: .3em; border-width: 1px 1px 0px 0px; border-style: solid; border-color: #999999; background-color: ; font-size: 100%; border-collapse:collapse; margin-left: 5px; }" & ChrW(13) & ChrW(10) & "        table.xmldoctable th, table.xmldoctable td { border-width: 0px 0px 1px 1px; border-style: solid; border-color: #999999; padding: 4px 6px; text-align: left; vertical-align: top; }" & ChrW(13) & ChrW(10) & "        table.xmldoctable th { background: #cccccc; vertical-align: bottom; }" & ChrW(13) & ChrW(10) & "        table.xmldoctable td { background-color: ; vertical-align: top;}" & ChrW(13) & ChrW(10) & "        </style>" & ChrW(13) & ChrW(10) & "        </head>" & ChrW(13) & ChrW(10) & "        <BODY style=""border:none"">" & ChrW(13) & ChrW(10) & "        <div id=""pagebody"">" & ChrW(13) & ChrW(10) & "        <!-- begin content -->")
        If (Me.SampleList.Count > 0) Then
          If TypeOf Me.fieldSampleList.Item(0) Is DemoCatalog Then
            Dim catalog As DemoCatalog
            For Each catalog In Me.SampleList
              Me.GenerateSampleTable(tw, catalog.SampleList, catalog.Name)
            Next
          Else
            Me.GenerateSampleTable(tw, Me.SampleList, MyBase.Name)
          End If
        End If
        tw.Write(ChrW(13) & ChrW(10) & "        </div>" & ChrW(13) & ChrW(10) & "        </BODY>" & ChrW(13) & ChrW(10) & "        </html>")
      Finally
        tw.Close()
      End Try
    End Sub

    Private Sub GenerateSampleTable(ByVal writer As TextWriter, ByVal tableList As ArrayList, ByVal tableTitle As String)
      writer.Write("<P><STRONG><FONT size=""2"">")
      writer.Write(tableTitle)
      writer.Write("</FONT></STRONG>" & ChrW(13) & ChrW(10) & "      <table class=""xmldoctable"" cellSpacing=""0"">" & ChrW(13) & ChrW(10) & "        <tr>" & ChrW(13) & ChrW(10) & "          <th> Sample</th>" & ChrW(13) & ChrW(10) & "          <th>Description</th>" & ChrW(13) & ChrW(10) & "        </tr>")
      Dim demoInfo As Demo
      For Each demoInfo In tableList
        Dim sampleName As String = demoInfo.Name
        writer.Write(String.Concat(New String() {"<tr><td><b><A href=", sampleName, ">", sampleName, "</A></b></td>"}))
        writer.Write(("<td>" & demoInfo.DescriptionShort & "</td></tr>"))
      Next
      writer.Write("</table>")
    End Sub
  End Class
End Namespace