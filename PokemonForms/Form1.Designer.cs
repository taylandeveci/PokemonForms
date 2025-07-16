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
            btnPokemonLoad = new Button();
            btnCategoryLoad = new Button();
            btnCountryLoad = new Button();
            btnOwnerLoad = new Button();
            btnMoveLoad = new Button();
            btnReviewLoad = new Button();
            btnReviewerLoad = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnPokemonLoad
            // 
            btnPokemonLoad.BackColor = Color.DodgerBlue;
            btnPokemonLoad.Cursor = Cursors.No;
            btnPokemonLoad.FlatStyle = FlatStyle.Popup;
            btnPokemonLoad.ForeColor = SystemColors.Window;
            btnPokemonLoad.Location = new Point(323, 38);
            btnPokemonLoad.Name = "btnPokemonLoad";
            btnPokemonLoad.Size = new Size(75, 23);
            btnPokemonLoad.TabIndex = 1;
            btnPokemonLoad.Text = "Pokemon";
            btnPokemonLoad.UseVisualStyleBackColor = false;
            btnPokemonLoad.Click += btnPokemonLoad_Click;
            // 
            // btnCategoryLoad
            // 
            btnCategoryLoad.BackColor = Color.DodgerBlue;
            btnCategoryLoad.FlatStyle = FlatStyle.Popup;
            btnCategoryLoad.ForeColor = SystemColors.Window;
            btnCategoryLoad.Location = new Point(323, 67);
            btnCategoryLoad.Name = "btnCategoryLoad";
            btnCategoryLoad.Size = new Size(75, 23);
            btnCategoryLoad.TabIndex = 2;
            btnCategoryLoad.Text = "Category";
            btnCategoryLoad.UseVisualStyleBackColor = false;
            btnCategoryLoad.Click += btnCategoryLoad_Click;
            // 
            // btnCountryLoad
            // 
            btnCountryLoad.BackColor = Color.DodgerBlue;
            btnCountryLoad.BackgroundImageLayout = ImageLayout.Center;
            btnCountryLoad.FlatStyle = FlatStyle.Popup;
            btnCountryLoad.ForeColor = SystemColors.Window;
            btnCountryLoad.Location = new Point(323, 154);
            btnCountryLoad.Name = "btnCountryLoad";
            btnCountryLoad.Size = new Size(75, 23);
            btnCountryLoad.TabIndex = 3;
            btnCountryLoad.Text = "Country";
            btnCountryLoad.UseVisualStyleBackColor = false;
            btnCountryLoad.Click += btnCountryLoad_Click;
            // 
            // btnOwnerLoad
            // 
            btnOwnerLoad.BackColor = Color.DodgerBlue;
            btnOwnerLoad.FlatStyle = FlatStyle.Popup;
            btnOwnerLoad.ForeColor = SystemColors.Window;
            btnOwnerLoad.Location = new Point(323, 125);
            btnOwnerLoad.Name = "btnOwnerLoad";
            btnOwnerLoad.Size = new Size(75, 23);
            btnOwnerLoad.TabIndex = 4;
            btnOwnerLoad.Text = "Owner";
            btnOwnerLoad.UseVisualStyleBackColor = false;
            btnOwnerLoad.Click += btnOwnerLoad_Click;
            // 
            // btnMoveLoad
            // 
            btnMoveLoad.BackColor = Color.DodgerBlue;
            btnMoveLoad.FlatStyle = FlatStyle.Popup;
            btnMoveLoad.ForeColor = SystemColors.Window;
            btnMoveLoad.Location = new Point(323, 183);
            btnMoveLoad.Name = "btnMoveLoad";
            btnMoveLoad.Size = new Size(75, 23);
            btnMoveLoad.TabIndex = 5;
            btnMoveLoad.Text = "Move";
            btnMoveLoad.UseVisualStyleBackColor = false;
            btnMoveLoad.Click += btnMoveLoad_Click;
            // 
            // btnReviewLoad
            // 
            btnReviewLoad.BackColor = Color.DodgerBlue;
            btnReviewLoad.FlatStyle = FlatStyle.Popup;
            btnReviewLoad.ForeColor = SystemColors.Window;
            btnReviewLoad.Location = new Point(323, 212);
            btnReviewLoad.Name = "btnReviewLoad";
            btnReviewLoad.Size = new Size(75, 23);
            btnReviewLoad.TabIndex = 6;
            btnReviewLoad.Text = "Review";
            btnReviewLoad.UseVisualStyleBackColor = false;
            btnReviewLoad.Click += btnReviewLoad_Click;
            // 
            // btnReviewerLoad
            // 
            btnReviewerLoad.BackColor = Color.DodgerBlue;
            btnReviewerLoad.FlatStyle = FlatStyle.Popup;
            btnReviewerLoad.ForeColor = SystemColors.Window;
            btnReviewerLoad.Location = new Point(323, 96);
            btnReviewerLoad.Name = "btnReviewerLoad";
            btnReviewerLoad.Size = new Size(75, 23);
            btnReviewerLoad.TabIndex = 7;
            btnReviewerLoad.Text = "Reviewer";
            btnReviewerLoad.UseVisualStyleBackColor = false;
            btnReviewerLoad.Click += btnReviewerLoad_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(269, 5);
            label1.Name = "label1";
            label1.Size = new Size(194, 30);
            label1.TabIndex = 9;
            label1.Text = "Please Select Data ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(752, 412);
            Controls.Add(label1);
            Controls.Add(btnReviewerLoad);
            Controls.Add(btnReviewLoad);
            Controls.Add(btnMoveLoad);
            Controls.Add(btnOwnerLoad);
            Controls.Add(btnCountryLoad);
            Controls.Add(btnCategoryLoad);
            Controls.Add(btnPokemonLoad);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnPokemonLoad;
        private Button btnCategoryLoad;
        private Button btnCountryLoad;
        private Button btnOwnerLoad;
        private Button btnMoveLoad;
        private Button btnReviewLoad;
        private Button btnReviewerLoad;
        private Label label1;
    }
}
