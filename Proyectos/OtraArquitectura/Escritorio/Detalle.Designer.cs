namespace Escritorio
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            numericUpDown1 = new NumericUpDown();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(63, 61);
            label1.Name = "label1";
            label1.Size = new Size(32, 20);
            label1.TabIndex = 0;
            label1.Text = "Dni";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(63, 127);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 1;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(63, 193);
            label3.Name = "label3";
            label3.Size = new Size(38, 20);
            label3.TabIndex = 2;
            label3.Text = "Mail";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(63, 262);
            label4.Name = "label4";
            label4.Size = new Size(86, 20);
            label4.TabIndex = 3;
            label4.Text = "Nacimiento";
            // 
            // button1
            // 
            button1.Location = new Point(85, 400);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 4;
            button1.Text = "Aceptar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(217, 400);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 5;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(206, 54);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(206, 120);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(206, 186);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 8;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(206, 257);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 9;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(206, 323);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 27);
            numericUpDown1.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(63, 330);
            label5.Name = "label5";
            label5.Size = new Size(74, 20);
            label5.TabIndex = 11;
            label5.Text = "Promedio";
            // 
            // Detalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(465, 450);
            Controls.Add(label5);
            Controls.Add(numericUpDown1);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Detalle";
            Text = "Detalle";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private DateTimePicker dateTimePicker1;
        private NumericUpDown numericUpDown1;
        private Label label5;
    }
}