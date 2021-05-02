Public Class Form29Review
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Form32ReviewEntry.TopLevel = False
        Form32ReviewEntry.FormBorderStyle = FormBorderStyle.None
        Form32ReviewEntry.Dock = DockStyle.Fill
        Form32ReviewEntry.rev = "blizzard"
        Form4progskeleton.Panel2.Controls.Add(Form32ReviewEntry)
        Form4progskeleton.Panel2.Tag = Form32ReviewEntry
        Form32ReviewEntry.BringToFront()
        Form32ReviewEntry.Show()

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

        Form4progskeleton.OpenMainPanel(New Form32ReviewEntry)



        Form8searchgame.TopLevel = False
        Form8searchgame.FormBorderStyle = FormBorderStyle.None
        Form8searchgame.Dock = DockStyle.Fill
        Form8searchgame.formname = "game"
        Form8searchgame.Button2.Text = "Select"
        Form4progskeleton.Panel1.Controls.Add(Form8searchgame)
        Form4progskeleton.Panel1.Tag = Form8searchgame
        Form8searchgame.BringToFront()
        Form8searchgame.Show()

    End Sub
End Class