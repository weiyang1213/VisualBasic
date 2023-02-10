Imports Google.Apis.Drive.v2
Imports Google.Apis.Auth.OAuth2
Imports System.Threading
Imports Google.Apis.Services
Imports Google.Apis.Drive.v2.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class Form4

    Dim service As New DriveService

    Private Sub createservice()

        Dim clientid = ""
        Dim clientsecret = ""

        Dim uc As UserCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(New ClientSecrets() With {.ClientId = clientid, .ClientSecret = clientsecret}, {DriveService.Scope.Drive}, "user", CancellationToken.None).Result
        service = New DriveService(New BaseClientService.Initializer() With {.HttpClientInitializer = uc, .ApplicationName = "Google Drive Vb Dot Net"})

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f As New OpenFileDialog


        If f.ShowDialog = DialogResult.OK Then
            Label1.Text = f.FileName
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If service.ApplicationName <> "Google Drive VB Dot Net" Then createservice()
        Dim myfile As New File
        Dim bytearry As Byte() = System.IO.File.ReadAllBytes(Label1.Text)
        Dim stream As New System.IO.MemoryStream(bytearry)
        Dim uploadrequest As FilesResource.InsertMediaUpload = service.Files.Insert(myfile, stream, myfile.MimeType)
        uploadrequest.Upload()
        Dim file As File = uploadrequest.ResponseBody
        MessageBox.Show("Upload Successfully " & file.Id)

    End Sub
End Class
