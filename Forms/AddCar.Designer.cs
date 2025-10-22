namespace dataGridView.Forms
{
    partial class AddCar
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
            components = new System.ComponentModel.Container();
            buttonSave = new Button();
            panel1 = new Panel();
            labelMakeCar = new Label();
            labelNumber = new Label();
            labelMileage = new Label();
            labelFuelConsumption = new Label();
            comboBoxMakeCar = new ComboBox();
            labelCurrentFuelVolume = new Label();
            labelRentCostPerMinute = new Label();
            textBoxNumber = new TextBox();
            numericUpDownMileage = new NumericUpDown();
            numericUpDownFuelConsumption = new NumericUpDown();
            numericUpDownCurrentFuelVolume = new NumericUpDown();
            numericUpDownRentCostPerMinute = new NumericUpDown();
            errorProviderError = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)numericUpDownMileage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownFuelConsumption).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCurrentFuelVolume).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRentCostPerMinute).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderError).BeginInit();
            SuspendLayout();
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.SlateGray;
            buttonSave.Dock = DockStyle.Bottom;
            buttonSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonSave.ForeColor = SystemColors.ButtonHighlight;
            buttonSave.Location = new Point(0, 449);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(370, 34);
            buttonSave.TabIndex = 1;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.SlateGray;
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(370, 64);
            panel1.TabIndex = 2;
            // 
            // labelMakeCar
            // 
            labelMakeCar.AutoSize = true;
            labelMakeCar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            labelMakeCar.Location = new Point(133, 83);
            labelMakeCar.Name = "labelMakeCar";
            labelMakeCar.Size = new Size(107, 23);
            labelMakeCar.TabIndex = 3;
            labelMakeCar.Text = "Марка авто";
            // 
            // labelNumber
            // 
            labelNumber.AutoSize = true;
            labelNumber.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            labelNumber.Location = new Point(67, 162);
            labelNumber.Name = "labelNumber";
            labelNumber.Size = new Size(101, 23);
            labelNumber.TabIndex = 4;
            labelNumber.Text = "ГОС номер";
            // 
            // labelMileage
            // 
            labelMileage.AutoSize = true;
            labelMileage.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            labelMileage.Location = new Point(98, 215);
            labelMileage.Name = "labelMileage";
            labelMileage.Size = new Size(70, 23);
            labelMileage.TabIndex = 5;
            labelMileage.Text = "Пробег";
            // 
            // labelFuelConsumption
            // 
            labelFuelConsumption.AutoSize = true;
            labelFuelConsumption.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            labelFuelConsumption.Location = new Point(28, 257);
            labelFuelConsumption.Name = "labelFuelConsumption";
            labelFuelConsumption.Size = new Size(140, 23);
            labelFuelConsumption.TabIndex = 6;
            labelFuelConsumption.Text = "Расход топлива";
            // 
            // comboBoxMakeCar
            // 
            comboBoxMakeCar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            comboBoxMakeCar.FormattingEnabled = true;
            comboBoxMakeCar.Location = new Point(115, 109);
            comboBoxMakeCar.Name = "comboBoxMakeCar";
            comboBoxMakeCar.Size = new Size(151, 31);
            comboBoxMakeCar.TabIndex = 7;
            // 
            // labelCurrentFuelVolume
            // 
            labelCurrentFuelVolume.AutoSize = true;
            labelCurrentFuelVolume.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            labelCurrentFuelVolume.Location = new Point(84, 319);
            labelCurrentFuelVolume.Name = "labelCurrentFuelVolume";
            labelCurrentFuelVolume.Size = new Size(215, 23);
            labelCurrentFuelVolume.TabIndex = 8;
            labelCurrentFuelVolume.Text = "Текущий объем топлива";
            // 
            // labelRentCostPerMinute
            // 
            labelRentCostPerMinute.AutoSize = true;
            labelRentCostPerMinute.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            labelRentCostPerMinute.Location = new Point(69, 375);
            labelRentCostPerMinute.Name = "labelRentCostPerMinute";
            labelRentCostPerMinute.Size = new Size(248, 23);
            labelRentCostPerMinute.TabIndex = 9;
            labelRentCostPerMinute.Text = "Стоимость аренды в минуту";
            // 
            // textBoxNumber
            // 
            textBoxNumber.Location = new Point(174, 161);
            textBoxNumber.Name = "textBoxNumber";
            textBoxNumber.Size = new Size(147, 27);
            textBoxNumber.TabIndex = 10;
            // 
            // numericUpDownMileage
            // 
            numericUpDownMileage.Location = new Point(174, 211);
            numericUpDownMileage.Name = "numericUpDownMileage";
            numericUpDownMileage.Size = new Size(147, 27);
            numericUpDownMileage.TabIndex = 15;
            numericUpDownMileage.TextAlign = HorizontalAlignment.Center;
            // 
            // numericUpDownFuelConsumption
            // 
            numericUpDownFuelConsumption.Location = new Point(174, 253);
            numericUpDownFuelConsumption.Name = "numericUpDownFuelConsumption";
            numericUpDownFuelConsumption.Size = new Size(147, 27);
            numericUpDownFuelConsumption.TabIndex = 16;
            numericUpDownFuelConsumption.TextAlign = HorizontalAlignment.Center;
            // 
            // numericUpDownCurrentFuelVolume
            // 
            numericUpDownCurrentFuelVolume.Location = new Point(119, 345);
            numericUpDownCurrentFuelVolume.Name = "numericUpDownCurrentFuelVolume";
            numericUpDownCurrentFuelVolume.Size = new Size(147, 27);
            numericUpDownCurrentFuelVolume.TabIndex = 17;
            numericUpDownCurrentFuelVolume.TextAlign = HorizontalAlignment.Center;
            // 
            // numericUpDownRentCostPerMinute
            // 
            numericUpDownRentCostPerMinute.Location = new Point(119, 401);
            numericUpDownRentCostPerMinute.Name = "numericUpDownRentCostPerMinute";
            numericUpDownRentCostPerMinute.Size = new Size(147, 27);
            numericUpDownRentCostPerMinute.TabIndex = 18;
            numericUpDownRentCostPerMinute.TextAlign = HorizontalAlignment.Center;
            // 
            // errorProviderError
            // 
            errorProviderError.ContainerControl = this;
            // 
            // AddCar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(370, 483);
            Controls.Add(numericUpDownRentCostPerMinute);
            Controls.Add(numericUpDownCurrentFuelVolume);
            Controls.Add(numericUpDownFuelConsumption);
            Controls.Add(numericUpDownMileage);
            Controls.Add(textBoxNumber);
            Controls.Add(labelRentCostPerMinute);
            Controls.Add(labelCurrentFuelVolume);
            Controls.Add(comboBoxMakeCar);
            Controls.Add(labelFuelConsumption);
            Controls.Add(labelMileage);
            Controls.Add(labelNumber);
            Controls.Add(labelMakeCar);
            Controls.Add(panel1);
            Controls.Add(buttonSave);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AddCar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добавить автомобиль";
            ((System.ComponentModel.ISupportInitialize)numericUpDownMileage).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownFuelConsumption).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCurrentFuelVolume).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRentCostPerMinute).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderError).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonSave;
        private Panel panel1;
        private Label labelMakeCar;
        private Label labelNumber;
        private Label labelMileage;
        private Label labelFuelConsumption;
        private ComboBox comboBoxMakeCar;
        private Label labelCurrentFuelVolume;
        private Label labelRentCostPerMinute;
        private TextBox textBoxNumber;
        private NumericUpDown numericUpDownMileage;
        private NumericUpDown numericUpDownFuelConsumption;
        private NumericUpDown numericUpDownCurrentFuelVolume;
        private NumericUpDown numericUpDownRentCostPerMinute;
        private ErrorProvider errorProviderError;
    }
}