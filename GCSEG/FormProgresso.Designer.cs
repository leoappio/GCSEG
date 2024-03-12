namespace GCSEG
{
    partial class FormProgresso
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
            progressBar1 = new ProgressBar();
            label1 = new Label();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(48, 48);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(193, 23);
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.TabIndex = 0;
            progressBar1.UseWaitCursor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(47, 9);
            label1.Name = "label1";
            label1.Size = new Size(193, 28);
            label1.TabIndex = 1;
            label1.Text = "Realizando cálculos...";
            label1.UseWaitCursor = true;
            // 
            // FormProgresso
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(310, 93);
            Controls.Add(label1);
            Controls.Add(progressBar1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormProgresso";
            Text = "Calculando...";
            UseWaitCursor = true;
            Load += FormProgresso_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar progressBar1;
        private Label label1;
    }
}