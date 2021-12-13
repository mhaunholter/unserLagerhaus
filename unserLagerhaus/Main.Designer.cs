
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pb_logo = new System.Windows.Forms.PictureBox();
            this.cb_search = new System.Windows.Forms.ComboBox();
            this.cb_searchBy = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            "Mitarbeiter"});
            this.cb_table.Location = new System.Drawing.Point(190, 74);
            this.cb_table.Name = "cb_table";
            this.cb_table.Size = new System.Drawing.Size(121, 21);
            this.cb_table.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 125);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 313);
            this.dataGridView1.TabIndex = 6;
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
            // cb_search
            // 
            this.cb_search.FormattingEnabled = true;
            this.cb_search.Location = new System.Drawing.Point(190, 32);
            this.cb_search.Name = "cb_search";
            this.cb_search.Size = new System.Drawing.Size(362, 21);
            this.cb_search.TabIndex = 8;
            // 
            // cb_searchBy
            // 
            this.cb_searchBy.FormattingEnabled = true;
            this.cb_searchBy.Location = new System.Drawing.Point(559, 32);
            this.cb_searchBy.Name = "cb_searchBy";
            this.cb_searchBy.Size = new System.Drawing.Size(121, 21);
            this.cb_searchBy.TabIndex = 9;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cb_searchBy);
            this.Controls.Add(this.cb_search);
            this.Controls.Add(this.pb_logo);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cb_table);
            this.Controls.Add(this.btn_search);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.ComboBox cb_table;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pb_logo;
        private System.Windows.Forms.ComboBox cb_search;
        private System.Windows.Forms.ComboBox cb_searchBy;
    }
}

