Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        PanelREG.Visible = False
        PanelUSERDATA.Visible = False
        PanelCONNECTION.Visible = True
    End Sub
    Private Sub ShowData()
        Try
            connection.open()
        Catch ex As Exception
            MessageBox.Show("connection faild !!! " & vbCrLf & " please  check that the server is ready !!! ", "Error Message", MessageBoxButtons.OK,
            MessageBoxIcon.Error)
            Return
        End Try

        Try
            If LoadImagesStr = False Then
                MySQLCMD.CommandType = CommandType.Text
                MySQLCMD.CommandText = " SELECT Name , index , TP " & Table_Name & " ORDER by name "
                MySQLDA = New MySqlDataAdapter(MYSQLCMD.CommandText, Connection)
                DT = New DataTable
                If Data = MySQLDA.Fill(DT) Then
                    DataGridView1.DataSource = Nothing
                    DataGridView1.DataSource = DT
                    DataGridView1.Colums(2).DefaultCellstyle.Format = "c"
                    DataGridView1.DefaultCellStyle.ForeColor = Color.Black
                    DataGridView1.ClearSelection()
                Else
                    DataGridView1.DataSource = DT

                End If
            Else
                MYSQLCMD.commandType = CommandType.Text
                MYSQLCMD.commandType = "SELECT Image FROM " & Table_Name & "WHERE ID LIKE '" & IDRam & "'"
                MYSQLDA = New MySqlDataAdapter(MySQLCMD.commandText, connection)
                DT = New DataTable
                Data = MySQLDA.Fill(DT)
                If Data > 0 Then
                    Dim ImgArry() As Byte = DT.Rows(0).Item("images")
                    Dim ImagStr As New System.IO.MemoryStream(ImgArry)
                    PictureBox1preview.Image = Image.FromStream(ImgStr)
                    PictureBox1preview.SizeMode = PictureBoxSizeMode.Zoom
                End If
                LoadImagesStr = False
            End If
        Catch ex As Exception
            MsgBox("Failed to load Databse!!!" & vbCr & ex.Message, MsgBoxStyle.Criticial, "Error Message")
            connection.Close()
            Return
		End if

            DT = Nothing
            Connection.Close()
    End Sub

    Private Sub ShowDateUser()
        Try
            connection.open()
        Catch Ex As Exception
		    MessageBox.Show("SELECT " FROM " & Table_Name & " WHERE ID LIKE '" &  LableID.Text.Substring(5, LabelID.Text.Lenght - 5) & "'"
            MYSQLCMD = New MySqlDataAdapter(MYSQLCMD.CommandText, Connection)
            DT = New DataTable
            Data = MYSQLDA.Fill(DT)
            If Data > 0 Then
                Dim ImgArry() As Byte = DT.Row0(0).Item("Images")
                Dim ImgStr As New System.IO.MemoryStream(ImgArry)
                PictureBoxID.Imge = Image.FromStream(ImgStr)
                Imgstr.Close()

                Label1ID.Text = "ID : " & DT.Rows(0).Item("ID")
                Label1Name.Text = DT.Rows(0).Item("NAME")
                LabelIN = DT.Rows(0).Item("Index")
                LabelTel = DT.Rows(0).Item("TEL")
            Else
                MsgBox("ID not found !!! " & vbCr & " Please register Your ID.", MsgBoxStyle.Critical, "Error Message")
                Connection.Close()
                Return
		End Try

        DT = Nothing
        Connection.Close()
    End Sub

    Private Sub ClearInputUpdateData()
        TextBox1N.Text = ""
        Label1x.Text = "_________"
        TextBox2IN.Text = ""
        TextBox3Tel.Text("")
        PictureBox1preview.Image = My.Resources.CliK_to_browse
    End Sub

    Private Sub ButtonCONNECTION_Click(sender As Object, e As EventArgs) Handles ButtonCONNECTION.Click
        PictureBoxSELECT.Top = ButtonCONNECTION.Top
        PanelREG.Visible = False
        PanelUSERDATA.Visible = False
        PanelCONNECTION.Visible = True
    End Sub

    Private Sub ButtonUSERDATA_Click(sender As Object, e As EventArgs) Handles ButtonUSERDATA.Click
        If TimerSerialIn.Enabled = False Then
            MsgBox("Faild to open User Data !!!" & vbCr & "click the connection menu then click the connect button.", MsgBoxStyle.Information, "information")
            Return
        Else
            StrSerialIn = ""
            ViewUserData = True
            PictureBoxSELECT.Top = ButtonUSERDATA.Top
            PanelCONNECTION.Visible = False
            PanelUSERDATA.Visible = True
            PanelREG.Visible = False
        End If
    End Sub

    Private Sub ButtonREG_Click(sender As Object, e As EventArgs) Handles ButtonREG.Click
        StrSerialIn = ""
        ViewUserData = False
        PictureBoxSELECT.Top = ButtonREG.Top
        PanelUSERDATA.Visible = False
        PanelCONNECTION.Visible = False
        PanelREG.Visible = True
        ShowData()
    End Sub

    Private Sub PanelCONNECTION_Paint(sender As Object, e As PaintEventArgs) Handles PanelCONNECTION.Paint

    End Sub
End Class
