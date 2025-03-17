Public Class Form6
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'フォームの位置を設定
        Me.Top = Form1.Top
        Me.Left = Form1.Left

        'BGMのオンオフ
        If bgm = True Then
            RadioButton1.Checked = True
        Else
            RadioButton2.Checked = True
        End If
        
        'フィーバータイムのオンオフ
        If fever = True Then
            RadioButton3.Checked = True
        Else
            RadioButton4.Checked = True
        End If

        '効果音のオンオフ
        If sound = True Then
            RadioButton5.Checked = True
        Else
            RadioButton6.Checked = True
        End If
    End Sub

    '確定ボタンをクリックしたとき
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '設定項目を記録
        If RadioButton1.Checked = True Then
            bgm = True
        Else
            bgm = False
        End If
        If RadioButton3.Checked = True Then
            fever = True
        Else
            fever = False
        End If
        If RadioButton5.Checked = True Then
            sound = True
        Else
            sound = False
        End If

        '効果音がオンの場合に再生
        If sound = True Then
            BtnSound()
        End If

        Me.Close()    '設定画面を閉じる
    End Sub

    'BGMをオンにしたタイミングでBGMを再生
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        startBGM1()
    End Sub

    'BGMをオフにしたタイミングでBGMを停止
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        stopBGM()
    End Sub
End Class
