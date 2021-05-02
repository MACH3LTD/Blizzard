Imports System.Data.SqlClient

Public Class Form16selectBillAdd
    Dim cn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\DB1.mdf;Integrated Security=True")
    Dim cn1 As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\elements.mdf;Integrated Security=True")
    Private Sub Form16selectBillAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cmd As New SqlCommand("select * from " + Form1.TextBox1.Text + "_svdadd", cn1)
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            ComboBox1.Items.Add(DirectCast(row, System.Data.DataRow)("nickname").ToString())
        Next
        RichTextBox1.ForeColor = Color.Silver
        RichTextBox1.Text = "Choose a Nickname Or Enter Delivery Address"
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim cmd1 As New SqlCommand("select address from " + Form1.TextBox1.Text + "_svdadd where nickname ='" + ComboBox1.SelectedItem + "'", cn1)
        Dim da As New SqlDataAdapter(cmd1)
        Dim dt As New DataTable
        da.Fill(dt)
        For Each row As DataRow In dt.Rows

            RichTextBox1.Text = (DirectCast(row, System.Data.DataRow)("address").ToString())
        Next
    End Sub
    Private Sub RichTextBox1_lostfocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox1.LostFocus
        If RichTextBox1.Text = "" Then
            RichTextBox1.ForeColor = Color.Silver
            RichTextBox1.Text = "Choose a Nickname Or Enter Delivery Address"
        End If
    End Sub
    Private Sub RichTextBox1_gotfocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox1.GotFocus


        If RichTextBox1.Text = "Choose a Nickname Or Enter Delivery Address" Then
            RichTextBox1.Text = ""
            RichTextBox1.ForeColor = Color.Black

        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim result1 As DialogResult = MessageBox.Show("Are you sure you want to go back? You will be redirected to your cart and your checkout details will not be saved", "Blizzard Checkout Details", MessageBoxButtons.YesNo)
        If result1 = DialogResult.Yes Then
            Form4progskeleton.OpenMainPanel(New Form14Cart)
            Form4progskeleton.OpenSubPanel(New Form8searchgame)
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If RichTextBox1.Text = "" Or RichTextBox1.Text = "Choose a Nickname Or Enter Delivery Address" Then
            MessageBox.Show("Please Enter Appropriate Address.")
        Else
            Dim result1 As DialogResult = MessageBox.Show("Are you sure you want to proceed?", "Blizzard Checkout Details", MessageBoxButtons.YesNo)
            If result1 = DialogResult.Yes Then
                Form17ReviewCheckoutDeet.add = RichTextBox1.Text
                Form17ReviewCheckoutDeet.TopLevel = False
                Form17ReviewCheckoutDeet.FormBorderStyle = FormBorderStyle.None
                Form17ReviewCheckoutDeet.Dock = DockStyle.Fill
                Form4progskeleton.Panel2.Controls.Add(Form17ReviewCheckoutDeet)
                Form4progskeleton.Panel2.Tag = Form17ReviewCheckoutDeet
                Form17ReviewCheckoutDeet.BringToFront()
                Form17ReviewCheckoutDeet.Show()
            End If
        End If
    End Sub
End Class