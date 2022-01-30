
namespace Manav_Otomasyonu
{
    partial class CategoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.brnDelete = new System.Windows.Forms.Button();
            this.brnSave = new System.Windows.Forms.Button();
            this.rchtxtDescription = new System.Windows.Forms.RichTextBox();
            this.cmbCategoryId = new System.Windows.Forms.ComboBox();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox1.Controls.Add(this.brnDelete);
            this.groupBox1.Controls.Add(this.brnSave);
            this.groupBox1.Controls.Add(this.rchtxtDescription);
            this.groupBox1.Controls.Add(this.cmbCategoryId);
            this.groupBox1.Controls.Add(this.txtCategoryName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(28, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 226);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kategori İşlemleri";
            // 
            // brnDelete
            // 
            this.brnDelete.Location = new System.Drawing.Point(405, 42);
            this.brnDelete.Name = "brnDelete";
            this.brnDelete.Size = new System.Drawing.Size(115, 55);
            this.brnDelete.TabIndex = 6;
            this.brnDelete.Text = "Sil";
            this.brnDelete.UseVisualStyleBackColor = true;
            this.brnDelete.Click += new System.EventHandler(this.brnDelete_Click);
            // 
            // brnSave
            // 
            this.brnSave.Location = new System.Drawing.Point(405, 134);
            this.brnSave.Name = "brnSave";
            this.brnSave.Size = new System.Drawing.Size(115, 55);
            this.brnSave.TabIndex = 6;
            this.brnSave.Text = "Kaydet";
            this.brnSave.UseVisualStyleBackColor = true;
            this.brnSave.Click += new System.EventHandler(this.brnSave_Click);
            // 
            // rchtxtDescription
            // 
            this.rchtxtDescription.Location = new System.Drawing.Point(155, 148);
            this.rchtxtDescription.Name = "rchtxtDescription";
            this.rchtxtDescription.Size = new System.Drawing.Size(210, 41);
            this.rchtxtDescription.TabIndex = 3;
            this.rchtxtDescription.Text = "";
            // 
            // cmbCategoryId
            // 
            this.cmbCategoryId.FormattingEnabled = true;
            this.cmbCategoryId.Location = new System.Drawing.Point(158, 90);
            this.cmbCategoryId.Name = "cmbCategoryId";
            this.cmbCategoryId.Size = new System.Drawing.Size(207, 28);
            this.cmbCategoryId.TabIndex = 2;
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Location = new System.Drawing.Point(158, 39);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(207, 27);
            this.txtCategoryName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Açıklama:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ust Kategori Id:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kategori Adı:";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(636, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 342);
            this.panel1.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calisto MT", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(45, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(361, 48);
            this.label8.TabIndex = 14;
            this.label8.Text = "Kategori İşlemleri";
            // 
            // CategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(882, 342);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CategoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CategoryForm";
            this.Load += new System.EventHandler(this.CategoryForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button brnDelete;
        private System.Windows.Forms.Button brnSave;
        private System.Windows.Forms.RichTextBox rchtxtDescription;
        private System.Windows.Forms.ComboBox cmbCategoryId;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
    }
}