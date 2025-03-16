Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = Form2.Left + (Form2.Width / 2) - (Me.Width / 2)
        Me.Top = Form2.Top + (Form2.Height / 2) - (Me.Height / 2)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '終了ボタン
        If sound = True Then
            FinishSound()
        End If
        stopBGM()
        Me.Close()
        Form2.Close()
        Form4.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'リスタートボタン
        If sound = True Then
            BtnSound()
        End If
        stopBGM()
        Me.Close()
        Form2.Close()
        Form2.Show()
        ten = 0
        fish_cntA = 0
        fish_cntB = 0
        fish_cntC = 0
        fish_cntD = 0
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'ゲームに戻るボタン
        If sound = True Then
            BtnSound()
        End If
        Me.Close()
        Form2.Timer1.Start()
        Form2.Timer2.Start()
        Form2.Timer3.Start()
    End Sub
End Class