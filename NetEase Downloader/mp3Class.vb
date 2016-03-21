Public Class mp3Class : Implements IEquatable(Of mp3Class)
    Dim songMainID As String
    Dim songMainName As String
    Dim songArtists As List(Of String)
    Dim songAlbum As String
    Dim songDuration As String
    Dim songMP3URL As String
    Dim songMVID As String
    Dim songID As String
    Dim songName As String
    Dim songSize As String
    Dim songExtension As String
    Dim songdfsID As String
    Dim songPlaytime As String
    Dim songBitrate As String
    Dim songSR As String



    Public Sub New(ByVal songMainID As String, ByVal songMainName As String, ByVal songArtists As List(Of String), ByVal songAlbum As String, ByVal songDuration As String,
                   ByVal songMP3URL As String, ByVal songID As String, ByVal songName As String, ByVal songSize As String, ByVal songExtension As String, ByVal songdfsID As String,
                   ByVal songPlaytime As String, ByVal songBitrate As String, ByVal songSR As String, ByVal songMVID As String)

        Me.songMainID = songMainID
        Me.songMainName = songMainName
        Me.songArtists = songArtists
        Me.songAlbum = songAlbum
        Me.songDuration = songDuration
        Me.songMP3URL = songMP3URL
        Me.songMVID = songMVID
        Me.songID = songID
        Me.songName = songName
        Me.songSize = songSize
        Me.songExtension = songExtension
        Me.songdfsID = songdfsID
        Me.songPlaytime = songPlaytime
        Me.songBitrate = songBitrate
        Me.songSR = songSR
    End Sub
    Public Overloads Function Equals(other As mp3Class) As Boolean _
                   Implements IEquatable(Of mp3Class).Equals
        If other Is Nothing Then Return False
        Return other.songID.Equals(Me.songID)
    End Function
    Public Function getSongMainID() As String
        Return Me.songMainID
    End Function
    Public Function getSongMainName() As String
        Return Me.songMainName
    End Function
    Public Function getSongArtists() As List(Of String)
        Return Me.songArtists
    End Function
    Public Function getSongAlbum() As String
        Return Me.songAlbum
    End Function
    Public Function getSongDuration() As String
        Return Me.songDuration
    End Function
    Public Function getSongMP3URL() As String
        Return Me.songMP3URL
    End Function


    Public Function getSongID() As String
        Return Me.songID
    End Function
    Public Function getSongName() As String
        Return Me.songName
    End Function
    Public Function getSongSize() As String
        Return Me.songSize
    End Function
    Public Function getSongExtension() As String
        Return Me.songExtension
    End Function
    'Public Function getSongDuration() As String
    '    Return Me.songDuration
    'End Function
    Public Function getSongdfsID() As String
        Return Me.songdfsID
    End Function
    Public Function getSongPlaytime() As String
        Return Me.songPlaytime
    End Function
    Public Function getSongBitrate() As String
        Return Me.songBitrate
    End Function
    Public Function getSongSR() As String
        Return Me.songSR
    End Function
    Public Function getSongMVID() As String
        Return Me.songMVID
    End Function
End Class
