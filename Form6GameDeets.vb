Imports System.Data.SqlClient
Public Class Form6GameDeets
    Dim cn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\DB1.mdf;Integrated Security=True")

    Public Property name1 As String
    Private Sub Form6GameDeets_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim c2 As New SqlCommand("select * from gameinfo where name ='" + name1 + "'", cn)
        Dim da1 As New SqlDataAdapter(c2)
        Dim dt2 As New DataTable
        da1.Fill(dt2)
        For Each row As DataRow In dt2.Rows
            Me.Label5.Text = (DirectCast(row, System.Data.DataRow)("dev").ToString())
            Me.Label6.Text = (DirectCast(row, System.Data.DataRow)("pub").ToString())
            Me.Label10.Text = (DirectCast(row, System.Data.DataRow)("mode").ToString())
            Me.Label7.Text = (DirectCast(row, System.Data.DataRow)("reldate").ToString())
            Me.Label8.Text = (DirectCast(row, System.Data.DataRow)("rating").ToString())
            Form7PCdeets.RichTextBox1.Text = (DirectCast(row, System.Data.DataRow)("min").ToString())
            Form7PCdeets.RichTextBox2.Text = (DirectCast(row, System.Data.DataRow)("max").ToString())
        Next
        Label7.Text = Label7.Text.Replace("12:00:00 AM", " ")
    End Sub
End Class