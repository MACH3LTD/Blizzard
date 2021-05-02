Imports System.Data.SqlClient
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Public Class Form28UserReport
    Dim cn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\DB1.mdf;Integrated Security=True")
    Dim cn1 As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\elements.mdf;Integrated Security=True")
    Dim rowc As Integer = 0
    Dim currentcommand As String = ""

    Private Sub Form28UserReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SaveFileDialog1.FileName = ""
        SaveFileDialog1.Filter = "PDF (*.pdf)|*.pdf"
        Me.HorizontalScroll.Maximum = 0
        Me.AutoScroll = True
        Timer1.Enabled = True
        Label3.Hide()

        Filter("select username, name, DOB, phno, emailid from userinfo order by name asc")

    End Sub
    Private Sub Filter(s As String)
        currentcommand = s
        Dim cmd As New SqlCommand(s, cn)
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)
        rowc = dt.Rows.Count
        DataGridView1.DataSource = dt
        DataGridView1.Refresh()
        DataGridView1.Columns(0).Width = 300
        DataGridView1.Columns(1).Width = 300
        DataGridView1.Columns(2).Width = 300
        DataGridView1.Columns(3).Width = 150
        DataGridView1.Columns(4).Width = 150

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
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        SaveFileDialog1.ShowDialog()
        If SaveFileDialog1.FileName = "" Then
            MessageBox.Show("Enter File Name!")
        Else
            export1()
            MessageBox.Show("PDF Successfully Created!")
        End If
    End Sub
    Private Sub export1()
        Dim cmd As New SqlCommand(currentcommand, cn)
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)
        rowc = dt.Rows.Count
        Dim p As New Paragraph
        Dim doc As New Document(iTextSharp.text.PageSize.A4, 40, 40, 40, 10)
        Dim w As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(SaveFileDialog1.FileName + ".pdf", FileMode.Create))
        Dim fontnormal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)
        Dim font As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)


        p = New Paragraph(New Chunk("BLIZZARD USER REPORT (" & Label3.Text & ")", font))
        doc.Open()
        doc.Add(p)

        Dim pdftable As New PdfPTable(dt.Columns.Count)
        pdftable.TotalWidth = 400.0F
        pdftable.LockedWidth = True

        Dim widths(0 To dt.Columns.Count - 1) As Single
        For i As Integer = 0 To dt.Columns.Count - 1
            widths(i) = 1.0F
        Next
        pdftable.SetWidths(widths)
        pdftable.HorizontalAlignment = 0
        pdftable.SpacingBefore = 2.0F

        Dim pdfcell As PdfPCell = New PdfPCell

        For i As Integer = 0 To dt.Columns.Count - 1
            pdfcell = New PdfPCell(New Phrase(New Chunk(DataGridView1.Columns(i).HeaderText, font)))
            pdfcell.HorizontalAlignment = PdfPCell.ALIGN_LEFT
            pdftable.AddCell(pdfcell)
        Next


        For rows As Integer = 0 To dt.Rows.Count - 1
            For columns As Integer = 0 To dt.Columns.Count - 1
                pdfcell = New PdfPCell(New Phrase(dt(rows)(columns).ToString(), fontnormal))
                pdftable.HorizontalAlignment = PdfPCell.ALIGN_LEFT

                pdftable.AddCell(pdfcell)
            Next
        Next
        doc.Add(pdftable)
        doc.Close()
        MessageBox.Show("PDF exported successfully!")
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label3.Text = Date.Now.ToString("dd/MM/yyyy hh:mm:ss")
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("Please Select a User")
        Else
            Dim result1 As DialogResult = MessageBox.Show("Are you sure you want to Delete this User?", "Blizzard User Details", MessageBoxButtons.YesNo)
            If result1 = DialogResult.Yes Then
                Dim c As New SqlCommand("drop table " + TextBox1.Text + "_mycart", cn1)
                cn1.Open()
                c.ExecuteNonQuery()
                cn1.Close()
                Dim c1 As New SqlCommand("drop table " + TextBox1.Text + "_orderhist", cn1)
                cn1.Open()
                c1.ExecuteNonQuery()
                cn1.Close()
                Dim c2 As New SqlCommand("drop table " + TextBox1.Text + "_svdadd", cn1)
                cn1.Open()
                c2.ExecuteNonQuery()
                cn1.Close()
                Dim c3 As New SqlCommand("drop table " + TextBox1.Text + "_svdcards", cn1)
                cn1.Open()
                c3.ExecuteNonQuery()
                cn1.Close()
                Dim try1 As New SqlCommand("delete from userinfo where username ='" + TextBox1.Text + "'", cn)
                cn.Open()
                try1.ExecuteNonQuery()
                cn.Close()
                MessageBox.Show("User Has Been Removed")
            End If
        End If
    End Sub



End Class