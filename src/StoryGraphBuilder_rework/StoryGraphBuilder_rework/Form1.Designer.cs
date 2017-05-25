namespace StoryGraphBuilder_rework
{
    partial class Form1
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
            this.main_display_pic_box = new System.Windows.Forms.PictureBox();
            this.btn_add_text_node = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.main_display_pic_box)).BeginInit();
            this.SuspendLayout();
            // 
            // main_display_pic_box
            // 
            this.main_display_pic_box.Location = new System.Drawing.Point(695, 12);
            this.main_display_pic_box.Name = "main_display_pic_box";
            this.main_display_pic_box.Size = new System.Drawing.Size(701, 573);
            this.main_display_pic_box.TabIndex = 0;
            this.main_display_pic_box.TabStop = false;
            this.main_display_pic_box.Click += new System.EventHandler(this.main_display_pic_box_Click);
            // 
            // btn_add_text_node
            // 
            this.btn_add_text_node.Location = new System.Drawing.Point(12, 12);
            this.btn_add_text_node.Name = "btn_add_text_node";
            this.btn_add_text_node.Size = new System.Drawing.Size(208, 37);
            this.btn_add_text_node.TabIndex = 1;
            this.btn_add_text_node.Text = "ADD TEXT NODE";
            this.btn_add_text_node.UseVisualStyleBackColor = true;
            this.btn_add_text_node.Click += new System.EventHandler(this.btn_add_text_node_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 597);
            this.Controls.Add(this.btn_add_text_node);
            this.Controls.Add(this.main_display_pic_box);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.main_display_pic_box)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox main_display_pic_box;
        private System.Windows.Forms.Button btn_add_text_node;
    }
}

