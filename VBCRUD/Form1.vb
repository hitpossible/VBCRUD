Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.IO

Public Class Form1
    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Dim ID As Integer = txtID.Text
        Dim firstname As String = txtFirstname.Text
        Dim lastname As String = txtLastname.Text
        Dim gender As String = cbGender.SelectedItem

        Dim query As String = "INSERT INTO member VALUES (@id, @firstname, @lastname, @gender)"

        Using con As SqlConnection = New SqlConnection("Data Source=LAPTOP-6G00CEKC;Initial Catalog=test;Integrated Security=True")
            Using cmd As SqlCommand = New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@id", ID)
                cmd.Parameters.AddWithValue("@firstname", firstname)
                cmd.Parameters.AddWithValue("@lastname", lastname)
                cmd.Parameters.AddWithValue("@gender", gender)

                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                txtID.Text = ""
                txtFirstname.Text = ""
                txtLastname.Text = ""
                MessageBox.Show("successfull inserted!")
                BindData()

            End Using
        End Using

    End Sub

    Public Sub BindData()
        Dim query As String = "SELECT * FROM member"
        Using con As SqlConnection = New SqlConnection("Data Source=LAPTOP-6G00CEKC;Initial Catalog=test;Integrated Security=True")
            Using cmd As SqlCommand = New SqlCommand(query, con)
                Using da As New SqlDataAdapter()
                    da.SelectCommand = cmd
                    Using dt As New DataTable()
                        da.Fill(dt)
                        DataGridView1.DataSource = dt

                    End Using
                End Using
            End Using
        End Using
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim query As String = "SELECT * FROM member WHERE id = '" & txtSearch.Text & "'"
        Using con As SqlConnection = New SqlConnection("Data Source=LAPTOP-6G00CEKC;Initial Catalog=test;Integrated Security=True")
            Using cmd As SqlCommand = New SqlCommand(query, con)
                Using da As New SqlDataAdapter()
                    da.SelectCommand = cmd
                    Using dt As New DataTable()
                        da.Fill(dt)

                        If dt.Rows.Count > 0 Then
                            txtID.Text = dt.Rows(0)(0).ToString()
                            txtFirstname.Text = dt.Rows(0)(1).ToString()
                            txtLastname.Text = dt.Rows(0)(2).ToString()
                            cbGender.Text = dt.Rows(0)(3).ToString()
                        Else
                            txtID.Text = ""
                            txtFirstname.Text = ""
                            txtLastname.Text = ""
                        End If



                    End Using
                End Using
            End Using
        End Using
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim ID As Integer = txtID.Text
        Dim firstname As String = txtFirstname.Text
        Dim lastname As String = txtLastname.Text
        Dim gender As String = cbGender.SelectedItem

        Dim query As String = "UPDATE member SET id = @id, firstname = @firstname, lastname = @lastname, gender = @gender WHERE id = @id"

        Using con As SqlConnection = New SqlConnection("Data Source=LAPTOP-6G00CEKC;Initial Catalog=test;Integrated Security=True")
            Using cmd As SqlCommand = New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@id", ID)
                cmd.Parameters.AddWithValue("@firstname", firstname)
                cmd.Parameters.AddWithValue("@lastname", lastname)
                cmd.Parameters.AddWithValue("@gender", gender)

                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                txtID.Text = ""
                txtFirstname.Text = ""
                txtLastname.Text = ""
                MessageBox.Show("successfull Updated!")
                BindData()

            End Using
        End Using
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim ID As Integer = txtID.Text
        Dim query As String = "DELETE FROM member WHERE id = @id"

        Using con As SqlConnection = New SqlConnection("Data Source=LAPTOP-6G00CEKC;Initial Catalog=test;Integrated Security=True")
            Using cmd As SqlCommand = New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@id", ID)

                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                txtID.Text = ""
                txtFirstname.Text = ""
                txtLastname.Text = ""
                MessageBox.Show("successfull Deleted!")
                BindData()

            End Using
        End Using
    End Sub
End Class
