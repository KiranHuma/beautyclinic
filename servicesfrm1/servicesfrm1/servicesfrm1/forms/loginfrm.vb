Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Odbc
Imports System.Data.DataTable
Imports System.Data.SqlClient
Public Class loginfrm
    Dim rdr As SqlDataReader
    Dim colColors As Collection = New Collection
    Dim provider As String
    Dim dataFile As String
    Dim connString As String
    Dim myConnection As SqlConnection = New SqlConnection
    Dim ds As DataSet = New DataSet
    Dim da As SqlDataAdapter
    Dim tables As DataTableCollection = ds.Tables
 
    Dim con As New SqlClient.SqlConnection
    Dim cmd As New SqlClient.SqlCommand

    Dim dt As New DataTable
    Dim cs As String = "Data Source=ANIRUDH;Initial Catalog=mainclinicdb;Integrated Security=True"
    'Database Connection
    Private Sub dbaccessconnection()

        Try
            con.ConnectionString = cs
            cmd.Connection = con
        Catch ex As Exception
            MsgBox("DataBase not connected due to the reason because " & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Me.Dispose()
    End Sub


    Private Sub loginfrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text.Length <= 0 Then
            MessageBox.Show("Please enter Username!")
        ElseIf TextBox2.Text.Length <= 0 Then
            MessageBox.Show("Please enter Password!")
        End If
        If TextBox1.Text = "beautyclinic " Or TextBox2.Text = "clinic123" Then
            Beep()
            Beep()
            MainFrom1.ShowDialog()         
            Me.Dispose()
        Else
            Label4.Visible = True
            Label4.ForeColor = System.Drawing.Color.Red
            Label4.Text = " Not succsessfully login "
        End If
        'End If
    End Sub


    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextBox2.PasswordChar = ControlChars.NullChar
            ' TextBox2.PasswordChar = ""
        Else
            TextBox2.PasswordChar = "*"
        End If
    End Sub
End Class