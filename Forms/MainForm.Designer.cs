namespace dataGridView
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            statusStripAuto = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabelStatusCar = new ToolStripStatusLabel();
            toolStripMenu = new ToolStrip();
            toolStripButtonProperties = new ToolStripButton();
            dataGridViewCar = new DataGridView();
            CarMakeCol = new DataGridViewComboBoxColumn();
            AutoNumberCol = new DataGridViewTextBoxColumn();
            MileageCol = new DataGridViewTextBoxColumn();
            FuelConsumptionCol = new DataGridViewTextBoxColumn();
            CurrentFuelVolumeCol = new DataGridViewTextBoxColumn();
            RentCostPerMinuteCol = new DataGridViewTextBoxColumn();
            FuelReserveHoursCol = new DataGridViewTextBoxColumn();
            RentAmountCol = new DataGridViewTextBoxColumn();
            statusStripAuto.SuspendLayout();
            toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCar).BeginInit();
            SuspendLayout();
            // 
            // statusStripAuto
            // 
            statusStripAuto.ImageScalingSize = new Size(20, 20);
            statusStripAuto.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabelStatusCar });
            statusStripAuto.Location = new Point(0, 424);
            statusStripAuto.Name = "statusStripAuto";
            statusStripAuto.Size = new Size(1218, 26);
            statusStripAuto.TabIndex = 0;
            statusStripAuto.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(191, 20);
            toolStripStatusLabel1.Text = "Количество автомобилей:";
            // 
            // toolStripStatusLabelStatusCar
            // 
            toolStripStatusLabelStatusCar.Name = "toolStripStatusLabelStatusCar";
            toolStripStatusLabelStatusCar.Size = new Size(408, 20);
            toolStripStatusLabelStatusCar.Text = "автомобилей с критически низким уровнем запаса хода:";
            // 
            // toolStripMenu
            // 
            toolStripMenu.BackColor = SystemColors.ActiveCaption;
            toolStripMenu.ImageScalingSize = new Size(20, 20);
            toolStripMenu.Items.AddRange(new ToolStripItem[] { toolStripButtonProperties });
            toolStripMenu.Location = new Point(0, 0);
            toolStripMenu.Name = "toolStripMenu";
            toolStripMenu.Size = new Size(1218, 27);
            toolStripMenu.TabIndex = 1;
            toolStripMenu.Text = "toolStrip1";
            // 
            // toolStripButtonProperties
            // 
            toolStripButtonProperties.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonProperties.Image = (Image)resources.GetObject("toolStripButtonProperties.Image");
            toolStripButtonProperties.ImageTransparentColor = Color.Magenta;
            toolStripButtonProperties.Name = "toolStripButtonProperties";
            toolStripButtonProperties.Size = new Size(29, 24);
            toolStripButtonProperties.Text = "toolStripButton1";
            toolStripButtonProperties.Click += toolStripButtonProperties_Click;
            // 
            // dataGridViewCar
            // 
            dataGridViewCar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCar.BackgroundColor = Color.SlateGray;
            dataGridViewCar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCar.Columns.AddRange(new DataGridViewColumn[] { CarMakeCol, AutoNumberCol, MileageCol, FuelConsumptionCol, CurrentFuelVolumeCol, RentCostPerMinuteCol, FuelReserveHoursCol, RentAmountCol });
            dataGridViewCar.Dock = DockStyle.Fill;
            dataGridViewCar.Location = new Point(0, 27);
            dataGridViewCar.Name = "dataGridViewCar";
            dataGridViewCar.RowHeadersWidth = 51;
            dataGridViewCar.Size = new Size(1218, 397);
            dataGridViewCar.TabIndex = 2;
            dataGridViewCar.CellFormatting += dataGridViewCar_CellFormatting;
            dataGridViewCar.CellPainting += dataGridViewCar_CellPainting;
            // 
            // CarMakeCol
            // 
            CarMakeCol.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            CarMakeCol.HeaderText = "Марка автомобиля";
            CarMakeCol.MinimumWidth = 6;
            CarMakeCol.Name = "CarMakeCol";
            CarMakeCol.Resizable = DataGridViewTriState.True;
            CarMakeCol.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // AutoNumberCol
            // 
            AutoNumberCol.HeaderText = "Гос. номер";
            AutoNumberCol.MinimumWidth = 6;
            AutoNumberCol.Name = "AutoNumberCol";
            // 
            // MileageCol
            // 
            MileageCol.HeaderText = "Пробег";
            MileageCol.MinimumWidth = 6;
            MileageCol.Name = "MileageCol";
            // 
            // FuelConsumptionCol
            // 
            FuelConsumptionCol.HeaderText = "Средний расход топлива";
            FuelConsumptionCol.MinimumWidth = 6;
            FuelConsumptionCol.Name = "FuelConsumptionCol";
            // 
            // CurrentFuelVolumeCol
            // 
            CurrentFuelVolumeCol.HeaderText = "Текущий объем топлива";
            CurrentFuelVolumeCol.MinimumWidth = 6;
            CurrentFuelVolumeCol.Name = "CurrentFuelVolumeCol";
            // 
            // RentCostPerMinuteCol
            // 
            RentCostPerMinuteCol.HeaderText = "Стоимость аренды (мин)";
            RentCostPerMinuteCol.MinimumWidth = 6;
            RentCostPerMinuteCol.Name = "RentCostPerMinuteCol";
            // 
            // FuelReserveHoursCol
            // 
            FuelReserveHoursCol.HeaderText = "Запас хода (ч)";
            FuelReserveHoursCol.MinimumWidth = 6;
            FuelReserveHoursCol.Name = "FuelReserveHoursCol";
            // 
            // RentAmountCol
            // 
            RentAmountCol.HeaderText = "Сумма аренды";
            RentAmountCol.MinimumWidth = 6;
            RentAmountCol.Name = "RentAmountCol";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1218, 450);
            Controls.Add(dataGridViewCar);
            Controls.Add(toolStripMenu);
            Controls.Add(statusStripAuto);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GoCar";
            statusStripAuto.ResumeLayout(false);
            statusStripAuto.PerformLayout();
            toolStripMenu.ResumeLayout(false);
            toolStripMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStripAuto;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStrip toolStripMenu;
        private ToolStripButton toolStripButtonProperties;
        private DataGridView dataGridViewCar;
        private ToolStripStatusLabel toolStripStatusLabelStatusCar;
        private DataGridViewComboBoxColumn CarMakeCol;
        private DataGridViewTextBoxColumn AutoNumberCol;
        private DataGridViewTextBoxColumn MileageCol;
        private DataGridViewTextBoxColumn FuelConsumptionCol;
        private DataGridViewTextBoxColumn CurrentFuelVolumeCol;
        private DataGridViewTextBoxColumn RentCostPerMinuteCol;
        private DataGridViewTextBoxColumn FuelReserveHoursCol;
        private DataGridViewTextBoxColumn RentAmountCol;
    }
}
