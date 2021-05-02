Imports System.Data.SqlClient
Public Class Form14Cart
    Dim cn1 As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\elements.mdf;Integrated Security=True")
    Dim cn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\DB1.mdf;Integrated Security=True")


    Private Sub Form14Cart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox2.Enabled = False
        ListBox1.ForeColor = Color.Black
        ListBox2.ForeColor = Color.Black

        Dim c As New SqlCommand("select id,name,price,type from " + Form1.TextBox1.Text + "_mycart", cn1)
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
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result1 As DialogResult = MessageBox.Show("Are you sure you want to delete this item?", "Blizzard Cart Details", MessageBoxButtons.YesNo)
        If result1 = DialogResult.Yes Then
            Dim c As New SqlCommand("delete from " + Form1.TextBox1.Text + "_mycart where name='" + ListBox1.SelectedItem + "'", cn1)
            cn1.Open()
            c.ExecuteNonQuery()
            cn1.Close()
            Dim select1 As Integer = ListBox1.SelectedIndex
            ListBox1.Items.RemoveAt(select1)
            ListBox2.Items.RemoveAt(select1)
        End If
        Dim l As Integer = 0
        For l_index As Integer = 0 To ListBox2.Items.Count - 1

            l = l + CInt(ListBox2.Items(l_index))
        Next
        Label3.Text = l
    End Sub
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result1 As DialogResult = MessageBox.Show("Are you sure you want to proceed to checkout?", "Blizzard Cart Details", MessageBoxButtons.YesNo)
        If result1 = DialogResult.Yes Then
            Form4progskeleton.OpenMainPanel(New Form16selectBillAdd)
            Form4progskeleton.OpenSubPanel(New Form4BGDesign)
        End If
    End Sub
End Class