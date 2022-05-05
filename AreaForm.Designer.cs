
namespace JustinTownleyCapstone
{
    partial class AreaForm
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
            this.addCountryButton = new System.Windows.Forms.Button();
            this.countryComboBox = new System.Windows.Forms.ComboBox();
            this.areaTextBox = new System.Windows.Forms.TextBox();
            this.areaIdTextBox = new System.Windows.Forms.TextBox();
            this.countryLabel = new System.Windows.Forms.Label();
            this.areaLabel = new System.Windows.Forms.Label();
            this.areaIdLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addCountryButton
            // 
            this.addCountryButton.Location = new System.Drawing.Point(391, 101);
            this.addCountryButton.Name = "addCountryButton";
            this.addCountryButton.Size = new System.Drawing.Size(75, 23);
            this.addCountryButton.TabIndex = 94;
            this.addCountryButton.Text = "add new";
            this.addCountryButton.UseVisualStyleBackColor = true;
            this.addCountryButton.Click += new System.EventHandler(this.addCountryButton_Click);
            // 
            // countryComboBox
            // 
            this.countryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countryComboBox.FormattingEnabled = true;
            this.countryComboBox.Location = new System.Drawing.Point(107, 101);
            this.countryComboBox.Name = "countryComboBox";
            this.countryComboBox.Size = new System.Drawing.Size(278, 21);
            this.countryComboBox.TabIndex = 93;
            // 
            // areaTextBox
            // 
            this.areaTextBox.Location = new System.Drawing.Point(107, 65);
            this.areaTextBox.Name = "areaTextBox";
            this.areaTextBox.Size = new System.Drawing.Size(359, 20);
            this.areaTextBox.TabIndex = 92;
            // 
            // areaIdTextBox
            // 
            this.areaIdTextBox.Location = new System.Drawing.Point(107, 22);
            this.areaIdTextBox.Name = "areaIdTextBox";
            this.areaIdTextBox.ReadOnly = true;
            this.areaIdTextBox.Size = new System.Drawing.Size(359, 20);
            this.areaIdTextBox.TabIndex = 91;
            // 
            // countryLabel
            // 
            this.countryLabel.AutoSize = true;
            this.countryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countryLabel.Location = new System.Drawing.Point(23, 101);
            this.countryLabel.Name = "countryLabel";
            this.countryLabel.Size = new System.Drawing.Size(64, 20);
            this.countryLabel.TabIndex = 90;
            this.countryLabel.Text = "Country";
            // 
            // areaLabel
            // 
            this.areaLabel.AutoSize = true;
            this.areaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.areaLabel.Location = new System.Drawing.Point(52, 63);
            this.areaLabel.Name = "areaLabel";
            this.areaLabel.Size = new System.Drawing.Size(43, 20);
            this.areaLabel.TabIndex = 89;
            this.areaLabel.Text = "Area";
            // 
            // areaIdLabel
            // 
            this.areaIdLabel.AutoSize = true;
            this.areaIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.areaIdLabel.Location = new System.Drawing.Point(31, 22);
            this.areaIdLabel.Name = "areaIdLabel";
            this.areaIdLabel.Size = new System.Drawing.Size(64, 20);
            this.areaIdLabel.TabIndex = 88;
            this.areaIdLabel.Text = "Area ID";
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(78, 141);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(136, 58);
            this.saveButton.TabIndex = 87;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(249, 141);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(136, 58);
            this.cancelButton.TabIndex = 86;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // AreaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 230);
            this.Controls.Add(this.addCountryButton);
            this.Controls.Add(this.countryComboBox);
            this.Controls.Add(this.areaTextBox);
            this.Controls.Add(this.areaIdTextBox);
            this.Controls.Add(this.countryLabel);
            this.Controls.Add(this.areaLabel);
            this.Controls.Add(this.areaIdLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Name = "AreaForm";
            this.Text = "AreaForm";
            this.VisibleChanged += new System.EventHandler(this.AreaForm_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addCountryButton;
        private System.Windows.Forms.ComboBox countryComboBox;
        private System.Windows.Forms.TextBox areaTextBox;
        private System.Windows.Forms.TextBox areaIdTextBox;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.Label areaLabel;
        private System.Windows.Forms.Label areaIdLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}