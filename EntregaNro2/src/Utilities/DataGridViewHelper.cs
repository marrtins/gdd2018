﻿using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using FrbaHotel.AbmHotel.Model;
using FrbaHotel.Utilities;
using Rubberduck.Winforms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Utilities
{
    public class DataGridViewHelper
    {
        public static void clean(DataGridView dgv)
        {
            if (dgv.CurrentCell != null)
            {
                DataTable dt = (DataTable)dgv.DataSource;
                dt.Clear();
            }
        }

        public static DataTable fill(SqlCommand command, DataGridView dataGridView)
        {
                var connection = ConfigurationManager.ConnectionStrings["GD1C2018ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connection);
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            sqlDataAdapter.Fill(dataTable);
            dataGridView.DataSource = dataTable;

            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AllowUserToAddRows = false;

            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (!column.Name.Equals("checkbox") && !column.Name.Equals("chk"))
                    column.ReadOnly = true;
            }

            conn.Close();
            return dataTable;
        }


    }
}