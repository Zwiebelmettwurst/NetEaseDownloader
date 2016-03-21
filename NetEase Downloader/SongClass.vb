Public Class SongClass : Implements IEquatable(Of SongClass)
    Dim songID As String
    Dim songName As String
    Dim songArtists As List(Of String)
    Dim songAlbum As String
    Dim songDuration As String
    Dim songMP3URL As String
    Dim hMusic As mp3Class
    Dim mMusic As mp3Class
    Dim lMusic As mp3Class
    Dim bMusic As mp3Class
    Dim MVID As String

    Public Sub New(ByVal songID As String, ByVal songName As String, ByVal songArtists As List(Of String), ByVal songAlbum As String, ByVal songDuration As String,
                   ByVal songMP3URL As String, ByVal hMusic As mp3Class, ByVal mMusic As mp3Class, ByVal lMusic As mp3Class, ByVal bMusic As mp3Class, ByVal MVID As String)
        Me.songID = songID
        Me.songName = songName
        Me.songArtists = songArtists
        Me.songAlbum = songAlbum
        Me.songDuration = songDuration
        Me.songMP3URL = songMP3URL
        Me.hMusic = hMusic
        Me.mMusic = mMusic
        Me.lMusic = lMusic
        Me.bMusic = bMusic
        Me.MVID = MVID
    End Sub
    Public Overloads Function Equals(other As SongClass) As Boolean _
                   Implements IEquatable(Of SongClass).Equals
        If other Is Nothing Then Return False
        Return other.songID.Equals(Me.songID)
    End Function

    Public Function getSongID() As String
        Return Me.songID
    End Function
    Public Function getSongName() As String
        Return Me.songName
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
    Public Function getmMusic() As mp3Class

        Return Me.mMusic
    End Function
    Public Function getlMusic() As mp3Class
        Return Me.lMusic
    End Function
    Public Function gethMusic() As mp3Class
        Return Me.hMusic
    End Function
    Public Function getbMusic() As mp3Class
        Return Me.bMusic
    End Function

    Public Function getSongMVID() As String
        Return Me.MVID
    End Function
    Public Function hashMusic() As Boolean
        If TypeOf (Me.hMusic) Is mp3Class Then
            Return True
        End If
        Return False
    End Function
    Public Function hasmMusic() As Boolean
        If TypeOf (Me.mMusic) Is mp3Class Then
            Return True
        End If
        Return False
    End Function
    Public Function haslMusic() As Boolean
        If TypeOf (Me.lMusic) Is mp3Class Then
            Return True
        End If
        Return False
    End Function
    Public Function hasbMusic() As Boolean
        If TypeOf (Me.bMusic) Is mp3Class Then
            Return True
        End If
        Return False
    End Function
End Class
