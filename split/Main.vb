Imports System.IO
Imports System.Text

Module Main

    Sub Main()
        InstallContexMenu.InstallAsContext()


        Dim Args As String() = Environment.GetCommandLineArgs

        If Args.Count < 2 Then
            Dim SB As New StringBuilder
            SB.AppendLine("usage split filename.ext [splitSize[KB|MB|GB]]")
            SB.AppendLine("eg, gui will ask for splitsize: split text.txt")
            SB.AppendLine("eg, with 10bytes: split text.txt 10")
            SB.AppendLine("eg, with 10MB: split backup.zip 10MB")
            SB.AppendLine("eg, with 1GB: split backup.zip 1GB")
            MsgBox(SB.ToString)
            End
        End If

        Dim FileToSplit As String = Args(1)
        Dim SplitSizeString As String


        If Args.Count = 3 Then
            SplitSizeString = Args(2)
        Else
            SplitSizeString = InputBox("splitSize[KB|MB|GB]", "Split Size", "1MB")
        End If



        Dim SplitSize As Integer

        If SplitSizeString.Length < 3 Then
            SplitSize = SplitSizeString
        Else
            Select Case SplitSizeString.Substring(SplitSizeString.Length - 2, 2)
                Case "KB"
                    SplitSize = SplitSizeString.Substring(0, SplitSizeString.Length - 2)
                    SplitSize = SplitSize * 1024
                Case "MB"
                    SplitSize = SplitSizeString.Substring(0, SplitSizeString.Length - 2)
                    SplitSize = SplitSize * 1024 * 1024
                Case "GB"
                    SplitSize = SplitSizeString.Substring(0, SplitSizeString.Length - 2)
                    SplitSize = SplitSize * 1024 * 1024 * 1024
                Case Else
                    SplitSize = SplitSizeString
            End Select
        End If



        Dim FileSize As Integer = My.Computer.FileSystem.GetFileInfo(FileToSplit).Length

        If FileSize < SplitSize Then
            MsgBox("File is smaller than split size, nothing to do")
            End
        End If

        Dim Parts As Integer = SplitFile.SplitFile(FileToSplit, SplitSize)

        MsgBox(String.Format("File splitted sucessfully in {0} parts", Parts))
    End Sub

End Module
