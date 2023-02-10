Public Class Form6
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label12.Text = (TextBox1.Text * TextBox4.Text).ToString
        Label13.Text = (TextBox2.Text * TextBox5.Text).ToString
        Label14.Text = (TextBox3.Text * TextBox6.Text).ToString
        TextBox7.Text = Int(Label12.Text) + Int(Label13.Text) + Int(Label14.Text)
    End Sub
End Class