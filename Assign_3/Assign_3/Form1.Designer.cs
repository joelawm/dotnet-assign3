namespace Assign_3
{
    partial class Form1
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
            this.PriceRangeGroupBox = new System.Windows.Forms.GroupBox();
            this.PriceQueryButton = new System.Windows.Forms.Button();
            this.MaxPriceTrackBar = new System.Windows.Forms.TrackBar();
            this.MaxPriceLabel = new System.Windows.Forms.Label();
            this.MinPriceLabel = new System.Windows.Forms.Label();
            this.MinPriceTrackBar = new System.Windows.Forms.TrackBar();
            this.SchoolCheckBox = new System.Windows.Forms.CheckBox();
            this.BuisnessCheckBox = new System.Windows.Forms.CheckBox();
            this.ResidentialtCheckBox = new System.Windows.Forms.CheckBox();
            this.SchoolRangeGroupBox = new System.Windows.Forms.GroupBox();
            this.SchoolQueryButton = new System.Windows.Forms.Button();
            this.SchoolDistanceUpDown = new System.Windows.Forms.NumericUpDown();
            this.SchoolDistanceLabel = new System.Windows.Forms.Label();
            this.SchoolLabel = new System.Windows.Forms.Label();
            this.SchoolCombobox = new System.Windows.Forms.ComboBox();
            this.ParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.GarageCheckBox = new System.Windows.Forms.CheckBox();
            this.ParametersQueryButton = new System.Windows.Forms.Button();
            this.SqFtUpDown = new System.Windows.Forms.NumericUpDown();
            this.SqFtLabel = new System.Windows.Forms.Label();
            this.BathUpDown = new System.Windows.Forms.NumericUpDown();
            this.BathLabel = new System.Windows.Forms.Label();
            this.BedUpDown = new System.Windows.Forms.NumericUpDown();
            this.BedLabel = new System.Windows.Forms.Label();
            this.ApartmentCheckBox = new System.Windows.Forms.CheckBox();
            this.HouseCheckBox = new System.Windows.Forms.CheckBox();
            this.TownersGroupBox = new System.Windows.Forms.GroupBox();
            this.TownersQueryButton = new System.Windows.Forms.Button();
            this.QueryResultsLabel = new System.Windows.Forms.Label();
            this.QueryOutputTextbox = new System.Windows.Forms.TextBox();
            this.BusinessRangeGroupBox = new System.Windows.Forms.GroupBox();
            this.BusinessQueryButton = new System.Windows.Forms.Button();
            this.BusinessDistanceUpDown = new System.Windows.Forms.NumericUpDown();
            this.BusinessDistacnceLabel = new System.Windows.Forms.Label();
            this.ForSaleLabel = new System.Windows.Forms.Label();
            this.ForSaleCombobox = new System.Windows.Forms.ComboBox();
            this.PriceRangeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxPriceTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinPriceTrackBar)).BeginInit();
            this.SchoolRangeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SchoolDistanceUpDown)).BeginInit();
            this.ParametersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SqFtUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BathUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BedUpDown)).BeginInit();
            this.TownersGroupBox.SuspendLayout();
            this.BusinessRangeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BusinessDistanceUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // PriceRangeGroupBox
            // 
            this.PriceRangeGroupBox.Controls.Add(this.PriceQueryButton);
            this.PriceRangeGroupBox.Controls.Add(this.MaxPriceTrackBar);
            this.PriceRangeGroupBox.Controls.Add(this.MaxPriceLabel);
            this.PriceRangeGroupBox.Controls.Add(this.MinPriceLabel);
            this.PriceRangeGroupBox.Controls.Add(this.MinPriceTrackBar);
            this.PriceRangeGroupBox.Controls.Add(this.SchoolCheckBox);
            this.PriceRangeGroupBox.Controls.Add(this.BuisnessCheckBox);
            this.PriceRangeGroupBox.Controls.Add(this.ResidentialtCheckBox);
            this.PriceRangeGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PriceRangeGroupBox.Location = new System.Drawing.Point(12, 12);
            this.PriceRangeGroupBox.Name = "PriceRangeGroupBox";
            this.PriceRangeGroupBox.Size = new System.Drawing.Size(488, 153);
            this.PriceRangeGroupBox.TabIndex = 0;
            this.PriceRangeGroupBox.TabStop = false;
            this.PriceRangeGroupBox.Text = "For Sale Properties Within Price Range";
            // 
            // PriceQueryButton
            // 
            this.PriceQueryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PriceQueryButton.Location = new System.Drawing.Point(346, 24);
            this.PriceQueryButton.Name = "PriceQueryButton";
            this.PriceQueryButton.Size = new System.Drawing.Size(75, 23);
            this.PriceQueryButton.TabIndex = 7;
            this.PriceQueryButton.Text = "Query";
            this.PriceQueryButton.UseVisualStyleBackColor = true;
            this.PriceQueryButton.Click += new System.EventHandler(this.PriceQueryButton_Click);
            // 
            // MaxPriceTrackBar
            // 
            this.MaxPriceTrackBar.LargeChange = 1;
            this.MaxPriceTrackBar.Location = new System.Drawing.Point(101, 103);
            this.MaxPriceTrackBar.Maximum = 350000;
            this.MaxPriceTrackBar.Name = "MaxPriceTrackBar";
            this.MaxPriceTrackBar.Size = new System.Drawing.Size(154, 45);
            this.MaxPriceTrackBar.TabIndex = 6;
            this.MaxPriceTrackBar.Scroll += new System.EventHandler(this.MaxPriceTrackBar_Scroll);
            // 
            // MaxPriceLabel
            // 
            this.MaxPriceLabel.AutoSize = true;
            this.MaxPriceLabel.Location = new System.Drawing.Point(107, 84);
            this.MaxPriceLabel.Name = "MaxPriceLabel";
            this.MaxPriceLabel.Size = new System.Drawing.Size(88, 18);
            this.MaxPriceLabel.TabIndex = 5;
            this.MaxPriceLabel.Text = "Max Price:";
            // 
            // MinPriceLabel
            // 
            this.MinPriceLabel.AutoSize = true;
            this.MinPriceLabel.Location = new System.Drawing.Point(107, 25);
            this.MinPriceLabel.Name = "MinPriceLabel";
            this.MinPriceLabel.Size = new System.Drawing.Size(84, 18);
            this.MinPriceLabel.TabIndex = 4;
            this.MinPriceLabel.Text = "Min Price:";
            // 
            // MinPriceTrackBar
            // 
            this.MinPriceTrackBar.LargeChange = 1;
            this.MinPriceTrackBar.Location = new System.Drawing.Point(101, 45);
            this.MinPriceTrackBar.Maximum = 350000;
            this.MinPriceTrackBar.Name = "MinPriceTrackBar";
            this.MinPriceTrackBar.Size = new System.Drawing.Size(156, 45);
            this.MinPriceTrackBar.TabIndex = 3;
            this.MinPriceTrackBar.Scroll += new System.EventHandler(this.MinPriceTrackBar_Scroll);
            // 
            // SchoolCheckBox
            // 
            this.SchoolCheckBox.AutoSize = true;
            this.SchoolCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SchoolCheckBox.Location = new System.Drawing.Point(7, 82);
            this.SchoolCheckBox.Name = "SchoolCheckBox";
            this.SchoolCheckBox.Size = new System.Drawing.Size(74, 22);
            this.SchoolCheckBox.TabIndex = 2;
            this.SchoolCheckBox.Text = "School";
            this.SchoolCheckBox.UseVisualStyleBackColor = true;
            // 
            // BuisnessCheckBox
            // 
            this.BuisnessCheckBox.AutoSize = true;
            this.BuisnessCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuisnessCheckBox.Location = new System.Drawing.Point(7, 53);
            this.BuisnessCheckBox.Name = "BuisnessCheckBox";
            this.BuisnessCheckBox.Size = new System.Drawing.Size(88, 22);
            this.BuisnessCheckBox.TabIndex = 1;
            this.BuisnessCheckBox.Text = "Buisness";
            this.BuisnessCheckBox.UseVisualStyleBackColor = true;
            // 
            // ResidentialtCheckBox
            // 
            this.ResidentialtCheckBox.AutoSize = true;
            this.ResidentialtCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResidentialtCheckBox.Location = new System.Drawing.Point(7, 24);
            this.ResidentialtCheckBox.Name = "ResidentialtCheckBox";
            this.ResidentialtCheckBox.Size = new System.Drawing.Size(96, 22);
            this.ResidentialtCheckBox.TabIndex = 0;
            this.ResidentialtCheckBox.Text = "Residental";
            this.ResidentialtCheckBox.UseVisualStyleBackColor = true;
            // 
            // SchoolRangeGroupBox
            // 
            this.SchoolRangeGroupBox.Controls.Add(this.SchoolQueryButton);
            this.SchoolRangeGroupBox.Controls.Add(this.SchoolDistanceUpDown);
            this.SchoolRangeGroupBox.Controls.Add(this.SchoolDistanceLabel);
            this.SchoolRangeGroupBox.Controls.Add(this.SchoolLabel);
            this.SchoolRangeGroupBox.Controls.Add(this.SchoolCombobox);
            this.SchoolRangeGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SchoolRangeGroupBox.Location = new System.Drawing.Point(12, 171);
            this.SchoolRangeGroupBox.Name = "SchoolRangeGroupBox";
            this.SchoolRangeGroupBox.Size = new System.Drawing.Size(489, 88);
            this.SchoolRangeGroupBox.TabIndex = 1;
            this.SchoolRangeGroupBox.TabStop = false;
            this.SchoolRangeGroupBox.Text = "For Sale Residences Within Range of a School";
            // 
            // SchoolQueryButton
            // 
            this.SchoolQueryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SchoolQueryButton.Location = new System.Drawing.Point(346, 45);
            this.SchoolQueryButton.Name = "SchoolQueryButton";
            this.SchoolQueryButton.Size = new System.Drawing.Size(75, 23);
            this.SchoolQueryButton.TabIndex = 4;
            this.SchoolQueryButton.Text = "Query";
            this.SchoolQueryButton.UseVisualStyleBackColor = true;
            this.SchoolQueryButton.Click += new System.EventHandler(this.SchoolQueryButton_Click);
            // 
            // SchoolDistanceUpDown
            // 
            this.SchoolDistanceUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SchoolDistanceUpDown.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.SchoolDistanceUpDown.Location = new System.Drawing.Point(196, 46);
            this.SchoolDistanceUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.SchoolDistanceUpDown.Name = "SchoolDistanceUpDown";
            this.SchoolDistanceUpDown.Size = new System.Drawing.Size(135, 24);
            this.SchoolDistanceUpDown.TabIndex = 3;
            // 
            // SchoolDistanceLabel
            // 
            this.SchoolDistanceLabel.AutoSize = true;
            this.SchoolDistanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SchoolDistanceLabel.Location = new System.Drawing.Point(192, 24);
            this.SchoolDistanceLabel.Name = "SchoolDistanceLabel";
            this.SchoolDistanceLabel.Size = new System.Drawing.Size(66, 18);
            this.SchoolDistanceLabel.TabIndex = 2;
            this.SchoolDistanceLabel.Text = "Distance";
            // 
            // SchoolLabel
            // 
            this.SchoolLabel.AutoSize = true;
            this.SchoolLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SchoolLabel.Location = new System.Drawing.Point(7, 24);
            this.SchoolLabel.Name = "SchoolLabel";
            this.SchoolLabel.Size = new System.Drawing.Size(55, 18);
            this.SchoolLabel.TabIndex = 1;
            this.SchoolLabel.Text = "School";
            // 
            // SchoolCombobox
            // 
            this.SchoolCombobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SchoolCombobox.FormattingEnabled = true;
            this.SchoolCombobox.Location = new System.Drawing.Point(6, 45);
            this.SchoolCombobox.Name = "SchoolCombobox";
            this.SchoolCombobox.Size = new System.Drawing.Size(182, 21);
            this.SchoolCombobox.TabIndex = 0;
            this.SchoolCombobox.DropDown += new System.EventHandler(this.SchoolCombobox_DropDown);
            // 
            // ParametersGroupBox
            // 
            this.ParametersGroupBox.Controls.Add(this.GarageCheckBox);
            this.ParametersGroupBox.Controls.Add(this.ParametersQueryButton);
            this.ParametersGroupBox.Controls.Add(this.SqFtUpDown);
            this.ParametersGroupBox.Controls.Add(this.SqFtLabel);
            this.ParametersGroupBox.Controls.Add(this.BathUpDown);
            this.ParametersGroupBox.Controls.Add(this.BathLabel);
            this.ParametersGroupBox.Controls.Add(this.BedUpDown);
            this.ParametersGroupBox.Controls.Add(this.BedLabel);
            this.ParametersGroupBox.Controls.Add(this.ApartmentCheckBox);
            this.ParametersGroupBox.Controls.Add(this.HouseCheckBox);
            this.ParametersGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParametersGroupBox.Location = new System.Drawing.Point(14, 359);
            this.ParametersGroupBox.Name = "ParametersGroupBox";
            this.ParametersGroupBox.Size = new System.Drawing.Size(489, 95);
            this.ParametersGroupBox.TabIndex = 2;
            this.ParametersGroupBox.TabStop = false;
            this.ParametersGroupBox.Text = "Specific Residence Parameters";
            // 
            // GarageCheckBox
            // 
            this.GarageCheckBox.AutoSize = true;
            this.GarageCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GarageCheckBox.Location = new System.Drawing.Point(262, 24);
            this.GarageCheckBox.Name = "GarageCheckBox";
            this.GarageCheckBox.Size = new System.Drawing.Size(76, 22);
            this.GarageCheckBox.TabIndex = 8;
            this.GarageCheckBox.Text = "Garage";
            this.GarageCheckBox.UseVisualStyleBackColor = true;
            // 
            // ParametersQueryButton
            // 
            this.ParametersQueryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParametersQueryButton.Location = new System.Drawing.Point(344, 24);
            this.ParametersQueryButton.Name = "ParametersQueryButton";
            this.ParametersQueryButton.Size = new System.Drawing.Size(75, 23);
            this.ParametersQueryButton.TabIndex = 5;
            this.ParametersQueryButton.Text = "Query";
            this.ParametersQueryButton.UseVisualStyleBackColor = true;
            this.ParametersQueryButton.Click += new System.EventHandler(this.ParametersQueryButton_Click);
            // 
            // SqFtUpDown
            // 
            this.SqFtUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SqFtUpDown.Increment = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.SqFtUpDown.Location = new System.Drawing.Point(183, 49);
            this.SqFtUpDown.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.SqFtUpDown.Minimum = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            this.SqFtUpDown.Name = "SqFtUpDown";
            this.SqFtUpDown.Size = new System.Drawing.Size(70, 24);
            this.SqFtUpDown.TabIndex = 7;
            this.SqFtUpDown.Value = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            // 
            // SqFtLabel
            // 
            this.SqFtLabel.AutoSize = true;
            this.SqFtLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SqFtLabel.Location = new System.Drawing.Point(180, 24);
            this.SqFtLabel.Name = "SqFtLabel";
            this.SqFtLabel.Size = new System.Drawing.Size(75, 18);
            this.SqFtLabel.TabIndex = 6;
            this.SqFtLabel.Text = "Min Sq Ft.";
            // 
            // BathUpDown
            // 
            this.BathUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BathUpDown.Location = new System.Drawing.Point(136, 49);
            this.BathUpDown.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.BathUpDown.Name = "BathUpDown";
            this.BathUpDown.Size = new System.Drawing.Size(34, 24);
            this.BathUpDown.TabIndex = 5;
            // 
            // BathLabel
            // 
            this.BathLabel.AutoSize = true;
            this.BathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BathLabel.Location = new System.Drawing.Point(136, 24);
            this.BathLabel.Name = "BathLabel";
            this.BathLabel.Size = new System.Drawing.Size(38, 18);
            this.BathLabel.TabIndex = 4;
            this.BathLabel.Text = "Bath";
            // 
            // BedUpDown
            // 
            this.BedUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BedUpDown.Location = new System.Drawing.Point(96, 49);
            this.BedUpDown.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.BedUpDown.Name = "BedUpDown";
            this.BedUpDown.Size = new System.Drawing.Size(34, 24);
            this.BedUpDown.TabIndex = 3;
            // 
            // BedLabel
            // 
            this.BedLabel.AutoSize = true;
            this.BedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BedLabel.Location = new System.Drawing.Point(96, 24);
            this.BedLabel.Name = "BedLabel";
            this.BedLabel.Size = new System.Drawing.Size(34, 18);
            this.BedLabel.TabIndex = 2;
            this.BedLabel.Text = "Bed";
            // 
            // ApartmentCheckBox
            // 
            this.ApartmentCheckBox.AutoSize = true;
            this.ApartmentCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApartmentCheckBox.Location = new System.Drawing.Point(6, 51);
            this.ApartmentCheckBox.Name = "ApartmentCheckBox";
            this.ApartmentCheckBox.Size = new System.Drawing.Size(94, 22);
            this.ApartmentCheckBox.TabIndex = 1;
            this.ApartmentCheckBox.Text = "Apartment";
            this.ApartmentCheckBox.UseVisualStyleBackColor = true;
            // 
            // HouseCheckBox
            // 
            this.HouseCheckBox.AutoSize = true;
            this.HouseCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HouseCheckBox.Location = new System.Drawing.Point(6, 23);
            this.HouseCheckBox.Name = "HouseCheckBox";
            this.HouseCheckBox.Size = new System.Drawing.Size(71, 22);
            this.HouseCheckBox.TabIndex = 0;
            this.HouseCheckBox.Text = "House";
            this.HouseCheckBox.UseVisualStyleBackColor = true;
            // 
            // TownersGroupBox
            // 
            this.TownersGroupBox.Controls.Add(this.TownersQueryButton);
            this.TownersGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TownersGroupBox.Location = new System.Drawing.Point(14, 460);
            this.TownersGroupBox.Name = "TownersGroupBox";
            this.TownersGroupBox.Size = new System.Drawing.Size(489, 58);
            this.TownersGroupBox.TabIndex = 2;
            this.TownersGroupBox.TabStop = false;
            this.TownersGroupBox.Text = "List of Properties Owned by Out-Of-Towners";
            // 
            // TownersQueryButton
            // 
            this.TownersQueryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TownersQueryButton.Location = new System.Drawing.Point(344, 23);
            this.TownersQueryButton.Name = "TownersQueryButton";
            this.TownersQueryButton.Size = new System.Drawing.Size(75, 23);
            this.TownersQueryButton.TabIndex = 9;
            this.TownersQueryButton.Text = "Query";
            this.TownersQueryButton.UseVisualStyleBackColor = true;
            // 
            // QueryResultsLabel
            // 
            this.QueryResultsLabel.AutoSize = true;
            this.QueryResultsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QueryResultsLabel.Location = new System.Drawing.Point(507, 9);
            this.QueryResultsLabel.Name = "QueryResultsLabel";
            this.QueryResultsLabel.Size = new System.Drawing.Size(115, 18);
            this.QueryResultsLabel.TabIndex = 3;
            this.QueryResultsLabel.Text = "Query Results";
            // 
            // QueryOutputTextbox
            // 
            this.QueryOutputTextbox.Location = new System.Drawing.Point(509, 30);
            this.QueryOutputTextbox.Multiline = true;
            this.QueryOutputTextbox.Name = "QueryOutputTextbox";
            this.QueryOutputTextbox.Size = new System.Drawing.Size(526, 488);
            this.QueryOutputTextbox.TabIndex = 4;
            // 
            // BusinessRangeGroupBox
            // 
            this.BusinessRangeGroupBox.Controls.Add(this.BusinessQueryButton);
            this.BusinessRangeGroupBox.Controls.Add(this.BusinessDistanceUpDown);
            this.BusinessRangeGroupBox.Controls.Add(this.BusinessDistacnceLabel);
            this.BusinessRangeGroupBox.Controls.Add(this.ForSaleLabel);
            this.BusinessRangeGroupBox.Controls.Add(this.ForSaleCombobox);
            this.BusinessRangeGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BusinessRangeGroupBox.Location = new System.Drawing.Point(12, 265);
            this.BusinessRangeGroupBox.Name = "BusinessRangeGroupBox";
            this.BusinessRangeGroupBox.Size = new System.Drawing.Size(489, 88);
            this.BusinessRangeGroupBox.TabIndex = 5;
            this.BusinessRangeGroupBox.TabStop = false;
            this.BusinessRangeGroupBox.Text = "Hiring Business(es) Witin Range of For Sale Residence";
            // 
            // BusinessQueryButton
            // 
            this.BusinessQueryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BusinessQueryButton.Location = new System.Drawing.Point(346, 45);
            this.BusinessQueryButton.Name = "BusinessQueryButton";
            this.BusinessQueryButton.Size = new System.Drawing.Size(75, 23);
            this.BusinessQueryButton.TabIndex = 4;
            this.BusinessQueryButton.Text = "Query";
            this.BusinessQueryButton.UseVisualStyleBackColor = true;
            this.BusinessQueryButton.Click += new System.EventHandler(this.BusinessQueryButton_Click);
            // 
            // BusinessDistanceUpDown
            // 
            this.BusinessDistanceUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BusinessDistanceUpDown.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.BusinessDistanceUpDown.Location = new System.Drawing.Point(196, 46);
            this.BusinessDistanceUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.BusinessDistanceUpDown.Name = "BusinessDistanceUpDown";
            this.BusinessDistanceUpDown.Size = new System.Drawing.Size(135, 24);
            this.BusinessDistanceUpDown.TabIndex = 3;
            // 
            // BusinessDistacnceLabel
            // 
            this.BusinessDistacnceLabel.AutoSize = true;
            this.BusinessDistacnceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BusinessDistacnceLabel.Location = new System.Drawing.Point(192, 24);
            this.BusinessDistacnceLabel.Name = "BusinessDistacnceLabel";
            this.BusinessDistacnceLabel.Size = new System.Drawing.Size(66, 18);
            this.BusinessDistacnceLabel.TabIndex = 2;
            this.BusinessDistacnceLabel.Text = "Distance";
            // 
            // ForSaleLabel
            // 
            this.ForSaleLabel.AutoSize = true;
            this.ForSaleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForSaleLabel.Location = new System.Drawing.Point(7, 24);
            this.ForSaleLabel.Name = "ForSaleLabel";
            this.ForSaleLabel.Size = new System.Drawing.Size(139, 18);
            this.ForSaleLabel.TabIndex = 1;
            this.ForSaleLabel.Text = "For-Sale Residence";
            // 
            // ForSaleCombobox
            // 
            this.ForSaleCombobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForSaleCombobox.FormattingEnabled = true;
            this.ForSaleCombobox.Location = new System.Drawing.Point(6, 45);
            this.ForSaleCombobox.MaxDropDownItems = 10;
            this.ForSaleCombobox.Name = "ForSaleCombobox";
            this.ForSaleCombobox.Size = new System.Drawing.Size(182, 21);
            this.ForSaleCombobox.TabIndex = 0;
            this.ForSaleCombobox.DropDown += new System.EventHandler(this.ForSaleCombobox_DropDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 527);
            this.Controls.Add(this.BusinessRangeGroupBox);
            this.Controls.Add(this.QueryOutputTextbox);
            this.Controls.Add(this.QueryResultsLabel);
            this.Controls.Add(this.TownersGroupBox);
            this.Controls.Add(this.ParametersGroupBox);
            this.Controls.Add(this.SchoolRangeGroupBox);
            this.Controls.Add(this.PriceRangeGroupBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.PriceRangeGroupBox.ResumeLayout(false);
            this.PriceRangeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxPriceTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinPriceTrackBar)).EndInit();
            this.SchoolRangeGroupBox.ResumeLayout(false);
            this.SchoolRangeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SchoolDistanceUpDown)).EndInit();
            this.ParametersGroupBox.ResumeLayout(false);
            this.ParametersGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SqFtUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BathUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BedUpDown)).EndInit();
            this.TownersGroupBox.ResumeLayout(false);
            this.BusinessRangeGroupBox.ResumeLayout(false);
            this.BusinessRangeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BusinessDistanceUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox PriceRangeGroupBox;
        private System.Windows.Forms.GroupBox SchoolRangeGroupBox;
        private System.Windows.Forms.GroupBox ParametersGroupBox;
        private System.Windows.Forms.GroupBox TownersGroupBox;
        private System.Windows.Forms.Label QueryResultsLabel;
        private System.Windows.Forms.TextBox QueryOutputTextbox;
        private System.Windows.Forms.Button PriceQueryButton;
        private System.Windows.Forms.TrackBar MaxPriceTrackBar;
        private System.Windows.Forms.Label MaxPriceLabel;
        private System.Windows.Forms.Label MinPriceLabel;
        private System.Windows.Forms.TrackBar MinPriceTrackBar;
        private System.Windows.Forms.CheckBox SchoolCheckBox;
        private System.Windows.Forms.CheckBox BuisnessCheckBox;
        private System.Windows.Forms.CheckBox ResidentialtCheckBox;
        private System.Windows.Forms.Button SchoolQueryButton;
        private System.Windows.Forms.NumericUpDown SchoolDistanceUpDown;
        private System.Windows.Forms.Label SchoolDistanceLabel;
        private System.Windows.Forms.Label SchoolLabel;
        private System.Windows.Forms.ComboBox SchoolCombobox;
        private System.Windows.Forms.GroupBox BusinessRangeGroupBox;
        private System.Windows.Forms.Button BusinessQueryButton;
        private System.Windows.Forms.NumericUpDown BusinessDistanceUpDown;
        private System.Windows.Forms.Label BusinessDistacnceLabel;
        private System.Windows.Forms.Label ForSaleLabel;
        private System.Windows.Forms.ComboBox ForSaleCombobox;
        private System.Windows.Forms.NumericUpDown BedUpDown;
        private System.Windows.Forms.Label BedLabel;
        private System.Windows.Forms.CheckBox ApartmentCheckBox;
        private System.Windows.Forms.CheckBox HouseCheckBox;
        private System.Windows.Forms.NumericUpDown SqFtUpDown;
        private System.Windows.Forms.Label SqFtLabel;
        private System.Windows.Forms.NumericUpDown BathUpDown;
        private System.Windows.Forms.Label BathLabel;
        private System.Windows.Forms.CheckBox GarageCheckBox;
        private System.Windows.Forms.Button ParametersQueryButton;
        private System.Windows.Forms.Button TownersQueryButton;
    }
}

