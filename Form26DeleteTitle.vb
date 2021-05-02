Imports System.Data.SqlClient

Public Class Form26DeleteTitle
    Dim cn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\DB1.mdf;Integrated Security=True")
    Dim cn1 As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\elements.mdf;Integrated Security=True")
    Dim i As Integer

    Private Sub Form26DeleteTitle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.HorizontalScroll.Maximum = 0
        Me.AutoScroll = True
        Dim cmd As New SqlCommand("select name,dev,pub,rating,price,avblstock from gameinfo order by avblstock asc", cn)
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)

        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Orator Std", 18, FontStyle.Bold)
        DataGridView1.DataSource = dt
        For i = 0 To DataGridView1.Rows.Count - 1
            Dim row1 As DataGridViewRow = DataGridView1.Rows(i)
            row1.Height = 60
            DataGridView1.Rows(i).DefaultCellStyle.Font = New Font("Orator Std", 18)
        Next
        DataGridView1.Columns(0).Width = 300
        DataGridView1.Columns(1).Width = 300
        DataGridView1.Columns(2).Width = 300
        DataGridView1.Columns(3).Width = 150
        DataGridView1.Columns(4).Width = 150
        DataGridView1.Columns(5).Width = 200
    End Sub
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Dim cmd As New SqlCommand("select name,dev,pub,rating,price,avblstock from gameinfo where name like '%" & TextBox2.Text & "%' order by avblstock asc", cn)
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)

        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Orator Std", 18, FontStyle.Bold)
        DataGridView1.DataSource = dt
        For i = 0 To DataGridView1.Rows.Count - 1
            Dim row1 As DataGridViewRow = DataGridView1.Rows(i)
            row1.Height = 60
            DataGridView1.Rows(i).DefaultCellStyle.Font = New Font("Orator Std", 18)
        Next
        DataGridView1.Columns(0).Width = 300
        DataGridView1.Columns(1).Width = 300
        DataGridView1.Columns(2).Width = 300
        DataGridView1.Columns(3).Width = 150
        DataGridView1.Columns(4).Width = 150
        DataGridView1.Columns(5).Width = 200
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("Please select a Title")
        Else
            Dim result1 As DialogResult = MessageBox.Show("Confirm the Removal of this Title From the Database.", "Blizzard Game Details", MessageBoxButtons.YesNo)
            If result1 = DialogResult.Yes Then
                Dim cmd1 As New SqlCommand("select avblstock from gameinfo where name='" + TextBox1.Text + "'", cn)
                Dim da As New SqlDataAdapter(cmd1)
                Dim dt As New DataTable
                da.Fill(dt)
                Dim cmd As New SqlCommand("delete from gameinfo where name='" + TextBox1.Text + "'", cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                MessageBox.Show("Game Deleted Successfully!")
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

End Class