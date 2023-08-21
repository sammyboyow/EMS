Imports System.Data.SqlClient

Module Module1
    Sub Main()
        ' Connection string for the source database
        Dim sourceConnectionString As String = "Data Source=172.30.0.17;Initial Catalog=HPCOMMON;Integrated Security=False;UID=sapdb;Pwd=sapdb"

        ' Connection string for the destination database
        Dim destinationConnectionString As String = "Data Source=192.175.10.40;Initial Catalog=HPCOMMON_TEST;Integrated Security=False;UID=sapdb;Pwd=sapdb"

        ' Name of the source table
        Dim sourceTableName As String = "PMI_PARA"

        ' Name of the destination table
        Dim destinationTableName As String = "EMPLOYEE"

        ' Create a SqlConnection object for the source database
        Using sourceConnection As New SqlConnection(sourceConnectionString)
            ' Open the source connection
            sourceConnection.Open()

            ' Create a SqlConnection object for the destination database
            Using destinationConnection As New SqlConnection(destinationConnectionString)
                ' Open the destination connection
                destinationConnection.Open()

                ' Create a SqlCommand object to retrieve the data from the source table
                Dim command As New SqlCommand($"SELECT * FROM {sourceTableName}", sourceConnection)

                ' Execute the command and get the SqlDataReader
                Dim reader As SqlDataReader = command.ExecuteReader()

                ' Create a SqlBulkCopy object with the destination connection
                Using bulkCopy As New SqlBulkCopy(destinationConnection)
                    ' Set the destination table name
                    bulkCopy.DestinationTableName = destinationTableName

                    ' Perform the bulk copy
                    bulkCopy.WriteToServer(reader)
                End Using

                ' Close the SqlDataReader
                reader.Close()
            End Using
        End Using

        Console.WriteLine("Bulk copy completed successfully.")
        Console.ReadLine()

    End Sub
End Module
