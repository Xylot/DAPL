namespace ProjectLab3ControlPanel
{
    partial class Form3
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
            this.BluetoothStatusLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CurrentTransistorLabel = new System.Windows.Forms.Label();
            this.SerialCommunicationMessage = new System.Windows.Forms.TextBox();
            this.Button_SendSerialMessage = new System.Windows.Forms.Button();
            this.TextBox_ReceivedCommunication = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BluetoothStatusLabel
            // 
            this.BluetoothStatusLabel.AutoSize = true;
            this.BluetoothStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BluetoothStatusLabel.Location = new System.Drawing.Point(49, 9);
            this.BluetoothStatusLabel.Name = "BluetoothStatusLabel";
            this.BluetoothStatusLabel.Size = new System.Drawing.Size(292, 42);
            this.BluetoothStatusLabel.TabIndex = 0;
            this.BluetoothStatusLabel.Text = "Bluetooth Status";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current Transistor:";
            // 
            // CurrentTransistorLabel
            // 
            this.CurrentTransistorLabel.AutoSize = true;
            this.CurrentTransistorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentTransistorLabel.Location = new System.Drawing.Point(209, 110);
            this.CurrentTransistorLabel.Name = "CurrentTransistorLabel";
            this.CurrentTransistorLabel.Size = new System.Drawing.Size(0, 26);
            this.CurrentTransistorLabel.TabIndex = 2;
            // 
            // SerialCommunicationMessage
            // 
            this.SerialCommunicationMessage.Location = new System.Drawing.Point(93, 154);
            this.SerialCommunicationMessage.Name = "SerialCommunicationMessage";
            this.SerialCommunicationMessage.Size = new System.Drawing.Size(285, 20);
            this.SerialCommunicationMessage.TabIndex = 3;
            // 
            // Button_SendSerialMessage
            // 
            this.Button_SendSerialMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_SendSerialMessage.Location = new System.Drawing.Point(12, 154);
            this.Button_SendSerialMessage.Name = "Button_SendSerialMessage";
            this.Button_SendSerialMessage.Size = new System.Drawing.Size(75, 20);
            this.Button_SendSerialMessage.TabIndex = 4;
            this.Button_SendSerialMessage.Text = "Send";
            this.Button_SendSerialMessage.UseVisualStyleBackColor = true;
            this.Button_SendSerialMessage.Click += new System.EventHandler(this.Button_SendSerialMessage_Click);
            // 
            // TextBox_ReceivedCommunication
            // 
            this.TextBox_ReceivedCommunication.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBox_ReceivedCommunication.Location = new System.Drawing.Point(12, 180);
            this.TextBox_ReceivedCommunication.Multiline = true;
            this.TextBox_ReceivedCommunication.Name = "TextBox_ReceivedCommunication";
            this.TextBox_ReceivedCommunication.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TextBox_ReceivedCommunication.Size = new System.Drawing.Size(366, 258);
            this.TextBox_ReceivedCommunication.TabIndex = 5;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 450);
            this.Controls.Add(this.TextBox_ReceivedCommunication);
            this.Controls.Add(this.Button_SendSerialMessage);
            this.Controls.Add(this.SerialCommunicationMessage);
            this.Controls.Add(this.CurrentTransistorLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BluetoothStatusLabel);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label BluetoothStatusLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CurrentTransistorLabel;
        private System.Windows.Forms.TextBox SerialCommunicationMessage;
        private System.Windows.Forms.Button Button_SendSerialMessage;
        private System.Windows.Forms.TextBox TextBox_ReceivedCommunication;
    }
}