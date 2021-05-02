Public Class Form21GameDB
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Form20AdminSkeleton.OpenMainPanel(New Form22AddNewGame)
        Me.Close()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Form20AdminSkeleton.OpenMainPanel(New Form23UpdateGame)
        Form20AdminSkeleton.OpenSubPanel(New Form24SearchGameUpdate)

        Me.Close()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Form20AdminSkeleton.OpenMainPanel(New Form25RestockTitle)
        Me.Close()

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Form20AdminSkeleton.OpenMainPanel(New Form26DeleteTitle)
        Me.Close()

    End Sub
End Class