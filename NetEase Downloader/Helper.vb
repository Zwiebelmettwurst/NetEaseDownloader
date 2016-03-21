Imports System.Text

Module Helper

    Public Sub lvwAddItem(ByVal lvw As ListView, ByVal mytag As Object, ByVal ParamArray Text() As String)

        With lvw

            .Items.Add(New ListViewItem(Text)).Tag = mytag
        End With
    End Sub
    Public Function Unicode2UTF8(ByVal strData As String) As String
        'http://www.utf8-zeichentabelle.de/unicode-utf8-table.pl?number=512&names=-&utf8=char
        Unicode2UTF8 = String.Empty
        If strData <> String.Empty Then
            Dim bytes() As Byte
            bytes = Encoding.GetEncoding("Windows-1252").GetBytes(strData)
            Unicode2UTF8 = Encoding.UTF8.GetString(bytes)
        End If
    End Function
    Public Function timemiltommss(ByVal mil As String) As String
        If IsNumeric(mil) Then
            Dim t As Integer = CInt(CInt(mil) / 1000)
            Dim sec1 As Integer = t Mod 60
            Dim min1 As Integer = CInt((t - sec1) / 60)

            Return min1.ToString("00") & ":" & sec1.ToString("00")
        Else
            Return "00:00"
        End If

    End Function
    Public Function TextStringToByteArray(ByRef str As String) As Byte()
        Dim enc As System.Text.Encoding = System.Text.Encoding.Default
        Return enc.GetBytes(str)
    End Function

    Public Function ByteArrayToString(ByRef Barr() As Byte) As String
        Return Convert.ToBase64String(Barr)
    End Function

End Module
