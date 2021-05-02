Imports System.Data.SqlClient

Public Class Form17ReviewCheckoutDeet
    Dim cn1 As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\elements.mdf;Integrated Security=True")
    Public Property add As String

    Dim cn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\DB1.mdf;Integrated Security=True")
    Private Sub Form17ReviewCheckoutDeet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.HorizontalScroll.Maximum = 0
        Me.AutoScroll = True
        ListBox1.Enabled = False
        ListBox2.Enabled = False
        RichTextBox1.ReadOnly = True
        Dim c As New SqlCommand("select name,price from " + Form1.TextBox1.Text + "_mycart", cn1)
        Dim da As New SqlDataAdapter(c)
        Dim dt As New DataTable
        dt.Clear()
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            ListBox1.Items.Add(DirectCast(row, System.Data.DataRow)("name").ToString())
            ListBox2.Items.Add(DirectCast(row, System.Data.DataRow)("price").ToString())

        Next
        Dim l As Integer = 0
        For l_index As Integer = 0 To ListBox2.Items.Count - 1

            l = l + CInt(ListBox2.Items(l_index))
        Next
        Label3.Text = l
        RichTextBox1.Text = add
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim result1 As DialogResult = MessageBox.Show("Are you sure you want to go back? You will be redirected to your cart and your checkout details will not be saved", "Blizzard Checkout Details", MessageBoxButtons.YesNo)
        If result1 = DialogResult.Yes Then
            Form4progskeleton.OpenMainPanel(New Form14Cart)
            Form4progskeleton.OpenSubPanel(New Form8searchgame)

            Form4BGDesign.Hide()
            Form4BGDesign.Close()
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result1 As DialogResult = MessageBox.Show("Are you sure you want to proceed?", "Blizzard Checkout Details", MessageBoxButtons.YesNo)
        If result1 = DialogResult.Yes Then

            Form4progskeleton.OpenMainPanel(New Form18BillPayment)

        End If
    End Sub
End Class