Imports System.Data.SqlClient
Public Class Form13SavedCards
    Dim cn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\DB1.mdf;Integrated Security=True")
    Dim cn1 As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\elements.mdf;Integrated Security=True")
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Form4progskeleton.OpenMainPanel(New Form9AccountDeets)
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim cmd1 As New SqlCommand("select * from " + Form1.TextBox1.Text + "_svdcards where nickname ='" + ComboBox1.SelectedItem + "'", cn1)
        Dim da As New SqlDataAdapter(cmd1)
        Dim dt As New DataTable
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            TextBox1.Text = (DirectCast(row, System.Data.DataRow)("name").ToString())
            TextBox2.Text = (DirectCast(row, System.Data.DataRow)("cardno").ToString())
            DateTimePicker1.Value = (DirectCast(row, System.Data.DataRow)("expdate"))
            TextBox4.Text = (DirectCast(row, System.Data.DataRow)("cvv").ToString())
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.ReadOnly = False
        TextBox2.ReadOnly = False
        TextBox4.ReadOnly = False
        TextBox5.ReadOnly = False
        DateTimePicker1.Enabled = True
        TextBox5.Show()
        ComboBox1.Hide()
        Button2.Hide()
        Label3.Show()
        Button3.Show()
        Button1.Hide()
        Button4.Show()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""

    End Sub

    Private Sub Form13SavedCards_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.HorizontalScroll.Maximum = 0
        Me.AutoScroll = True
        Button1.Show()
        Button3.Hide()
        Label3.Hide()
        TextBox5.Hide()
        Button4.Hide()
        TextBox1.ReadOnly = True
        TextBox2.ReadOnly = True
        TextBox4.ReadOnly = True
        TextBox5.ReadOnly = True
        DateTimePicker1.Enabled = False
        Dim cmd As New SqlCommand("select * from " + Form1.TextBox1.Text + "_svdcards", cn1)
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            ComboBox1.Items.Add(DirectCast(row, System.Data.DataRow)("nickname").ToString())
        Next
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Then
            MessageBox.Show("Fields Cannot Be Empty")
        ElseIf textbox2.TextLength < 17 Then
            MessageBox.Show("Incorrect Card Number")
        ElseIf textbox4.TextLength < 4 Then
            MessageBox.Show("Incorrect CVV Number")
        Else
            Dim result As DialogResult = MessageBox.Show("Do you want to save this card?", "Blizzard Card Details", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Dim cmd As New SqlCommand("insert into " + Form1.TextBox1.Text + "_svdcards(nickname,name,cardno,expdate,cvv) values(@nn,@nam,@cardn,@exp,@c)", cn1)
                cn1.Open()
                cmd.Parameters.AddWithValue("@nn", TextBox5.Text)
                cmd.Parameters.AddWithValue("@nam", TextBox1.Text)
                cmd.Parameters.AddWithValue("@cardn", TextBox2.Text)
                cmd.Parameters.AddWithValue("@exp", DateTimePicker1.Value)
                cmd.Parameters.AddWithValue("@c", TextBox4.Text)
                Dim value = cmd.ExecuteScalar()
                If value > 0 Then
                    MessageBox.Show("Unsuccessful!")
                Else
                    MessageBox.Show("Card added successfully!")
                End If
                cn.Close()
                Dim cmd1 As New SqlCommand("insert into unicard values(@nam1,@cardn1,@exp1,@c1)", cn)
                cn.Open()
                cmd1.Parameters.AddWithValue("@nam1", TextBox1.Text)
                cmd1.Parameters.AddWithValue("@cardn1", TextBox2.Text)
                cmd1.Parameters.AddWithValue("@exp1", DateTimePicker1.Value)
                cmd1.Parameters.AddWithValue("@c1", TextBox4.Text)
                Dim val1 = cmd1.ExecuteScalar()
                cn.Close()
                Button1.Hide()
                Button3.Hide()
                Button2.Show()
                TextBox5.Hide()
                ComboBox1.Show()
                TextBox1.ReadOnly = True
                TextBox2.ReadOnly = True
                TextBox4.ReadOnly = True
                TextBox5.ReadOnly = True
                DateTimePicker1.Enabled = False
                Form4progskeleton.OpenMainPanel(New Form13SavedCards)
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim result As DialogResult = MessageBox.Show("Do you want to cancel?", "Blizzard Address Details", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            TextBox1.ReadOnly = True
            TextBox2.ReadOnly = True
            TextBox4.ReadOnly = True
            TextBox5.ReadOnly = True
            DateTimePicker1.Enabled = False
            Dim cmd1 As New SqlCommand("select * from " + Form1.TextBox1.Text + "_svdcards where nickname ='" + ComboBox1.SelectedItem + "'", cn1)
            Dim da As New SqlDataAdapter(cmd1)
            Dim dt As New DataTable
            da.Fill(dt)
            For Each row As DataRow In dt.Rows
                TextBox1.Text = (DirectCast(row, System.Data.DataRow)("name").ToString())
                TextBox2.Text = (DirectCast(row, System.Data.DataRow)("cardno").ToString())
                DateTimePicker1.Value = (DirectCast(row, System.Data.DataRow)("expdate"))
                TextBox4.Text = (DirectCast(row, System.Data.DataRow)("cvv").ToString())
            Next
        End If
        Button1.Hide()
        Button3.Hide()
        Button2.Show()
        TextBox5.Hide()
        ComboBox1.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("Please Choose a NickName")
        Else
            Dim result1 As DialogResult = MessageBox.Show("Are you sure you want to delete this Card?", "Blizzard Card Details", MessageBoxButtons.YesNo)
            If result1 = DialogResult.Yes Then
                Dim cmd As New SqlCommand("delete from " + Form1.TextBox1.Text + "_svdcards where nickname= '" + ComboBox1.SelectedItem + "'", cn1)
                cn1.Open()
                cmd.ExecuteNonQuery()
                cn1.Close()
                Form4progskeleton.OpenMainPanel(New Form13SavedCards)
            End If
        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        Dim charactersAllowed As String = " _abcdefghijklmnopqrstuvwxyz1234567890"
        Dim theText As String = TextBox5.Text
        Dim Letter As String
        Dim SelectionIndex As Integer = TextBox5.SelectionStart
        Dim Change As Integer
        For x As Integer = 0 To TextBox5.Text.Length - 1
            Letter = TextBox5.Text.Substring(x, 1)
            If charactersAllowed.Contains(Letter) = False Then
                theText = theText.Replace(Letter, String.Empty)
                Change = 1
            End If
        Next

        TextBox5.Text = theText
        TextBox5.Select(SelectionIndex - Change, 0)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim charactersAllowed As String = " ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
        Dim theText As String = TextBox1.Text
        Dim Letter As String
        Dim SelectionIndex As Integer = TextBox1.SelectionStart
        Dim Change As Integer

        For x As Integer = 0 To TextBox1.Text.Length - 1
            Letter = TextBox1.Text.Substring(x, 1)
            If charactersAllowed.Contains(Letter) = False Then
                theText = theText.Replace(Letter, String.Empty)
                Change = 1
            End If
        Next

        TextBox1.Text = theText
        TextBox1.Select(SelectionIndex - Change, 0)
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Dim charactersAllowed As String = "1234567890"
        Dim theText As String = TextBox2.Text
        Dim Letter As String
        Dim SelectionIndex As Integer = TextBox2.SelectionStart
        Dim Change As Integer

        For x As Integer = 0 To TextBox2.Text.Length - 1
            Letter = TextBox2.Text.Substring(x, 1)
            If charactersAllowed.Contains(Letter) = False Then
                theText = theText.Replace(Letter, String.Empty)
                Change = 1
            End If
        Next

        TextBox2.Text = theText
        TextBox2.Select(SelectionIndex - Change, 0)
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        Dim charactersAllowed As String = "1234567890"
        Dim theText As String = TextBox4.Text
        Dim Letter As String
        Dim SelectionIndex As Integer = TextBox4.SelectionStart
        Dim Change As Integer

        For x As Integer = 0 To TextBox4.Text.Length - 1
            Letter = TextBox4.Text.Substring(x, 1)
            If charactersAllowed.Contains(Letter) = False Then
                theText = theText.Replace(Letter, String.Empty)
                Change = 1
            End If
        Next

        TextBox4.Text = theText
        TextBox4.Select(SelectionIndex - Change, 0)
    End Sub
End Class