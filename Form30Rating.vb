Imports System.Data.SqlClient

Public Class Form30Rating
    Dim cn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\DB1.mdf;Integrated Security=True")
    Dim cn1 As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\elements.mdf;Integrated Security=True")
    Public Property s As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result1 As DialogResult = MessageBox.Show("Are you sure you want to Cancel?", "Blizzard Rating Details", MessageBoxButtons.YesNo)
        If result1 = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub
    Public Sub rating(rat As Double)
        Dim c1 As New SqlCommand("select name, rating, ratinguserno from gameinfo where name='" + s + "'", cn)
        Dim da As New SqlDataAdapter(c1)
        Dim dt As New DataTable
        Dim r As String = ""
        Dim ruser As String = ""
        Dim r1 As Double = 0.0
        Dim ruser1 As Double = 0.0
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            r = (DirectCast(row, System.Data.DataRow)("rating").ToString())
            ruser = (DirectCast(row, System.Data.DataRow)("ratinguserno").ToString())
        Next
        If ruser = "0" Then
            'r1 = CDbl(r)
            'ruser1 = CDbl(ruser)
            r = rat
            ruser = 1
        Else
            'r = CDbl(r)
            'ruser1 = CDbl(ruser)
            ruser = ruser + 1
            r = (r + rat) / ruser
        End If
        Dim c As New SqlCommand("update gameinfo set rating=@r, ratinguserno = @ru where name='" + s + "'", cn)
        cn.Open()
        c.Parameters.AddWithValue("@r", r)
        c.Parameters.AddWithValue("@ru", ruser)
        c.ExecuteNonQuery()
        cn.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result1 As DialogResult = MessageBox.Show("Are you sure you want to Submit?", "Blizzard Rating Details", MessageBoxButtons.YesNo)
        If result1 = DialogResult.Yes Then
            If RadioButton1.Checked = True Then
                rating(1)
            ElseIf RadioButton2.Checked = True Then
                rating(2)
            ElseIf RadioButton3.Checked = True Then
                rating(3)
            ElseIf RadioButton4.Checked = True Then
                rating(4)
            ElseIf RadioButton5.Checked = True Then
                rating(5)
            End If
            Me.Close()
        End If
    End Sub
End Class