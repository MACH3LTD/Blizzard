Imports System.Data.SqlClient
Public Class Form10LogAndSec
    Dim RdOnly As Boolean = False
    Dim cn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\DB1.mdf;Integrated Security=True")
    Dim cn1 As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\elements.mdf;Integrated Security=True")
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Form4progskeleton.OpenMainPanel(New Form9AccountDeets)
        Me.Close()
    End Sub

    Private Sub Form10LogAndSec_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.HorizontalScroll.Maximum = 0
            Me.AutoScroll = True
            RdOnly = True
            TextBox1.BackColor = Color.LightGray
            TextBox2.BackColor = Color.LightGray
            DateTimePicker1.Enabled = False
            TextBox4.BackColor = Color.LightGray
            TextBox5.BackColor = Color.LightGray
            TextBox6.BackColor = Color.LightGray
            TextBox7.BackColor = Color.LightGray
            Dim c As SqlCommand = New SqlCommand("select * from userinfo where username ='" + Form1.TextBox1.Text + "'", cn)
            Dim da As New SqlDataAdapter(c)
            Dim dt As New DataTable
            Dim dat As New Date
            da.Fill(dt)
            For Each row As DataRow In dt.Rows
                TextBox1.Text = (DirectCast(row, System.Data.DataRow)("username").ToString())
                TextBox2.Text = (DirectCast(row, System.Data.DataRow)("name").ToString())
                DateTimePicker1.Value = (DirectCast(row, System.Data.DataRow)("DOB"))
                TextBox4.Text = (DirectCast(row, System.Data.DataRow)("emailid").ToString())
                TextBox7.Text = (DirectCast(row, System.Data.DataRow)("password").ToString())
                TextBox5.Text = (DirectCast(row, System.Data.DataRow)("secque").ToString())
                TextBox6.Text = (DirectCast(row, System.Data.DataRow)("secans").ToString())
            Next
            Button3.Hide()
            Button2.Hide()
        Catch e1 As Exception
            MessageBox.Show("Error: " + e1.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DateTimePicker1.Enabled = True
        RdOnly = False
        TextBox1.BackColor = Color.White
        TextBox2.BackColor = Color.White
        TextBox4.BackColor = Color.White
        TextBox5.BackColor = Color.White
        TextBox6.BackColor = Color.White
        TextBox7.BackColor = Color.White
        Button1.Hide()
        Button3.Show()
        Button2.Show()
    End Sub
    Function IsValidEmailFormat(ByVal s As String) As Boolean
        Try
            Dim a As New System.Net.Mail.MailAddress(s)
        Catch
            Return False
        End Try
        Return True
    End Function
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim checkemail As Boolean = IsValidEmailFormat(TextBox4.Text)
        Try
            If TextBox1.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox2.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Then
                MessageBox.Show("empty fields not allowed!")
            ElseIf checkemail = False Then
                MessageBox.Show("Incorrect Email Format")
            Else

                RdOnly = True
                TextBox1.BackColor = Color.LightGray
                TextBox2.BackColor = Color.LightGray
                TextBox4.BackColor = Color.LightGray
                TextBox5.BackColor = Color.LightGray
                TextBox6.BackColor = Color.LightGray
                TextBox7.BackColor = Color.LightGray
                Dim result1 As DialogResult = MessageBox.Show("Confirm Update?", "Blizzard User Details", MessageBoxButtons.YesNo)
                If result1 = DialogResult.Yes Then

                    Dim c As New SqlCommand("update userinfo set username=@un, name=@n, DOB=@d, emailid=@e, password=@p, secque=@sq, secans=@sa where username ='" + Form1.TextBox1.Text + "'", cn)
                    Using cn
                        Using c
                            cn.Open()
                            c.Parameters.AddWithValue("@un", TextBox1.Text)
                            c.Parameters.AddWithValue("@n", TextBox2.Text)
                            c.Parameters.AddWithValue("@d", DateTimePicker1.Value)
                            c.Parameters.AddWithValue("@e", TextBox4.Text)
                            c.Parameters.AddWithValue("@p", TextBox7.Text)
                            c.Parameters.AddWithValue("@sq", TextBox5.Text)
                            c.Parameters.AddWithValue("@sa", TextBox6.Text)
                            c.ExecuteNonQuery()
                            Button2.Hide()
                            Button3.Hide()
                            Button1.Show()
                        End Using
                    End Using
                    Dim c1 As New SqlCommand("sys.sp_rename '" + Form1.TextBox1.Text.ToString() + "_mycart' , '" + TextBox1.Text.ToString() + "_mycart'", cn1)
                    Dim c2 As New SqlCommand("sys.sp_rename '" + Form1.TextBox1.Text.ToString() + "_svdadd' , '" + TextBox1.Text.ToString() + "_svdadd'", cn1)
                    Dim c3 As New SqlCommand("sys.sp_rename '" + Form1.TextBox1.Text.ToString() + "_svdcards' , '" + TextBox1.Text.ToString() + "_svdcards'", cn1)
                    Dim c4 As New SqlCommand("sys.sp_rename '" + Form1.TextBox1.Text.ToString() + "_orderhist' , '" + TextBox1.Text.ToString() + "_orderhist'", cn1)

                    cn1.Open()
                    c1.ExecuteNonQuery()
                    c2.ExecuteNonQuery()
                    c3.ExecuteNonQuery()
                    c4.ExecuteNonQuery()

                    cn1.Close()
                    Form4progskeleton.OpenMainPanel(New Form10LogAndSec)

                    'Dim result As DialogResult = MessageBox.Show("You will be logged out and the application will be closed for the changes to be saved.", "Blizzard User Details", MessageBoxButtons.OK)
                    'If result = DialogResult.OK Then
                    '    Application.Exit()
                    'End If

                End If
            End If
        Catch e1 As Exception
            MessageBox.Show("Error: " + e1.Message)

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim r As DialogResult = MessageBox.Show("Do you want to cancel?", "Blizzard User Details", MessageBoxButtons.YesNo)
        If r = DialogResult.Yes Then
            RdOnly = True
            TextBox1.BackColor = Color.LightGray
            TextBox2.BackColor = Color.LightGray
            TextBox4.BackColor = Color.LightGray
            TextBox5.BackColor = Color.LightGray
            TextBox6.BackColor = Color.LightGray
            TextBox7.BackColor = Color.LightGray
            DateTimePicker1.Enabled = False
            Dim c As SqlCommand = New SqlCommand("select * from userinfo where username ='" + Form1.TextBox1.Text + "'", cn)
            Dim da As New SqlDataAdapter(c)
            Dim dt As New DataTable
            da.Fill(dt)
            For Each row As DataRow In dt.Rows
                TextBox1.Text = (DirectCast(row, System.Data.DataRow)("username").ToString())
                TextBox2.Text = (DirectCast(row, System.Data.DataRow)("name").ToString())
                DateTimePicker1.Value = (DirectCast(row, System.Data.DataRow)("DOB"))
                TextBox4.Text = (DirectCast(row, System.Data.DataRow)("emailid").ToString())
                TextBox7.Text = (DirectCast(row, System.Data.DataRow)("password").ToString())
                TextBox5.Text = (DirectCast(row, System.Data.DataRow)("secque").ToString())
                TextBox6.Text = (DirectCast(row, System.Data.DataRow)("secans").ToString())
            Next
            Button2.Hide()
            Button3.Hide()
            Button1.Show()
        End If
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If RdOnly = True Then
            e.KeyChar = ChrW(Keys.None)
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If RdOnly = True Then
            e.KeyChar = ChrW(Keys.None)
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox3_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        If RdOnly = True Then
            e.KeyChar = ChrW(Keys.None)
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox4_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If RdOnly = True Then
            e.KeyChar = ChrW(Keys.None)
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox5_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If RdOnly = True Then
            e.KeyChar = ChrW(Keys.None)
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox6_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        If RdOnly = True Then
            e.KeyChar = ChrW(Keys.None)
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox7_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        If RdOnly = True Then
            e.KeyChar = ChrW(Keys.None)
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim charactersAllowed As String = "_abcdefghijklmnopqrstuvwxyz1234567890"
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
        Dim charactersAllowed As String = " ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
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
        Dim charactersAllowed As String = "@.abcdefghijklmnopqrstuvwxyz1234567890"
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

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub
End Class