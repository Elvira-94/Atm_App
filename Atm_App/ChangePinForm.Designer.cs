namespace Atm_App
{
    partial class ChangePinForm
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
            this.lblAccountName = new System.Windows.Forms.Label();
            this.lblNewPin = new System.Windows.Forms.Label();
            this.lblConfirmPin = new System.Windows.Forms.Label();
            this.btnChangePin = new System.Windows.Forms.Button();
            this.txtNewPin = new System.Windows.Forms.TextBox();
            this.txtConfirmPin = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountName.Location = new System.Drawing.Point(312, 38);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(106, 37);
            this.lblAccountName.TabIndex = 0;
            this.lblAccountName.Text = "label1";
            // 
            // lblNewPin
            // 
            this.lblNewPin.AutoSize = true;
            this.lblNewPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPin.Location = new System.Drawing.Point(82, 125);
            this.lblNewPin.Name = "lblNewPin";
            this.lblNewPin.Size = new System.Drawing.Size(143, 37);
            this.lblNewPin.TabIndex = 1;
            this.lblNewPin.Text = "New Pin";
            // 
            // lblConfirmPin
            // 
            this.lblConfirmPin.AutoSize = true;
            this.lblConfirmPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPin.Location = new System.Drawing.Point(82, 214);
            this.lblConfirmPin.Name = "lblConfirmPin";
            this.lblConfirmPin.Size = new System.Drawing.Size(196, 37);
            this.lblConfirmPin.TabIndex = 2;
            this.lblConfirmPin.Text = "Confirm Pin";
            // 
            // btnChangePin
            // 
            this.btnChangePin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePin.Location = new System.Drawing.Point(177, 333);
            this.btnChangePin.Name = "btnChangePin";
            this.btnChangePin.Size = new System.Drawing.Size(152, 63);
            this.btnChangePin.TabIndex = 3;
            this.btnChangePin.Text = "Submit";
            this.btnChangePin.UseVisualStyleBackColor = true;
            this.btnChangePin.Click += new System.EventHandler(this.btnChangePin_Click);
            // 
            // txtNewPin
            // 
            this.txtNewPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPin.Location = new System.Drawing.Point(366, 118);
            this.txtNewPin.Name = "txtNewPin";
            this.txtNewPin.Size = new System.Drawing.Size(248, 44);
            this.txtNewPin.TabIndex = 4;
            // 
            // txtConfirmPin
            // 
            this.txtConfirmPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPin.Location = new System.Drawing.Point(366, 207);
            this.txtConfirmPin.Name = "txtConfirmPin";
            this.txtConfirmPin.Size = new System.Drawing.Size(248, 44);
            this.txtConfirmPin.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(462, 333);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(267, 63);
            this.button1.TabIndex = 6;
            this.button1.Text = "Main Page";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChangePinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtConfirmPin);
            this.Controls.Add(this.txtNewPin);
            this.Controls.Add(this.btnChangePin);
            this.Controls.Add(this.lblConfirmPin);
            this.Controls.Add(this.lblNewPin);
            this.Controls.Add(this.lblAccountName);
            this.Name = "ChangePinForm";
            this.Text = "ChangePinForm";
            this.Load += new System.EventHandler(this.ChangePinForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAccountName;
        private System.Windows.Forms.Label lblNewPin;
        private System.Windows.Forms.Label lblConfirmPin;
        private System.Windows.Forms.Button btnChangePin;
        private System.Windows.Forms.TextBox txtNewPin;
        private System.Windows.Forms.TextBox txtConfirmPin;
        private System.Windows.Forms.Button button1;
    }
}