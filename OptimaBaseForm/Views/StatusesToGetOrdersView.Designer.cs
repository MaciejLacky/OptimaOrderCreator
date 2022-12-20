﻿namespace OptimaBaseForm.Views
{
    partial class StatusesToGetOrdersView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCloseView = new System.Windows.Forms.Button();
            this.btnSaveView = new System.Windows.Forms.Button();
            this.gbStatusMapping = new System.Windows.Forms.GroupBox();
            this.btnDeleteStatusMapping = new System.Windows.Forms.Button();
            this.btnAddStatusMapping = new System.Windows.Forms.Button();
            this.dgvStatusMapping = new System.Windows.Forms.DataGridView();
            this.label165 = new System.Windows.Forms.Label();
            this.cbStatusMappingEnd = new System.Windows.Forms.ComboBox();
            this.label166 = new System.Windows.Forms.Label();
            this.cbStatusMappingStart = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbStatusMapping.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatusMapping)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnCloseView);
            this.panel1.Controls.Add(this.btnSaveView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 521);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 40);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.gbStatusMapping);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(984, 521);
            this.panel2.TabIndex = 1;
            // 
            // btnCloseView
            // 
            this.btnCloseView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseView.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnCloseView.FlatAppearance.BorderSize = 0;
            this.btnCloseView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseView.ForeColor = System.Drawing.Color.White;
            this.btnCloseView.Location = new System.Drawing.Point(791, 6);
            this.btnCloseView.Name = "btnCloseView";
            this.btnCloseView.Size = new System.Drawing.Size(92, 29);
            this.btnCloseView.TabIndex = 3;
            this.btnCloseView.Text = "Anuluj";
            this.btnCloseView.UseVisualStyleBackColor = false;
            // 
            // btnSaveView
            // 
            this.btnSaveView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveView.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSaveView.FlatAppearance.BorderSize = 0;
            this.btnSaveView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveView.ForeColor = System.Drawing.Color.White;
            this.btnSaveView.Location = new System.Drawing.Point(889, 6);
            this.btnSaveView.Name = "btnSaveView";
            this.btnSaveView.Size = new System.Drawing.Size(92, 29);
            this.btnSaveView.TabIndex = 2;
            this.btnSaveView.Text = "Zapisz";
            this.btnSaveView.UseVisualStyleBackColor = false;
            // 
            // gbStatusMapping
            // 
            this.gbStatusMapping.Controls.Add(this.btnDeleteStatusMapping);
            this.gbStatusMapping.Controls.Add(this.btnAddStatusMapping);
            this.gbStatusMapping.Controls.Add(this.dgvStatusMapping);
            this.gbStatusMapping.Controls.Add(this.label165);
            this.gbStatusMapping.Controls.Add(this.cbStatusMappingEnd);
            this.gbStatusMapping.Controls.Add(this.label166);
            this.gbStatusMapping.Controls.Add(this.cbStatusMappingStart);
            this.gbStatusMapping.Location = new System.Drawing.Point(4, 21);
            this.gbStatusMapping.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbStatusMapping.Name = "gbStatusMapping";
            this.gbStatusMapping.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbStatusMapping.Size = new System.Drawing.Size(967, 333);
            this.gbStatusMapping.TabIndex = 1;
            this.gbStatusMapping.TabStop = false;
            this.gbStatusMapping.Text = "Mapowanie statusów zamówień do pobrania";
            // 
            // btnDeleteStatusMapping
            // 
            this.btnDeleteStatusMapping.Location = new System.Drawing.Point(762, 122);
            this.btnDeleteStatusMapping.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDeleteStatusMapping.Name = "btnDeleteStatusMapping";
            this.btnDeleteStatusMapping.Size = new System.Drawing.Size(88, 27);
            this.btnDeleteStatusMapping.TabIndex = 154;
            this.btnDeleteStatusMapping.Text = "Usuń";
            this.btnDeleteStatusMapping.UseVisualStyleBackColor = true;
            // 
            // btnAddStatusMapping
            // 
            this.btnAddStatusMapping.Location = new System.Drawing.Point(856, 122);
            this.btnAddStatusMapping.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAddStatusMapping.Name = "btnAddStatusMapping";
            this.btnAddStatusMapping.Size = new System.Drawing.Size(88, 27);
            this.btnAddStatusMapping.TabIndex = 153;
            this.btnAddStatusMapping.Text = "Dodaj";
            this.btnAddStatusMapping.UseVisualStyleBackColor = true;
            // 
            // dgvStatusMapping
            // 
            this.dgvStatusMapping.AllowUserToAddRows = false;
            this.dgvStatusMapping.AllowUserToDeleteRows = false;
            this.dgvStatusMapping.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStatusMapping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatusMapping.Location = new System.Drawing.Point(15, 28);
            this.dgvStatusMapping.Margin = new System.Windows.Forms.Padding(2);
            this.dgvStatusMapping.Name = "dgvStatusMapping";
            this.dgvStatusMapping.ReadOnly = true;
            this.dgvStatusMapping.RowHeadersWidth = 51;
            this.dgvStatusMapping.RowTemplate.Height = 24;
            this.dgvStatusMapping.Size = new System.Drawing.Size(520, 291);
            this.dgvStatusMapping.TabIndex = 150;
            // 
            // label165
            // 
            this.label165.AutoSize = true;
            this.label165.Location = new System.Drawing.Point(738, 58);
            this.label165.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label165.Name = "label165";
            this.label165.Size = new System.Drawing.Size(107, 15);
            this.label165.TabIndex = 152;
            this.label165.Text = "Status po pobraniu";
            // 
            // cbStatusMappingEnd
            // 
            this.cbStatusMappingEnd.FormattingEnabled = true;
            this.cbStatusMappingEnd.Location = new System.Drawing.Point(735, 77);
            this.cbStatusMappingEnd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbStatusMappingEnd.Name = "cbStatusMappingEnd";
            this.cbStatusMappingEnd.Size = new System.Drawing.Size(209, 23);
            this.cbStatusMappingEnd.TabIndex = 151;
            // 
            // label166
            // 
            this.label166.AutoSize = true;
            this.label166.Location = new System.Drawing.Point(553, 58);
            this.label166.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label166.Name = "label166";
            this.label166.Size = new System.Drawing.Size(106, 15);
            this.label166.TabIndex = 149;
            this.label166.Text = "Status do pobrania";
            // 
            // cbStatusMappingStart
            // 
            this.cbStatusMappingStart.FormattingEnabled = true;
            this.cbStatusMappingStart.Location = new System.Drawing.Point(552, 77);
            this.cbStatusMappingStart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbStatusMappingStart.Name = "cbStatusMappingStart";
            this.cbStatusMappingStart.Size = new System.Drawing.Size(177, 23);
            this.cbStatusMappingStart.TabIndex = 148;
            // 
            // StatusesToGetOrdersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "StatusesToGetOrdersView";
            this.Text = "StatusesToGetOrdersView";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.gbStatusMapping.ResumeLayout(false);
            this.gbStatusMapping.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatusMapping)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button btnCloseView;
        private Button btnSaveView;
        private GroupBox gbStatusMapping;
        private Button btnDeleteStatusMapping;
        private Button btnAddStatusMapping;
        private DataGridView dgvStatusMapping;
        private Label label165;
        private ComboBox cbStatusMappingEnd;
        private Label label166;
        private ComboBox cbStatusMappingStart;
    }
}