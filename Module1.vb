Module Module1

    Public Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Integer, ByVal hwndCallback As Integer) As Integer

    Public ten As Integer = 0　　'スコア
    Public level As String       '難易度
    Public playerName As String  'プレイヤーの名前
    Public bgm As Boolean = True    'BGMのON/OFF
    Public fever As Boolean = True  'フィーバータイムのON/OFF
    Public sound As Boolean = True  '効果音のON/OFF

    Public fish_cntA As Integer = 0  '赤い金魚を捕まえた数
    Public fish_cntB As Integer = 0  '黒い金魚を捕まえた数
    Public fish_cntC As Integer = 0  'ピラニアを捕まえた数
    Public fish_cntD As Integer = 0  '黄金の金魚を捕まえた数

    Public BGM1 As String = "C:..\..\Resources\金魚すくい.mp3"
    Public BGM2 As String = "C:..\..\Resources\下町屋台で食べ歩き.mp3"
    Public BGM3 As String = "C:..\..\Resources\花影.mp3"
    Public Sound1 As String = "C:..\..\Resources\決定ボタンを押す3.wav"
    Public Sound2 As String = "C:..\..\Resources\水をバシャッとかける2.wav"
    Public Sound3 As String = "C:..\..\Resources\和太鼓でカカッ.wav"
    Public Sound4 As String = "C:..\..\Resources\シャキーン1.wav"

    Public Sub BtnSound()       'ボタンを押したときに効果音を流す
        My.Computer.Audio.Play(Sound1,
            AudioPlayMode.Background)
    End Sub
    Public Sub FishSound()       '金魚を捕まえたときに効果音を流す
        My.Computer.Audio.Play(Sound2,
            AudioPlayMode.Background)
    End Sub

    Public Sub FinishSound()       'ゲーム終了時に効果音を流す
        My.Computer.Audio.Play(Sound3,
            AudioPlayMode.Background)
    End Sub


    Public Sub startBGM1()          'BGMを再生する
        Call mciSendString(String.Format("open ""{0}"" alias MySound", BGM1), "", 0, 0)
        Call mciSendString("play MySound", "", 0, 0)
    End Sub

    Public Sub startBGM2()
        Call mciSendString(String.Format("open ""{0}"" alias MySound", BGM2), "", 0, 0)
        Call mciSendString("play MySound", "", 0, 0)
    End Sub

    Public Sub startBGM3()
        Call mciSendString(String.Format("open ""{0}"" alias MySound", BGM3), "", 0, 0)
        Call mciSendString("play MySound", "", 0, 0)
    End Sub

    Public Sub stopBGM()  'BGMを止める
        Call mciSendString("stop MySound", "", 0, 0)
        Call mciSendString("close MySound", "", 0, 0)
    End Sub
End Module
