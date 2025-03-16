Public Class Form5
    Dim BtnFlg As Integer = 0
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = Form1.Top
        Me.Left = Form1.Left
        PictureBox1.ImageLocation = "C:..\..\Resources\ルール説明1.jpg"

        Button3.Visible = False
        Button4.Visible = False
        Button5.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '次へボタン
        If BtnFlg = 0 Then
            PictureBox1.ImageLocation = "C:..\..\Resources\ルール説明2.jpg"
            Button2.Visible = True
            BtnFlg += 1
        Else
            PictureBox1.ImageLocation = "C:..\..\Resources\ルール説明3.jpg"
            BtnFlg += 1
            Button1.Visible = False
            Button3.Visible = True
            Button4.Visible = True
            Button5.Visible = True
        End If
        If sound = True Then
            BtnSound()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        '戻るボタン
        If BtnFlg = 0 Then
            Me.Close()
        ElseIf BtnFlg = 1 Then
            PictureBox1.ImageLocation = "C:..\..\Resources\ルール説明1.jpg"
            Button1.Visible = True
            BtnFlg -= 1
        Else
            PictureBox1.ImageLocation = "C:..\..\Resources\ルール説明2.jpg"
            BtnFlg -= 1
            Button1.Visible = True
            Button3.Visible = False
            Button4.Visible = False
            Button5.Visible = False
        End If
        If sound = True Then
            BtnSound()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        level = "kantan"
        GameStart()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        level = "hutsu"
        GameStart()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        level = "muzukashii"
        GameStart()
    End Sub

    Sub GameStart()
        If sound = True Then
            BtnSound()
        End If
        Call mciSendString("stop MySound", "", 0, 0)  'BGMを止める
        Call mciSendString("close MySound", "", 0, 0)
        Form2.Show()
        Me.Close()
    End Sub

End Class