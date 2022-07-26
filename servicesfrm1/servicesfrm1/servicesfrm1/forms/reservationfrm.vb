Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Odbc
Imports System.Data.DataTable
Imports System.Data.SqlClient

Public Class reservationfrm
    Private bitmap As Bitmap
    Dim rdr As SqlDataReader
    Dim provider As String
    Dim dataFile As String
    Dim connString As String
    Dim myConnection As SqlConnection = New SqlConnection
    Dim ds As DataSet = New DataSet
    Dim da As SqlDataAdapter
    Dim tables As DataTableCollection = ds.Tables
    Dim source1 As New BindingSource()
    Dim source2 As New BindingSource()
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
    'insert Function
    Private Sub insert()
        Try
            dbaccessconnection()
            con.Open()
            cmd.CommandText = "insert into tbl_reservation(R_Entryno,Re_id,Rate_ID,Service_Name,Gender,Service_Description,Member_ID,Memebr_name,m_contactinfo,m_age,m_address,Reservation_Date,Reservation_Time,R_Date,Reservation_Status)values('" & reentry_txt.Text & "','" & resid_txt.Text & "','" & rid_txt.Text & "','" & rese_sertxt.Text & "','" & re_gendrtxt.Text & "','" & re_serdescriptiontxt.Text & "','" & re_mname_txt.Text & "','" & mid_txt.Text & "','" & re_membercntct_txt.Text & "','" & re_memberage_txt.Text & "','" & re_memberadress_txt.Text & "','" & dte_txt.Value & "','" & rese_time.Value & "','" & reservedon_txt.Value & "','" & pending_txt.Text & "')"
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            MsgBox("Data Inserted Failed because " & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    'edit Funtion
    Private Sub edit()
        con.Close()
        Try
            dbaccessconnection()
            con.Open()
            'TabControl1.SelectedTab = TabPage2
            cmd.CommandText = ("UPDATE tbl_reservation SET  R_Entryno= '" & reentry_txt.Text & "', Re_id= '" & resid_txt.Text & "',Rate_ID= '" & rid_txt.Text & "',Service_Name= '" & rese_sertxt.Text & "',Gender= '" & re_gendrtxt.Text & "',Service_Description= '" & re_serdescriptiontxt.Text & "',Member_ID= '" & re_mname_txt.Text & "',Memebr_name= '" & mid_txt.Text & "',m_contactinfo= '" & re_membercntct_txt.Text & "',m_age= '" & re_memberage_txt.Text & "',m_address= '" & re_memberadress_txt.Text & "',Reservation_Date= '" & dte_txt.Value & "',Reservation_Time= '" & rese_time.Value & "',R_Date= '" & reservedon_txt.Value & "' where R_Entryno=" & reentry_txt.Text & "")
            cmd.ExecuteNonQuery()
            welcomemsg.ForeColor = System.Drawing.Color.DarkGreen
            welcomemsg.Text = "'" & rid_txt.Text & "' details update successfully!"

            con.Close()
        Catch ex As Exception
            MessageBox.Show("Data Not Updated" & ex.Message)
            welcomemsg.ForeColor = System.Drawing.Color.Red
            Me.Dispose()
        End Try
    End Sub
    'Delete function

    Private Sub DeleteSelecedRows()
        Try
            Dim ObjConnection As New SqlConnection()
            Dim i As Integer
            Dim mResult
            mResult = MsgBox("Want you really delete the selected records?", _
            vbYesNo + vbQuestion, "Removal confirmation")
            If mResult = vbNo Then
                Exit Sub
            End If
            ObjConnection.ConnectionString = cs
            Dim ObjCommand As New SqlCommand()
            ObjCommand.Connection = ObjConnection
            For i = Me.get_reservationdata.SelectedRows.Count - 1 To 0 Step -1
                ObjCommand.CommandText = "delete from tbl_reservation where R_Entryno='" & get_reservationdata.SelectedRows(i).Cells("R_Entryno").Value & "'"
                ObjConnection.Open()
                ObjCommand.ExecuteNonQuery()
                ObjConnection.Close()
                Me.get_reservationdata.Rows.Remove(Me.get_reservationdata.SelectedRows(i))
            Next
        Catch ex As Exception
            MessageBox.Show("Failed:Deleting Selected Values" & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    'auto increment the entry id
    Private Sub txtboxid()
        Try
            dbaccessconnection()
            con.Open()
            Dim num As New Integer
            cmd.CommandText = "SELECT MAX(R_Entryno) FROM tbl_reservation"
            If (IsDBNull(cmd.ExecuteScalar)) Then
                num = 1
                reentry_txt.Text = num.ToString
            Else

                num = cmd.ExecuteScalar + 1
                reentry_txt.Text = num.ToString
            End If
            con.Close()
        Catch ex As Exception
            MsgBox("Failed:Autoincrement of Reservation Entry" & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    'auto increment alphanumeric id
    Private Sub autogenerated()
        Try
            Dim curValue As Integer
            Dim result As String
            Using con As SqlConnection = New SqlConnection(cs)
                con.Open()
                Dim cmd = New SqlCommand("select Max(Re_id) from tbl_reservation", con)
                result = cmd.ExecuteScalar().ToString()
                If String.IsNullOrEmpty(result) Then
                    result = "RES-0000"
                End If

                result = result.Substring(3)
                Int32.TryParse(result, curValue)
                curValue = curValue + 1
                result = "IN" + curValue.ToString("D4")
                resid_txt.Text = result
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed:AutoIncrement of ReservationID" & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    'Show data of reservations in grid
    Private Sub getdata()
        Try
            Dim con As New SqlConnection(cs)
            con.Open()
            Dim da As New SqlDataAdapter("Select R_Entryno,Re_id,Rate_ID,Service_Name,Gender,Service_Description,Member_ID,Memebr_name,m_contactinfo as [Contact Number],m_age as [Age],m_address as [Address],Reservation_Date,Reservation_Time,R_Date from tbl_reservation ", con)
            Dim dt As New DataTable
            da.Fill(dt)
            source2.DataSource = dt
            get_reservationdata.DataSource = dt
            get_reservationdata.Refresh()
        Catch ex As Exception
            MessageBox.Show("Failed:Retrieving Data" & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    'get recent rate-ids of services in dropdown
    Private Sub RateID_FillCombo()
        Try
            Dim conn As New System.Data.SqlClient.SqlConnection(cs)
            Dim strSQL As String = "SELECT Service_Name FROM tbl_services"
            Dim da As New System.Data.SqlClient.SqlDataAdapter(strSQL, conn)
            Dim ds As New DataSet
            da.Fill(ds, "tbl_services")
            With Me.rese_sertxtt
                .DataSource = ds.Tables("tbl_services")
                .DisplayMember = "Service_Name"
                .ValueMember = "Service_Name"
                .SelectedIndex = -1
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems
            End With


        Catch ex As Exception
            MessageBox.Show("Failed:Retrieving and Populating Recent RatesName " & ex.Message)
            Me.Dispose()
        End Try

    End Sub
    'get registerd Membersdata for services in dropdown
    Private Sub M_ID_FillCombo()
        Try
            Dim conn As New System.Data.SqlClient.SqlConnection(cs)
            Dim strSQL As String = "SELECT * FROM tbl_memberreg"
            Dim da As New System.Data.SqlClient.SqlDataAdapter(strSQL, conn)
            Dim ds As New DataSet
            da.Fill(ds, "tbl_memberreg")
            With Me.mid_txt
                .DataSource = ds.Tables("tbl_memberreg")
                .DisplayMember = "m_name"
                .ValueMember = "m_name"
                .SelectedIndex = -1
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems
            End With

        Catch ex As Exception
            MessageBox.Show("Failed:Retrieving Registered MembersName " & ex.Message)
            Me.Dispose()
        End Try

    End Sub
    'Functions on form load
    Private Sub reservationfrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call CenterToScreen()
        dbaccessconnection()
        getdata()
        txtboxid()
        autogenerated()

        M_ID_FillCombo()
        'getdata_reservation()
        Me.Label11.Text = Format(Now, "yyyy-MM-dd")
        Me.Label31.Text = TimeOfDay.ToString("h:mm:ss tt")
        ' getdata_reservation()
    End Sub
    'Empty the textboxes
    Private Sub clear()
        Try
            rid_txt.Text = ""
            mid_txt.Text = ""
            rese_sertxt.Text = ""
            rese_sertxtt.Text = ""
        Catch ex As Exception
            MsgBox("Failed:Clear " & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    '>>>>>>>>>>>>>>>>>>>>>Buttons<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    'Save Button
    Private Sub svemem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles svemem.Click

        If Len(Trim(rid_txt.Text)) = 0 Then
            MessageBox.Show("Please Enter RateID", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            rid_txt.Focus()
            Exit Sub
        End If
        Try
            MessageBox.Show("Are you sure to add data", "Data Adding", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            insert()
            getdata()
            'RateID_FillCombo()
            getdata_reservation()
            ' M_ID_FillCombo()
            get_reservationdata.Refresh()
            welcomemsg.Text = "'" & rid_txt.Text & "' details saved successfully!"
            welcomemsg.ForeColor = System.Drawing.Color.DarkGreen

        Catch ex As Exception
            welcomemsg.Text = "Error while saving '" & rid_txt.Text & "' reservation details"
            welcomemsg.ForeColor = System.Drawing.Color.Red
            MsgBox("DataBase not connected due to the reason because " & ex.Message)
            Me.Dispose()
        End Try

    End Sub
    'edit Button
    Private Sub btnupdte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdte.Click
        edit()
        getdata()
        get_reservationdata.Refresh()
        btnupdte.Enabled = False
    End Sub
    'close Button
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Dispose()
    End Sub
    ' delete Button
    Private Sub Btndel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btndel.Click
        TabControl1.SelectedTab = TabPage2
    End Sub
    'delete button in grid
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        DeleteSelecedRows()
    End Sub
    'Add Button
    Private Sub Btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnadd.Click
        Clear()
        ' getdata()
        txtboxid()
        autogenerated()
        RateID_FillCombo()
        M_ID_FillCombo()
        svemem.Enabled = True
        btnupdte.Enabled = False
    End Sub
    'add services if more then 1
    Private Sub s_nameadd()
        rese_sertxt.Text &= rese_sertxtt.Text & "," & vbNewLine
    End Sub
    'for services:::By selecting from dropdown menu ,it will gives the deltails in other textboxes w.r.t selected value
    Private Sub rid_txt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rid_txt.SelectedIndexChanged
        Dim str As String = cs
        Dim con As SqlConnection = New SqlConnection(str)
        Dim query As String = "select * from tbl_services where Service_Name = '" & rese_sertxtt.Text & "' "
        Dim cmd As SqlCommand = New SqlCommand(query, con)
        Dim dbr As SqlDataReader
        Try
            con.Open()
            dbr = cmd.ExecuteReader()
            If dbr.Read() Then
                rid_txt.Text = dbr.GetValue(1)
                re_gendrtxt.Text = dbr.GetValue(3)
                re_serdescriptiontxt.Text = dbr.GetValue(6)
            End If
            re_gendrtxt.Visible = True
            re_serdescriptiontxt.Visible = True
            Label18.Visible = True
            Label20.Visible = True

        Catch ex As Exception
            MessageBox.Show("Failed:Selected Value of services", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Dispose()
        End Try
    End Sub
    'for members:::By selecting from dropdown menu ,it will gives the deltails in other textboxes w.r.t selected value
    'show details of that member
    Private Sub mid_txt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mid_txt.SelectedIndexChanged
        Dim str As String = cs
        Dim con As SqlConnection = New SqlConnection(str)
        Dim query As String = "select * from tbl_memberreg where m_name = '" & mid_txt.Text & "' "
        Dim cmd As SqlCommand = New SqlCommand(query, con)
        Dim dbr As SqlDataReader
        Try
            con.Open()
            dbr = cmd.ExecuteReader()
            If dbr.Read() Then
                re_mname_txt.Text = dbr.GetValue(1)
                re_membercntct_txt.Text = dbr.GetValue(3)
                re_memberage_txt.Text = dbr.GetValue(4)
                re_memberadress_txt.Text = dbr.GetValue(5)
            End If
            re_mname_txt.Visible = True
            re_membercntct_txt.Visible = True
            re_memberage_txt.Visible = True
            re_memberadress_txt.Visible = True
            re_gendrtxt.Visible = True
            Label5.Visible = True
            Label16.Visible = True
            Label14.Visible = True
            Label12.Visible = True
            Label17.Visible = True
            Label18.Visible = True

        Catch ex As Exception
            MessageBox.Show("Failed:Selected Value of members", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Dispose()
        End Try
    End Sub
    'click on text of grid
    Private Sub get_reservationdata_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles get_reservationdata.CellContentClick
        TabControl1.SelectedTab = TabPage1
        svemem.Enabled = False
        Btndel.Enabled = True
        btnupdte.Enabled = True
        re_gendrtxt.Visible = True
        re_serdescriptiontxt.Visible = True
        Label18.Visible = True
        Label20.Visible = True
        Label5.Visible = True
        Label16.Visible = True
        Label14.Visible = True
        Label12.Visible = True
        Try
            Btndel.Enabled = True
            btnupdte.Enabled = True
            Me.reentry_txt.Text = get_reservationdata.CurrentRow.Cells(0).Value.ToString
            Me.resid_txt.Text = get_reservationdata.CurrentRow.Cells(1).Value.ToString
            Me.rid_txt.Text = get_reservationdata.CurrentRow.Cells(2).Value.ToString
            Me.rese_sertxt.Text = get_reservationdata.CurrentRow.Cells(3).Value.ToString
            Me.rese_sertxtt.Text = get_reservationdata.CurrentRow.Cells(3).Value.ToString
            Me.re_gendrtxt.Text = get_reservationdata.CurrentRow.Cells(4).Value.ToString
            Me.re_serdescriptiontxt.Text = get_reservationdata.CurrentRow.Cells(5).Value.ToString
            Me.re_mname_txt.Text = get_reservationdata.CurrentRow.Cells(6).Value.ToString
            Me.mid_txt.Text = get_reservationdata.CurrentRow.Cells(7).Value.ToString
            Me.re_membercntct_txt.Text = get_reservationdata.CurrentRow.Cells(8).Value.ToString
            Me.re_memberage_txt.Text = get_reservationdata.CurrentRow.Cells(9).Value.ToString
            Me.re_memberadress_txt.Text = get_reservationdata.CurrentRow.Cells(10).Value.ToString
            Me.dte_txt.Value = get_reservationdata.CurrentRow.Cells(11).Value.ToString
            Me.rese_time.Text = get_reservationdata.CurrentRow.Cells(12).Value.ToString
            Me.reservedon_txt.Text = get_reservationdata.CurrentRow.Cells(13).Value.ToString

        Catch ex As Exception
            MessageBox.Show("Failed:Selected Value of Cellcontent", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Dispose()
        End Try
    End Sub

   
    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>today reservation functions>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    'get today reservation data
    Private Sub getdata_reservation()
        Try
            Dim con As New SqlConnection(cs)
            con.Open()
            Dim da As New SqlDataAdapter("Select Top 20 R_Entryno,Memebr_name,Reservation_Date,Reservation_Time,Reservation_Served_EndTime,Serve_Emplyee,Reservation_Status From tbl_reservation where Reservation_Date = '" & Label11.Text & "'", con)
            Dim dt As New DataTable
            da.Fill(dt)
            source2.DataSource = dt
            DataGridView1.DataSource = dt
            DataGridView1.Refresh()
        Catch ex As Exception
            MessageBox.Show("Failed:Today Reservation" & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    'search client name by textbox
    Private Sub client_search_txt()
        Dim str As String
        Try
            con.Open()
            str = "Select R_Entryno,Memebr_name,Reservation_Date,Reservation_Time,Reservation_Status from tbl_reservation where Memebr_name like '" & TextBox3.Text & "%' and Reservation_Date = '" & Label11.Text & "'"
            cmd = New SqlCommand(str, con)
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "tbl_reservation")
            con.Close()
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "tbl_reservation"
            DataGridView1.Visible = True
        Catch ex As Exception
            MessageBox.Show("Failed:Today Reservation ClientName Search", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Dispose()
        End Try
    End Sub
    'search when text-change
    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        client_search_txt()
    End Sub
    ' get today-pending reservation
    Private Sub getdata_pending_reservation()
        Try
            Dim con As New SqlConnection(cs)
            con.Open()
            Dim da As New SqlDataAdapter("Select Top 20 R_Entryno,Memebr_name,Reservation_Date,Reservation_Time,Reservation_Status From tbl_reservation where Reservation_Date = '" & Label11.Text & "' And Reservation_Status ='Pending'", con)
            Dim dt As New DataTable
            da.Fill(dt)
            source2.DataSource = dt
            DataGridView1.DataSource = dt
            DataGridView1.Refresh()
        Catch ex As Exception
            MessageBox.Show("Failed:Today Pending Reservation", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Dispose()
        End Try
    End Sub
    ' button for update the status
    Private Sub refreshstatus()
        con.Close()
        Try
            dbaccessconnection()
            con.Open()
            cmd.CommandText = ("UPDATE tbl_reservation SET Serve_Emplyee= '" & today_employeeadd_txt.Text & "',Reservation_Status='" & today_Cstatus.Text & "',Reservation_Served_EndTime='" & DateTimePicker1.Value & "' where R_Entryno=" & today_entry.Text & "")
            cmd.ExecuteNonQuery()
            ' MessageBox.Show("Status Updated")
            con.Close()
        Catch ex As Exception
            MessageBox.Show("Data Not Updated" & ex.Message)
        End Try
    End Sub
    'check if emplyee is available or not
   
    Private Sub Check_employee()
        'employee_search_txt()
      
        Dim str As String
        Try
            con.Open()
            str = "Select R_Entryno,Memebr_name,Reservation_Time,Reservation_Served_EndTime,Serve_Emplyee,Reservation_Status from tbl_reservation where Serve_Emplyee like '" & today_employeeadd_txt.Text & "%'  And Reservation_Time BETWEEN '" & today_Ctime.Text & "' AND '" & Label31.Text & "'  And Reservation_Status ='Serving' AND Reservation_Date = '" & Label11.Text & "'"
            cmd = New SqlCommand(str, con)
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "tbl_reservation")
            con.Close()
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "tbl_reservation"
            
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub
    'add the new reservation
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        refreshstatus()
        getdata_reservation()
        DataGridView1.Visible = True
       
       
        Me.Label33.Text = ""
    End Sub
    Private Sub getdata_served_reservation()
        Try
            Dim con As New SqlConnection(cs)
            con.Open()
            Dim da As New SqlDataAdapter("Select Top 20 R_Entryno,Memebr_name,Reservation_Date,Reservation_Time,Reservation_Served_EndTime,Reservation_Status,Serve_Emplyee From tbl_reservation where Reservation_Date = '" & Label11.Text & "' And Reservation_Status ='Served'", con)
            Dim dt As New DataTable
            da.Fill(dt)
            source2.DataSource = dt
            DataGridView1.DataSource = dt
            DataGridView1.Refresh()
        Catch ex As Exception
            MessageBox.Show("Failed:Today Served Reservation", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Dispose()
        End Try
    End Sub
    Private Sub getdata_serving_reservation()
        Try
            Dim con As New SqlConnection(cs)
            con.Open()
            Dim da As New SqlDataAdapter("Select Top 20 R_Entryno,Memebr_name,Reservation_Date,Reservation_Time,Reservation_Served_EndTime,Serve_Emplyee,Reservation_Status From tbl_reservation where Reservation_Date = '" & Label11.Text & "' And Reservation_Status ='Serving'", con)
            Dim dt As New DataTable
            da.Fill(dt)
            source2.DataSource = dt
            DataGridView1.DataSource = dt
            DataGridView1.Refresh()
        Catch ex As Exception
            MessageBox.Show("Failed:Today Serving Reservation", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Dispose()
        End Try
    End Sub
    Private Sub getdata_cancelled_reservation()
        Try
            Dim con As New SqlConnection(cs)
            con.Open()
            Dim da As New SqlDataAdapter("Select Top 20 R_Entryno,Memebr_name,Reservation_Date,Reservation_Time,Reservation_Status From tbl_reservation where Reservation_Date = '" & Label11.Text & "' And Reservation_Status ='Cancelled'", con)
            Dim dt As New DataTable
            da.Fill(dt)
            source2.DataSource = dt
            DataGridView1.DataSource = dt
            DataGridView1.Refresh()
        Catch ex As Exception
            MessageBox.Show("Failed:Today Cancelled Reservation", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Dispose()
        End Try
    End Sub
    'pinding radiobutton
    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        getdata_pending_reservation()
    End Sub
    'served radiobutton
    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        getdata_served_reservation()
    End Sub
    'serving radiobutton
    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        getdata_serving_reservation()
    End Sub
    'cancell radiobutton
    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        getdata_cancelled_reservation()
    End Sub
   
    'check employee availabilty after wrinting its name in textbox
    Private Sub today_employeeadd_txt_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles today_employeeadd_txt.Validated
        Check_employee()
    End Sub

    Private Sub today_Cname_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles today_Cname.MouseClick

    End Sub

    Private Sub today_Cname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles today_Cname.Validated

    End Sub

    'textboxs papoluating
    Private Sub today_textbox_client()
        Dim strsql As String = "select R_Entryno,Memebr_name,Reservation_Date,Reservation_Time,Reservation_Served_EndTime,Serve_Emplyee,Reservation_Status from tbl_reservation where Memebr_name like('" + today_Cname.Text + "%')"
        Dim strcon As String = cs
        Dim odapre As New SqlDataAdapter(strsql, strcon)
        Dim datTable As New DataTable
        Dim incount As Integer
        odapre.Fill(datTable)
        For incount = 0 To datTable.Rows.Count - 1
            today_entry.Text = datTable.Rows(incount)("R_Entryno").ToString
            today_Cdate.Text = datTable.Rows(incount)("Reservation_Date").ToString
            today_Ctime.Text = datTable.Rows(incount)("Reservation_Time").ToString
            today_Cstatus.Text = datTable.Rows(incount)("Reservation_Status").ToString
            today_employeeadd_txt.Text = datTable.Rows(incount)("Serve_Emplyee").ToString
            DateTimePicker1.Text = datTable.Rows(incount)("Reservation_Served_EndTime").ToString
            ' DateofBirthDateTimePicker.Text = datTable.Rows(incount)("DateofBirth").ToString
            ' EmailaddressTextBox.Text = datTable.Rows(incount)("Emailaddress").ToString
            ' PicturesPictureBox1. = datTable.Rows(incount)("Pictures")
        Next
    End Sub
    Private Sub today_Cname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles today_Cname.Validating
        today_textbox_client()
    End Sub


   
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        today_Cname.Text = ""
        today_entry.Text = ""
        today_Cstatus.Text = ""
        today_employeeadd_txt.Text = ""
        today_entry.Text = ""
        Button3.Enabled = True
        getdata_reservation()
        Label33.Text = ""
    End Sub
    'payment button
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        today_Cname.Text = ratesfrm.mname_txt.Text
        ratesfrm.Show()
    End Sub
    'send member name and employee name to payment form

    'search by date
    Private Sub payment_productsearchdate()
        con.Close()
        Try
            ' Dim cn As New SqlConnection
            Dim ds As New DataSet
            Dim dt As New DataTable
            Dim dfrom As DateTime = DateTimePicker1.Value
            Dim dto As DateTime = DateTimePicker2.Value
            myConnection.ConnectionString = cs
            myConnection.Open()
            Dim str As String = "Select * from tbl_reservation where R_Date >= '" & Format(dfrom, "MM-dd-yyyy") & "' and R_Date <='" & Format(dto, "MM-dd-yyyy") & "'"
            Dim da As SqlDataAdapter = New SqlDataAdapter(str, myConnection)
            da.Fill(dt)
            get_reservationdata.DataSource = dt
            myConnection.Close()
            get_reservationdata.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Failed:Date Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Dispose()
        End Try
    End Sub
    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton5.CheckedChanged
        payment_productsearchdate()
        RadioButton5.Checked = False
    End Sub
    'search member name in grid
    Private Sub search_txt()
        Dim str As String
        Try
            con.Open()
            str = "Select * from tbl_reservation where Memebr_name like '" & TextBox2.Text & "%'"
            cmd = New SqlCommand(str, con)
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "tbl_reservation")
            con.Close()
            get_reservationdata.DataSource = ds
            get_reservationdata.DataMember = "tbl_reservation"
            get_reservationdata.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Failed:Member Name Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Dispose()
        End Try
    End Sub
   
    Private Sub rese_sertxtt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rese_sertxtt.SelectedIndexChanged
        Dim str As String = cs
        Dim con As SqlConnection = New SqlConnection(str)
        Dim query As String = "select * from tbl_services where Service_Name = '" & rese_sertxtt.Text & "' "
        Dim cmd As SqlCommand = New SqlCommand(query, con)
        Dim dbr As SqlDataReader
        Try
            con.Open()
            dbr = cmd.ExecuteReader()
            If dbr.Read() Then
                rid_txt.Text = dbr.GetValue(1)
                re_gendrtxt.Text = dbr.GetValue(3)
                re_serdescriptiontxt.Text = dbr.GetValue(6)
            End If
            re_gendrtxt.Visible = True
            re_serdescriptiontxt.Visible = True
            Label18.Visible = True
            Label20.Visible = True
            ' s_nameadd()
        Catch ex As Exception
            MessageBox.Show("Failed:Selected Value of services", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Dispose()
        End Try
        ' s_nameadd()
    End Sub
    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        search_txt()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Try
           
            Me.today_Cname.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
           

        Catch ex As Exception
            MessageBox.Show("Failed:Selected Value of Cellcontent ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Dispose()
        End Try
    End Sub

    Private Sub today_Cname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles today_Cname.TextChanged
        today_textbox_client()
    End Sub

    Private Sub today_Cstatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles today_Cstatus.SelectedIndexChanged
        If today_Cstatus.Text = "Pending" Then
            today_employeeadd_txt.Text = ""
            Button3.Enabled = True
        Else
            Button3.Enabled = True
        End If
    End Sub

    

    Private Sub today_employeeadd_txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles today_employeeadd_txt.Validating

    End Sub

    Private Sub employee_search_txt()

        Dim str As String
        Try
            con.Open()
            str = "Select R_Entryno,Reservation_Status,Serve_Emplyee from tbl_reservation where Serve_Emplyee like '" & today_employeeadd_txt.Text & "%' And Reservation_Status='Serving' And Reservation_Date = '" & Label11.Text & "'"
            cmd = New SqlCommand(str, con)
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "tbl_reservation")
            con.Close()
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "tbl_reservation"
            DataGridView1.Visible = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Failed:Emplyee NameSearch", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Dispose()
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub today_employeeadd_txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles today_employeeadd_txt.TextChanged
        employee_search_txt()
        If (DataGridView1.Rows.Count = 0 Or Nothing) Then
            Label33.ForeColor = System.Drawing.Color.DarkGreen
            Me.Label33.Text = "Available"
            Button3.Enabled = True
        Else

            Label33.ForeColor = System.Drawing.Color.Red
            Me.Label33.Text = "NO"
            Button3.Enabled = False
        End If
            



    End Sub

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click

    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub Label10_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label10.MouseHover
        If btnupdte.Enabled = False Then
            ToolTip1.IsBalloon = True
            ToolTip1.UseAnimation = True
            ToolTip1.ToolTipTitle = ""
            ToolTip1.SetToolTip(Label10, "Select the field from Grid to Edit")
        Else
            ToolTip1.IsBalloon = True
            ToolTip1.UseAnimation = True
            ToolTip1.ToolTipTitle = ""
            ToolTip1.SetToolTip(Label10, "Click to Edit")
        End If
    End Sub

    Private Sub Button6_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(Button6, "Select the one field or more from Grid to Remove")
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        s_nameadd()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
         RateID_FillCombo()
    End Sub

  
   

    

  
    
    Private Sub closee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles closee.Click
        Me.Dispose()
    End Sub
End Class