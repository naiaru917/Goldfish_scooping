Public Class Form6
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = Form1.Top
        Me.Left = Form1.Left
        If bgm = True Then
            RadioButton1.Checked = True
        Else
            RadioButton2.Checked = True
        End If
        If fever = True Then
            RadioButton3.Checked = True
        Else
            RadioButton4.Checked = True
        End If
        If sound = True Then
            RadioButton5.Checked = True
        Else
            RadioButton6.Checked = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '確定ボタン
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

        If sound = True Then
            BtnSound()
        End If

        Me.Close()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        startBGM1()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        stopBGM()
    End Sub
End Class