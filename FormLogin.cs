using _1_2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _1_2
{
    public partial class FormLogin : Form
    {
        public User CurrentUser { get; private set; }

        public bool IsGuest { get; private set; }
        public FormLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtLogin.Text))
            {
                MessageBox.Show("Введите логин", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new ShopDbContext())
            {
                var user = db.Users
                    .Where(w => w.Login == txtLogin.Text)
                    .FirstOrDefault();

                if (user != null)
                {
                    CurrentUser = user;
                    IsGuest = false;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            CurrentUser = null;
            IsGuest = true;
            this.DialogResult= DialogResult.OK;
            this.Close();
        }
    }
}
