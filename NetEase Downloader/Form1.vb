Option Strict On
Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json

Public Class Form1

    Dim savepath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic)
    Dim cookieCon As New CookieContainer
    Dim request As HttpWebRequest
    Dim getSongInfo As New List(Of SongClass)
    Dim seitenQuelltext As String
    Dim proxy As New List(Of WebProxy)
    Dim myselectedsong As SongClass
    Dim lastdownloadpath As String
    Private cLvwSort As ListViewSort
    Dim SW As Stopwatch



    Private Sub downloadProxy()
        Me.Enabled = False

        Dim wc As New WebClient
        Dim proxypage As String = wc.DownloadString("http://cn-proxy.com")
        '    Dim rx As New Regex("<tr>\n<td>([0-9.]*)<\/td>\n<td>([0-9]*)<\/td>\n<td>(.*)<\/td>\n<td>\n<div class=""graph""><strong class=""bar"" style=""width: ([0-9]+)%; background:#00dd00;""><span><\/span><\/strong><\/div>\n<\/td>\n<td>([0-9-.: ]+)<\/td>\n<\/tr>", RegexOptions.Multiline)

        Dim mmatch As MatchCollection = Regex.Matches(proxypage, "<tr>\n<td>([0-9.]*)<\/td>\n<td>([0-9]*)<\/td>\n<td>(.*)<\/td>\n<td>\n<div class=""graph""><strong class=""bar"" style=""width: ([0-9]+)%; background:#00dd00;""><span><\/span><\/strong><\/div>\n<\/td>\n<td>([0-9-.: ]+)<\/td>\n<\/tr>")

        Dim rxmatches As MatchCollection = Regex.Matches(proxypage, "<tr>\n<td>([0-9.]*)<\/td>\n<td>([0-9]*)<\/td>\n<td>(.*)<\/td>\n<td>\n<div class=""graph""><strong class=""bar"" style=""width: ([0-9]+)%; background:#00dd00;""><span><\/span><\/strong><\/div>\n<\/td>\n<td>([0-9-.: ]+)<\/td>\n<\/tr>") ', "<tr>\n<td>([0-9.]*)<\/td>\n<td>([0-9]*)<\/td>\n<td>(.*)<\/td>\n<td>\n<div class=""graph""><strong class=""bar"" style=""width: ([0-9]+)%; background:#00dd00;""><span><\/span><\/strong><\/div>\n<\/td>\n<td>([0-9-.: ]+)<\/td>\n<\/tr>")
        proxy.Clear()
        '    Dim sw As New StreamWriter(Application.StartupPath & "/Proxy.txt", False)

        For Each m As Match In mmatch
            proxy.Add(New WebProxy(m.Groups(1).ToString, CInt(m.Groups(2).ToString)))
            '  sw.WriteLine(m.Groups(1).ToString & ":" & m.Groups(2).ToString)

        Next
        '   chb_useproxy.Text = "Proxy (" & proxy.Count.ToString & ")"
        ' sw.Close()
        Me.Enabled = True

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        cLvwSort = New ListViewSort(lvw_Songs)
        lbl_savepath.Text = savepath
        Dim l As New Threading.Thread(AddressOf downloadProxy)
        l.IsBackground = True
        l.Start()
    End Sub

    Private Sub btn_changesavepath_Click(sender As Object, e As EventArgs) Handles btn_changesavepath.Click
        Dim fbd As New FolderBrowserDialog
        With fbd

            If .ShowDialog = DialogResult.OK Then
                savepath = .SelectedPath
                lbl_savepath.Text = savepath
            End If
        End With
    End Sub
    Private Sub startQuery()
        Dim t As New Threading.Thread(AddressOf doQuery)
        t.IsBackground = True
        t.Start()
    End Sub
    Private Sub doQuery()
        If txt_searchQuery.Text.Length < 1 Then Exit Sub
        btn_searchQuery.Enabled = False
        lbl_status.Text = "searching..."

        Try


            Dim myApi As String = getApi("http://music.163.com/api/search/get/", txt_searchQuery.Text, "25") 'nup_limit.Value.ToString)
            '  Dim jreader As New JsonTextReader(New StringReader(TextBox1.Text))
            '  
            Dim song = Linq.JObject.Parse(myApi)
            Dim hasResult As Linq.JToken = song.Item("result")
            If hasResult.Item("songCount").ToString = "0" Then
                Exit Sub
            End If
            Dim s As Linq.JToken = song.Item("result")("songs")
            Dim songList As New List(Of String)
            For Each item In s.Children
                songList.Add(item.Item("id").ToString)
            Next
            Dim mySongQuery As String = String.Join(",", songList)
            Dim webClient As New System.Net.WebClient
            webClient.Proxy = RandomProxy()
            Dim result As String = webClient.DownloadString("http://music.163.com/api/song/detail?ids=[" & mySongQuery & "]")
            Dim resultsongs = Linq.JObject.Parse(result)
            Dim mynewSongs As Linq.JToken = resultsongs.Item("songs")


            getSongInfo.Clear()
            lvw_Songs.Items.Clear()


            For Each songi In mynewSongs.Children
                Dim getSongArtists As New List(Of String)

                '   Dim at As Linq.JToken = resultsongs.Item("songs").Item("artists")
                Dim at As Linq.JToken = songi.Item("artists")

                For Each artist In at
                    getSongArtists.Add(Unicode2UTF8(artist.Item("name").ToString))
                Next

                Dim hM As mp3Class = Nothing
                Dim mM As mp3Class = Nothing
                Dim lM As mp3Class = Nothing
                Dim bM As mp3Class = Nothing

                If songi.Item("hMusic").HasValues Then
                    hM = New mp3Class(songi.Item("id").ToString, Unicode2UTF8(songi.Item("name").ToString), getSongArtists, Unicode2UTF8(songi.Item("album")("name").ToString), songi.Item("duration").ToString, songi.Item("mp3Url").ToString, songi.Item("hMusic")("id").ToString, Unicode2UTF8(songi.Item("hMusic")("name").ToString), songi.Item("hMusic")("size").ToString, songi.Item("hMusic")("extension").ToString, songi.Item("hMusic")("dfsId").ToString, songi.Item("hMusic")("playTime").ToString, songi.Item("hMusic")("bitrate").ToString, songi.Item("hMusic")("sr").ToString, songi.Item("mvid").ToString)
                End If
                If songi.Item("mMusic").HasValues Then
                    mM = New mp3Class(songi.Item("id").ToString, Unicode2UTF8(songi.Item("name").ToString), getSongArtists, Unicode2UTF8(songi.Item("album")("name").ToString), songi.Item("duration").ToString, songi.Item("mp3Url").ToString, songi.Item("mMusic")("id").ToString, Unicode2UTF8(songi.Item("mMusic")("name").ToString), songi.Item("mMusic")("size").ToString, songi.Item("mMusic")("extension").ToString, songi.Item("mMusic")("dfsId").ToString, songi.Item("mMusic")("playTime").ToString, songi.Item("mMusic")("bitrate").ToString, songi.Item("mMusic")("sr").ToString, songi.Item("mvid").ToString)
                End If
                If songi.Item("lMusic").HasValues Then
                    lM = New mp3Class(songi.Item("id").ToString, Unicode2UTF8(songi.Item("name").ToString), getSongArtists, Unicode2UTF8(songi.Item("album")("name").ToString), songi.Item("duration").ToString, songi.Item("mp3Url").ToString, songi.Item("lMusic")("id").ToString, Unicode2UTF8(songi.Item("lMusic")("name").ToString), songi.Item("lMusic")("size").ToString, songi.Item("lMusic")("extension").ToString, songi.Item("lMusic")("dfsId").ToString, songi.Item("lMusic")("playTime").ToString, songi.Item("lMusic")("bitrate").ToString, songi.Item("lMusic")("sr").ToString, songi.Item("mvid").ToString)
                End If
                If songi.Item("bMusic").HasValues Then
                    bM = New mp3Class(songi.Item("id").ToString, Unicode2UTF8(songi.Item("name").ToString), getSongArtists, Unicode2UTF8(songi.Item("album")("name").ToString), songi.Item("duration").ToString, songi.Item("mp3Url").ToString, songi.Item("bMusic")("id").ToString, Unicode2UTF8(songi.Item("bMusic")("name").ToString), songi.Item("bMusic")("size").ToString, songi.Item("bMusic")("extension").ToString, songi.Item("bMusic")("dfsId").ToString, songi.Item("bMusic")("playTime").ToString, songi.Item("bMusic")("bitrate").ToString, songi.Item("bMusic")("sr").ToString, songi.Item("mvid").ToString)
                End If
                'songi.Item("album")("name").ToString
                getSongInfo.Add(New SongClass(songi.Item("id").ToString, Unicode2UTF8(songi.Item("name").ToString), getSongArtists, Unicode2UTF8(songi.Item("album")("name").ToString), songi.Item("duration").ToString, songi.Item("mp3Url").ToString,
                                             hM,
                                             mM,
                                              lM,
                                              bM,
                                                   songi.Item("mvid").ToString))

            Next

            For Each foundSound In getSongInfo
                'Dim mvidcheck As String = "✖"
                'If Not foundSound.getSongMVID = "0" Then
                '    mvidcheck = "✔"
                'End If
                '  lvwAddItem(lvw_Songs, foundSound.getSongID, foundSound.getSongName, foundSound.getSongArtists(0), foundSound.getSongAlbum, timemiltommss(foundSound.getSongDuration), (CInt(getBestMusic(foundSound).getSongBitrate) / 1000).ToString & " kbit/s", mvidcheck)
                lvwAddItem(lvw_Songs, foundSound, foundSound.getSongName, String.Join(", ", foundSound.getSongArtists(0)), (CInt(getBestMusic(foundSound).getSongBitrate) / 1000).ToString & " kbit/s")
            Next

        Catch ex As Exception
            ' MessageBox.Show(ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        lbl_status.Text = "idle"
        btn_searchQuery.Enabled = True
    End Sub
    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_searchQuery.Click
        startQuery()

    End Sub
    Private Function getBestMusic(ByVal SongClasstoCheck As SongClass) As mp3Class
        'If Not SongClasstoCheck.gethMusic = Nothing Then Return SongClasstoCheck.gethMusic()
        'If Not SongClasstoCheck.getmMusic.getSongID = Nothing Then Return SongClasstoCheck.getmMusic()
        'If Not SongClasstoCheck.getlMusic.getSongID = Nothing Then Return SongClasstoCheck.getlMusic()
        'If Not SongClasstoCheck.getbMusic.getSongID = Nothing Then Return SongClasstoCheck.getbMusic()
        If SongClasstoCheck.hashMusic Then Return SongClasstoCheck.gethMusic()
        If SongClasstoCheck.hasmMusic Then Return SongClasstoCheck.getmMusic()
        If SongClasstoCheck.haslMusic Then Return SongClasstoCheck.getlMusic()
        If SongClasstoCheck.hasbMusic Then Return SongClasstoCheck.getbMusic()

        Return Nothing
    End Function
    Private Function getApi(ByVal URL As String, ByVal query As String, ByVal limit As String) As String
        'Login auf Facebook
        Try


            request = DirectCast(HttpWebRequest.Create(URL), HttpWebRequest)
            request.Method = "POST"
            request.CookieContainer = cookieCon
            '     request.UserAgent = "User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64; rv:33.0) Gecko/20100101 Firefox/33.0"
            request.ContentType = "application/x-www-form-urlencoded"
            '    request.Host = "streamcloud.eu"
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8"
            request.Headers.Add("Cookie: appver = 2.0.2")
            '  request.Headers.Add("Referer: http://music.163.com")
            '  request.Headers.Add("Content-Type: application/x-www-form-urlencoded")
            request.Referer = "http://music.163.com"
            Dim post As String = "s=" & query & "&type=1&offset=0&sub=false&limit=" & limit
            Dim byteArr() As Byte = Encoding.Default.GetBytes(post)
            request.ContentLength = byteArr.Length

            Dim dataStream As Stream = request.GetRequestStream()
            dataStream.Write(byteArr, 0, byteArr.Length)

            Dim response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)


            response = DirectCast(request.GetResponse(), HttpWebResponse)

            Dim reader As New StreamReader(response.GetResponseStream(), Encoding.ASCII)
            seitenQuelltext = reader.ReadToEnd()

            ' Dim f As Match = Regex.Match(seitenQuelltext, "(?<=file: "")(.*)(?="")", RegexOptions.IgnoreCase)
            '  Dim p As String = f.Groups(0).Value

            'Account Daten überprüfen

            Return seitenQuelltext

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ""

        End Try
    End Function
    Private Function decryptID(ByVal dfsID As String) As String
        Dim byte1 As Byte() = TextStringToByteArray("3go8&$8*3*3h0k(2)2")
        Dim byte2 As Byte() = TextStringToByteArray(dfsID)
        Dim byte1_len As Integer = byte1.Length
        For i As Integer = 0 To byte2.Length - 1
            byte2(i) = byte2(i) Xor byte1(i Mod byte1_len)
        Next
        Dim md5Hash As System.Security.Cryptography.MD5 = System.Security.Cryptography.MD5.Create

        Dim result As String = ByteArrayToString(md5Hash.ComputeHash(byte2))
        result = result.Replace("/", "_")
        result = result.Replace("+", "-")
        Return result
        ' MsgBox(result)
    End Function
    Private Function RandomProxy() As WebProxy
        Dim rnd As New Random()
        Dim newproxy As WebProxy = proxy(rnd.Next(0, proxy.Count - 1))
        Return newproxy


    End Function
    Private Function formatBytes(ByVal Bytes As Long) As String
        If Bytes >= 1073741824 Then
            Return (Bytes / 1024 / 1024 / 1024).ToString("#0.00") & " GB"
        ElseIf Bytes >= 1048576 Then
            Return (Bytes / 1024 / 1024).ToString("#0.00") & " MB"
        ElseIf Bytes >= 1024 Then
            Return (Bytes / 1024).ToString("#0.00") & " KB"
        ElseIf Bytes < 1024 Then
            Return (Bytes).ToString("#0.00") & " Bytes"
        End If
        Return "0 Bytes"
    End Function
    Private Sub downloadProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        ' sw.Stop()

        ProgressBar1.Maximum = CInt(e.TotalBytesToReceive / 1024)
        ProgressBar1.Value = CInt(e.BytesReceived / 1024)
        If SW.ElapsedMilliseconds > 0 Then
            lbl_downloadprogress.Text = "Download: " & formatBytes(e.BytesReceived) & " / " & formatBytes(e.TotalBytesToReceive) & " - " & e.ProgressPercentage.ToString & " % - " & Math.Floor((e.BytesReceived / SW.ElapsedMilliseconds)).ToString + " KB/s"
        Else
            lbl_downloadprogress.Text = "Download: " & formatBytes(e.BytesReceived) & " / " & formatBytes(e.TotalBytesToReceive) & " - " & e.ProgressPercentage.ToString & " %"

        End If
        '
        '  sw.Restart()
    End Sub
    Private Sub downloadFinished(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)

        ' btn_download.Enabled = True
        lvw_Songs.Enabled = True
        btn_listen.Enabled = True

    End Sub
    Private Sub subDownloadMusic() '(ByVal SongID As String)

        btn_download.Enabled = False
        Dim mysong As SongClass = myselectedsong 'getSongInfobyID(SongID)
        Dim myfoundsong As mp3Class = getBestMusic(mysong)
        Dim decryptedStr As String = decryptID(myfoundsong.getSongdfsID)
        Dim dl As New WebClient
        AddHandler dl.DownloadProgressChanged, AddressOf downloadProgressChanged
        AddHandler dl.DownloadFileCompleted, AddressOf downloadFinished
        Dim mysongname As String = (myfoundsong.getSongMainName & "_-_" & String.Join("_&_", myfoundsong.getSongArtists) & "." & myfoundsong.getSongExtension).Replace(" ", "_")
        '  If chb_useproxy.Checked And proxy.Count > 0 Then
        dl.Proxy = RandomProxy()
        '  End If
        ' AddHandler dl.DownloadFileCompleted, AddressOf MusicDownloadDone
        lbl_downloadprogress.Text = "Download: 0 KB / 0 KB - 0 % - 0 KB/s"
        lbl_downloadprogress.Visible = True
        lastdownloadpath = savepath & "\" & mysongname
        dl.DownloadFileAsync(New Uri("http://m1.music.126.net/" & decryptedStr & "/" & myfoundsong.getSongdfsID & "." & myfoundsong.getSongExtension), savepath & "\" & mysongname)
    End Sub
    Private Function getSongInfobyID(ByVal SongID As String) As SongClass
        For i As Integer = 0 To getSongInfo.Count - 1
            If getSongInfo(i).getSongID = SongID Then
                Return getSongInfo(i)
            End If
        Next
        Return Nothing

    End Function
    Private Sub btn_download_Click(sender As Object, e As EventArgs) Handles btn_download.Click
        If lvw_Songs.SelectedItems.Count = 1 Then
            lvw_Songs.Enabled = False
            SW = Stopwatch.StartNew

            subDownloadMusic() '(CType(lvw_Songs.Items(lvw_Songs.SelectedIndices(0)).Tag, String))
        End If
    End Sub

    Private Sub lvw_Songs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvw_Songs.SelectedIndexChanged
        If lvw_Songs.SelectedItems.Count = 1 Then

            ProgressBar1.Value = 0
            btn_download.Enabled = True
            btn_listen.Enabled = False

            lbl_downloadprogress.Visible = False

            myselectedsong = CType(lvw_Songs.Items(lvw_Songs.SelectedIndices(0)).Tag, SongClass)
            lbl_title.Text = "Song: " & myselectedsong.getSongName & " - " & String.Join(", ", myselectedsong.getSongArtists)
        End If
    End Sub

    Private Sub btn_listen_Click(sender As Object, e As EventArgs) Handles btn_listen.Click
        Process.Start(lastdownloadpath)
    End Sub
End Class
