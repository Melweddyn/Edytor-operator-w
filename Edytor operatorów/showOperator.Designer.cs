using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static Edytor_operatorów.startForm;

namespace Edytor_operatorów
{
    partial class showOperator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent(List<startForm.Operator> operators)
        {
            

            this.fName = new System.Windows.Forms.TextBox();
            this.sName = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.Phone = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.Active = new System.Windows.Forms.CheckBox();
            this.Save = new System.Windows.Forms.Button();
            this.nextOperator = new System.Windows.Forms.Button();
            this.prevOperator = new System.Windows.Forms.Button();
            this.Index = new System.Windows.Forms.TextBox();
            this.ID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            //
            //
            //
            this.ID.Text = operators.First().id.ToString();
            this.Index.Text = "0";
            // 
            // fName
            // 
            this.fName.Location = new System.Drawing.Point(341, 195);
            this.fName.Name = "fName";
            this.fName.Size = new System.Drawing.Size(180, 22);
            this.fName.TabIndex = 0;
            this.fName.Text = operators.First().fName;
            // 
            // sName
            // 
            this.sName.Location = new System.Drawing.Point(546, 195);
            this.sName.Name = "sName";
            this.sName.Size = new System.Drawing.Size(180, 22);
            this.sName.TabIndex = 1;
            this.sName.Text = operators.First().lName;
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(341, 155);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(385, 22);
            this.name.TabIndex = 2;
            this.name.Text = operators.First().Name;
            // 
            // Phone
            // 
            this.Phone.Location = new System.Drawing.Point(341, 238);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(180, 22);
            this.Phone.TabIndex = 3;
            this.Phone.Text = operators.First().phone;
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(546, 238);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(180, 22);
            this.email.TabIndex = 4;
            this.email.Text = operators.First().email;
            // 
            // Active
            // 
            this.Active.AutoSize = true;
            this.Active.Location = new System.Drawing.Point(481, 289);
            this.Active.Name = "Active";
            this.Active.Size = new System.Drawing.Size(98, 20);
            this.Active.TabIndex = 5;
            this.Active.Text = "Nieaktywny";
            this.Active.UseVisualStyleBackColor = true;
            this.Active.Checked = operators.First().active;
            // 
            // Save
            // 
            this.Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save.Location = new System.Drawing.Point(442, 369);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(180, 65);
            this.Save.TabIndex = 6;
            this.Save.Text = "Zapisz";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += (sender, e) => Save_Click(sender, e);
            // 
            // nextOperator
            // 
            this.nextOperator.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nextOperator.Location = new System.Drawing.Point(866, 179);
            this.nextOperator.Name = "nextOperator";
            this.nextOperator.Size = new System.Drawing.Size(180, 66);
            this.nextOperator.TabIndex = 7;
            this.nextOperator.Text = "Następny";
            this.nextOperator.UseVisualStyleBackColor = true;
            this.nextOperator.Click += (sender, e) => Next_Click(sender, e, operators);
            if (operators.Count == 1)
            {
                this.nextOperator.Hide();
            }
            // 
            // prevOperator
            // 
            this.prevOperator.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.prevOperator.Location = new System.Drawing.Point(34, 179);
            this.prevOperator.Name = "prevOperator";
            this.prevOperator.Size = new System.Drawing.Size(180, 65);
            this.prevOperator.TabIndex = 8;
            this.prevOperator.Text = "Poprzedni";
            this.prevOperator.UseVisualStyleBackColor = true;
            this.prevOperator.Click += (sender, e) => Prev_Click(sender, e, operators);
            this.prevOperator.Hide();
            // 
            // showOperator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 518);
            this.Controls.Add(this.prevOperator);
            this.Controls.Add(this.nextOperator);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Active);
            this.Controls.Add(this.email);
            this.Controls.Add(this.Phone);
            this.Controls.Add(this.name);
            this.Controls.Add(this.sName);
            this.Controls.Add(this.fName);
            this.Name = "showOperator";
            this.Text = "Edytor operatorów";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Next_Click(object sender, EventArgs e, List<startForm.Operator> operators)
        {
            this.Index.Text = (Int32.Parse(this.Index.Text) + 1).ToString();
            this.ID.Text = operators[Int32.Parse(this.Index.Text)].id.ToString();
            this.fName.Text = operators[Int32.Parse(this.Index.Text)].fName;
            this.sName.Text = operators[Int32.Parse(this.Index.Text)].lName;
            this.name.Text = operators[Int32.Parse(this.Index.Text)].Name;
            this.Phone.Text = operators[Int32.Parse(this.Index.Text)].phone;
            this.email.Text = operators[Int32.Parse(this.Index.Text)].email;
            this.Active.Checked = operators[Int32.Parse(this.Index.Text)].active;

            if (Convert.ToInt32(this.Index.Text) == operators.Count - 1)
            {
                this.nextOperator.Hide();
            }
            else
            {
                this.nextOperator.Show();
            }

            if (Convert.ToInt32(this.Index.Text) == 0)
            {
                this.prevOperator.Hide();
            }
            else
            {
                this.prevOperator.Show();
            }

        }
        private void Prev_Click(object sender, EventArgs e, List<startForm.Operator> operators)
        {
            this.Index.Text = (Int32.Parse(this.Index.Text) - 1).ToString();
            this.ID.Text = operators[Int32.Parse(this.Index.Text)].id.ToString();
            this.fName.Text = operators[Int32.Parse(this.Index.Text)].fName;
            this.sName.Text = operators[Int32.Parse(this.Index.Text)].lName;
            this.name.Text = operators[Int32.Parse(this.Index.Text)].Name;
            this.Phone.Text = operators[Int32.Parse(this.Index.Text)].phone;
            this.email.Text = operators[Int32.Parse(this.Index.Text)].email;
            this.Active.Checked = operators[Int32.Parse(this.Index.Text)].active;

            if (Convert.ToInt32(this.Index.Text) == operators.Count - 1)
            {
                this.nextOperator.Hide();
            }
            else
            {
                this.nextOperator.Show();
            }

            if (Convert.ToInt32(this.Index.Text) == 0)
            {
                this.prevOperator.Hide();
            }
            else
            {
                this.prevOperator.Show();
            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            

            using (SqlConnection con = new SqlConnection(startForm.Connection.GetString()))
            {
               

                string SQL = "UPDATE Operators SET Code = '" + this.name.Text + "', Name = '" + this.fName.Text + "', Surname = '" + this.sName.Text + "', Phone = '" + this.Phone.Text + "', Email = '" + this.email.Text + "', Inactive = '" + this.Active.Checked + "' FROM Operators WHERE ID = " + this.ID.Text + ";";

                using (SqlCommand cmd = new SqlCommand(SQL, con))
                {
                    cmd.CommandText = SQL;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Zapisano operatora!");
                }
            }

        }

        #endregion

        private System.Windows.Forms.TextBox fName;
        private System.Windows.Forms.TextBox sName;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox Phone;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.CheckBox Active;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button nextOperator;
        private System.Windows.Forms.Button prevOperator;
        private System.Windows.Forms.TextBox ID;
        private System.Windows.Forms.TextBox Index;
    }
}