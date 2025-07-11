using PokemonForms.Models;
using System;
using System.ComponentModel;
using System.Windows.Forms;


namespace PokemonForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            btnPokemonLoad = new Button();
            btnCategoryLoad = new Button();
            btnCountryLoad = new Button();
            btnOwnerLoad = new Button();
            btnMoveLoad = new Button();
            btnReviewLoad = new Button();
            btnReviewerLoad = new Button();
            ((ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(131, 24);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(480, 242);
            dataGridView1.TabIndex = 0;
            // 
            // btnPokemonLoad
            // 
            btnPokemonLoad.Location = new Point(212, 272);
            btnPokemonLoad.Name = "btnPokemonLoad";
            btnPokemonLoad.Size = new Size(75, 23);
            btnPokemonLoad.TabIndex = 1;
            btnPokemonLoad.Text = "Pokemon";
            btnPokemonLoad.UseVisualStyleBackColor = true;
            btnPokemonLoad.Click += btnPokemonLoad_Click;
            // 
            // btnCategoryLoad
            // 
            btnCategoryLoad.Location = new Point(253, 301);
            btnCategoryLoad.Name = "btnCategoryLoad";
            btnCategoryLoad.Size = new Size(75, 23);
            btnCategoryLoad.TabIndex = 2;
            btnCategoryLoad.Text = "Category";
            btnCategoryLoad.UseVisualStyleBackColor = true;
            btnCategoryLoad.Click += btnCategoryLoad_Click;
            // 
            // btnCountryLoad
            // 
            btnCountryLoad.Location = new Point(293, 272);
            btnCountryLoad.Name = "btnCountryLoad";
            btnCountryLoad.Size = new Size(75, 23);
            btnCountryLoad.TabIndex = 3;
            btnCountryLoad.Text = "Country";
            btnCountryLoad.UseVisualStyleBackColor = true;
            btnCountryLoad.Click += btnCountryLoad_Click;
            // 
            // btnOwnerLoad
            // 
            btnOwnerLoad.Location = new Point(374, 272);
            btnOwnerLoad.Name = "btnOwnerLoad";
            btnOwnerLoad.Size = new Size(75, 23);
            btnOwnerLoad.TabIndex = 4;
            btnOwnerLoad.Text = "Owner";
            btnOwnerLoad.UseVisualStyleBackColor = true;
            btnOwnerLoad.Click += btnOwnerLoad_Click;
            // 
            // btnMoveLoad
            // 
            btnMoveLoad.Location = new Point(415, 301);
            btnMoveLoad.Name = "btnMoveLoad";
            btnMoveLoad.Size = new Size(75, 23);
            btnMoveLoad.TabIndex = 5;
            btnMoveLoad.Text = "Move";
            btnMoveLoad.UseVisualStyleBackColor = true;
            btnMoveLoad.Click += btnMoveLoad_Click;
            // 
            // btnReviewLoad
            // 
            btnReviewLoad.Location = new Point(455, 272);
            btnReviewLoad.Name = "btnReviewLoad";
            btnReviewLoad.Size = new Size(75, 23);
            btnReviewLoad.TabIndex = 6;
            btnReviewLoad.Text = "Review";
            btnReviewLoad.UseVisualStyleBackColor = true;
            btnReviewLoad.Click += btnReviewLoad_Click;
            // 
            // btnReviewerLoad
            // 
            btnReviewerLoad.Location = new Point(334, 301);
            btnReviewerLoad.Name = "btnReviewerLoad";
            btnReviewerLoad.Size = new Size(75, 23);
            btnReviewerLoad.TabIndex = 7;
            btnReviewerLoad.Text = "Reviewer";
            btnReviewerLoad.UseVisualStyleBackColor = true;
            btnReviewerLoad.Click += btnReviewerLoad_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnReviewerLoad);
            Controls.Add(btnReviewLoad);
            Controls.Add(btnMoveLoad);
            Controls.Add(btnOwnerLoad);
            Controls.Add(btnCountryLoad);
            Controls.Add(btnCategoryLoad);
            Controls.Add(btnPokemonLoad);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnPokemonLoad;
        private Button btnCategoryLoad;
        private Button btnCountryLoad;
        private Button btnOwnerLoad;
        private Button btnMoveLoad;
        private Button btnReviewLoad;
        private Button btnReviewerLoad;
    }
}
