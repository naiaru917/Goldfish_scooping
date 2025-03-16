Public Class Form7

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = Form4.Top
        Me.Left = Form4.Left
        Label2.Text = ""
        Label3.Text = ""

        Dim score(11) As Integer
        Dim name(11) As String
        If level = "kantan" Then
            Label4.Text = "〈簡単〉"
            Dim rank1 As New IO.StreamReader(“rankScoreK.txt”)  'メモ帳呼び出し
            Dim rank2 As New IO.StreamReader(“rankNameK.txt”)

            For i = 0 To 9
                score(i) = rank1.ReadLine() '変数 score に1行ずつ格納
            Next
            rank1.Close()  'メモ帳閉じる

            For i = 0 To 9
                name(i) = rank2.ReadLine() '変数 name に1行ずつ格納
            Next
            rank2.Close()  'メモ帳閉じる
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

        For i = 0 To 9
            Label2.Text &= i + 1 & "位 " & score(i) & "点" & vbLf
            Label3.Text &= Name(i) & vbLf
        Next

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '閉じるボタン
        If sound = True Then
            BtnSound()
        End If
        Me.Close()
    End Sub
End Class