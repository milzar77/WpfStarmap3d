﻿namespace WpfStarmap3d
{
    partial class MyPanel
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
            panel1 = new Panel();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Name = "panel1";
            panel1.Size = new Size(1, 280);
            panel1.TabIndex = 0;
            // 
            // MyPanel
            // 
            Controls.Add(panel1);
            Name = "Form1";
            Size = new Size(800, 600);
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        public Panel panel1;
    }
}