Imports System.Data.OleDb
Imports System.Data.Odbc
Imports System.Data.DataTable
Imports System.Data.SqlClient
Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Linq
Imports Microsoft.Office.Interop

Public Class productreporfrm
    Dim con As New SqlClient.SqlConnection
    Dim cmd As New SqlClient.SqlCommand
    Dim provider As String
    Dim dataFile As String
    Dim connString As String

    Dim myConnection As SqlConnection = New SqlConnection
    Dim ds As DataSet = New DataSet

    Dim da As SqlDataAdapter
    Dim tables As DataTableCollection = ds.Tables
    Dim source1 As New BindingSource()
    Dim cs As String = "Data Source=ANIRUDH;Initial Catalog=mainclinicdb;Integrated Security=True"
    Private Sub dbaccessconnection()

        Try
            con.ConnectionString = cs
            cmd.Connection = con

        Catch ex As Exception
            MsgBox("DataBase not connected due to the reason because " & ex.Message)
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim cn As New SqlConnection
            Dim ds As New DataSet
            Dim dt As New DataTable
            Dim dfrom As DateTime = DateTimePicker1.Value
            Dim dto As DateTime = DateTimePicker2.Value
            cn.ConnectionString = cs
            cn.Open()
            Dim str As String = "select pro_id,P_id,p_name,p_price,p_dte,p_description from tbl_products where p_dte >= '" & Format(dfrom, "MM-dd-yyyy") & "' and p_dte <='" & Format(dto, "MM-dd-yyyy") & "'"
            Dim da As SqlDataAdapter = New SqlDataAdapter(str, cn)
            da.Fill(dt)
            DataGridView1.DataSource = dt
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
        Catch ex As Exception
            MsgBox("Failed:Get Data " & ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Cursor = Cursors.WaitCursor

            Dim rprt As New productreports 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand As New SqlCommand()
            Dim myDA As New SqlDataAdapter()
            Dim myDS As New mainclinicdbDataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            Dim dfrom As DateTime = DateTimePicker1.Value
            Dim dto As DateTime = DateTimePicker2.Value
            MyCommand.Connection = myConnection
            MyCommand.CommandText = "select pro_id,P_id,p_name,p_price,p_dte,p_description from tbl_products  where p_dte  >= '" & Format(dfrom, "MM-dd-yyyy") & "' and p_dte <='" & Format(dto, "MM-dd-yyyy") & "'"
            MyCommand.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA.Fill(myDS, "tbl_products")
            rprt.SetDataSource(myDS)
            prodctreportview.CrystalReportViewer1.ReportSource = rprt
            prodctreportview.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private myDS As New mainclinicdbDataSet() ' Dataset you created.
    Private Sub wordconvert()
        Dim rpt As New productreports() 'The report you created.
        Dim myConnection As SqlConnection
        Dim MyCommand As New SqlCommand()
        Dim myDA As New SqlDataAdapter()
        Try
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand.CommandText = "SELECT * FROM tbl_products"
            MyCommand.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand

            myDA.Fill(myDS, "tbl_products")
            rpt.SetDataSource(myDS)
            prodctreportview.CrystalReportViewer1.ReportSource = rpt

        Catch Excep As Exception
            MessageBox.Show(Excep.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub excelconvert()


    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If DataGridView1.RowCount = Nothing Then
            MessageBox.Show("Sorry nothing to export into excel sheet.." & vbCrLf & "Please retrieve data in datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim rowsTotal, colsTotal As Short
        Dim I, j, iC As Short
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim xlApp As New Excel.Application
        Try
            Dim excelBook As Excel.Workbook = xlApp.Workbooks.Add
            Dim excelWorksheet As Excel.Worksheet = CType(excelBook.Worksheets(1), Excel.Worksheet)
            xlApp.Visible = True

            rowsTotal = DataGridView1.RowCount
            colsTotal = DataGridView1.Columns.Count - 1
            With excelWorksheet
                .Cells.Select()
                .Cells.Delete()
                For iC = 0 To colsTotal
                    .Cells(1, iC + 1).Value = DataGridView1.Columns(iC).HeaderText
                Next
                For I = 0 To rowsTotal - 1
                    For j = 0 To colsTotal
                        .Cells(I + 2, j + 1).value = DataGridView1.Rows(I).Cells(j).Value.ToString()
                    Next j
                Next I
                .Rows("1:1").Font.FontStyle = "Bold"
                .Rows("1:1").Font.Size = 12

                .Cells.Columns.AutoFit()
                .Cells.Select()
                .Cells.EntireColumn.AutoFit()
                .Cells(1, 1).Select()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'RELEASE ALLOACTED RESOURCES
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            xlApp = Nothing
        End Try
    End Sub

    Private Sub productreporfrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        wordconvert()
        Call CenterToScreen()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'This Code is used to Convert to word document
        Dim reportWord As New productreports() ' Report Name 
        Dim strExportFile As String = "e:\ProducRegistraionReport.doc"
        reportWord.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
        reportWord.ExportOptions.ExportFormatType = ExportFormatType.WordForWindows
        Dim objOptions As DiskFileDestinationOptions = New DiskFileDestinationOptions()
        objOptions.DiskFileName = strExportFile
        reportWord.ExportOptions.DestinationOptions = objOptions
        reportWord.SetDataSource(myDS)
        reportWord.Export()
        objOptions = Nothing
        reportWord = Nothing
        MsgBox("Please Check your E Drive.There will be a File with the Name of ProducRegistrationReport.Please Copy and Paste it in other folder for record otherwise it will replace when you print new one")
    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Dispose()
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button4_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.MouseHover

        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(Button4, "Get Data By Clicking on Get data Button")


    End Sub

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Dispose()
    End Sub
End Class