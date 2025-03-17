Public Class Form5
    Dim BtnFlg As Integer = 0    '現在何ページ目なのかを管理するための変数
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'フォームの位置を設定
        Me.Top = Form1.Top
        Me.Left = Form1.Left
        PictureBox1.ImageLocation = "C:..\..\Resources\ルール説明1.jpg"    'ルール説明１を表示

        Button3.Visible = False
        Button4.Visible = False
        Button5.Visible = False
    End Sub

    '次へボタンをクリックしたとき
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If BtnFlg = 0 Then    '直前が１ページ目なら
            PictureBox1.ImageLocation = "C:..\..\Resources\ルール説明2.jpg"
            Button2.Visible = True    '戻るボタン非表示
            BtnFlg += 1
        Else    '直前が2ページ目なら
            PictureBox1.ImageLocation = "C:..\..\Resources\ルール説明3.jpg"
            BtnFlg += 1
            Button1.Visible = False    '次へボタンを非表示
            Button3.Visible = True     '難易度「簡単」ボタンを表示
            Button4.Visible = True     '難易度「普通」ボタンを表示
            Button5.Visible = True     '難易度「難しい」ボタンを表示
        End If
        If sound = True Then
            BtnSound()
        End If
    End Sub

    '戻るボタンをクリックしたとき
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
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

    '簡単ボタンをクリックしたとき
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        level = "kantan"
        GameStart()
    End Sub

    '普通ボタンをクリックしたとき
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        level = "hutsu"
        GameStart()
    End Sub

    '難しいボタンをクリックしたとき
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        level = "muzukashii"
        GameStart()
    End Sub

    'ゲームを開始
    Sub GameStart()
        If sound = True Then
            BtnSound()
        End If
        Call mciSendString("stop MySound", "", 0, 0)  'BGMを止める
        Call mciSendString("close MySound", "", 0, 0)
        Form2.Show()    'ゲーム画面を表示
        Me.Close()
    End Sub

End Class
