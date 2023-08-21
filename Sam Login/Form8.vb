
Imports System.Data.SqlClient
Imports System.Data.OracleClient

Public Class BulkCopy
    'Private Sub btnbulkCopy_Click(sender As Object, e As EventArgs) Handles btnbulkCopy.Click
    '    Dim oracleConnectionString As String = "YourOracleConnectionString"
    '    Dim sqlConnectionString As String = "Data Source=192.175.10.40;Initial Catalog=HPCOMMON_TEST;Integrated Security=False;UID=sapdb;Pwd=sapdb"
    '    Dim oracleTableName As String = "YourOracleTableName"
    '    Dim sqlTableName As String = "PMI_PARA"

    '    Using oracleConnection As New OracleConnection(oracleConnectionString)
    '        Using sqlConnection As New SqlConnection(sqlConnectionString)
    '            oracleConnection.Open()
    '            sqlConnection.Open()

    '            Dim selectQuery As String = "SELECT * FROM PMI_PARA" & oracleTableName
    '            Dim oracleCommand As New OracleCommand(selectQuery, oracleConnection)
    '            Dim oracleDataReader As OracleDataReader = oracleCommand.ExecuteReader()

    '            Using bulkCopy As New SqlBulkCopy(sqlConnection)
    '                bulkCopy.DestinationTableName = sqlTableName
    '                bulkCopy.WriteToServer(oracleDataReader)
    '            End Using

    '            oracleDataReader.Close()
    '        End Using
    '    End Using

    '    MessageBox.Show("Bulk copy completed successfully.")

    'End Sub
End Class