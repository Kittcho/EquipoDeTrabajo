Imports System
Imports System.Data
Imports System.IO

Namespace Samples
  Public MustInherit Class Demo

    ' Fields
    Private demoControl As BaseDemoControl
    Private Shared demoPath As String
    Private fieldDescriptionFull As String
    Private fieldDescriptionShort As String
    Private fieldImageResourceName As String
    Private fieldName As String

    ' Methods
    Shared Sub New()
      Dim demoFolder As DirectoryInfo = Directory.GetParent(Environment.CurrentDirectory)
      Demo.demoPath = IIf((demoFolder Is Nothing), "", demoFolder.FullName & "\VB")
    End Sub

    Public Sub New(ByVal name As String, ByVal descriptionShort As String, ByVal descriptionFull As String)
      Me.New(name, descriptionShort, descriptionFull, "")
    End Sub

    Public Sub New(ByVal name As String, ByVal descriptionShort As String, ByVal descriptionFull As String, ByVal imageResourceName As String)
      Me.demoControl = Nothing
      Me.fieldName = name
      Me.fieldDescriptionShort = descriptionShort
      Me.fieldDescriptionFull = descriptionFull
      Me.fieldImageResourceName = imageResourceName
    End Sub

    ' Properties
    Public ReadOnly Property CodeFileName() As String
      Get
        Return (Path.Combine(Demo.demoPath, Me.Name) & "\" & Me.Name & "DemoControl.vb")
      End Get
    End Property

    Public Overridable ReadOnly Property CreateSql() As String
      Get
        Return ""
      End Get
    End Property

    Public ReadOnly Property DescriptionFull() As String
      Get
        Return Me.fieldDescriptionFull
      End Get
    End Property

    Public ReadOnly Property DescriptionShort() As String
      Get
        Return Me.fieldDescriptionShort
      End Get
    End Property

    Public Overridable ReadOnly Property DropSql() As String
      Get
        Return ""
      End Get
    End Property

    Public ReadOnly Property ImageResourceName() As String
      Get
        Return Me.fieldImageResourceName
      End Get
    End Property

    Public ReadOnly Property Name() As String
      Get
        Return Me.fieldName
      End Get
    End Property

    ' Methods
    Protected MustOverride Function CreateDemoControl(ByVal connection As IDbConnection) As BaseDemoControl

    Public Overridable Sub GenerateReadMe(ByVal fileName As String)
      Dim tw As TextWriter = New StreamWriter(fileName)
      Try
        tw.Write("<!doctype html public ""-//w3c//dtd html 4.0 Transitional//en"">" & ChrW(13) & ChrW(10) & "        <html>" & ChrW(13) & ChrW(10) & "        <head>" & ChrW(13) & ChrW(10) & "        <title>Samples</title>" & ChrW(13) & ChrW(10) & "        <style> body { margin: 1px; padding: 1px; background: ; color: #000000; font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 70%; width: 100%; } p { margin: .5em; }" & ChrW(13) & ChrW(10) & "        </style>" & ChrW(13) & ChrW(10) & "        </head>" & ChrW(13) & ChrW(10) & "        <BODY  style=""border:none"">" & ChrW(13) & ChrW(10) & "        <div id=""Div1"">" & ChrW(13) & ChrW(10) & "        <!-- begin content -->" & ChrW(13) & ChrW(10) & "        <P><STRONG><FONT size=""2"">")
        tw.Write(Me.Name)
        tw.Write("</FONT></STRONG>" & ChrW(13) & ChrW(10) & "        </P>" & ChrW(13) & ChrW(10) & "        <P><STRONG></STRONG>" & ChrW(13) & ChrW(10) & "        <hr size=""1"">" & ChrW(13) & ChrW(10) & "        <P>")
        tw.Write(Me.DescriptionFull)
        tw.Write("      </P>" & ChrW(13) & ChrW(10) & "        </div>" & ChrW(13) & ChrW(10) & "        </BODY>" & ChrW(13) & ChrW(10) & "        </html>")
      Finally
        tw.Close()
      End Try
    End Sub

    Public Function GetDemo(ByVal connection As IDbConnection, ByVal handler As WriteStatusHandler) As BaseDemoControl
      If (Me.demoControl Is Nothing) Then
        Me.demoControl = Me.CreateDemoControl(connection)
        AddHandler Me.demoControl.WriteStatus, handler
      End If
      Return Me.demoControl
    End Function
  End Class
End Namespace