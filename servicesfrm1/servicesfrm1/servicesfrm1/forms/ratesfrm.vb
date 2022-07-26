Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Odbc
Imports System.Data.DataTable
Imports System.Data.SqlClient
Imports System.Configuration
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Linq
Imports Microsoft.Office.Interop
Public Class ratesfrm


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
    Dim str As String
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
    ' Transaction insert function
    Private Sub p_insert()
        Try
            dbaccessconnection()
            con.Open()
            cmd.CommandText = "insert into tbl_productsales(Transaction_ID,Member_Name,Memebr_ID,Product_Details,Product_Total_Items,ProPrice_without_Discount,ProPrice_with_Discount,Product_Remarks,Service_Details,SerPrice_without_Discount,SerPrice_with_Discount,Service_Remarks,Transaction_Date)values('" & transactionid_txt.Text & "','" & mname_txt.Text & "','" & mbid_txt.Text & "','" & RichTextBox1.Text & "','" & Label5.Text & "','" & uinttotalprice_txt.Text & "','" & pro_single_totalbill.Text & "','" & RichTextBox4.Text & "','" & RichTextBox2.Text & "','" & servictotal_txt.Text & "','" & sertotal_bill.Text & "','" & RichTextBox5.Text & "','" & transactiondte_txt.Value & "')"
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            MsgBox("Data Inserted Failed because " & ex.Message)
            Me.Dispose()
        End Try
    End Sub
    Private Sub ratesfrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Membr_FillCombo()
        product_FillCombo()
        pay_txtboxid()
        payment_getdata()


        pro2_getdata()
        ser2_getdata()
        transaction_servicesgetdata()
        transaction_productgetdata()
        service_FillCombo()
        p_editbtn.Enabled = False
        Call CenterToScreen()
        ' Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        ' Me.WindowState = FormWindowState.Maximized
    End Sub

   
   
    Private Sub pay_txtboxid()
        Try
            dbaccessconnection()
            con.Open()
            Dim num As New Integer
            cmd.CommandText = "SELECT MAX(Transaction_ID) FROM tbl_productsales "
            If (IsDBNull(cmd.ExecuteScalar)) Then
                num = 1
                transactionid_txt.Text = num.ToString
            Else

                num = cmd.ExecuteScalar + 1
                transactionid_txt.Text = num.ToString
            End If
            con.Close()
        Catch ex As Exception
            MsgBox("Error in Entrynumber" & ex.Message)
            Me.Dispose()
        End Try
    End Sub
   
    Private Sub payment_getdata()

        Dim con As New SqlConnection(cs)
        con.Open()
        Dim da As New SqlDataAdapter("Select Transaction_ID,Member_Name,Memebr_ID,Product_Details,Product_Total_Items,ProPrice_without_Discount,ProPrice_with_Discount,Product_Remarks,Service_Details,SerPrice_without_Discount,SerPrice_with_Discount,Service_Remarks,Transaction_Date from tbl_productsales", con)
        Dim dt As New DataTable
        da.Fill(dt)
        source1.DataSource = dt
        payment_grid.DataSource = dt
        payment_grid.Refresh()
    End Sub
    Private Sub pro2_getdata()

        Dim con As New SqlConnection(cs)
        con.Open()
        Dim da As New SqlDataAdapter("Select I_Id,Pro_id,Product_name,Totalquantity from tbl_inventrry ", con)
        Dim dt As New DataTable
        da.Fill(dt)
        source1.DataSource = dt
        pro2_gird.DataSource = dt
        pro2_gird.Refresh()
    End Sub
    Private Sub ser2_getdata()

        Dim con As New SqlConnection(cs)
        con.Open()
        Dim da As New SqlDataAdapter("Select Rate_ID,Service_Name,Service_Price from tbl_services ", con)
        Dim dt As New DataTable
        da.Fill(dt)
        source1.DataSource = dt
        ser2_grid.DataSource = dt
        ser2_grid.Refresh()
    End Sub
    
    'to empty textboxes
    Private Sub p_clear()
        Try


            'mname_txt.Text = ""
            ' mbid_txt.Text = ""
            pid_txt.Text = ""
            pprice_txt.Text = "0"
            transactionid_txt.Text = ""
            mname_txt.Text = ""
            mbid_txt.Text = ""
            RichTextBox1.Text = ""
            Label5.Text = ""

            uinttotalprice_txt.Text = "0"
            pro_single_totalbill.Text = "0"
            RichTextBox4.Text = ""
            RichTextBox2.Text = ""
            servictotal_txt.Text = ""
            sertotal_bill.Text = ""
            RichTextBox5.Text = ""
            single_dis_txt.Text = "0"
            Label5.Text = "0"
            Label24.Text = "0"
            pquantity_txt.Text = ""
            pr_single_dis.Text = "0"
            unitprce_txt.Text = ""
            pname_txt.Text = ""
            s_rateid_txt.Text = ""
            sname_txt.Text = ""
            sprice_txt.Text = "0"
            ser_dis_txt.Text = "0"
            emname_txt.Text = ""
            ser_peritm_txt.Text = "0"
            servictotal_txt.Text = "0"
            sertotal_bill.Text = "0"
            totalofser_pro_outdis.Text = ""
            total_ser_pro_withdis.Text = ""

           


        Catch ex As Exception
            MsgBox("Error:Some thing is going wrong,Close application and try again")
        End Try
    End Sub
   
  
  


   
  

    
    Private Sub TabPage3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage3.Click
        pay_txtboxid()

    End Sub

   

    Private Sub pquantity_txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles pquantity_txt.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub pquantity_txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pquantity_txt.TextChanged

    End Sub

   
    Private Sub Membr_FillCombo()
        Try
            'Dim myConnToAccess As OleDbConnection
            Dim myConnToAccess As SqlConnection
            Dim ds As DataSet
            ' Dim da As OleDbDataAdapter
            Dim da As SqlDataAdapter
            Dim tables As DataTableCollection
            ' myConnToAccess = New OleDbConnection("provider=Microsoft.ACE.Oledb.12.0;Data Source=airline.accdb")
            myConnToAccess = New SqlConnection(cs)
            myConnToAccess.Open()
            ds = New DataSet
            tables = ds.Tables
            da = New SqlDataAdapter("SELECT m_name from tbl_memberreg", myConnToAccess)
            da.Fill(ds, "tbl_memberreg")
            Dim view1 As New DataView(tables(0))
            With mname_txt
                .DataSource = ds.Tables("tbl_memberreg")
                .DisplayMember = "m_name"
                .ValueMember = "m_name"
                .SelectedIndex = -1
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems
            End With
        Catch ex As Exception
            MessageBox.Show("Error in Entrynumber" & ex.Message)
        End Try
    End Sub
   
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
            da = New SqlDataAdapter("SELECT Product_name from tbl_inventrry", myConnToAccess)
            da.Fill(ds, "tbl_inventrry")
            Dim view1 As New DataView(tables(0))
            With pname_txt
                .DataSource = ds.Tables("tbl_inventrry")
                .DisplayMember = "Product_name"
                .ValueMember = "Product_name"
                .SelectedIndex = -1
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems

            End With
        Catch ex As Exception
            MessageBox.Show("Error in Entrynumber" & ex.Message)
        End Try
    End Sub

    Private Sub pname_txt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pname_txt.SelectedIndexChanged
        Dim str As String = cs
        Dim con As SqlConnection = New SqlConnection(str)
        Dim query As String = "select * from tbl_inventrry where Product_name = '" & pname_txt.Text & "' "
        Dim cmd As SqlCommand = New SqlCommand(query, con)
        Dim dbr As SqlDataReader
        Try

            con.Open()
            dbr = cmd.ExecuteReader()
            If dbr.Read() Then

                pid_txt.Text = dbr.GetValue(2)
                Label24.Text = dbr.GetValue(5)
                'unitprce_txt.Text = dbr.GetValue(8)

            End If
        Catch ex As Exception
            MessageBox.Show("Error in Entrynumber" & ex.Message)
        End Try
    End Sub
    Private Sub service_FillCombo()
        Try
            'Dim myConnToAccess As OleDbConnection
            Dim myConnToAccess As SqlConnection
            Dim ds As DataSet
            ' Dim da As OleDbDataAdapter
            Dim da As SqlDataAdapter
            Dim tables As DataTableCollection
            ' myConnToAccess = New OleDbConnection("provider=Microsoft.ACE.Oledb.12.0;Data Source=airline.accdb")
            myConnToAccess = New SqlConnection(cs)
            myConnToAccess.Open()
            ds = New DataSet
            tables = ds.Tables
            da = New SqlDataAdapter("SELECT Rate_ID from tbl_services", myConnToAccess)
            da.Fill(ds, "tbl_services")
            Dim view1 As New DataView(tables(0))
            With s_rateid_txt
                .DataSource = ds.Tables("tbl_services")
                .DisplayMember = "Rate_ID"
                .ValueMember = "Rate_ID"
                .SelectedIndex = -1
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.ListItems
            End With
        Catch ex As Exception
            MessageBox.Show("At least one entry", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub subtruct_stock()
        Dim subb As Int64
        subb = Convert.ToInt64(Label24.Text) - Convert.ToInt64(pquantity_txt.Text)
        Label24.Text = Convert.ToString(subb)
    End Sub
 
    Private Sub quantitystockout_in()
        Try
            dbaccessconnection()
            con.Open()
            cmd.CommandText = ("UPDATE tbl_inventrry SET Sale_Quantity= '" & pquantity_txt.Text & "',Totalquantity= '" & Label24.Text & "',Stock_outdate= '" & transactiondte_txt.Value & "' where Pro_id='" & pid_txt.Text & "'")
            cmd.ExecuteNonQuery()
            'message_txt.Text = " details updated successfully!"
                con.Close()


        Catch ex As Exception
            MessageBox.Show("Data Not Updated" & ex.Message)
        End Try
    End Sub
    'discount function
  
    Private Sub p_pricetotal()

        Dim mul As Double
        Dim addd As Double
        mul = Double.Parse(pquantity_txt.Text) * Double.Parse(unitprce_txt.Text)
        pprice_txt.Text = Double.Parse(mul)
        addd = Double.Parse(pprice_txt.Text) + Double.Parse(uinttotalprice_txt.Text)
        uinttotalprice_txt.Text = Convert.ToString(addd)

    End Sub

   
  
   
   
    Private Sub p_nameadd()
        RichTextBox1.Text &= "Name" & ":" & pname_txt.Text & "," & "Price" & ":" + unitprce_txt.Text & "," & "Discount" & ":" + pr_single_dis.Text & "," & "Bill" & ":" + single_dis_txt.Text & vbNewLine
    End Sub
    'single item total
    Private Sub prosingle_pricetotal()
        Dim addd As Double
        addd = Double.Parse(single_dis_txt.Text) + Double.Parse(pro_single_totalbill.Text)
        pro_single_totalbill.Text = (addd)
    End Sub
    Private Sub pro_quantitytotal()
        Dim addd As Double
        addd = Double.Parse(pquantity_txt.Text) + Double.Parse(Label5.Text)
        Label5.Text = (addd)
    End Sub
   
    Private Sub prosingle_discount()
        Dim PercentageNumberResult As Double
        PercentageNumberResult = pprice_txt.Text / 100 * pr_single_dis.Text
        TextBox5.Text = PercentageNumberResult
        Dim subtractdiscount As Double
        subtractdiscount = pprice_txt.Text - TextBox5.Text
        single_dis_txt.Text = subtractdiscount
    End Sub
    Private Sub pro_services_distotal()
        Dim addd As Double
        addd = Double.Parse(pro_single_totalbill.Text) + Double.Parse(sertotal_bill.Text)
        total_ser_pro_withdis.Text = (addd)
    End Sub
    Private Sub s_pricewith_nodiscounttotal()


        Dim addd As Double
        addd = Double.Parse(uinttotalprice_txt.Text) + Double.Parse(servictotal_txt.Text)
        totalofser_pro_outdis.Text = Convert.ToString(addd)
    End Sub
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try         
            If Label24.Text <= 0 Then
                Button1.Enabled = False
                Label14.Text = "NO Stock avaliable"
            Else
                If pquantity_txt.Text = "" Then
                    MsgBox("Enter quantity ")
                   

                Else
                    If pr_single_dis.Text = "" Then
                        pr_single_dis.Text = "0"
                    End If
                    If unitprce_txt.Text = "" Then
                        unitprce_txt.Text = "0"
                    End If
                    subtruct_stock()
                    p_pricetotal()
                    prosingle_discount()
                    prosingle_pricetotal()
                    ' quantitystockout_in()
                    p_nameadd()
                    pro_quantitytotal()
                    pro2_getdata()
                    ser2_getdata()

                End If
            End If
        Catch ex As Exception
            ' Label25.Text = "Error while saving '" & type_txt.Text & "' rates details"
            'Label25.ForeColor = System.Drawing.Color.Red
            MsgBox("Error " & ex.Message)
            'MessageBox.Show("Data already exist, you again select Ticket Details and Try other entry", "Data Invalid, Application is closing", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Dispose()
        End Try

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If TextBox2.Text = "" Then
            MsgBox("please provide name")
        Else
            Try
                con.Open()
                str = "select * from tbl_inventrry where Product_name ='" & TextBox2.Text & "'"
                cmd = New SqlCommand(str, con)
                da = New SqlDataAdapter(cmd)
                ds = New DataSet
                da.Fill(ds, "tbl_inventrry")
                con.Close()
                pro2_gird.DataSource = ds
                pro2_gird.DataMember = "tbl_inventrry"
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        TextBox2.Clear()
        TextBox2.Visible = True
    End Sub

    Private Sub pro2_gird_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles pro2_gird.CellContentClick
        Try

            ' Me.pid_txt.Text = pro2_gird.CurrentRow.Cells(1).Value.ToString
            Me.pname_txt.Text = pro2_gird.CurrentRow.Cells(2).Value.ToString
            'Me.Label24.Text = pro2_gird.CurrentRow.Cells(3).Value.ToString
            'Me.unitprce_txt.Text = pro2_gird.CurrentRow.Cells(4).Value.ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Dispose()
    End Sub
    'services sale

    Private Sub services_single_discount()
        Dim PercentageNumberResult As Double
        PercentageNumberResult = sprice_txt.Text / 100 * ser_dis_txt.Text
        TextBox5.Text = PercentageNumberResult
        Dim subtractdiscount As Double
        subtractdiscount = sprice_txt.Text - TextBox5.Text
        ser_peritm_txt.Text = subtractdiscount
    End Sub
    Private Sub s_pricetotal()
        Dim addd As Double
        addd = Double.Parse(sprice_txt.Text) + Double.Parse(servictotal_txt.Text)
        servictotal_txt.Text = Convert.ToString(addd)
    End Sub
    Private Sub s_pricewithdiscounttotal()
       

        Dim addd As Double
        addd = Double.Parse(ser_peritm_txt.Text) + Double.Parse(sertotal_bill.Text)
        sertotal_bill.Text = Convert.ToString(addd)
    End Sub
   
    Private Sub s_nameadd()
        RichTextBox2.Text &= "Name" & ":" & sname_txt.Text & "," & "Price" & ":" + sprice_txt.Text & "," & "Discount" & ":" + ser_dis_txt.Text & "," & "Bill" & ":" + sertotal_bill.Text & "Employee" & ":" + emname_txt.Text & vbNewLine

    End Sub
  

  

 
    Private Sub mbid_txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mbid_txt.TextChanged

    End Sub

   
    Private Sub mname_txt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mname_txt.SelectedIndexChanged
        Dim str As String = cs
        Dim con As SqlConnection = New SqlConnection(str)
        Dim query As String = "select * from tbl_memberreg where m_name = '" & mname_txt.Text & "' "
        Dim cmd As SqlCommand = New SqlCommand(query, con)
        Dim dbr As SqlDataReader
        Try

            con.Open()
            dbr = cmd.ExecuteReader()
            If dbr.Read() Then

                mbid_txt.Text = dbr.GetValue(1)
            End If
        Catch ex As Exception
            MessageBox.Show("At least one entry", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub Label24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label24.Click

    End Sub

    Private Sub Label24_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label24.TextChanged
        If Label24.Text < 0 Then
            MessageBox.Show("Out of stock", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        pro_services_distotal()
        s_pricewith_nodiscounttotal()
    End Sub

    
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try          
            If ser_dis_txt.Text = "" Then
                ser_dis_txt.Text = "0"
            End If
            s_pricetotal()
            s_nameadd()
            ' s_pricetotal()
            services_single_discount()
            s_pricewithdiscounttotal()

        Catch ex As Exception
            MsgBox("Error " & ex.Message)

            Me.Dispose()
        End Try
    End Sub

   
    Private Sub ser2_grid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ser2_grid.CellContentClick
        Try

            Me.s_rateid_txt.Text = ser2_grid.CurrentRow.Cells(0).Value.ToString
            Me.sname_txt.Text = ser2_grid.CurrentRow.Cells(1).Value.ToString
            Me.sprice_txt.Text = ser2_grid.CurrentRow.Cells(2).Value.ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

  
  
    Private Sub services_sale()
        If TextBox2.Text = "" And TextBox2.Text.Length = 0 Then
            pro2_gird.Visible = False
        Else
            Try
                con.Open()
                str = "select * from tbl_inventrry where Product_name like '" & TextBox2.Text & "%'"
                cmd = New SqlCommand(str, con)
                da = New SqlDataAdapter(cmd)
                ds = New DataSet
                da.Fill(ds, "tbl_inventrry")
                con.Close()
                pro2_gird.DataSource = ds
                pro2_gird.DataMember = "tbl_inventrry"
                pro2_gird.Visible = True
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub s_rateid_txt_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s_rateid_txt.SelectedIndexChanged
        Dim str As String = cs
        Dim con As SqlConnection = New SqlConnection(str)
        Dim query As String = "select * from tbl_services where Rate_ID = '" & s_rateid_txt.Text & "' "
        Dim cmd As SqlCommand = New SqlCommand(query, con)
        Dim dbr As SqlDataReader
        Try

            con.Open()
            dbr = cmd.ExecuteReader()
            If dbr.Read() Then

                sname_txt.Text = dbr.GetValue(2)
                sprice_txt.Text = dbr.GetValue(4)
            End If
        Catch ex As Exception
            MessageBox.Show("At least one entry", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged


            Try
                con.Open()
            str = "select I_Id,Pro_id,Product_name,Totalquantity from tbl_inventrry where Product_name like '" & TextBox2.Text & "%'"
                cmd = New SqlCommand(str, con)
                da = New SqlDataAdapter(cmd)
                ds = New DataSet
                da.Fill(ds, "tbl_inventrry")
                con.Close()
                pro2_gird.DataSource = ds
                pro2_gird.DataMember = "tbl_inventrry"
                pro2_gird.Visible = True
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged
        'Rate_ID,Service_Name,Service_Price from tbl_services
        If TextBox6.Text = "" And TextBox2.Text.Length = 0 Then
            ser2_grid.Visible = False
        Else
            Try
                con.Open()
                str = "select Rate_ID,Service_Name,Service_Price from tbl_services where Service_Name like '" & TextBox6.Text & "%'"
                cmd = New SqlCommand(str, con)
                da = New SqlDataAdapter(cmd)
                ds = New DataSet
                da.Fill(ds, "tbl_inventrry")
                con.Close()
                ser2_grid.DataSource = ds
                ser2_grid.DataMember = "tbl_inventrry"
                ser2_grid.Visible = True
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub


    
    Private Sub p_savebtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p_savebtn.Click
        If Len(Trim(mname_txt.Text)) = 0 Then
            MessageBox.Show("Please select Member name ", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            mname_txt.Focus()
            Exit Sub
        End If


        Try
            MessageBox.Show("Are you sure to add data", "Data Adding", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            p_insert()
            quantitystockout_in()
            payment_getdata()
            message_txt.Text = "'" & pid_txt.Text & "' details saved successfully!"
            message_txt.ForeColor = System.Drawing.Color.DarkGreen
            payment_getdata()
            pro2_getdata()
            ser2_getdata()
            transaction_servicesgetdata()
            transaction_productgetdata()
            p_savebtn.Enabled = True
        Catch ex As Exception
            message_txt.Text = "Error while saving '" & pid_txt.Text & "' payment details"
            message_txt.ForeColor = System.Drawing.Color.Red
            MsgBox("DataBase not connected due to the reason because " & ex.Message)
            'MessageBox.Show("Data already exist, you again select Ticket Details and Try other entry", "Data Invalid, Application is closing", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Dispose()
        End Try
    End Sub
   
    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        ' TextBox1.Visible = True

       
        transactioncheck.Visible = False
        transactioncheck.Enabled = False
        payment_getProductdata()


    End Sub
    Private Sub payment_getProductdata()

        Dim con As New SqlConnection(cs)
        con.Open()
        Dim da As New SqlDataAdapter("Select Transaction_ID,Member_Name,Memebr_ID,Product_Details,Product_Total_Items,ProPrice_without_Discount,ProPrice_with_Discount,Product_Remarks,Transaction_Date from tbl_productsales", con)
        Dim dt As New DataTable
        da.Fill(dt)
        source1.DataSource = dt
        payment_grid.DataSource = dt
        payment_grid.Refresh()
    End Sub
    Private Sub payment_getServicedata()

        Dim con As New SqlConnection(cs)
        con.Open()
        Dim da As New SqlDataAdapter("Select Transaction_ID,Member_Name,Memebr_ID,Service_Details,SerPrice_without_Discount,SerPrice_with_Discount,Service_Remarks,Transaction_Date from tbl_productsales", con)
        Dim dt As New DataTable
        da.Fill(dt)
        source1.DataSource = dt
        payment_grid.DataSource = dt
        payment_grid.Refresh()
    End Sub
    ',Service_Details,SerPrice_without_Discount,SerPrice_with_Discount,Service_Remarks,Transaction_Date

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        con.Close()
        payment_getServicedata()

       
        transactioncheck.Visible = False
        transactioncheck.Enabled = False
       
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        ' con.Close()
       
            payment_getdata()
            transactioncheck.Visible = True
            transactioncheck.Enabled = True
          

       
    End Sub

   
    'payment gridfilter functions

    Private Sub payment_productsearchdate()
        con.Close()
        ' Dim cn As New SqlConnection
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim dfrom As DateTime = trandtefrom_txt.Value
        Dim dto As DateTime = trandteto_txt.Value
        myConnection.ConnectionString = cs
        myConnection.Open()
        Dim str As String = "Select * from tbl_productsales where Transaction_Date >= '" & Format(dfrom, "MM-dd-yyyy") & "' and Transaction_Date <='" & Format(dto, "MM-dd-yyyy") & "'"
        Dim da As SqlDataAdapter = New SqlDataAdapter(str, myConnection)
        da.Fill(dt)
        payment_grid.DataSource = dt
        myConnection.Close()
        payment_grid.Refresh()
    End Sub
    Private Sub payment_servicessearchdate()
        ' Dim cn As New SqlConnection
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim dfrom As DateTime = trandtefrom_txt.Value
        Dim dto As DateTime = trandteto_txt.Value
        myConnection.ConnectionString = cs
        myConnection.Open()
        Dim str As String = "Select Transaction_ID,Member_Name,Memebr_ID,Service_Details,SerPrice_without_Discount,SerPrice_with_Discount,Service_Remarks,Transaction_Date from tbl_productsales where Transaction_Date >= '" & Format(dfrom, "MM-dd-yyyy") & "' and Transaction_Date <='" & Format(dto, "MM-dd-yyyy") & "'"
        Dim da As SqlDataAdapter = New SqlDataAdapter(str, myConnection)
        da.Fill(dt)
        payment_grid.DataSource = dt
        myConnection.Close()
        payment_grid.Refresh()
    End Sub
    Private Sub payment_pro_servicessearchdate()
        ' Dim cn As New SqlConnection
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim dfrom As DateTime = trandtefrom_txt.Value
        Dim dto As DateTime = trandteto_txt.Value
        myConnection.ConnectionString = cs
        myConnection.Open()
        Dim str As String = "Select * from tbl_productsales where Transaction_Date >= '" & Format(dfrom, "MM-dd-yyyy") & "' and Transaction_Date <='" & Format(dto, "MM-dd-yyyy") & "'"
        Dim da As SqlDataAdapter = New SqlDataAdapter(str, myConnection)
        da.Fill(dt)
        payment_grid.DataSource = dt
        myConnection.Close()
        payment_grid.Refresh()
    End Sub
 
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        transactioncheck.Checked = False

        payment_productsearchdate()
    End Sub

 

    Private Sub servcheck_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      
        transactioncheck.Checked = False
        payment_servicessearchdate()
    End Sub

    Private Sub transactioncheck_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
       
        transactioncheck.Checked = True
        payment_pro_servicessearchdate()
    End Sub
   
   
  

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' If TextBox1.Text = "" And RadioButton4.Checked = True Then
        ' MsgBox("Please Enter in Search Box")
        ' RadioButton4.Checked = False
        payment_getdata()
        ' Else
        ' membrsearch_txt()
        ' End If

    End Sub
  

    Private Sub prodcutcheckbox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        con.Close()
        payment_productsearchdate()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        search_highlight()

    End Sub
    Private Sub search_highlight()
        Dim someText As String = TextBox1.Text
        Dim gridRow As Integer = 0
        Dim gridColumn As Integer = 0
        For Each Row As DataGridViewRow In payment_grid.Rows
            For Each column As DataGridViewColumn In payment_grid.Columns
                Dim cell As DataGridViewCell = (payment_grid.Rows(gridRow).Cells(gridColumn))
                If cell.Value.ToString.ToLower.Contains(someText.ToLower) Then
                    cell.Style.BackColor = Color.Yellow
                    cell.Style.ForeColor = Color.Red
                End If
                gridColumn += 1
            Next column
            gridColumn = 0
            gridRow += 1
        Next Row
    End Sub
    Private Sub transactioncheck_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles transactioncheck.CheckedChanged
        con.Close()
        payment_productsearchdate()
    End Sub

    Private Sub servcheck_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        con.Close()
        payment_servicessearchdate()
    End Sub

  

    Private Sub searchcombo_txt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage2.Click

    End Sub
    Private Sub edit()
        con.Close()
        Try

            dbaccessconnection()
            con.Open()

           
            cmd.CommandText = ("UPDATE tbl_productsales SET Transaction_ID= '" & transactionid_txt.Text & "', Member_Name= '" & mname_txt.Text & "',Memebr_ID= '" & mbid_txt.Text & "',Product_Details= '" & RichTextBox1.Text & "',Product_Total_Items= '" & Label5.Text & "',ProPrice_without_Discount= '" & uinttotalprice_txt.Text & "',ProPrice_with_Discount= '" & pro_single_totalbill.Text & "',Product_Remarks= '" & RichTextBox4.Text & "', Service_Details= '" & RichTextBox2.Text & "',SerPrice_without_Discount= '" & servictotal_txt.Text & "',SerPrice_with_Discount= '" & sertotal_bill.Text & "', Service_Remarks= '" & RichTextBox5.Text & "',Transaction_Date= '" & transactiondte_txt.Value & "' where Transaction_ID=" & transactionid_txt.Text & "")
            cmd.ExecuteNonQuery()
            'MessageBox.Show("Data Updated")
            message_txt.ForeColor = System.Drawing.Color.DarkGreen
            message_txt.Text = "'" & pid_txt.Text & "' details update successfully!"

            con.Close()


        Catch ex As Exception
            MessageBox.Show("Data Not Updated" & ex.Message)
        End Try
    End Sub
    Private Sub p_editbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p_editbtn.Click
        edit()
        transaction_servicesgetdata()
        transaction_productgetdata()
        payment_getdata()

        pro2_getdata()
        ser2_getdata()

        p_editbtn.Enabled = False
    End Sub

    Private Sub p_editbtn_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles p_editbtn.DragOver
        
    End Sub

    Private Sub p_editbtn_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles p_editbtn.MouseHover
      
    End Sub

    Private Sub payment_grid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles payment_grid.CellContentClick
        TabControl1.SelectedTab = TabPage3

        p_savebtn.Enabled = False
        p_editbtn.Enabled = True

    End Sub



    Private Sub payment_grid_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles payment_grid.CellMouseClick
        Try
            'insert into tbl_productsales(Transaction_ID,Member_Name,Memebr_ID,Product_Details,Product_Total_Items,ProPrice_without_Discount,ProPrice_with_Discount,Product_Remarks,Service_Details,SerPrice_without_Discount,SerPrice_with_Discount,Service_Remarks,Transaction_Date)
            'values('" & transactionid_txt.Text & "','" & mname_txt.Text & "','" & mbid_txt.Text & "','" & RichTextBox1.Text & "','" & Label5.Text & "','" & uinttotalprice_txt.Text & "','" & pro_single_totalbill.Text & "','" & RichTextBox4.Text & "','" & RichTextBox2.Text & "','" & servictotal_txt.Text & "','" & sertotal_bill.Text & "','" & RichTextBox5.Text & "','" & transactiondte_txt.Value & "')"
            Me.transactionid_txt.Text = payment_grid.CurrentRow.Cells(0).Value.ToString
            Me.mname_txt.Text = payment_grid.CurrentRow.Cells(1).Value.ToString
            Me.mbid_txt.Text = payment_grid.CurrentRow.Cells(2).Value.ToString
            Me.RichTextBox1.Text = payment_grid.CurrentRow.Cells(3).Value.ToString
            Me.Label5.Text = payment_grid.CurrentRow.Cells(4).Value.ToString
            Me.uinttotalprice_txt.Text = payment_grid.CurrentRow.Cells(5).Value.ToString
            Me.pro_single_totalbill.Text = payment_grid.CurrentRow.Cells(6).Value.ToString
            Me.RichTextBox4.Text = payment_grid.CurrentRow.Cells(7).Value.ToString
            Me.RichTextBox2.Text = payment_grid.CurrentRow.Cells(8).Value.ToString
            Me.servictotal_txt.Text = payment_grid.CurrentRow.Cells(9).Value.ToString
            Me.sertotal_bill.Text = payment_grid.CurrentRow.Cells(10).Value.ToString
            Me.RichTextBox5.Text = payment_grid.CurrentRow.Cells(11).Value.ToString

            Me.transactiondte_txt.Value = payment_grid.CurrentRow.Cells(12).Value.ToString


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DeleteSelecedRows()
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
        For i = Me.payment_grid.SelectedRows.Count - 1 To 0 Step -1
            ObjCommand.CommandText = "delete from tbl_productsales where Transaction_ID='" & payment_grid.SelectedRows(i).Cells("Transaction_ID").Value & "'"
            ObjConnection.Open()
            ObjCommand.ExecuteNonQuery()
            ObjConnection.Close()
            Me.payment_grid.Rows.Remove(Me.payment_grid.SelectedRows(i))
        Next

    End Sub
    Private Sub p_delbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p_delbtn.Click
        TabControl1.SelectedTab = TabPage3
    End Sub

    Private Sub p_removebtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p_removebtn.Click
        DeleteSelecedRows()
    End Sub
    Private Sub Label15_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs)
   
    End Sub

    Private Sub Panel1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub pid_txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pid_txt.TextChanged
        Dim strsql As String = "select p_price from tbl_products where p_name like('" + pname_txt.Text + "%')"
        Dim strcon As String = cs
        Dim odapre As New SqlDataAdapter(strsql, strcon)
        Dim datTable As New DataTable
        Dim incount As Integer
        odapre.Fill(datTable)
        For incount = 0 To datTable.Rows.Count - 1
            unitprce_txt.Text = datTable.Rows(incount)("p_price").ToString
            ' DateofBirthDateTimePicker.Text = datTable.Rows(incount)("DateofBirth").ToString
            ' EmailaddressTextBox.Text = datTable.Rows(incount)("Emailaddress").ToString
            ' PicturesPictureBox1. = datTable.Rows(incount)("Pictures")
        Next
      
    End Sub

    Private Sub sname_txt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sname_txt.SelectedIndexChanged
        Try
            Dim strsql As String = "select Serve_Emplyee from tbl_reservation where Memebr_name like('" + mname_txt.Text + "%')"
            Dim strcon As String = cs
            Dim odapre As New SqlDataAdapter(strsql, strcon)
            Dim datTable As New DataTable
            Dim incount As Integer
            odapre.Fill(datTable)
            For incount = 0 To datTable.Rows.Count - 1
                emname_txt.Text = datTable.Rows(incount)("Serve_Emplyee").ToString

            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Failed:EmployeeName Populating", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Dispose()
        End Try
    End Sub
    'services transaction getdata
    Private Sub transaction_servicesgetdata()
        
        Dim con As New SqlConnection(cs)
        con.Open()
        Dim da As New SqlDataAdapter("Select Transaction_ID,Member_Name,Memebr_ID,Service_Details,SerPrice_without_Discount,SerPrice_with_Discount,Service_Remarks,Transaction_Date from tbl_productsales", con)
        Dim dt As New DataTable
        da.Fill(dt)
        source1.DataSource = dt
        serv_getdata.DataSource = dt
        serv_getdata.Refresh()
    End Sub

    'product transaction getdata
    Private Sub transaction_productgetdata()

        Dim con As New SqlConnection(cs)
        con.Open()
        Dim da As New SqlDataAdapter("Select Transaction_ID,Member_Name,Memebr_ID,Product_Details,Product_Total_Items,ProPrice_without_Discount,ProPrice_with_Discount,Product_Remarks,Transaction_Date from tbl_productsales", con)
        Dim dt As New DataTable
        da.Fill(dt)
        source1.DataSource = dt
        prodcut_getdata.DataSource = dt
        prodcut_getdata.Refresh()
    End Sub

    'searchproduct by date
    Private Sub product_searchdate()
        con.Close()
        Try
            ' Dim cn As New SqlConnection
            Dim ds As New DataSet
            Dim dt As New DataTable
            Dim dfrom As DateTime = DateTimePicker1.Value
            Dim dto As DateTime = DateTimePicker2.Value
            myConnection.ConnectionString = cs
            myConnection.Open()
            Dim str As String = "Select Transaction_ID,Member_Name,Memebr_ID,Product_Details,Product_Total_Items,ProPrice_without_Discount,ProPrice_with_Discount,Product_Remarks,Transaction_Date from tbl_productsales where Transaction_Date >= '" & Format(dfrom, "MM-dd-yyyy") & "' and Transaction_Date <='" & Format(dto, "MM-dd-yyyy") & "'"
            Dim da As SqlDataAdapter = New SqlDataAdapter(str, myConnection)
            da.Fill(dt)
            prodcut_getdata.DataSource = dt
            myConnection.Close()
            prodcut_getdata.Refresh()
          
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Failed:Date Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Dispose()
        End Try
    End Sub
    Private myDS As New mainclinicdbDataSet() ' Dataset you created.
    Private Sub wordconvert()
        Dim rpt As New ProductSaleReport() 'The report you created.
        Dim myConnection As SqlConnection
        Dim MyCommand As New SqlCommand()
        Dim myDA As New SqlDataAdapter()
        Try
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand.CommandText = "SELECT Transaction_ID,Member_Name,Memebr_ID,Product_Details,Product_Total_Items,ProPrice_without_Discount,ProPrice_with_Discount,Product_Remarks,Transaction_Date from tbl_productsales "
            MyCommand.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand

            myDA.Fill(myDS, "tbl_productsales")
            rpt.SetDataSource(myDS)
            ProductSaleReportFrm.ProductSaleViewer1.ReportSource = rpt

        Catch Excep As Exception
            MessageBox.Show(Excep.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub RadioButton4_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        product_searchdate()
        RadioButton4.Checked = False


    End Sub
    'searchservices by date
    Private Sub services_searchdate()
        con.Close()
        Try
            ' Dim cn As New SqlConnection
            Dim ds As New DataSet
            Dim dt As New DataTable
            Dim dfrom As DateTime = DateTimePicker4.Value
            Dim dto As DateTime = DateTimePicker3.Value
            myConnection.ConnectionString = cs
            myConnection.Open()
            Dim str As String = "Select  Transaction_ID,Member_Name,Memebr_ID,Service_Details,SerPrice_without_Discount,SerPrice_with_Discount,Service_Remarks,Transaction_Date from tbl_productsales where Transaction_Date >= '" & Format(dfrom, "MM-dd-yyyy") & "' and Transaction_Date <='" & Format(dto, "MM-dd-yyyy") & "'"
            Dim da As SqlDataAdapter = New SqlDataAdapter(str, myConnection)
            da.Fill(dt)
            serv_getdata.DataSource = dt
            myConnection.Close()
            serv_getdata.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Failed:Date Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Dispose()
        End Try
    End Sub
    'search member name in productgrid
    Private Sub product_search_txtbox()
        Dim str As String
        Try
            con.Open()
            str = "Select Transaction_ID,Member_Name,Memebr_ID,Product_Details,Product_Total_Items,ProPrice_without_Discount,ProPrice_with_Discount,Product_Remarks,Transaction_Date from tbl_productsales  where Member_Name like '" & TextBox3.Text & "%'"
            cmd = New SqlCommand(str, con)
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "tbl_productsales")
            con.Close()
            prodcut_getdata.DataSource = ds
            prodcut_getdata.DataMember = "tbl_productsales"
            prodcut_getdata.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Failed:Member Name Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Dispose()
        End Try
    End Sub
    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton5.CheckedChanged
        services_searchdate()
        RadioButton5.Checked = False
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
       
        product_search_txtbox()
    End Sub
    'search member name in servicesgrid
    Private Sub services_search_txtbox()
        Dim str As String
        Try
            con.Open()
            str = "Select  Transaction_ID,Member_Name,Memebr_ID,Service_Details,SerPrice_without_Discount,SerPrice_with_Discount,Service_Remarks,Transaction_Date from tbl_productsales  where Member_Name like '" & TextBox4.Text & "%'"
            cmd = New SqlCommand(str, con)
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "tbl_productsales")
            con.Close()
            serv_getdata.DataSource = ds
            serv_getdata.DataMember = "tbl_productsales"
            serv_getdata.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Failed:Member Name Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Dispose()
        End Try
    End Sub
    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        services_search_txtbox()
    End Sub

    Private Sub pr_single_dis_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles pr_single_dis.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub ser_dis_txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ser_dis_txt.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub ser_dis_txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ser_dis_txt.TextChanged

    End Sub

    Private Sub p_removebtn_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles p_removebtn.DragDrop

    End Sub

    Private Sub p_removebtn_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles p_removebtn.MouseHover
        ToolTip1.IsBalloon = True
        ToolTip1.UseAnimation = True
        ToolTip1.ToolTipTitle = ""
        ToolTip1.SetToolTip(p_removebtn, "Select the one field or more from Grid to Remove")
    End Sub

  

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If pr_single_dis.Text = " " Then
            pr_single_dis.Text = "0"
        End If
        TabControl1.SelectedTab = TabPage1

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

        Dim str As String
        Try
            con.Open()
            str = "Select * from tbl_productsales where Member_Name like '" & TextBox1.Text & "%'"
            cmd = New SqlCommand(str, con)
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "tbl_productsales")
            con.Close()
            payment_grid.DataSource = ds
            payment_grid.DataMember = "tbl_productsales"
            payment_grid.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Failed:Product Name Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Dispose()
        End Try
    End Sub

   

    Private Sub prodcut_getdata_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles prodcut_getdata.CellMouseClick
        Try
            'insert into tbl_productsales(Transaction_ID,Member_Name,Memebr_ID,Product_Details,Product_Total_Items,ProPrice_without_Discount,ProPrice_with_Discount,Product_Remarks,Service_Details,SerPrice_without_Discount,SerPrice_with_Discount,Service_Remarks,Transaction_Date)
            'values('" & transactionid_txt.Text & "','" & mname_txt.Text & "','" & mbid_txt.Text & "','" & RichTextBox1.Text & "','" & Label5.Text & "','" & uinttotalprice_txt.Text & "','" & pro_single_totalbill.Text & "','" & RichTextBox4.Text & "','" & RichTextBox2.Text & "','" & servictotal_txt.Text & "','" & sertotal_bill.Text & "','" & RichTextBox5.Text & "','" & transactiondte_txt.Value & "')"
            Me.transactionid_txt.Text = prodcut_getdata.CurrentRow.Cells(0).Value.ToString
            Me.mname_txt.Text = prodcut_getdata.CurrentRow.Cells(1).Value.ToString
            Me.mbid_txt.Text = prodcut_getdata.CurrentRow.Cells(2).Value.ToString
            Me.RichTextBox1.Text = prodcut_getdata.CurrentRow.Cells(3).Value.ToString
            Me.Label5.Text = prodcut_getdata.CurrentRow.Cells(4).Value.ToString
            Me.uinttotalprice_txt.Text = prodcut_getdata.CurrentRow.Cells(5).Value.ToString
            Me.pro_single_totalbill.Text = prodcut_getdata.CurrentRow.Cells(6).Value.ToString
            Me.RichTextBox4.Text = prodcut_getdata.CurrentRow.Cells(7).Value.ToString

            Me.transactiondte_txt.Value = prodcut_getdata.CurrentRow.Cells(8).Value.ToString


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try
    End Sub

    Private Sub prodcut_getdata_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles prodcut_getdata.CellContentClick
      
        TabControl1.SelectedTab = TabPage3

        p_savebtn.Enabled = False
        p_editbtn.Enabled = True
    End Sub

    Private Sub serv_getdata_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles serv_getdata.CellContentClick
        TabControl1.SelectedTab = TabPage1

        p_savebtn.Enabled = False
        p_editbtn.Enabled = True
    End Sub

 
    Private Sub serv_getdata_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles serv_getdata.CellMouseClick
        Try
            'insert into tbl_productsales(Transaction_ID,Member_Name,Memebr_ID,Product_Details,Product_Total_Items,ProPrice_without_Discount,ProPrice_with_Discount,Product_Remarks,Service_Details,SerPrice_without_Discount,SerPrice_with_Discount,Service_Remarks,Transaction_Date)
            'values('" & transactionid_txt.Text & "','" & mname_txt.Text & "','" & mbid_txt.Text & "','" & RichTextBox1.Text & "','" & Label5.Text & "','" & uinttotalprice_txt.Text & "','" & pro_single_totalbill.Text & "','" & RichTextBox4.Text & "','" & RichTextBox2.Text & "','" & servictotal_txt.Text & "','" & sertotal_bill.Text & "','" & RichTextBox5.Text & "','" & transactiondte_txt.Value & "')"
            Me.transactionid_txt.Text = serv_getdata.CurrentRow.Cells(0).Value.ToString
            Me.mname_txt.Text = serv_getdata.CurrentRow.Cells(1).Value.ToString
            Me.mbid_txt.Text = serv_getdata.CurrentRow.Cells(2).Value.ToString
           
            Me.RichTextBox2.Text = serv_getdata.CurrentRow.Cells(3).Value.ToString
            Me.servictotal_txt.Text = serv_getdata.CurrentRow.Cells(4).Value.ToString
            Me.sertotal_bill.Text = serv_getdata.CurrentRow.Cells(5).Value.ToString
            Me.RichTextBox5.Text = serv_getdata.CurrentRow.Cells(6).Value.ToString

            Me.transactiondte_txt.Value = serv_getdata.CurrentRow.Cells(7).Value.ToString


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub unitprce_txt_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles unitprce_txt.DoubleClick

      
        Dim strsql As String = "select p_price from tbl_products where p_name like('" + pname_txt.Text + "%')"
        Dim strcon As String = cs
        Dim odapre As New SqlDataAdapter(strsql, strcon)
        Dim datTable As New DataTable
        Dim incount As Integer
        odapre.Fill(datTable)
        For incount = 0 To datTable.Rows.Count - 1
            unitprce_txt.Text = datTable.Rows(incount)("p_price").ToString
            ' DateofBirthDateTimePicker.Text = datTable.Rows(incount)("DateofBirth").ToString
            ' EmailaddressTextBox.Text = datTable.Rows(incount)("Emailaddress").ToString
            ' PicturesPictureBox1. = datTable.Rows(incount)("Pictures")
        Next
    End Sub

    Private Sub unitprce_txt_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles unitprce_txt.MouseDoubleClick

    End Sub

   

    Private Sub Button12_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Me.Dispose()
    End Sub

    Private Sub p_addbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p_addbtn.Click
        p_clear()

        pay_txtboxid()
        p_savebtn.Enabled = True
        p_editbtn.Enabled = False
        payment_getdata()

        pro2_getdata()
        ser2_getdata()
        transaction_servicesgetdata()
        transaction_productgetdata()
    End Sub

    Private Sub Label29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label29.Click

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub
End Class
'