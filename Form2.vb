Imports System.Data.SqlClient
Public Class Form2
    Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\DB1.mdf;Integrated Security=True"
    Dim str1 As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\elements.mdf;Integrated Security=True"
    Dim Conn1 As New SqlConnection(str1)
    Dim cn As New SqlConnection(str)
    Dim cmd As New SqlCommand
    Dim cmd1 As New SqlCommand
    Dim cmd2 As New SqlCommand
    Private Property mf As Boolean
    Private Property mfm As Point
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub



    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click


        Me.Close()
        Form1.Show()

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim charactersAllowed As String = " abcdefghijklmnopqrstuvwxyz"
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Try
            If TextBox1.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Then
                MessageBox.Show("empty fields not allowed!")
            Else
                If TextBox3.Text.Trim() = TextBox4.Text.Trim() Then

                    Dim sql As String = "INSERT INTO userinfo (username,name,DOB,password,usertype,log) values (@usernam, @nam, @DO, @passwor,@ut,@l)"
                    Using cn As New SqlConnection(str)
                        Using cmd As New SqlCommand(sql, cn)
                            cn.Open()
                            cmd.Parameters.AddWithValue("@nam", TextBox1.Text)
                            cmd.Parameters.AddWithValue("@DO", DateTimePicker1.Value.ToString)
                            cmd.Parameters.AddWithValue("@passwor", TextBox3.Text)
                            cmd.Parameters.AddWithValue("@usernam", TextBox5.Text)
                            cmd.Parameters.AddWithValue("@ut", "user")
                            cmd.Parameters.AddWithValue("@l", "false")

                            Dim value = cmd.ExecuteScalar()
                            If value > 0 Then
                                MessageBox.Show("signup unsuccessful!")
                            Else
                                MessageBox.Show("Please restart application to ensure successful registration")
                                Application.Exit()

                            End If
                            cn.Close()
                        End Using
                    End Using
                    Dim sql1 As String = "CREATE TABLE " + TextBox5.Text + "_orderhist (number varchar(50), number1 varchar(MAX), digit varchar(MAX))"
                    Using Conn1 As New SqlConnection(str1)
                        Using cmd1 As New SqlCommand(sql1, Conn1)
                            Conn1.Open()
                            cmd1.ExecuteNonQuery()
                            Conn1.Close()
                        End Using
                    End Using
                    Dim sql2 As String = "CREATE TABLE " + TextBox5.Text + "_svdadd (nickname varchar(20), address varchar(MAX))"
                    Using Conn1 As New SqlConnection(str1)
                        Using cmd2 As New SqlCommand(sql2, Conn1)
                            Conn1.Open()
                            cmd2.ExecuteNonQuery()
                            Conn1.Close()

                        End Using
                    End Using
                    Dim sql3 As String = "CREATE TABLE " + TextBox5.Text + "_svdcards (nickname varchar(20), name varchar(MAX), cardno varchar(MAX), expdate date, cvv int)"
                    Using Conn1 As New SqlConnection(str1)
                        Using cmd3 As New SqlCommand(sql3, Conn1)
                            Conn1.Open()
                            cmd3.ExecuteNonQuery()
                            Conn1.Close()

                        End Using
                    End Using
                    Dim sql4 As String = "CREATE TABLE " + TextBox5.Text + "_mycart (id int, name varchar(MAX), price decimal(10,2), type varchar(10))"
                    Using Conn1 As New SqlConnection(str1)
                        Using cmd2 As New SqlCommand(sql4, Conn1)
                            Conn1.Open()
                            cmd2.ExecuteNonQuery()
                            Conn1.Close()

                        End Using
                    End Using
                Else
                    MsgBox("Passwords do not match")
                End If
                TextBox3.Text = ""
                TextBox4.Text = ""

                Dim formpg As New Form1
                Dim signup As New Form2
                Me.Close()
                formpg.Show()
            End If
        Catch e1 As Exception
            MessageBox.Show("Error! " + e1.Message)

        End Try
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        Dim charactersAllowed As String = "_abcdefghijklmnopqrstuvwxyz1234567890"
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
    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp
        If e.Button = MouseButtons.Left Then
            mf = False
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = MouseButtons.Left Then
            mf = True
            Me.Cursor = Cursors.Default
            mfm = e.Location
        End If
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If mf Then
            Me.Location = Me.Location + (e.Location - mfm)
        End If
    End Sub
End Class

'shalalalalaaa