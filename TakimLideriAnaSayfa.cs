﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeriTabaniProje
{
    public partial class TakimLideriAnaSayfa : Form
    {
        public TakimLideriAnaSayfa()
        {
            InitializeComponent();
        }

        private void TakimLideriAnaSayfa_Load(object sender, EventArgs e)
        {
            HosgeldinizMesaji();
            Label lbl = label1;
            Panel pnl = panel1;
            lbl.Location = new Point((pnl.Width - lbl.Width) / 2, lbl.Location.Y);
        }
        private void HosgeldinizMesaji()
        {
            string connectionString = "Data Source=SEYHMUSPC;Initial Catalog=PrimTakipSistemi;Integrated Security=True;";
            string query = "SELECT TakimLideriAd, TakimLideriSoyad FROM TakimLiderleri WHERE TakimLideriID=@ID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ID", LoginForm.ID);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string Adi = reader["TakimLideriAd"].ToString();
                        string Soyadi = reader["TakimLideriSoyad"].ToString();
                        label1.Text = "Hoş geldiniz, " + Adi + " " + Soyadi;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm();
            form.Show();
            Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PrimItirazlari primItirazlari = new PrimItirazlari();
            primItirazlari.Show();
            Hide();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.LightSeaGreen;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.MediumTurquoise;
        }
    }
}
