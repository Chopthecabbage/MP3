namespace _62view_v3
{
    partial class ReferenceForm
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
            this.btnReference = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnReference
            // 
            this.btnReference.Location = new System.Drawing.Point(499, 12);
            this.btnReference.Name = "btnReference";
            this.btnReference.Size = new System.Drawing.Size(75, 23);
            this.btnReference.TabIndex = 0;
            this.btnReference.Text = "검색";
            this.btnReference.UseVisualStyleBackColor = true;
            this.btnReference.Click += new System.EventHandler(this.btnReference_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(499, 41);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "추가";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtReference
            // 
            this.txtReference.Location = new System.Drawing.Point(26, 13);
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(467, 21);
            this.txtReference.TabIndex = 2;
            this.txtReference.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReference_KeyDown);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(26, 71);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(548, 340);
            this.listBox1.TabIndex = 3;
            // 
            // ReferenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 450);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.txtReference);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnReference);
            this.Name = "ReferenceForm";
            this.Text = "ReferenceForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReference;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtReference;
        private System.Windows.Forms.ListBox listBox1;
    }
}