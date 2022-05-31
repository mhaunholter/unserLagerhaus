
namespace unserLagerhaus
{
    partial class SetColumn
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
        private void InitializeComponent()
        {
            this.btn_confirm = new System.Windows.Forms.Button();
            this.cb_type = new System.Windows.Forms.ComboBox();
            this.lb_columnName = new System.Windows.Forms.Label();
            this.tb_charLength = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_confirm
            // 
            this.btn_confirm.Location = new System.Drawing.Point(58, 106);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(75, 23);
            this.btn_confirm.TabIndex = 0;
            this.btn_confirm.Text = "Bestätigen";
            this.btn_confirm.UseVisualStyleBackColor = true;
            this.btn_confirm.Click += new System.EventHandler(this.btn_confirm_Click);
            // 
            // cb_type
            // 
            this.cb_type.FormattingEnabled = true;
            this.cb_type.Items.AddRange(new object[] {
            "int",
            "bigint",
            "nvarchar",
            "date",
            "float(8,2)"});
            this.cb_type.Location = new System.Drawing.Point(37, 53);
            this.cb_type.Name = "cb_type";
            this.cb_type.Size = new System.Drawing.Size(121, 21);
            this.cb_type.TabIndex = 1;
            // 
            // lb_columnName
            // 
            this.lb_columnName.AutoSize = true;
            this.lb_columnName.Location = new System.Drawing.Point(80, 37);
            this.lb_columnName.Name = "lb_columnName";
            this.lb_columnName.Size = new System.Drawing.Size(29, 13);
            this.lb_columnName.TabIndex = 2;
            this.lb_columnName.Text = "label";
            // 
            // tb_charLength
            // 
            this.tb_charLength.Location = new System.Drawing.Point(37, 80);
            this.tb_charLength.Name = "tb_charLength";
            this.tb_charLength.Size = new System.Drawing.Size(121, 20);
            this.tb_charLength.TabIndex = 3;
            // 
            // SetColumn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(192, 146);
            this.Controls.Add(this.tb_charLength);
            this.Controls.Add(this.lb_columnName);
            this.Controls.Add(this.cb_type);
            this.Controls.Add(this.btn_confirm);
            this.Name = "SetColumn";
            this.Text = "SetColumn";
            this.Load += new System.EventHandler(this.SetColumn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_confirm;
        private System.Windows.Forms.ComboBox cb_type;
        private System.Windows.Forms.Label lb_columnName;
        private System.Windows.Forms.TextBox tb_charLength;
    }
}