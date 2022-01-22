
namespace unserLagerhaus
{
    partial class Main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btn_search = new System.Windows.Forms.Button();
            this.cb_table = new System.Windows.Forms.ComboBox();
            this.dgv_Table = new System.Windows.Forms.DataGridView();
            this.pb_logo = new System.Windows.Forms.PictureBox();
            this.cb_searchBy = new System.Windows.Forms.ComboBox();
            this.tb_searchFor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Table)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(686, 30);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 0;
            this.btn_search.Text = "Suchen";
            this.btn_search.UseVisualStyleBackColor = true;
            // 
            // cb_table
            // 
            this.cb_table.FormattingEnabled = true;
            this.cb_table.Items.AddRange(new object[] {
            "Produkte",
            "Mitarbeiter",
            "Bestellungen"});
            this.cb_table.Location = new System.Drawing.Point(190, 74);
            this.cb_table.Name = "cb_table";
            this.cb_table.Size = new System.Drawing.Size(121, 21);
            this.cb_table.TabIndex = 2;
            this.cb_table.Text = "Produkte";
            this.cb_table.SelectedIndexChanged += new System.EventHandler(this.cb_table_SelectedIndexChanged);
            // 
            // dgv_Table
            // 
            this.dgv_Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Table.Location = new System.Drawing.Point(12, 125);
            this.dgv_Table.Name = "dgv_Table";
            this.dgv_Table.Size = new System.Drawing.Size(776, 313);
            this.dgv_Table.TabIndex = 6;
            // 
            // pb_logo
            // 
            this.pb_logo.Image = ((System.Drawing.Image)(resources.GetObject("pb_logo.Image")));
            this.pb_logo.InitialImage = null;
            this.pb_logo.Location = new System.Drawing.Point(13, 13);
            this.pb_logo.Name = "pb_logo";
            this.pb_logo.Size = new System.Drawing.Size(170, 106);
            this.pb_logo.TabIndex = 7;
            this.pb_logo.TabStop = false;
            // 
            // cb_searchBy
            // 
            this.cb_searchBy.FormattingEnabled = true;
            this.cb_searchBy.Location = new System.Drawing.Point(509, 32);
            this.cb_searchBy.Name = "cb_searchBy";
            this.cb_searchBy.Size = new System.Drawing.Size(171, 21);
            this.cb_searchBy.TabIndex = 9;
            // 
            // tb_searchFor
            // 
            this.tb_searchFor.Location = new System.Drawing.Point(190, 33);
            this.tb_searchFor.Name = "tb_searchFor";
            this.tb_searchFor.Size = new System.Drawing.Size(313, 20);
            this.tb_searchFor.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(187, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Suchen nach";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(509, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Spalte";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_searchFor);
            this.Controls.Add(this.cb_searchBy);
            this.Controls.Add(this.pb_logo);
            this.Controls.Add(this.dgv_Table);
            this.Controls.Add(this.cb_table);
            this.Controls.Add(this.btn_search);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Table)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.ComboBox cb_table;
        private System.Windows.Forms.DataGridView dgv_Table;
        private System.Windows.Forms.PictureBox pb_logo;
        private System.Windows.Forms.ComboBox cb_searchBy;
        private System.Windows.Forms.TextBox tb_searchFor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

