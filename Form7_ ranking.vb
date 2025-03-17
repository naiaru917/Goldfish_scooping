Public Class Form7

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'フォームの位置を設定
        Me.Top = Form4.Top
        Me.Left = Form4.Left

        'テキストを初期化（空欄に）
        Label2.Text = ""    '順位とスコア表示用
        Label3.Text = ""    'プレイヤー名表示用

        Dim score(11) As Integer    'スコアを管理
        Dim name(11) As String      'プレイヤー名を管理

        '難易度が「簡単」の場合
        If level = "kantan" Then
            Label4.Text = "〈簡単〉"
            Dim rank1 As New IO.StreamReader(“rankScoreK.txt”)  'メモ帳から過去のスコアデータを呼び出し
            Dim rank2 As New IO.StreamReader(“rankNameK.txt”)   'メモ帳から過去のプレイヤー名データを呼び出し

            For i = 0 To 9
                score(i) = rank1.ReadLine() '変数 score に1行ずつ格納
            Next
            rank1.Close()  'メモ帳閉じる

            For i = 0 To 9
                name(i) = rank2.ReadLine() '変数 name に1行ずつ格納
            Next
            rank2.Close()  'メモ帳閉じる

        '難易度が「普通」の場合
        ElseIf level = "hutsu" Then
            Label4.Text = "〈普通〉"
            Dim rank1 As New IO.StreamReader(“rankScoreH.txt”)  'メモ帳呼び出し
            Dim rank2 As New IO.StreamReader(“rankNameH.txt”)

            For i = 0 To 9
                score(i) = rank1.ReadLine() '変数 score に1行ずつ格納
            Next
            rank1.Close()  'メモ帳閉じる

            For i = 0 To 9
                name(i) = rank2.ReadLine() '変数 name に1行ずつ格納
            Next
            rank2.Close()  'メモ帳閉じる

        '難易度が「難しい」の場合
        Else
            Label4.Text = "〈難しい〉"
            Dim rank1 As New IO.StreamReader(“rankScoreM.txt”)  'メモ帳呼び出し
            Dim rank2 As New IO.StreamReader(“rankNameM.txt”)

            For i = 0 To 9
                score(i) = rank1.ReadLine() '変数 score に1行ずつ格納
            Next
            rank1.Close()  'メモ帳閉じる

            For i = 0 To 9
                name(i) = rank2.ReadLine() '変数 name に1行ずつ格納
            Next
            rank2.Close()  'メモ帳閉じる
        End If

        'テキストにスコアとプレイヤー名を表示
        For i = 0 To 9
            Label2.Text &= i + 1 & "位 " & score(i) & "点" & vbLf
            Label3.Text &= Name(i) & vbLf
        Next
    End Sub

    '閉じるボタンをクリックしたとき
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If sound = True Then
            BtnSound()
        End If
        Me.Close()
    End Sub
End Class
