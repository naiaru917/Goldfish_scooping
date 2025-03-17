Public Class Form4
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'フォームの位置を設定
        Me.Left = Form1.Left
        Me.Top = Form1.Top

        'スコアの表示
        Label1.Text = ten & "点"
        Label2.Text = "金魚：" & fish_cntA & " /出目金：" & fish_cntB & " /ピラニア：" & fish_cntC & " /黄金の金魚：" & fish_cntD
        Form2.Close()

        If bgm = True Then
            startBGM3()
        End If


        Dim score(11) As Integer
        Dim Name(11) As String

        '難易度が「簡単」のとき
        If level = "kantan" Then
            Dim rank1 As New IO.StreamReader(“rankScoreK.txt”)  'メモ帳から過去のスコアデータを呼び出し
            Dim rank2 As New IO.StreamReader(“rankNameK.txt”) 　'メモ帳から過去のプレイヤー名データを呼び出し

            For i = 0 To 9
                score(i) = rank1.ReadLine() '変数 score に1行ずつ格納
            Next
            rank1.Close()  'メモ帳閉じる

            For i = 0 To 9
                Name(i) = rank2.ReadLine() '変数 name に1行ずつ格納
            Next
            rank2.Close()  'メモ帳閉じる

        '難易度が「普通」のとき
        ElseIf level = "hutsuu" Then
            Dim rank1 As New IO.StreamReader(“rankScoreH.txt”)
            Dim rank2 As New IO.StreamReader(“rankNameH.txt”)

            For i = 0 To 9
                score(i) = rank1.ReadLine()
            Next
            rank1.Close()

            For i = 0 To 9
                Name(i) = rank2.ReadLine()
            Next
            rank2.Close()

        '難易度が「難しい」のとき
        Else
            Dim rank1 As New IO.StreamReader(“rankScoreM.txt”)
            Dim rank2 As New IO.StreamReader(“rankNameM.txt”)

            For i = 0 To 9
                score(i) = rank1.ReadLine()
            Next
            rank1.Close()

            For i = 0 To 9
                Name(i) = rank2.ReadLine()
            Next
            rank2.Close()
        End If

        'ランキング10位の記録を更新したかを確認
        If ten > score(9) Then
            Label3.Text = "NEW SCORE!!!"
            Label4.Text = "名前を入力してください"
        Else
            Label3.Text = ""
            Label4.Text = ""
            TextBox1.Visible = False
            Button4.Visible = False
        End If

    End Sub

    'スタート画面へボタンをクリックしたとき
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If sound = True Then
            BtnSound()
        End If
        Call mciSendString("stop MySound", "", 0, 0)  'BGMを止める
        Call mciSendString("close MySound", "", 0, 0)
        Call mciSendString(String.Format("open ""{0}"" alias MySound", BGM1), "", 0, 0)
        Call mciSendString("play MySound", "", 0, 0)
        Me.Close()
    End Sub

    '終了ボタンをクリックしたとき
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If sound = True Then
            BtnSound()
        End If
        Me.Close()
        Form1.Close()
    End Sub

    'ランキングボタンをクリックしたとき
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If sound = True Then
            BtnSound()
        End If
        Form7.Show()
    End Sub

    '登録ボタンをクリックしたとき
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If sound = True Then
            BtnSound()
        End If

        'テキストボックスが空欄の場合、エラーメッセージを出す
        If TextBox1.Text = "" Then
            MessageBox.Show("名前を入力してください。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim score(11) As Integer
        Dim Name(11) As String

        If level = "kantan" Then
            Dim rank1 As New IO.StreamReader(“rankScoreK.txt”)   'メモ帳から過去のスコアデータを呼び出し
            Dim rank2 As New IO.StreamReader(“rankNameK.txt”)    'メモ帳から過去のプレイヤー名データを呼び出し

            For i = 0 To 9
                score(i) = rank1.ReadLine() '変数 score に1行ずつ格納
            Next
            rank1.Close()  'メモ帳閉じる

            For i = 0 To 9
                Name(i) = rank2.ReadLine() '変数 name に1行ずつ格納
            Next
            rank2.Close()  'メモ帳閉じる
        ElseIf level = "hutsu" Then
            Dim rank1 As New IO.StreamReader(“rankScoreH.txt”)
            Dim rank2 As New IO.StreamReader(“rankNameH.txt”)

            For i = 0 To 9
                score(i) = rank1.ReadLine()
            Next
            rank1.Close()

            For i = 0 To 9
                Name(i) = rank2.ReadLine()
            Next
            rank2.Close()
        Else
            Dim rank1 As New IO.StreamReader(“rankScoreM.txt”)
            Dim rank2 As New IO.StreamReader(“rankNameM.txt”)

            For i = 0 To 9
                score(i) = rank1.ReadLine()
            Next
            rank1.Close()

            For i = 0 To 9
                Name(i) = rank2.ReadLine() '変数 name に1行ずつ格納
            Next
            rank2.Close()  'メモ帳閉じる
        End If

        playerName = TextBox1.Text
        score(10) = ten
        Name(10) = playerName

        For i = 0 To 9
            If score(10) >= score(i) Then
                score(11) = score(i)
                score(i) = score(10)
                score(10) = score(11)
                Name(11) = Name(i)
                Name(i) = Name(10)
                Name(10) = Name(11)
            End If
        Next

        If level = "kantan" Then
            Dim rank3 As New IO.StreamWriter("rankScoreK.txt")
            Dim rank4 As New IO.StreamWriter("rankNameK.txt")
            For i = 0 To 9
                rank3.WriteLine(score(i)) '変数の中身をメモ帳に上書きする
                rank4.WriteLine(Name(i))
            Next
            rank3.Close()  'メモ帳閉じる
            rank4.Close()
        ElseIf level = "hutsu" Then
            Dim rank3 As New IO.StreamWriter("rankScoreH.txt")
            Dim rank4 As New IO.StreamWriter("rankNameH.txt")
            For i = 0 To 9
                rank3.WriteLine(score(i))
                rank4.WriteLine(Name(i))
            Next
            rank3.Close()
            rank4.Close()
        Else
            Dim rank3 As New IO.StreamWriter("rankScoreM.txt")
            Dim rank4 As New IO.StreamWriter("rankNameM.txt")
            For i = 0 To 9
                rank3.WriteLine(score(i))
                rank4.WriteLine(Name(i))
            Next
            rank3.Close()
            rank4.Close()
        End If

        TextBox1.Text = ""
        Form7.Show()
    End Sub

End Class
