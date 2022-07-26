
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Odbc
Imports System.Data.DataTable
Imports System.Data.SqlClient


Public Class MainFrom1
    Private bitmap As Bitmap 'for print grid
    Dim rdr As SqlDataReader
    Dim colColors As Collection = New Collection 'for color of listbox
    Dim provider As String  'for access and sql same
    Dim dataFile As String  'for access and sql same
    Dim connString As String   'for access and sql same
    ' Dim myConnection As OleDbConnection = New OleDbConnection   'for access replace it  Dim myConnection As SqlConnection = New SqlConnection
    Dim myConnection As SqlConnection = New SqlConnection
    Dim ds As DataSet = New DataSet            'for access and sql same
    ' Dim da As OleDbDataAdapter                'for access replace it with Dim da As SqlDataAdapter
    Dim da As SqlDataAdapter
    Dim tables As DataTableCollection = ds.Tables  'for access and sql same
    Dim source1 As New BindingSource()                    'for access and sql same
    Dim source2 As New BindingSource()
    Dim con As New SqlClient.SqlConnection                      'for sql
    Dim cmd As New SqlClient.SqlCommand                        'for sql

    Dim dt As New DataTable
    Dim cs As String = "Data Source=ADMINRG-FFQIQKT;Initial Catalog=mainclinicdb;Integrated Security=True"

    Private Sub dbaccessconnection()

        Try
            con.ConnectionString = "Data Source=ADMINRG-FFQIQKT;Initial Catalog=mainclinicdb;Integrated Security=True"
            cmd.Connection = con
            'MessageBox.Show(con.State.ToString())
            'MsgBox("DataBase connected ")
        Catch ex As Exception
            MsgBox("DataBase not connected due to the reason because " & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dbaccessconnection()
        Call CenterToScreen()
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        regmmberfrm.Show()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If MsgBox("Are you sure want to exit now?", MsgBoxStyle.YesNo, "Closing warning") = MsgBoxResult.Yes Then ' If you select yes in the MsgBox then it will close the window
            Me.Close()
            '  Me.Dispose() ' Close the window
        Else
            ' Will not close the application
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        reservationfrm.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        ReportsAndExportFrm.Show()

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        prodcutfrm.Show()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        inventryfrm.Show()
    End Sub

 
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ratesfrm.Show()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
