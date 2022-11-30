using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace Edytor_operatorów
{
    public partial class startForm : Form
    {
        public startForm()
        {
            InitializeComponent();
        }

        public static class Connection
        {
            public static string serverName
            { get; set; }
            public static string login
            { get; set; }
            public static string password
            { get; set; }
            public static string database
            { get; set; }

            public static string GetString()
            {
                return "server=" + serverName + ";uid= " + login + ";pwd= " + password + ";database=" + database + ";";
            }
        }

            public class Operator
        {
            public int id
            { get; set; }
            public string Name
            { get; set; }
            public string fName
            { get; set; }
            public string lName
            { get; set; }
            public string phone
            { get; set; }
            public string email
            { get; set; }
            public bool active
            { get; set; }

            public Operator(int id, string Name, string fName, string lName, string phone, string email, bool active)
            {
                this.id = id;
                this.Name = Name;
                this.fName = fName;
                this.lName = lName;
                this.phone = phone;
                this.email = email;
                this.active = active;
            }



        }

        public class dbData
        {
            private string server;
            private string user;
            private string password;
            private string database;

            public dbData (string server, string user, string password, string database)
            {
                this.server = server;
                this.user = user;
                this.password = password;
                this.database = database;
            }

            public string GetString()
            {
                return "server=" + this.server + ";uid= " + this.user + ";pwd= " + this.password + ";database=" + this.database + ";";
            }
        }

        public static List<string> GetDBList(string server, string user, string password)
        {
            List<string> list = new List<string>();

            // Open connection to the database
            string conString = "server= " + server + ";uid= " + user + ";pwd=" + password + ";";

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(dr[0].ToString());
                        }
                    }
                }
            }
            return list;

        }

        public bool CheckDBCnt(string server, string login, string password, string DB)
        {
            string connectString = "server=" + server + ";uid= " + login + ";pwd= " + password + ";database=" + DB + ";";
 
            using (SqlConnection connection = new SqlConnection(connectString))
                {
                    try
                    {
                        connection.Open();

                        SqlCommand cmd = new SqlCommand("SELECT * from Operators", connection);
                        cmd.ExecuteReader();
                        connection.Close();
                        return true;
                    }
                    catch (SqlException)
                    {
                        return false;
                    }
                }
        }

        public bool CheckSRVCnt(string server, string login, string password)
        {
            string connectString = "server=" + server + ";uid= " + login + ";pwd= " + password + ";";
            
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                try
                {
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }

        public List<Operator> GetOperators(dbData Cnt)
        {
            using (SqlConnection connection = new SqlConnection(Cnt.GetString()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from Operators", connection);
                List<Operator> operatorList = new List<Operator>();

                using (SqlDataReader oReader = cmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        operatorList.Add(new Operator(Int32.Parse(oReader["ID"].ToString()), oReader["Code"].ToString(), oReader["Name"].ToString(), oReader["Surname"].ToString(), oReader["Phone"].ToString(), oReader["Email"].ToString(), Convert.ToBoolean(oReader["Inactive"])));
                    }
                }

                return operatorList;
            }
        }

        private void InitializeComponent()
        {
            this.loginButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.startLabel = new System.Windows.Forms.Label();
            this.userLogin = new System.Windows.Forms.TextBox();
            this.userPassword = new System.Windows.Forms.TextBox();
            this.dbList = new System.Windows.Forms.ComboBox();
            this.serverName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(525, 284);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 0;
            this.loginButton.Text = "Otwórz";
            this.loginButton.Click += new System.EventHandler(this.Login_Click);
            this.loginButton.Hide();
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(401, 284);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 7;
            this.nextButton.Text = "Dalej";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.Next_Click);
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.startLabel.Location = new System.Drawing.Point(52, 43);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(1056, 31);
            this.startLabel.TabIndex = 2;
            this.startLabel.Text = "Wskaż bazę DMS do której chcesz się zalogować, a następnie wpisz dane dostępowe:";
            // 
            // userLogin
            // 
            this.userLogin.Location = new System.Drawing.Point(401, 184);
            this.userLogin.Name = "userLogin";
            this.userLogin.Size = new System.Drawing.Size(199, 22);
            this.userLogin.TabIndex = 4;
            // 
            // userPassword
            // 
            this.userPassword.Location = new System.Drawing.Point(401, 212);
            this.userPassword.Name = "userPassword";
            this.userPassword.PasswordChar = '*';
            this.userPassword.Size = new System.Drawing.Size(199, 22);
            this.userPassword.TabIndex = 5;
            // 
            // dbList
            // 
            this.dbList.FormattingEnabled = true;
            this.dbList.Location = new System.Drawing.Point(401, 240);
            this.dbList.Name = "dbList";
            this.dbList.Size = new System.Drawing.Size(199, 24);
            this.dbList.TabIndex = 6;
            this.dbList.Hide();
            // 
            // serverName
            // 
            this.serverName.FormattingEnabled = true;
            this.serverName.Location = new System.Drawing.Point(401, 154);
            this.serverName.Name = "serverName";
            this.serverName.Size = new System.Drawing.Size(199, 24);
            this.serverName.TabIndex = 8;
            // 
            // startForm
            // 
            this.ClientSize = new System.Drawing.Size(1151, 452);
            this.Controls.Add(this.serverName);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.dbList);
            this.Controls.Add(this.userPassword);
            this.Controls.Add(this.userLogin);
            this.Controls.Add(this.startLabel);
            this.Controls.Add(this.loginButton);
            this.Name = "startForm";
            this.Text = "Edytor operatorów";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (CheckDBCnt(serverName.Text, userLogin.Text, userPassword.Text, dbList.Text))
            {
                Connection.serverName = serverName.Text;
                Connection.login = userLogin.Text;
                Connection.password = userPassword.Text;
                Connection.database = dbList.Text;
                dbData CurrentCnt = new dbData(Connection.serverName, Connection.login, Connection.password, Connection.database);
                                
                showOperator s1 = new showOperator(GetOperators(CurrentCnt));

                s1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nie znaleziono bazy operatorów DMS w wybranej bazie danych!");
            }
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (CheckSRVCnt(serverName.Text, userLogin.Text, userPassword.Text))
            {
                dbList.Show();
                loginButton.Show();
                nextButton.Hide();

                serverName.Enabled = false;
                userLogin.Enabled = false;
                userPassword.Enabled = false;

                dbList.DataSource = GetDBList(serverName.Text, userLogin.Text, userPassword.Text);
            }
            else
            {
                MessageBox.Show("Nie znaleziono bazy!");
            }
        }
    }
}