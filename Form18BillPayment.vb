Imports System.Data.SqlClient
Public Class Form18BillPayment
    Dim cn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\DB1.mdf;Integrated Security=True")
    Dim cn1 As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\elements.mdf;Integrated Security=True")
    Private rng As New Random
    Dim i As Integer

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim result1 As DialogResult = MessageBox.Show("Are you sure you want to go back to home page? Your checkout details will not be saved", "Blizzard Checkout Details", MessageBoxButtons.YesNo)
        If result1 = DialogResult.Yes Then
            Form4progskeleton.OpenMainPanel(New Form5home)
            Form4progskeleton.OpenSubPanel(New Form8searchgame)
            Me.Close()
        End If
    End Sub

    Private Sub Form18BillPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.HorizontalScroll.Maximum = 0
        Me.AutoScroll = True
        Label8.Hide()
        Label8.Text = ""
        Label9.Hide()
        Label3.Text = Form17ReviewCheckoutDeet.Label3.Text
        Timer1.Enabled = True
        Dim cmd As New SqlCommand("select * from " + Form1.TextBox1.Text + "_svdcards", cn1)
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)
        For Each row As DataRow In dt.Rows
            ComboBox1.Items.Add(DirectCast(row, System.Data.DataRow)("nickname").ToString())
        Next
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
        If TextBox1.Text = "" Or TextBox4.Text = "" Or TextBox2.Text = "" Then
            MessageBox.Show("Fields Cannot Be Empty")
            'ElseIf textbox2.TextLength < 16 Then
            '    MessageBox.Show("Incorrect Card Number")
            'ElseIf textbox4.TextLength < 4 Then
            '    MessageBox.Show("Incorrect CVV Number")
        Else
            Dim result1 As DialogResult = MessageBox.Show("Are you sure you want to proceed?", "Blizzard Checkout Details", MessageBoxButtons.YesNo)
            If result1 = DialogResult.Yes Then
                'check payment
                Try
                    Dim getdeets As New SqlCommand("select * from unicard where cardno = '" + TextBox2.Text + "'", cn)
                    Dim dt1 As New DataTable
                    Dim da1 As New SqlDataAdapter(getdeets)
                    Dim name1 As String = ""
                    Dim cardno1 As String = ""
                    Dim expdate1 As String = ""
                    Dim cvv1 As String = ""
                    da1.Fill(dt1)
                    For Each row As DataRow In dt1.Rows
                        name1 = (DirectCast(row, System.Data.DataRow)("name").ToString())
                        expdate1 = (DirectCast(row, System.Data.DataRow)("expdate"))
                        cardno1 = (DirectCast(row, System.Data.DataRow)("cardno").ToString())
                        cvv1 = (DirectCast(row, System.Data.DataRow)("cvv").ToString())
                    Next
                    If TextBox2.Text <> cardno1 Or TextBox1.Text <> name1 Or TextBox4.Text <> cvv1 Or DateTimePicker1.Value <> expdate1 Then
                        MessageBox.Show("Incorrect details")
                    Else
                        Dim c As New SqlCommand("select id,name,price,type from " + Form1.TextBox1.Text + "_mycart", cn1)
                        Dim da As New SqlDataAdapter(c)
                        Dim dt As New DataTable
                        dt.Clear()
                        da.Fill(dt)
                        Dim dig As String = ""
                        For Each row As DataRow In dt.Rows
                            If Label8.Text = "" Then
                                Label8.Text = (DirectCast(row, System.Data.DataRow)("name").ToString())
                                Dim number1 = String.Concat(Enumerable.Range(1, 25).Select(Function(n) rng.Next(0, 10)))
                                dig = number1.ToString
                            Else
                                Label8.Text = Label8.Text & "," & (DirectCast(row, System.Data.DataRow)("name").ToString())
                                Dim number = String.Concat(Enumerable.Range(1, 25).Select(Function(n) rng.Next(0, 10)))
                                dig = dig + "," + number.ToString
                            End If
                        Next

                        For i = 0 To dt.Rows.Count - 1
                            Dim netcmd As New SqlCommand("select netsale from gameinfo where name = '" + dt.Rows(i)(1).ToString + "'", cn)
                            Dim data As New SqlDataAdapter(netcmd)
                            Dim tab As New DataTable
                            data.Fill(tab)
                            Dim rownet As String = tab.Rows(0)(0).ToString
                            rownet = rownet + 1
                            Dim netcmd1 As New SqlCommand("update gameinfo set netsale=@net where name = '" + dt.Rows(i)(1).ToString + "'", cn)
                            cn.Open()
                            netcmd1.Parameters.AddWithValue("@net", rownet)
                            netcmd1.ExecuteNonQuery()
                            cn.Close()

                        Next
                        Dim cmd As New SqlCommand("insert into " + Form1.TextBox1.Text + "_orderhist values (@dt,@add,@d)", cn1)
                        cn1.Open()
                        cmd.Parameters.AddWithValue("@dt", Label9.Text)
                        cmd.Parameters.AddWithValue("@add", Label8.Text)
                        cmd.Parameters.AddWithValue("@d", dig)

                        cmd.ExecuteNonQuery()
                        cn1.Close()
                        Dim c1 As New SqlCommand("truncate table " + Form1.TextBox1.Text + "_mycart", cn1)
                        cn1.Open()
                        c1.ExecuteNonQuery()
                        cn1.Close()














                        Form4progskeleton.OpenMainPanel(New Form19ThankYou)
                    End If
                Catch e1 As Exception
                    MessageBox.Show("Error!: " + e1.Message.ToString())
                End Try
            End If
        End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label9.Text = Date.Now.ToString("dd/MM/yyyy hh:mm:ss")
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim charactersAllowed As String = " ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890"
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