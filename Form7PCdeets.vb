Imports System.Data.SqlClient

Public Class Form7PCdeets
    Dim cn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\DB1.mdf;Integrated Security=True")
    Public Property name2 As String

    Private Sub Form7PCdeets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim c2 As New SqlCommand("select * from gameinfo where name ='" + name2 + "'", cn)
        Dim da1 As New SqlDataAdapter(c2)
        Dim dt2 As New DataTable
        da1.Fill(dt2)
        For Each row As DataRow In dt2.Rows

            RichTextBox1.Text = (DirectCast(row, System.Data.DataRow)("min").ToString())
            RichTextBox2.Text = (DirectCast(row, System.Data.DataRow)("max").ToString())
        Next
    End Sub
End Class