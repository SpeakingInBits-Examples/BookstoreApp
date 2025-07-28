namespace BookstoreApp
{
    partial class Main
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
            lstBooks = new ListBox();
            btnAddUpdate = new Button();
            btnDelete = new Button();
            groupBox1 = new GroupBox();
            button1 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lstBooks
            // 
            lstBooks.FormattingEnabled = true;
            lstBooks.Location = new Point(12, 12);
            lstBooks.Name = "lstBooks";
            lstBooks.Size = new Size(400, 394);
            lstBooks.TabIndex = 0;
            // 
            // btnAddUpdate
            // 
            btnAddUpdate.Location = new Point(430, 12);
            btnAddUpdate.Name = "btnAddUpdate";
            btnAddUpdate.Size = new Size(120, 40);
            btnAddUpdate.TabIndex = 1;
            btnAddUpdate.Text = "Add/Update";
            btnAddUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(430, 62);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 40);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Location = new Point(430, 143);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(158, 94);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Author Management";
            // 
            // button1
            // 
            button1.Location = new Point(6, 35);
            button1.Name = "button1";
            button1.Size = new Size(146, 48);
            button1.TabIndex = 0;
            button1.Text = "Manage Authors";
            button1.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 430);
            Controls.Add(groupBox1);
            Controls.Add(lstBooks);
            Controls.Add(btnAddUpdate);
            Controls.Add(btnDelete);
            Name = "Main";
            Text = "Bookstore - Books";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstBooks;
        private System.Windows.Forms.Button btnAddUpdate;
        private System.Windows.Forms.Button btnDelete;
        private GroupBox groupBox1;
        private Button button1;
    }
}
