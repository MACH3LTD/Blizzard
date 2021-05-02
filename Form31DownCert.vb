Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Imaging
Public Class Form31DownCert
    Dim cn1 As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\elements.mdf;Integrated Security=True")
    Dim cn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\DB1.mdf;Integrated Security=True")
    Public Property na As String
    Private Sub Form31DownCert_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            PictureBox7.Enabled = False
            Dim c2 As New SqlCommand("select COA from gameinfo where name ='" + na + "'", cn)
            Dim da1 As New SqlDataAdapter(c2)
            Dim dt2 As New DataTable
            da1.Fill(dt2)
            Dim img5() As Byte
            img5 = dt2.Rows(0)(0)
            Dim ms5 As New MemoryStream(img5)
            PictureBox7.Image = Image.FromStream(ms5)
        Catch e1 As Exception
            MessageBox.Show("Error: " + e1.Message)
        End Try
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim result As DialogResult = MessageBox.Show("Do you want to go back?", "Blizzard Certificate Details", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Form4progskeleton.OpenMainPanel(New Form9AccountDeets)
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim svd As New SaveFileDialog()
        With svd
            .Title = "Save Image As"
            .Filter = "Jpg, Jpeg Images|*.jpg;*.jpeg|PNG Image|*.png|BMP Image|*.bmp"
            .DefaultExt = ".png"
            If .ShowDialog = DialogResult.OK Then
                If .FilterIndex = 1 Then
                    PictureBox7.Image.Save(svd.FileName, Imaging.ImageFormat.Jpeg)
                ElseIf .FilterIndex = 2 Then
                    PictureBox7.Image.Save(svd.FileName, Imaging.ImageFormat.Png)
                ElseIf .FilterIndex = 3 Then
                    PictureBox7.Image.Save(svd.FileName, Imaging.ImageFormat.Bmp)
                End If
            End If
        End With

    End Sub
End Class