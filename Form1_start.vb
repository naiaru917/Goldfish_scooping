Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bgm = True Then
            startBGM1()    'BGMを再生する
        End If
    End Sub
    
    'スタートボタンをクリックしたとき
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form5.Show()    'ルール画面を表示
        If sound = True Then
            BtnSound()  'ボタンの効果音を再生
        End If
    End Sub

     '設定ボタンをクリックしたとき
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form6.Show()    '設定画面を表示
        If sound = True Then
            BtnSound()  'ボタンの効果音を再生
        End If
    End Sub

End Class
