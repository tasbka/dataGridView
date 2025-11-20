
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
            statusStripAuto = new StatusStrip();
            toolStripStatusLabelCount = new ToolStripStatusLabel();
            toolStripStatusLabelStatusCar = new ToolStripStatusLabel();
            toolStripMenu = new ToolStrip();
            toolStripButtonProperties = new ToolStripButton();
            toolStripButtonEdit = new ToolStripButton();
            toolStripButtonDel = new ToolStripButton();
            CarMakeCol = new DataGridViewComboBoxColumn();
            AutoNumberCol = new DataGridViewTextBoxColumn();
            MileageCol = new DataGridViewTextBoxColumn();
            FuelConsumptionCol = new DataGridViewTextBoxColumn();
            CurrentFuelVolumeCol = new DataGridViewTextBoxColumn();
            RentCostPerMinuteCol = new DataGridViewTextBoxColumn();
            FuelReserveHoursCol = new DataGridViewTextBoxColumn();
            RentAmountCol = new DataGridViewTextBoxColumn();
            dataGridViewCar = new System.Windows.Forms.DataGridView();
            CarMakeCol1 = new DataGridViewTextBoxColumn();
            AutoNumberCol1 = new DataGridViewTextBoxColumn();
            MileageCol1 = new DataGridViewTextBoxColumn();
            FuelConsumptionCol1 = new DataGridViewTextBoxColumn();
            CurrentFuelVolumeCol1 = new DataGridViewTextBoxColumn();
            RentCostPerMinuteCol1 = new DataGridViewTextBoxColumn();
            statusStripAuto.SuspendLayout();
            toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCar).BeginInit();
            SuspendLayout();
            // 
            // statusStripAuto
            // 
            statusStripAuto.ImageScalingSize = new Size(20, 20);
            statusStripAuto.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelCount, toolStripStatusLabelStatusCar });
            statusStripAuto.Location = new Point(0, 424);
            statusStripAuto.Name = "statusStripAuto";
            statusStripAuto.Size = new Size(1218, 26);
            statusStripAuto.TabIndex = 0;
            statusStripAuto.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCount
            // 
            toolStripStatusLabelCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            toolStripStatusLabelCount.Name = "toolStripStatusLabelCount";
            toolStripStatusLabelCount.Size = new Size(201, 20);
            toolStripStatusLabelCount.Text = "Количество автомобилей:";
            // 
            // toolStripStatusLabelStatusCar
            // 
            toolStripStatusLabelStatusCar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            toolStripStatusLabelStatusCar.Name = "toolStripStatusLabelStatusCar";
            toolStripStatusLabelStatusCar.Size = new Size(424, 20);
            toolStripStatusLabelStatusCar.Text = "автомобилей с критически низким уровнем запаса хода:";
            // 
            // toolStripMenu
            // 
            toolStripMenu.BackColor = Color.LightBlue;
            toolStripMenu.ImageScalingSize = new Size(20, 20);
            toolStripMenu.Items.AddRange(new ToolStripItem[] { toolStripButtonProperties, toolStripButtonEdit, toolStripButtonDel });
            toolStripMenu.Location = new Point(0, 0);
            toolStripMenu.Name = "toolStripMenu";
            toolStripMenu.Size = new Size(1218, 27);
            toolStripMenu.TabIndex = 1;
            toolStripMenu.Text = "toolStrip1";
            // 
            // toolStripButtonProperties
            // 
            toolStripButtonProperties.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonProperties.Image = DataGridViewProject.Properties.Resources.добавить;
            toolStripButtonProperties.ImageTransparentColor = Color.Magenta;
            toolStripButtonProperties.Name = "toolStripButtonProperties";
            toolStripButtonProperties.Size = new Size(29, 24);
            toolStripButtonProperties.Text = "toolStripButton1";
            toolStripButtonProperties.Click += toolStripButtonProperties_Click;
            // 
            // toolStripButtonEdit
            // 
            toolStripButtonEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonEdit.Image = DataGridViewProject.Properties.Resources.редактировать;
            toolStripButtonEdit.ImageTransparentColor = Color.Magenta;
            toolStripButtonEdit.Name = "toolStripButtonEdit";
            toolStripButtonEdit.Size = new Size(29, 24);
            toolStripButtonEdit.Text = "toolStripButton1";
            toolStripButtonEdit.Click += toolStripButtonEdit_Click;
            // 
            // toolStripButtonDel
            // 
            toolStripButtonDel.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonDel.Image = DataGridViewProject.Properties.Resources.удалить;
            toolStripButtonDel.ImageTransparentColor = Color.Magenta;
            toolStripButtonDel.Name = "toolStripButtonDel";
            toolStripButtonDel.Size = new Size(29, 24);
            toolStripButtonDel.Text = "toolStripButton2";
            toolStripButtonDel.Click += toolStripButtonDel_Click;
            // 
            // CarMakeCol
            // 
            CarMakeCol.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            CarMakeCol.HeaderText = "Марка автомобиля";
            CarMakeCol.MinimumWidth = 6;
            CarMakeCol.Name = "CarMakeCol";
            CarMakeCol.ReadOnly = true;
            CarMakeCol.Resizable = DataGridViewTriState.True;
            CarMakeCol.SortMode = DataGridViewColumnSortMode.Automatic;
            CarMakeCol.Width = 125;
            // 
            // AutoNumberCol
            // 
            AutoNumberCol.HeaderText = "Гос. номер";
            AutoNumberCol.MinimumWidth = 6;
            AutoNumberCol.Name = "AutoNumberCol";
            AutoNumberCol.ReadOnly = true;
            AutoNumberCol.Width = 125;
            // 
            // MileageCol
            // 
            MileageCol.HeaderText = "Пробег";
            MileageCol.MinimumWidth = 6;
            MileageCol.Name = "MileageCol";
            MileageCol.ReadOnly = true;
            MileageCol.Width = 125;
            // 
            // FuelConsumptionCol
            // 
            FuelConsumptionCol.HeaderText = "Средний расход топлива";
            FuelConsumptionCol.MinimumWidth = 6;
            FuelConsumptionCol.Name = "FuelConsumptionCol";
            FuelConsumptionCol.ReadOnly = true;
            FuelConsumptionCol.Width = 125;
            // 
            // CurrentFuelVolumeCol
            // 
            CurrentFuelVolumeCol.HeaderText = "Текущий объем топлива";
            CurrentFuelVolumeCol.MinimumWidth = 6;
            CurrentFuelVolumeCol.Name = "CurrentFuelVolumeCol";
            CurrentFuelVolumeCol.ReadOnly = true;
            CurrentFuelVolumeCol.Width = 125;
            // 
            // RentCostPerMinuteCol
            // 
            RentCostPerMinuteCol.HeaderText = "Стоимость аренды (мин)";
            RentCostPerMinuteCol.MinimumWidth = 6;
            RentCostPerMinuteCol.Name = "RentCostPerMinuteCol";
            RentCostPerMinuteCol.ReadOnly = true;
            RentCostPerMinuteCol.Width = 125;
            // 
            // FuelReserveHoursCol
            // 
            FuelReserveHoursCol.HeaderText = "Запас хода (ч)";
            FuelReserveHoursCol.MinimumWidth = 6;
            FuelReserveHoursCol.Name = "FuelReserveHoursCol";
            FuelReserveHoursCol.ReadOnly = true;
            FuelReserveHoursCol.Width = 125;
            // 
            // RentAmountCol
            // 
            RentAmountCol.HeaderText = "Сумма аренды";
            RentAmountCol.MinimumWidth = 6;
            RentAmountCol.Name = "RentAmountCol";
            RentAmountCol.ReadOnly = true;
            RentAmountCol.Width = 125;
            // 
            // dataGridViewCar
            // 
            dataGridViewCar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCar.BackgroundColor = SystemColors.ButtonFace;
            dataGridViewCar.BorderStyle = BorderStyle.None;
            dataGridViewCar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCar.Columns.AddRange(new DataGridViewColumn[] { CarMakeCol1, AutoNumberCol1, MileageCol1, FuelConsumptionCol1, CurrentFuelVolumeCol1, RentCostPerMinuteCol1 });
            dataGridViewCar.Dock = DockStyle.Fill;
            dataGridViewCar.Location = new Point(0, 27);
            dataGridViewCar.Name = "dataGridViewCar";
            dataGridViewCar.RowHeadersWidth = 51;
            dataGridViewCar.Size = new Size(1218, 397);
            dataGridViewCar.TabIndex = 2;
            dataGridViewCar.CellContentClick += dataGridViewCar_CellContentClick;
            dataGridViewCar.CellFormatting += dataGridViewCar_CellFormatting_1;
            // 
            // CarMakeCol1
            // 
            CarMakeCol1.HeaderText = "Марка ";
            CarMakeCol1.MinimumWidth = 6;
            CarMakeCol1.Name = "CarMakeCol1";
            // 
            // AutoNumberCol1
            // 
            AutoNumberCol1.HeaderText = "Номер";
            AutoNumberCol1.MinimumWidth = 6;
            AutoNumberCol1.Name = "AutoNumberCol1";
            // 
            // MileageCol1
            // 
            MileageCol1.HeaderText = "Пробег";
            MileageCol1.MinimumWidth = 6;
            MileageCol1.Name = "MileageCol1";
            // 
            // FuelConsumptionCol1
            // 
            FuelConsumptionCol1.HeaderText = "Расход топлива";
            FuelConsumptionCol1.MinimumWidth = 6;
            FuelConsumptionCol1.Name = "FuelConsumptionCol1";
            // 
            // CurrentFuelVolumeCol1
            // 
            CurrentFuelVolumeCol1.HeaderText = "Объем топлива";
            CurrentFuelVolumeCol1.MinimumWidth = 6;
            CurrentFuelVolumeCol1.Name = "CurrentFuelVolumeCol1";
            // 
            // RentCostPerMinuteCol1
            // 
            RentCostPerMinuteCol1.HeaderText = "Цена аренды";
            RentCostPerMinuteCol1.MinimumWidth = 6;
            RentCostPerMinuteCol1.Name = "RentCostPerMinuteCol1";
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
            Load += MainForm_Load;
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
        private ToolStripStatusLabel toolStripStatusLabelCount;
        private ToolStrip toolStripMenu;
        private ToolStripButton toolStripButtonProperties;
        //private DataGridView dataGridViewCar;
        private ToolStripStatusLabel toolStripStatusLabelStatusCar;
        private DataGridViewComboBoxColumn CarMakeCol;
        private DataGridViewTextBoxColumn AutoNumberCol;
        private DataGridViewTextBoxColumn MileageCol;
        private DataGridViewTextBoxColumn FuelConsumptionCol;
        private DataGridViewTextBoxColumn CurrentFuelVolumeCol;
        private DataGridViewTextBoxColumn RentCostPerMinuteCol;
        private DataGridViewTextBoxColumn FuelReserveHoursCol;
        private DataGridViewTextBoxColumn RentAmountCol;
        private ToolStripButton toolStripButtonEdit;
        private ToolStripButton toolStripButtonDel;
        private System.Windows.Forms.DataGridView dataGridViewCar;
        private DataGridViewTextBoxColumn CarMakeCol1;
        private DataGridViewTextBoxColumn AutoNumberCol1;
        private DataGridViewTextBoxColumn MileageCol1;
        private DataGridViewTextBoxColumn FuelConsumptionCol1;
        private DataGridViewTextBoxColumn CurrentFuelVolumeCol1;
        private DataGridViewTextBoxColumn RentCostPerMinuteCol1;
    }
}
