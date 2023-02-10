
Imports MySql.Data.MySqlClient
Public Class Form5

    Dim sqlConn As New MySqlConnection
    Dim sqlCmd As New MySqlCommand
    Dim sqlRd As MySqlDataReader
    Dim sqlRd2 As MySqlDataReader
    Dim sqlDt As New DataTable
    Dim Dt As New MySqlDataAdapter
    Dim sqlQuery As String

    Dim server As String = "localhost"
    Dim username As String = "root"
    Dim password As String = "weiyang"
    Dim database As String = "database"
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        updateTable()
        Me.CenterToScreen()
    End Sub

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


    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Form3.Show()
        Me.Hide()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sqlConn.ConnectionString = "server =" + server + ";" + "user id=" + username + ";" +
            "password=" + password + ";" + "database=" + database

        Try
            sqlConn.Open()
            sqlQuery = "INSERT INTO database.transaction (earn_or_spend, categories, amount) VALUES ('" & TextBox1.Text & "',  '" & TextBox2.Text & "', '" & TextBox3.Text & "');"

            sqlCmd = New MySqlCommand(sqlQuery, sqlConn)
            sqlRd = sqlCmd.ExecuteReader
            sqlConn.Close()
            sqlDt.Clear()
            DataGridView1.DataSource = sqlDt
            updateTable()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            sqlConn.Dispose()
        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            For Each txt In Panel2.Controls
                If TypeOf txt Is TextBox Then
                    txt.text = ""
                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        sqlConn.ConnectionString = "server =" + server + ";" + "user id=" + username + ";" +
            "password=" + password + ";" + "database=" + database

        Try
            sqlConn.Open()
            sqlQuery = "DELETE FROM database.transaction WHERE id=" & DataGridView1.CurrentRow.Cells(0).Value.ToString & ";"

            sqlCmd = New MySqlCommand(sqlQuery, sqlConn)
            sqlRd = sqlCmd.ExecuteReader
            sqlConn.Close()
            sqlDt.Clear()
            DataGridView1.DataSource = sqlDt
            updateTable()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            sqlConn.Dispose()
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        sqlConn.ConnectionString = "server =" + server + ";" + "user id=" + username + ";" +
            "password=" + password + ";" + "database=" + database

        Try
            Dim amount As Object

            amount = InputBox("Please enter your earn amount", " 韓國餐"， "")
            If amount Is "" Then
                MsgBox("Not Filling amount")
            Else
                MsgBox("Successfully Added")
            End If
            sqlConn.Open()
            sqlQuery = "INSERT INTO database.weiyang (earn_or_spend, categories, amount) VALUES ('Earn',  '韓國餐', ' " & amount & " ');"

            sqlCmd = New MySqlCommand(sqlQuery, sqlConn)
            sqlRd = sqlCmd.ExecuteReader
            sqlConn.Close()
            sqlDt.Clear()
            DataGridView1.DataSource = sqlDt
            updateTable()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            sqlConn.Dispose()
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        sqlConn.ConnectionString = "server =" + server + ";" + "user id=" + username + ";" +
           "password=" + password + ";" + "database=" + database

        Try
            Dim amount As Object

            amount = InputBox("Please enter your earn amount", " 游泳"， " ")
            If amount Is "" Then
                MsgBox("Not Filling amount")
            Else
                MsgBox("Successfully Added")
            End If
            sqlConn.Open()
            sqlQuery = "INSERT INTO database.weiyang (earn_or_spend, categories, amount) VALUES ('Earn',  '游泳', ' " & amount & " ');"

            sqlCmd = New MySqlCommand(sqlQuery, sqlConn)
            sqlRd = sqlCmd.ExecuteReader
            sqlConn.Close()
            sqlDt.Clear()
            DataGridView1.DataSource = sqlDt
            updateTable()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            sqlConn.Dispose()
        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        sqlConn.ConnectionString = "server =" + server + ";" + "user id=" + username + ";" +
           "password=" + password + ";" + "database=" + database

        Try
            Dim amount As Object

            amount = InputBox("Please enter your earn amount", "裝修"， "")
            If amount Is "" Then
                MsgBox("Not Filling amount")
            Else
                MsgBox("Successfully Added")
            End If
            sqlConn.Open()
            sqlQuery = "INSERT INTO database.weiyang (earn_or_spend, categories, amount) VALUES ('Earn',  '裝修', ' " & amount & " ');"

            sqlCmd = New MySqlCommand(sqlQuery, sqlConn)
            sqlRd = sqlCmd.ExecuteReader
            sqlConn.Close()
            sqlDt.Clear()
            DataGridView1.DataSource = sqlDt
            updateTable()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            sqlConn.Dispose()
        End Try
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        sqlConn.ConnectionString = "server =" + server + ";" + "user id=" + username + ";" +
           "password=" + password + ";" + "database=" + database

        Try
            Dim amount As Object

            amount = InputBox("Please enter your earn amount", "開銷： 吃"， "")
            If amount Is "" Then
                MsgBox("Not Filling amount")
            Else
                MsgBox("Successfully Added")
            End If
            sqlConn.Open()
            sqlQuery = "INSERT INTO database.weiyang (earn_or_spend, categories, amount) VALUES ('Spend',  '吃', ' " & amount & " ');"

            sqlCmd = New MySqlCommand(sqlQuery, sqlConn)
            sqlRd = sqlCmd.ExecuteReader
            sqlConn.Close()
            sqlDt.Clear()
            DataGridView1.DataSource = sqlDt
            updateTable()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            sqlConn.Dispose()
        End Try
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        sqlConn.ConnectionString = "server =" + server + ";" + "user id=" + username + ";" +
          "password=" + password + ";" + "database=" + database

        Try
            Dim amount As Object

            amount = InputBox("Please enter your earn amount", "開銷： 車"， "\")
            If amount Is "" Then
                MsgBox("Not Filling amount")
            Else
                MsgBox("Successfully Added")
            End If
            sqlConn.Open()
            sqlQuery = "INSERT INTO database.weiyang (earn_or_spend, categories, amount) VALUES ('Spend',  '車', ' " & amount & " ');"

            sqlCmd = New MySqlCommand(sqlQuery, sqlConn)
            sqlRd = sqlCmd.ExecuteReader
            sqlConn.Close()
            sqlDt.Clear()
            DataGridView1.DataSource = sqlDt
            updateTable()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            sqlConn.Dispose()
        End Try
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        sqlConn.ConnectionString = "server =" + server + ";" + "user id=" + username + ";" +
          "password=" + password + ";" + "database=" + database

        Try
            Dim amount As Object

            amount = InputBox("Please enter your earn amount", "開銷： 水電等雜費"， "")
            If amount Is "" Then
                MsgBox("Not Filling amount")
            Else
                MsgBox("Successfully Added")
            End If
            sqlConn.Open()
            sqlQuery = "INSERT INTO database.weiyang (earn_or_spend, categories, amount) VALUES ('Spend',  '水電等雜費', ' " & amount & " ');"

            sqlCmd = New MySqlCommand(sqlQuery, sqlConn)
            sqlRd = sqlCmd.ExecuteReader
            sqlConn.Close()
            sqlDt.Clear()
            DataGridView1.DataSource = sqlDt
            updateTable()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            sqlConn.Dispose()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'update
        sqlConn.ConnectionString = "server =" + server + ";" + "user id=" + username + ";" +
            "password=" + password + ";" + "database=" + database

        Try
            sqlConn.Open()
            sqlQuery = "update database.transaction set earn_or_spend = ' " + TextBox1.Text + " ',categories = ' " + TextBox2.Text + " ',amount = ' " + TextBox3.Text + " ' where id=" & TextBox4.Text & "   "

            sqlCmd = New MySqlCommand(sqlQuery, sqlConn)
            sqlRd = sqlCmd.ExecuteReader
            sqlConn.Close()
            sqlDt.Clear()
            DataGridView1.DataSource = sqlDt
            updateTable()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            sqlConn.Dispose()
        End Try
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        sqlConn.ConnectionString = "server =" + server + ";" + "user id=" + username + ";" +
            "password=" + password + ";" + "database=" + database

        Try
            sqlConn.Open()
            sqlQuery = "TRUNCATE TABLE database.transaction"

            sqlCmd = New MySqlCommand(sqlQuery, sqlConn)
            sqlRd = sqlCmd.ExecuteReader
            sqlConn.Close()
            sqlDt.Clear()
            DataGridView1.DataSource = sqlDt
            updateTable()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            sqlConn.Dispose()
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            TextBox4.Text = DataGridView1.SelectedRows(0).Cells(0).Value.ToString
            TextBox1.Text = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
            TextBox2.Text = DataGridView1.SelectedRows(0).Cells(2).Value.ToString
            TextBox3.Text = DataGridView1.SelectedRows(0).Cells(3).Value.ToString
        Catch ex As Exception
            'MessageBox.Show(" Please click item id to update ")
        End Try
    End Sub
End Class