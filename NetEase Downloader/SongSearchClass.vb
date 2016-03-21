
Public Class SongSearchClass : Implements IEquatable(Of SongSearchClass)
    Dim songID As String
    Dim songName As String
    Dim songArtists As List(Of String)
    Dim songDuration As String

    Public Sub New(ByVal songID As String, ByVal songName As String, ByVal songArtists As List(Of String), ByVal songDuration As String)
        Me.songID = songID
        Me.songName = songName
        Me.songArtists = songArtists
        Me.songDuration = songDuration
    End Sub
    Public Overloads Function Equals(other As SongSearchClass) As Boolean _
                   Implements IEquatable(Of SongSearchClass).Equals
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
    Public Function getSongDuration() As String
        Return Me.songDuration
    End Function
End Class
