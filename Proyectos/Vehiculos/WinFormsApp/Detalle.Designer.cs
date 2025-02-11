namespace WinFormsApp
{
    partial class Detalle
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
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(216, 33);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(216, 92);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(216, 152);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(216, 212);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 3;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(216, 274);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 4;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(216, 337);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(125, 27);
            textBox5.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 36);
            label1.Name = "label1";
            label1.Size = new Size(98, 20);
            label1.TabIndex = 6;
            label1.Text = "Tipo vehiculo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 95);
            label2.Name = "label2";
            label2.Size = new Size(142, 20);
            label2.TabIndex = 7;
            label2.Text = "Cantidad de Puertas";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 155);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 8;
            label3.Text = "Marca";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(39, 215);
            label4.Name = "label4";
            label4.Size = new Size(61, 20);
            label4.TabIndex = 9;
            label4.Text = "Modelo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(39, 277);
            label5.Name = "label5";
            label5.Size = new Size(58, 20);
            label5.TabIndex = 10;
            label5.Text = "Patente";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(39, 340);
            label6.Name = "label6";
            label6.Size = new Size(50, 20);
            label6.TabIndex = 11;
            label6.Text = "Precio";
            // 
            // button1
            // 
            button1.Location = new Point(147, 396);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 12;
            button1.Text = "Aceptar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Detalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(441, 450);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Name = "Detalle";
            Text = "Detalle";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button button1;
    }
}