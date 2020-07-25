Imports System.IO

Module SplitFile

    Function SplitFile(SourceFullPath As String, SplitSizeInBytes As Integer) As Integer

        Dim FileSizeInBytes As Integer = My.Computer.FileSystem.GetFileInfo(SourceFullPath).Length
        Dim QtyParts As Integer = Math.Ceiling(FileSizeInBytes / SplitSizeInBytes)


        Using FileSource As New FileStream(SourceFullPath, FileMode.Open)

            For Part As Integer = 1 To QtyParts

                Dim PartFileName As String = SourceFullPath & ".p" & Part

                Using PartDest As New FileStream(PartFileName, FileMode.CreateNew)
                    CopyExact(FileSource, PartDest, SplitSizeInBytes)
                End Using

            Next
        End Using

        Return QtyParts
    End Function

    Sub CopyExact(Source As FileStream, Dest As FileStream, Size As Integer)

        Dim IdealBuffSize = 64 * 1024

        Dim RemaingSize As Integer = Size


        Do While RemaingSize > 0

            Dim BuffSize As Integer = IIf(RemaingSize > IdealBuffSize, IdealBuffSize, RemaingSize)
            Dim Buff(BuffSize - 1) As Byte

            Dim bytesRead As Integer = Source.Read(Buff, 0, BuffSize)

            Dest.Write(Buff, 0, bytesRead)

            RemaingSize -= BuffSize
        Loop
    End Sub

End Module
