Imports System.IO
Imports System.Text

Module Main

    Sub Main()
        InstallContexMenu.InstallAsOpen(".p1")

        Dim Args As String() = Environment.GetCommandLineArgs

        If Args.Count <> 2 Then
            Dim SB As New StringBuilder
            SB.AppendLine("usage join filename.ext.p1")
            SB.AppendLine("eg: split text.txt.p1")
            MsgBox(SB.ToString)
            End
        End If

        Dim FileToJoin As String = Args(1)

        Dim FullSize As Integer = JoinFile.JoinFile(FileToJoin)

        MsgBox(String.Format("File joinned sucessfully, total size {0}", FullSize))
    End Sub

End Module
