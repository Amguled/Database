Imports System.Data.OleDb


'Imports System.Data.SqlClient
'Imports System.Data.Odbc

Public Class Form1
    'database path = xxxxx
    Dim OLEDBConnStr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Z:\2020\CPRG\Sunday class/FalsebayCollege.accdb"
    Dim OLEDBConn As New OleDb.OleDbConnection(OLEDBConnStr)


    'Dim odbcConnStr As String = "Driver={Microsoft access Driver(*.mdb *.accdb)}; DBQ=Path/.extension"

    'Dim conn As New SqlClient.SqlConnection("")
    ' Dim con As New Odbc.OdbcConnection(odbcConnStr)


    Dim com As New OleDb.OleDbCommand


    Dim studentRecordsTable As New Data.DataTable
    Dim marksTable As New Data.DataTable

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'con.ConnectionString = conStr
        com.Connection = OLEDBConn

        Try


            com.CommandText = "SELECT *FROM studentRecordsTable"
            'open the connection
            OLEDBConn.Open()

            studentRecordsTable.Load(com.ExecuteReader())
            MessageBox.Show("it loaded")

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        Finally
            'closed the conncetion
            ' con.close()
            'reset sql statement

        End Try




    End Sub

    Private Sub btnCapture_Click(sender As Object, e As EventArgs) Handles btnCapture.Click
        Try


            com.CommandText = "INSERT INTO StudentRecords(StudentNumber,FirstName,Surname) VALUES ('1719','Try','Catch',)"

            com.CommandText = "INSERT INTO StudentRecords(StudentNumber,FirstName,Surname) VALUES (@StudentNumber,@FirstName,@Surname)"



            'open the connection

            OLEDBConn.Open()

            com.Parameters.AddWithValue("@StudentNumber", txtStudNumber.Text)
            com.Parameters.AddWithValue("@FirstName", txtName)
            com.Parameters.AddWithValue("@Surname", txtSurname)

            'adds records into database
            com.ExecuteNonQuery()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        Finally
            'closed the conncetion
            OLEDBConn.Close()
            'reset sql statement
            com.Parameters.Clear()


        End Try
    End Sub
End Class
