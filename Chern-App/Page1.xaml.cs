using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SQLite;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chern_App
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private SQLiteConnection sqlite;

        public Page1()
        {
            InitializeComponent();
            string cs = @"URI=file:..\price.db";
            sqlite = new SQLiteConnection(cs);

            DataTable dt = new DataTable();

            sqlite.Open();  //Initiate connection to the db

            string stm = "SELECT * FROM product";

            using var cmd = new SQLiteCommand(stm, sqlite);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                MessageBox.Show(rdr["Name"].ToString());
            }
            //MessageBox.Show(Path.D(System.Reflection.Assembly.GetExecutingAssembly().Location));
            sqlite.Close();
        }
    }
}
