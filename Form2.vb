Public Class Form2
    Dim fish_x() As Integer  '金魚のX方向の移動距離
    Dim fish_y() As Integer  '金魚のY方向の移動距離
    Dim pb(7) As PictureBox
    Dim time As Integer = 20  '制限時間
    Dim frg As Boolean        'フィーバー用のフラグ
    Dim cnt() As Integer = {0, 0, 0, 0, 0, 0, 0, 0} '時間差にするための変数
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = Form1.Top
        Me.Left = Form1.Left

        pb(0) = PictureBox
        pb(1) = PictureBox3
        pb(2) = PictureBox4
        pb(3) = PictureBox5
        pb(4) = PictureBox6
        pb(5) = PictureBox7
        pb(6) = PictureBox8
        pb(7) = PictureBox9

        Timer1.Start()
        Timer2.Start()
        Timer3.Start()
        Timer4.Start()

        If fever = True Then
            Timer5.Start()   'フィーバーの処理
        End If

        Label1.Text = ""
        Label2.Text = "残り時間:" & time
        Label3.Visible = False

        '難易度処理（速度を変える）
        If level = "muzukashii" Then
            fish_x = {-9, -12, -15, -16, 8, 12, 13, 20}
            fish_y = {-9, -9, -10, -18, -13, -9, -15, -18}
        ElseIf level = "hutsu" Then
            fish_x = {-5, -7, -9, -11, 5, 6, 10, 12}
            fish_y = {-5, -7, -9, -12, -5, -6, -10, -12}
        Else
            fish_x = {-3, -3, -4, -6, 6, 3, 5, 8}
            fish_y = {-3, -4, -5, -7, -8, -3, -6, -9}
        End If

        '画像の上下の反転
        pb(3).Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
        pb(3).Refresh()
        pb(7).Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
        pb(7).Refresh()

        'BGMの再生
        If bgm = True Then
            startBGM2()
        End If

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        For i = 0 To pb.GetUpperBound(0)
            '金魚が画面外に出た時の処理
            If pb(i).Left <= 0 Or pb(i).Left + pb(i).Width >= Me.ClientRectangle.Width Then
                fish_x(i) *= -1
            End If
            If pb(i).Top <= 0 Or pb(i).Top + pb(i).Height >= Me.ClientRectangle.Height Then
                fish_y(i) *= -1
                pb(i).Image.RotateFlip(RotateFlipType.RotateNoneFlipY)  '画像の上下の反転
                pb(i).Refresh()
            End If

            '金魚を動かす処理
            pb(i).Left += fish_x(i)
            pb(i).Top += fish_y(i)
        Next


        Label1.Text = ten & "点"

        Dim mouse_Pos As Point = PointToClient(Windows.Forms.Cursor.Position) 'マウスカーソルの座標
        PictureBox1.Top = mouse_Pos.Y - (PictureBox1.Height / 2)  'マウスの位置とポイ画像の位置を連携させる
        PictureBox1.Left = mouse_Pos.X - (PictureBox1.Width / 2)

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        '残り時間を減らす処理
        time -= 1
        Label2.Text = "残り時間：" & time

        '残り時間が0になったときの処理
        If time = 0 Then
            Timer1.Stop()
            Timer3.Stop()

            If sound = True Then
                FinishSound()
                Label3.Visible = True
                Label3.Text = "Finish!!"
            End If
        End If

        '終了２秒後にForm移動
        If time = -2 Then
            Form4.Show()
        End If

    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        '捕まえた金魚を再表示する処理
        For i = 0 To pb.GetUpperBound(0)
            If pb(i).Visible = False Then
                If cnt(i) - 3 = time Then  '2秒後に画像を表示する
                    pb(i).Visible = True
                    'ランダムな場所に画像を表示する
                    Randomize()
                    Dim y As Integer = Rnd() * (Me.Height - pb(i).Height)  '表示するY座標をランダムに決める
                    Dim x As Integer = Rnd() * (Me.Width - pb(i).Width)  '表示するY座標をランダムに決める
                    pb(i).Top = y
                    pb(i).Left = x
                End If
            End If
        Next

    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        '画像を反転させ、泳いでいるように見せる
        For i = 0 To pb.GetUpperBound(0)
            pb(i).Image.RotateFlip(RotateFlipType.RotateNoneFlipX)  '画像の左右の反転
            pb(i).Refresh()
        Next
    End Sub

    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles Timer5.Tick
        'フィーバータイム処理
        If time = 10 Then
            My.Computer.Audio.Play(Sound4,
            AudioPlayMode.Background)
            Label3.Visible = True

            For i = 0 To pb.GetUpperBound(0)
                pb(i).Width += 2
                pb(i).Height += 2
                pb(i).ImageLocation = "C:..\..\Resources\金色の金魚.png" '画像を変更する
                pb(i).BackColor = Color.PaleTurquoise
                If fish_y(i) > 0 Then
                    pb(i).Image.RotateFlip(RotateFlipType.RotateNoneFlipY)  '画像の上下の反転
                    pb(i).Refresh()
                End If
            Next
            PictureBox1.BackColor = Color.PaleTurquoise
            Me.BackColor = Color.PaleTurquoise
            frg = True
        End If
        If time = 8 Then   '2秒後にラベルを非表示にする
            Label3.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '一時停止を押した時の処理
        If sound = True Then
            BtnSound()
        End If
        Form3.Show()
        Timer1.Stop()
        Timer2.Stop()
        Timer3.Stop()

    End Sub

    '金魚をクリックした時の処理↓
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox.Click
        If frg = False Then
            ten += 10
            fish_cntA += 1
        Else
            ten += 50
            fish_cntD += 1
        End If

        pb(0).Visible = False
        cnt(0) = time

        If sound = True Then
            FishSound()
        End If
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If frg = False Then
            ten += 10
            fish_cntA += 1
        Else
            ten += 50
            fish_cntD += 1
        End If

        pb(1).Visible = False
        cnt(1) = time

        If sound = True Then
            FishSound()
        End If
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        If frg = False Then
            ten += 30
            fish_cntB += 1
        Else
            ten += 50
            fish_cntD += 1
        End If

        pb(2).Visible = False
        cnt(2) = time

        If sound = True Then
            FishSound()
        End If
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        If frg = False Then
            ten -= 50
            fish_cntC += 1
        Else
            ten += 50
            fish_cntD += 1
        End If

        pb(3).Visible = False
        cnt(3) = time

        If sound = True Then
            FishSound()
        End If
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        If frg = False Then
            ten += 10
            fish_cntA += 1
        Else
            ten += 50
            fish_cntD += 1
        End If

        pb(4).Visible = False
        cnt(4) = time

        If sound = True Then
            FishSound()
        End If
    End Sub
    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        If frg = False Then
            ten += 10
            fish_cntA += 1
        Else
            ten += 50
            fish_cntD += 1
        End If

        pb(5).Visible = False
        cnt(5) = time

        If sound = True Then
            FishSound()
        End If
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        If frg = False Then
            ten += 30
            fish_cntB += 1
        Else
            ten += 50
            fish_cntD += 1
        End If

        pb(6).Visible = False
        cnt(6) = time

        If sound = True Then
            FishSound()
        End If
    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        If frg = False Then
            ten -= 50
            fish_cntC += 1
        Else
            ten += 50
            fish_cntD += 1
        End If

        pb(7).Visible = False
        cnt(7) = time

        If sound = True Then
            FishSound()
        End If
    End Sub


End Class