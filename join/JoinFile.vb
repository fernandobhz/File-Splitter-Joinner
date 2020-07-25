Imports System.IO

Module JoinFile

    Function JoinFile(FirstPartFullPath As String) As Integer

        Dim DestFullPath = FirstPartFullPath.Substring(0, FirstPartFullPath.Length - 3)

        Using DestFile As New FileStream(DestFullPath, FileMode.CreateNew)

            Dim Part As Integer = 1

            Do
                Dim PartFullPath As String = DestFullPath & ".p" & Part

                If Not My.Computer.FileSystem.FileExists(PartFullPath) Then
                    Exit Do
                End If

                Using PartSource As New FileStream(PartFullPath, FileMode.Open)
                    PartSource.CopyTo(DestFile)
                End Using

                Part += 1

            Loop

            Return DestFile.Length

        End Using

    End Function

End Module
