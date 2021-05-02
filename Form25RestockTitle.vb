Imports System.Data.SqlClient
Public Class Form25RestockTitle
    Dim cn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\DB1.mdf;Integrated Security=True")
    Dim cn1 As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\elements.mdf;Integrated Security=True")
    Dim i As Integer
    Dim stock As Integer = 0

    Public Property s As String
    Private Sub Form25RestockTitle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.HorizontalScroll.Maximum = 0
        Me.AutoScroll = True
        Button3.Hide()
        Button1.Hide()
        TextBox3.Hide()
        Label4.Hide()
        Dim dgv As New DataGridView()


        Filter("select name,dev,pub,rating,price,avblstock from gameinfo order by avblstock asc")

    End Sub
    Private Sub Filter(s As String)
        Dim cmd As New SqlCommand(s, cn)
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)
        DataGridView1.DataSource = dt
        DataGridView1.Columns(0).Width = 300
        DataGridView1.Columns(1).Width = 300
        DataGridView1.Columns(2).Width = 300
        DataGridView1.Columns(3).Width = 150
        DataGridView1.Columns(4).Width = 150
        DataGridView1.Columns(5).Width = 200
    End Sub
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Filter("select name,dev,pub,rating,price,avblstock from gameinfo where name like '%" & TextBox2.Text & "%' order by avblstock asc")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("Please Select a Title.")
        Else
            Button2.Hide()
            Button1.Show()
            Button3.Show()
            TextBox3.Show()
            Label4.Show()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox3.Text = "" Then
            MessageBox.Show("Enter Stock Amount to Be Purchased.")
        Else
            Dim result1 As DialogResult = MessageBox.Show("Confirm Pruchase?", "Blizzard Stock Details", MessageBoxButtons.YesNo)
            If result1 = DialogResult.Yes Then
                Dim cmd1 As New SqlCommand("select avblstock from gameinfo where name='" + TextBox1.Text + "'", cn)
                Dim da As New SqlDataAdapter(cmd1)
                Dim dt As New DataTable
                da.Fill(dt)
                stock = dt.Rows(0).Item(0)
                stock = stock + TextBox3.Text
                Dim cmd As New SqlCommand("update gameinfo set avblstock=@as where name='" + TextBox1.Text + "'", cn)
                cn.Open()
                cmd.Parameters.AddWithValue("@as", stock)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Stock Purchased Successfully!")
                cn.Close()
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            Dim i As Integer
            i = e.RowIndex
            Dim sr As DataGridViewRow
            sr = DataGridView1.Rows(i)
            TextBox1.Text = sr.Cells(0).Value.ToString()
        Catch e1 As Exception
            Console.WriteLine("Exception caught: {0}", e1)
        End Try
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim result As DialogResult = MessageBox.Show("Do you want to go back? Data not stored will be deleted.", "Blizzard Game Details", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Form20AdminSkeleton.OpenMainPanel(New Form21GameDB)
            Me.Close()
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
End Class