﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DepartmentOfCommerceProject.Infrastructure;

namespace DepartmentOfCommerceProject.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        //private void LoginButton_Click(object sender, RoutedEventArgs e)
        //{
        //    string login = loginTextBox.Text;
        //    string pass = passwordTextBox.Password;

        //    loginTextBox.Text = "";
        //    passwordTextBox.Password = "";

        //    string hash = Crypto.GetMd5Hash(login + ":" + pass);
        //    MessageBox.Show(hash);
        //}
    }
}