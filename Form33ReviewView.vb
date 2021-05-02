Imports System.Data.SqlClient
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Public Class Form33ReviewView
    Dim cn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\DB1.mdf;Integrated Security=True")
    Dim cn1 As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\College\IV Sem\Software Development\Blizzard\Blizzard v2\Blizzard\elements.mdf;Integrated Security=True")
    Dim rowc As Integer = 0
    Dim currentcommand As String = ""
    Private Sub Form33ReviewView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SaveFileDialog1.FileName = ""
        SaveFileDialog1.Filter = "PDF (*.pdf)|*.pdf"
        Timer1.Enabled = True
        Label3.Hide()
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
        DataGridView1.Columns(2).Width = 600

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            Filter("select * from reviews where Type = 'Blizzard'")
        End If

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            Filter("select * from reviews where Type <> 'Blizzard'")
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If RadioButton1.Checked = False And RadioButton2.Checked = False Then
            MessageBox.Show("Please choose a Filter.")
        Else
            SaveFileDialog1.ShowDialog()
            If SaveFileDialog1.FileName = "" Then
                MessageBox.Show("Enter File Name!")
            Else
                export1()
                MessageBox.Show("PDF Successfully Created!")
            End If
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


        p = New Paragraph(New Chunk("BLIZZARD REVIEW REPORT (" & Label3.Text & ")", font))
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
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label3.Text = Date.Now.ToString("dd/MM/yyyy hh:mm:ss")
    End Sub
End Class