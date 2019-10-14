using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ORM.Objects;

namespace DepartmentOfCommerceProject
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static string connectionString = "";
        public static DatabaseManager DBManager { get; } = new DatabaseManager(connectionString);
    }
}
