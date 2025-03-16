Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bgm = True Then
            'BGMを再生する
            startBGM1()
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'スタートボタン
        Form5.Show()
        If sound = True Then
            BtnSound()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        '設定ボタン
        Form6.Show()
        If sound = True Then
            BtnSound()
        End If
    End Sub

End Class
