Option Explicit On
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Odbc
Imports System.Data.DataTable
Imports System.Data.SqlClient   'FOR SQL CONNECTION AND COMMAND.
Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel      ' EXCEL APPLICATION.
Imports ExcelAutoFormat = Microsoft.Office.Interop.Excel.XlRangeAutoFormat      ' TO AUTOFORMAT THE SHEET.
Imports System.Drawing.Imaging
Imports System.Security.Cryptography
Imports System.Text

Public Class prodcutfrm
    Private bitmap As Bitmap 'for print grid
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
    '>>>>>>>>>>>>>>>>>>>>>>>>Product>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    'insert Function
    Private Sub insert()
        Try
            dbaccessconnection()
            con.Open()
            cmd.CommandText = "insert into tbl_products(pro_id,P_id,p_name,p_price,p_dte,p_description,photo)values('" & pro_txt.Text & "','" & pid_txt.Text & "','" & name_txt.Text & "','" & price_txt.Text & "','" & p_dtetxt.Value & "','" & des_txt.Text & "',@photo)"
            Dim ms As New MemoryStream()
            Dim bmpImage As New Bitmap(photo.Image)
            bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New SqlParameter("@photo", SqlDbType.Image)
            p.Value = data
            cmd.Parameters.Add(p)

            ms.Close()
            ms.Dispose()

            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()


            If bmpImage IsNot Nothing Then
                bmpImage.Dispose()
            End If
            welcomemsg.ForeColor = System.Drawing.Color.DarkGreen
            welcomemsg.Text = "'" & name_txt.Text & "'  details saved successfully!"
            con.Close()
        Catch ex As Exception
            MsgBox("Data Inserted Failed because " & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    'edit Funtion
    Private Sub edit()
        Try
            con.Open()
            cmd.CommandText = ("UPDATE tbl_products SET  pro_id= '" & pro_txt.Text & "', P_id= '" & pid_txt.Text & "',p_name= '" & name_txt.Text & "',p_price= '" & price_txt.Text & "',p_dte= '" & p_dtetxt.Value & "',p_description= '" & des_txt.Text & "',photo=@photo where pro_id=" & pro_txt.Text & "")
            Dim ms As New MemoryStream()
            Dim bmpImage As New Bitmap(photo.Image)
            bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New SqlParameter("@photo", SqlDbType.Image)
            p.Value = data
            cmd.Parameters.Add(p)
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            welcomemsg.ForeColor = System.Drawing.Color.DarkGreen
            welcomemsg.Text = "'" & name_txt.Text & "'  details update successfully!"

            con.Close()

        Catch ex As Exception
            MessageBox.Show("Data Not Updated" & ex.Message)
            welcomemsg.ForeColor = System.Drawing.Color.Red
            Me.Dispose()
        End Try
    End Sub
    'delete function
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
            For i = Me.get_productdata.SelectedRows.Count - 1 To 0 Step -1
                ObjCommand.CommandText = "delete from tbl_products where pro_id='" & get_productdata.SelectedRows(i).Cells("pro_id").Value & "'"
                ObjConnection.Open()
                ObjCommand.ExecuteNonQuery()
                ObjConnection.Close()
                Me.get_productdata.Rows.Remove(Me.get_productdata.SelectedRows(i))
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
            cmd.CommandText = "SELECT MAX(pro_id) FROM tbl_products "
            If (IsDBNull(cmd.ExecuteScalar)) Then
                num = 1
                pro_txt.Text = num.ToString
            Else

                num = cmd.ExecuteScalar + 1
                pro_txt.Text = num.ToString
            End If
            con.Close()
        Catch ex As Exception
            MsgBox("Failed:Autoincrement of Product Entry" & ex.Message)
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
                Dim cmd = New SqlCommand("select Max(P_id) from tbl_products", con)
                result = cmd.ExecuteScalar().ToString()
                If String.IsNullOrEmpty(result) Then
                    result = "PRO-0000"
                End If

                result = result.Substring(3)
                Int32.TryParse(result, curValue)
                curValue = curValue + 1
                result = "PRO" + curValue.ToString("D4")
                pid_txt.Text = result
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed:AutoIncrement of ProductID" & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    'Show data of products in grid
    Private Sub getdata()
        Try
            Dim con As New SqlConnection(cs)
            con.Open()
            Dim da As New SqlDataAdapter("Select * from tbl_products ", con)
            Dim dt As New DataTable
            da.Fill(dt)
            source2.DataSource = dt
            get_productdata.DataSource = dt
            get_productdata.Refresh()
        Catch ex As Exception
            MessageBox.Show("Failed:Retrieving Data" & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    'get recent names of products in dropdown
    Private Sub product_FillCombo()
        Try
            Dim myConnToAccess As SqlConnection
            Dim ds As DataSet
            Dim da As SqlDataAdapter
            Dim tables As DataTableCollection
            myConnToAccess = New SqlConnection(cs)
            myConnToAccess.Open()
            ds = New DataSet
            tables = ds.Tables
            da = New SqlDataAdapter("SELECT p_name from tbl_products", myConnToAccess)
            da.Fill(ds, "tbl_products")
            Dim view1 As New DataView(tables(0))
            With name_txt
                .DataSource = ds.Tables("tbl_products")
                .DisplayMember = "p_name"
                .ValueMember = "p_name"
                .SelectedIndex = -1
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems
            End With
        Catch ex As Exception
            MessageBox.Show(" Failed:Retrieving RecentNames " & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    'Functions on form load
    Private Sub prodcutfrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        autogenerated()
        dbaccessconnection()
        getdata()
        txtboxid()
        ser_txtboxid()
        ser_getdata()
        ser_autogenerated()
        Call CenterToScreen()
    End Sub
    'Empty the textboxes
    Private Sub clear()
        Try
            con.Close()
            name_txt.Text = ""
            price_txt.Text = ""
            des_txt.Text = ""
            photo.Image = Nothing
        Catch ex As Exception
            MsgBox("Failed:Clear " & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    '>>>>>>>>>>>>>>>>>>>>>Buttons<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    'Save Button
    Private Sub svemem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles svemem.Click

        If Len(Trim(name_txt.Text)) = 0 Then
            MessageBox.Show("Please select Product Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            pro_txt.Focus()
            Exit Sub
        End If
        Try
            MessageBox.Show("Are you sure to add data", "Data Adding", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            insert()
            getdata()
            welcomemsg.Text = "'" & pid_txt.Text & "' products details saved successfully!"
            welcomemsg.ForeColor = System.Drawing.Color.DarkGreen
        Catch ex As Exception
            welcomemsg.Text = "Failed:Saving '" & pid_txt.Text & "' products details"
            welcomemsg.ForeColor = System.Drawing.Color.Red
            MsgBox("DataBase not connected due to the reason because " & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    'edit Button
    Private Sub btnupdte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdte.Click
        edit()
        getdata()
        btnupdte.Enabled = False
    End Sub
    'close button
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Me.Dispose()
    End Sub
    ' delete Button
    Private Sub Btndel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btndel.Click
        TabControl1.SelectedTab = TabPage2
    End Sub
    'grid delete Button 
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        DeleteSelecedRows()
    End Sub
    'Add Button

    Private Sub Btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnadd.Click
        clear()
        txtboxid()
        autogenerated()
        svemem.Enabled = True
        btnupdte.Enabled = False
    End Sub
    'picture upload button
    Private Sub uploadbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uploadbtn.Click
        Try
            With OpenFileDialog1
                .Filter = ("Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;")
                .FilterIndex = 4
            End With
            'Clear the file name
            OpenFileDialog1.FileName = ""
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                photo.Image = Image.FromFile(OpenFileDialog1.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub
    'Recent names button
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        product_FillCombo()
    End Sub
    'report button
    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    'grid mouseclick
    Private Sub get_productdata_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles get_productdata.CellMouseClick
        Try

            Me.pro_txt.Text = get_productdata.CurrentRow.Cells(0).Value.ToString
            Me.pid_txt.Text = get_productdata.CurrentRow.Cells(1).Value.ToString
            Me.name_txt.Text = get_productdata.CurrentRow.Cells(2).Value.ToString
            Me.price_txt.Text = get_productdata.CurrentRow.Cells(3).Value.ToString
            Me.p_dtetxt.Value = get_productdata.CurrentRow.Cells(4).Value.ToString
            Me.des_txt.Text = get_productdata.CurrentRow.Cells(5).Value.ToString
            ' Image()
            Dim i As Integer
            i = get_productdata.CurrentRow.Index
            Dim bytes As [Byte]() = (Me.get_productdata.Item(6, i).Value)
            Dim ms As New MemoryStream(bytes)
            photo.Image = Image.FromStream(ms)
        Catch ex As Exception
            MsgBox("Failed:GridCick " & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    'grid contentclick
    Private Sub get_productdata_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles get_productdata.CellContentClick
        TabControl1.SelectedTab = TabPage1
        svemem.Enabled = False
        Btndel.Enabled = True
        btnupdte.Enabled = True

    End Sub

    '>>>>>>>>>>>>>>>>>>>>>>Service Form>>>>>>>>>>>>>>>>>>>>>>

    'Service insert function
    Private Sub s_insert()
        Try
            dbaccessconnection()
            con.Open()
            cmd.CommandText = "insert into tbl_services(Sentry_no,Rate_ID,Service_Name,Gender,Service_Price,Service_Date,Service_Description)values('" & eservice_txt.Text & "','" & rateid_txt.Text & "','" & servicename_txt.Text & "','" & gnder_txt.Text & "','" & serprice_txt.Text & "','" & s_dte_txt.Value & "','" & sevicedes_txt.Text & "')"
            cmd.ExecuteNonQuery()
            Label21.Text = "'" & rateid_txt.Text & "'  details saved successfully!"
            Label21.ForeColor = System.Drawing.Color.DarkGreen
            con.Close()

        Catch ex As Exception
            MsgBox("Data Inserted in Services Failed because " & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    'edit function of services
    Private Sub ser_edit()
        con.Close()
        Try
            dbaccessconnection()
            con.Open()

            cmd.CommandText = ("UPDATE tbl_services SET Sentry_no= '" & eservice_txt.Text & "', Rate_ID= '" & rateid_txt.Text & "',Service_Name= '" & servicename_txt.Text & "',Gender= '" & gnder_txt.Text & "',Service_Price= '" & serprice_txt.Text & "',Service_Date= '" & s_dte_txt.Value & "',Service_Description= '" & sevicedes_txt.Text & "' where Sentry_no=" & eservice_txt.Text & "")
            cmd.ExecuteNonQuery()

            Label21.Text = "'" & rateid_txt.Text & "'  details update successfully!"
            Label21.ForeColor = System.Drawing.Color.DarkGreen
            sergetdata.Refresh()
            con.Close()
        Catch ex As Exception
            MessageBox.Show("Services Data Not Updated" & ex.Message)
            welcomemsg.ForeColor = System.Drawing.Color.Red
            Me.Dispose()
        End Try
    End Sub
    'Delete function
    Private Sub ser_DeleteSelecedRows()
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
            For i = Me.sergetdata.SelectedRows.Count - 1 To 0 Step -1
                ObjCommand.CommandText = "delete from tbl_services where Sentry_no='" & sergetdata.SelectedRows(i).Cells("Sentry_no").Value & "'"
                ObjConnection.Open()
                ObjCommand.ExecuteNonQuery()
                ObjConnection.Close()
                Me.sergetdata.Rows.Remove(Me.sergetdata.SelectedRows(i))
            Next
        Catch ex As Exception
            MessageBox.Show("Failed:Deleting Selected Values" & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    'auto increment the entry id
    Private Sub ser_txtboxid()
        Try
            dbaccessconnection()
            con.Open()
            Dim num As New Integer
            cmd.CommandText = "SELECT MAX(Sentry_no) FROM tbl_services "
            If (IsDBNull(cmd.ExecuteScalar)) Then
                num = 1
                eservice_txt.Text = num.ToString
            Else

                num = cmd.ExecuteScalar + 1
                eservice_txt.Text = num.ToString
            End If
            con.Close()
        Catch ex As Exception
            MsgBox("Failed:Autoincrement of Services Entry" & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    'auto increment alphanumeric id
    Private Sub ser_autogenerated()
        Try
            Dim curValue As Integer
            Dim result As String
            Using con As SqlConnection = New SqlConnection(cs)
                con.Open()
                Dim cmd = New SqlCommand("select Max(Rate_ID) from tbl_services", con)
                result = cmd.ExecuteScalar().ToString()
                If String.IsNullOrEmpty(result) Then
                    result = "RID-0000"
                End If

                result = result.Substring(3)
                Int32.TryParse(result, curValue)
                curValue = curValue + 1
                result = "RID" + curValue.ToString("D4")
                rateid_txt.Text = result
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed:AutoIncrement of ServicesID" & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    'services get data
    Private Sub ser_getdata()
        Try
            Dim con As New SqlConnection(cs)
            con.Open()
            Dim da As New SqlDataAdapter("Select * from tbl_services ", con)
            Dim dt As New DataTable
            da.Fill(dt)
            source2.DataSource = dt
            sergetdata.DataSource = dt
            sergetdata.Refresh()
        Catch ex As Exception
            MessageBox.Show("Failed:Retrieving Services Data" & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    'Empty the textboxes
    Private Sub s_clear()
        Try
            rateid_txt.Text = ""
            servicename_txt.Text = ""
            gnder_txt.Text = ""
            serprice_txt.Text = ""

        Catch ex As Exception
            MsgBox("Failed:Clear " & ex.Message)
            Me.Dispose()
        End Try
    End Sub

    'service save button
    Private Sub ser_svbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ser_svbtn.Click
        Try
            MessageBox.Show("Are you sure to add data", "Data Adding", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            'TextBox1.Text = pid_txt.Text
            ' FillCombo()
            s_insert()
            ser_getdata()
            Label21.Text = "'" & rateid_txt.Text & "' details saved successfully!"
            Label21.ForeColor = System.Drawing.Color.DarkGreen

        Catch ex As Exception
            Label21.Text = "Error while saving '" & rateid_txt.Text & "' services details"
            Label21.ForeColor = System.Drawing.Color.Red
            MsgBox("DataBase not connected due to the reason because " & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    ' service delete buttton
    Private Sub ser_delbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ser_delbtn.Click
        TabControl1.SelectedTab = TabPage4
    End Sub

    'service grid delete button
    Private Sub select_delet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles select_delet.Click
        ser_DeleteSelecedRows()
    End Sub
    'service addbutton
    Private Sub ser_addbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ser_addbtn.Click
        s_clear()
        ser_txtboxid()
        ser_autogenerated()
        ser_svbtn.Enabled = True
        ser_editbtn.Enabled = False
    End Sub
    'service edit button 
    Private Sub ser_editbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ser_editbtn.Click
        ser_edit()
        getdata()
        ser_getdata()
        ser_editbtn.Enabled = False
    End Sub
    'button of 'see menu' of services
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        menu_picturebox.Visible = True
    End Sub
    'click on content
    Private Sub sergetdata_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles sergetdata.CellContentClick
        TabControl1.SelectedTab = TabPage3
        ser_svbtn.Enabled = False
        ser_delbtn.Enabled = True
        ser_editbtn.Enabled = True
    End Sub

    'service grid mouse click
    Private Sub sergetdata_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles sergetdata.CellMouseClick
        Try

            Me.eservice_txt.Text = sergetdata.CurrentRow.Cells(0).Value.ToString
            Me.rateid_txt.Text = sergetdata.CurrentRow.Cells(1).Value.ToString
            Me.servicename_txt.Text = sergetdata.CurrentRow.Cells(2).Value.ToString
            Me.gnder_txt.Text = sergetdata.CurrentRow.Cells(3).Value.ToString
            Me.serprice_txt.Text = sergetdata.CurrentRow.Cells(4).Value.ToString
            Me.s_dte_txt.Value = sergetdata.CurrentRow.Cells(5).Value.ToString
            Me.sevicedes_txt.Text = sergetdata.CurrentRow.Cells(6).Value.ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'the price textbox only accept numbers
    Private Sub price_txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles price_txt.KeyPress
        'If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
        'e.Handled = True
        ' End If
    End Sub
    'the servceprice textbox only accept numbers
    Private Sub serprice_txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles serprice_txt.KeyPress
        ' If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
        'e.Handled = True
        ' End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged

        con.Close()
        Try
            ' Dim cn As New SqlConnection
            Dim ds As New DataSet
            Dim dt As New DataTable
            Dim dfrom As DateTime = DateTimePicker1.Value
            Dim dto As DateTime = DateTimePicker2.Value
            myConnection.ConnectionString = cs
            myConnection.Open()
            Dim str As String = "Select * from tbl_products where p_dte >= '" & Format(dfrom, "MM-dd-yyyy") & "' and p_dte <='" & Format(dto, "MM-dd-yyyy") & "'"
            Dim da As SqlDataAdapter = New SqlDataAdapter(str, myConnection)
            da.Fill(dt)
            get_productdata.DataSource = dt
            myConnection.Close()
            get_productdata.Refresh()
            RadioButton1.Checked = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Failed:Date Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Dispose()
        End Try

    End Sub
    Private Sub search_txt()
        Dim str As String
        Try
            con.Open()
            str = "Select * from tbl_products where p_name like '" & TextBox3.Text & "%'"
            cmd = New SqlCommand(str, con)
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "tbl_products")
            con.Close()
            get_productdata.DataSource = ds
            get_productdata.DataMember = "tbl_products"
            get_productdata.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Failed:Product Name Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Dispose()
        End Try
    End Sub
    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        search_txt()
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        con.Close()
        Try
            ' Dim cn As New SqlConnection
            Dim ds As New DataSet
            Dim dt As New DataTable
            Dim dfrom As DateTime = DateTimePicker4.Value
            Dim dto As DateTime = DateTimePicker3.Value
            myConnection.ConnectionString = cs
            myConnection.Open()
            Dim str As String = "Select * from tbl_services where Service_Date >= '" & Format(dfrom, "MM-dd-yyyy") & "' and Service_Date <='" & Format(dto, "MM-dd-yyyy") & "'"
            Dim da As SqlDataAdapter = New SqlDataAdapter(str, myConnection)
            da.Fill(dt)
            sergetdata.DataSource = dt
            myConnection.Close()
            sergetdata.Refresh()
            RadioButton2.Checked = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Failed:Date Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Dispose()
        End Try

    End Sub
    Private Sub services_search_txt()
        Dim str As String
        Try
            con.Open()
            str = "Select * from tbl_services where Service_Name like '" & TextBox2.Text & "%'"
            cmd = New SqlCommand(str, con)
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "tbl_services")
            con.Close()
            sergetdata.DataSource = ds
            sergetdata.DataMember = "tbl_services"
            sergetdata.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Failed:Product Name Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Dispose()
        End Try
    End Sub
    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        services_search_txt()
    End Sub

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click

    End Sub

    Private Sub Label10_MarginChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label10.MarginChanged

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

    Private Sub Label20_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label20.MouseHover
        If btnupdte.Enabled = False Then
            ToolTip1.IsBalloon = True
            ToolTip1.UseAnimation = True
            ToolTip1.ToolTipTitle = ""
            ToolTip1.SetToolTip(Label20, "Select the field from Grid to Edit")
        Else
            ToolTip1.IsBalloon = True
            ToolTip1.UseAnimation = True
            ToolTip1.ToolTipTitle = ""
            ToolTip1.SetToolTip(Label20, "Click to Edit")
        End If
    End Sub

    Private Sub Button6_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(Button6, "Select the one field or more from Grid to Remove")
    End Sub

    Private Sub select_delet_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles select_delet.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(select_delet, "Select the one field or more from Grid to Remove")
    End Sub

   
    Private Sub price_txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles price_txt.TextChanged

    End Sub

    Private Sub TabPage4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage4.Click

    End Sub

    Private Sub Label20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label20.Click

    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub




    Private Sub name_txt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles name_txt.SelectedIndexChanged

    End Sub

    Private Sub serprice_txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles serprice_txt.TextChanged

    End Sub

    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub TabPage3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage3.Click

    End Sub
End Class
