Public Class Form9AccountDeets
    Dim currentChildForm As New Form
    Private Sub Form9AccountDeets_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Form4progskeleton.OpenMainPanel(New Form10LogAndSec)

        Me.Close()

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Form4progskeleton.OpenMainPanel(New Form10LogAndSec)
        Me.Close()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Form4progskeleton.OpenMainPanel(New Form11SavedAdd)
        Me.Close()

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Form4progskeleton.OpenMainPanel(New Form11SavedAdd)
        Me.Close()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Form4progskeleton.OpenMainPanel(New Form12PrevOrd)
        Me.Close()

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Form4progskeleton.OpenMainPanel(New Form12PrevOrd)
        Me.Close()

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Form4progskeleton.OpenMainPanel(New Form13SavedCards)
        Me.Close()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Form4progskeleton.OpenMainPanel(New Form13SavedCards)
        Me.Close()
    End Sub
End Class