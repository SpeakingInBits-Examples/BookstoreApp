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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 430);
            Controls.Add(lstBooks);
            Controls.Add(btnAddUpdate);
            Controls.Add(btnDelete);
            Name = "Form1";
            Text = "Bookstore - Books";
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstBooks;
        private System.Windows.Forms.Button btnAddUpdate;
        private System.Windows.Forms.Button btnDelete;
    }
}
