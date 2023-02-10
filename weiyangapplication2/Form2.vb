
Imports MySql.Data.MySqlClient
Imports System.IO 'Working With Files
Imports System.Text 'Working With Text

'iTextSharp Libraries
Imports iTextSharp.text 'Core PDF Text Functionalities
Imports iTextSharp.text.pdf 'PDF Content
Imports iTextSharp.text.pdf.parser 'Content Parser
Imports ClosedXML.Excel

Public Class Form2

    Dim sqlConn As New MySqlConnection
    Dim sqlCmd As New MySqlCommand
    Dim sqlRd As MySqlDataReader
    Dim sqlDt As New DataTable
    Dim Dt As New MySqlDataAdapter
    Dim sqlRd2 As MySqlDataReader
    Dim sqlRd3 As MySqlDataReader
    Dim sqlRd4 As MySqlDataReader
    Dim sqlRd5 As MySqlDataReader

    Dim server As String = "localhost"
    Dim username As String = "root"
    Dim password As String = "weiyang"
    Dim database As String = "database"

    Private Sub updateTable()
        sqlConn.ConnectionString = "server =" + server + ";" + "user id=" + username + ";" +
            "password=" + password + ";" + "database=" + database

        sqlConn.Open()
        sqlCmd.Connection = sqlConn
        sqlCmd.CommandText = "SELECT * FROM database.transaction;"

        sqlRd = sqlCmd.ExecuteReader
        sqlDt.Load(sqlRd)
        sqlRd.Close()
        sqlConn.Close()
        DataGridView1.DataSource = sqlDt

    End Sub

    Private Sub updateChart()

        sqlConn.ConnectionString = "server =" + server + ";" + "user id=" + username + ";" +
            "password=" + password + ";" + "database=" + database

        Try
            sqlConn.Open()
            sqlCmd.Connection = sqlConn
            sqlCmd.CommandText = "SELECT * FROM database.transaction;"

            sqlRd5 = sqlCmd.ExecuteReader

            While sqlRd5.Read
                Chart1.Series("Spend").Points.AddXY(sqlRd5.GetString("categories"), sqlRd5.GetInt32("amount"))
                Chart2.Series("Spend").Points.AddXY(sqlRd5.GetString("categories"), sqlRd5.GetInt32("amount"))
            End While

            sqlConn.Close()

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            sqlConn.Dispose()

        End Try

    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        updateChart()
    End Sub


    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Form3.Show()
        Me.Hide()
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FolderBrowserDialog1.ShowDialog()

        Dim pdfDoc As New Document(PageSize.A4, 40, 40, 40, 20)
        Dim pdfWrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(FolderBrowserDialog1.SelectedPath.ToString + "\statament.pdf", FileMode.Create))
        Dim Paragraph As New Paragraph

        pdfDoc.Open()


        'pdfDoc.Add(New Paragraph("Hello World"))
        'pdfDoc.NewPage()
        'pdfDoc.Add(New Paragraph("Hello World Again"))

        pdfDoc.AddTitle("Wei Yang Statement")

        Dim pTitle As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim pTable As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK)

        'title to center
        Paragraph = New Paragraph(New Chunk("Wei Yang Statenment", pTitle))
        Paragraph.Alignment = Element.ALIGN_CENTER
        Paragraph.SpacingAfter = 5.0F
        pdfDoc.Add(Paragraph)

        'create data into table
        Dim PdfTable As New PdfPTable(DataGridView1.Columns.Count)
        'set width of table
        PdfTable.TotalWidth = 500.0F
        PdfTable.LockedWidth = True

        Dim widths(0 To DataGridView1.Columns.Count - 1) As Single
        For i As Integer = 0 To DataGridView1.Columns.Count - 1
            widths(i) = 1.0F
        Next

        PdfTable.SetWidths(widths)
        PdfTable.HorizontalAlignment = 0
        PdfTable.SpacingBefore = 5.0F

        'decalraion pdf cell
        Dim pdfcell As PdfPCell = New PdfPCell

        'craete pdf header
        For i As Integer = 0 To DataGridView1.Columns.Count - 1
            pdfcell = New PdfPCell(New Phrase(New Chunk(DataGridView1.Columns(i).HeaderText, pTable)))
            'align header table
            pdfcell.HorizontalAlignment = PdfPCell.ALIGN_LEFT
            'add cells into pdftable
            PdfTable.AddCell(pdfcell)
        Next

        'add data into pdf table
        For i As Integer = 0 To DataGridView1.Rows.Count - 2
            For j As Integer = 0 To DataGridView1.Columns.Count - 1
                pdfcell = New PdfPCell(New Phrase(DataGridView1(j, i).Value.ToString(), pTable))
                PdfTable.HorizontalAlignment = PdfPCell.ALIGN_LEFT
                PdfTable.AddCell(pdfcell)

            Next
        Next

        'add pdf table into pdf document
        pdfDoc.Add(PdfTable)

        pdfDoc.Close()
        MessageBox.Show("You have sucessfully export your pdf statement file")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        Using sfd As SaveFileDialog = New SaveFileDialog() With {.Filter = "Excel Worksheet|*.xlsx"}
            If sfd.ShowDialog() = DialogResult.OK Then
                Try
                    Using workbook As XLWorkbook = New XLWorkbook()
                        workbook.Worksheets.Add(sqlDt, "test")
                        workbook.SaveAs(sfd.FileName)
                    End Using
                    MessageBox.Show("You have sucessfully export your  excel file")
                Catch ex As Exception
                    MessageBox.Show(ex.Message)

                End Try
            End If

        End Using
    End Sub

    Private Sub updateSum()
        sqlConn.ConnectionString = "server =" + server + ";" + "user id=" + username + ";" +
            "password=" + password + ";" + "database=" + database

        sqlConn.Open()
        sqlCmd.Connection = sqlConn
        sqlCmd.CommandText = "SELECT SUM(amount) AS sum FROM database.transaction;"

        sqlRd2 = sqlCmd.ExecuteReader
        If sqlRd2.Read Then
            Label3.Text = sqlRd2("sum")
        Else
            MessageBox.Show("No data founded")
        End If


        sqlRd2.Close()
        sqlConn.Close()


    End Sub

    Private Sub updateEarn()

        sqlConn.ConnectionString = "server =" + server + ";" + "user id=" + username + ";" +
            "password=" + password + ";" + "database=" + database

        sqlConn.Open()
        sqlCmd.Connection = sqlConn
        sqlCmd.CommandText = "SELECT sum(case when amount>0 then amount else 0 end)AS Earn FROM database.transaction;"

        sqlRd3 = sqlCmd.ExecuteReader
        If sqlRd3.Read Then
            Label1.Text = sqlRd3("Earn")
            Label13.Text = (sqlRd3("Earn") * 40) / 100
            Label14.Text = (sqlRd3("Earn") * 10) / 100
            Label15.Text = (sqlRd3("Earn") * 50) / 100
            TextBox1.Text = 40%
            TextBox2.Text = 10%
            TextBox3.Text = 50%

        Else
            MessageBox.Show("No data founded")
        End If


        sqlRd3.Close()
        sqlConn.Close()


    End Sub

    Private Sub updateSpend()
        sqlConn.ConnectionString = "server =" + server + ";" + "user id=" + username + ";" +
            "password=" + password + ";" + "database=" + database

        sqlConn.Open()
        sqlCmd.Connection = sqlConn
        sqlCmd.CommandText = "SELECT sum(case when amount<0 then amount else 0 end) AS Spend FROM database.transaction;"

        sqlRd4 = sqlCmd.ExecuteReader
        If sqlRd4.Read Then
            Label5.Text = sqlRd4("Spend")
        Else
            MessageBox.Show("No data founded")
        End If


        sqlRd4.Close()
        sqlConn.Close()


    End Sub

    Private Sub Form2_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        sqlConn.ConnectionString = "server =" + server + ";" + "user id=" + username + ";" +
            "password=" + password + ";" + "database=" + database

        sqlConn.Open()
        sqlCmd.Connection = sqlConn
        sqlCmd.CommandText = "SELECT * FROM database.transaction;"

        sqlRd = sqlCmd.ExecuteReader
        sqlDt.Load(sqlRd)
        sqlRd.Close()
        sqlConn.Close()
        sqlDt.Clear()
        DataGridView1.DataSource = sqlDt
        updateTable()
        updateSpend()
        updateEarn()
        updateSum()
        Chart1.Series("Spend").Points.Clear()
        Chart2.Series("Spend").Points.Clear()
        updateChart()
    End Sub

End Class