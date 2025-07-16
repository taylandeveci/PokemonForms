namespace PokemonForms
{

    partial class EditPage
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
            dataGridView1 = new DataGridView();
            AddData = new Button();
            UpdateData = new Button();
            DeleteData = new Button();
            BringDetail = new Button();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.Window;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(485, 426);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // AddData
            // 
            AddData.BackColor = Color.DodgerBlue;
            AddData.FlatStyle = FlatStyle.Popup;
            AddData.ForeColor = SystemColors.Window;
            AddData.Location = new Point(503, 170);
            AddData.Name = "AddData";
            AddData.Size = new Size(285, 23);
            AddData.TabIndex = 1;
            AddData.Text = "Add Data";
            AddData.UseVisualStyleBackColor = false;
            AddData.Click += AddData_Click;
            // 
            // UpdateData
            // 
            UpdateData.BackColor = Color.DodgerBlue;
            UpdateData.FlatStyle = FlatStyle.Popup;
            UpdateData.ForeColor = SystemColors.Window;
            UpdateData.Location = new Point(503, 199);
            UpdateData.Name = "UpdateData";
            UpdateData.Size = new Size(285, 23);
            UpdateData.TabIndex = 2;
            UpdateData.Text = "Update Data";
            UpdateData.UseVisualStyleBackColor = false;
            UpdateData.Click += UpdateData_Click;
            // 
            // DeleteData
            // 
            DeleteData.BackColor = Color.DodgerBlue;
            DeleteData.FlatStyle = FlatStyle.Popup;
            DeleteData.ForeColor = SystemColors.Window;
            DeleteData.Location = new Point(503, 228);
            DeleteData.Name = "DeleteData";
            DeleteData.Size = new Size(285, 23);
            DeleteData.TabIndex = 3;
            DeleteData.Text = "Delete Data";
            DeleteData.UseVisualStyleBackColor = false;
            DeleteData.Click += DeleteData_Click;
            // 
            // BringDetail
            // 
            BringDetail.BackColor = Color.DodgerBlue;
            BringDetail.Cursor = Cursors.Cross;
            BringDetail.FlatStyle = FlatStyle.Popup;
            BringDetail.ForeColor = SystemColors.Window;
            BringDetail.Location = new Point(503, 257);
            BringDetail.Name = "BringDetail";
            BringDetail.Size = new Size(285, 23);
            BringDetail.TabIndex = 4;
            BringDetail.Text = "BringDetail";
            BringDetail.UseVisualStyleBackColor = false;
            BringDetail.Click += BringDetail_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Tomato;
            btnBack.FlatStyle = FlatStyle.Popup;
            btnBack.ForeColor = SystemColors.Window;
            btnBack.Location = new Point(608, 341);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 23);
            btnBack.TabIndex = 5;
            btnBack.Text = "Go Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // EditPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(BringDetail);
            Controls.Add(DeleteData);
            Controls.Add(UpdateData);
            Controls.Add(AddData);
            Controls.Add(dataGridView1);
            Name = "EditPage";
            Text = "EditPage";
            Load += EditPage_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button AddData;
        private Button UpdateData;
        private Button DeleteData;
        private Button BringDetail;
        private Button btnBack;

    }
}