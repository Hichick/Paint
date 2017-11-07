namespace paint
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_add2 = new System.Windows.Forms.Button();
            this.button_add3 = new System.Windows.Forms.Button();
            this.button_add4 = new System.Windows.Forms.Button();
            this.button_del = new System.Windows.Forms.Button();
            this.button_sdvig_x = new System.Windows.Forms.Button();
            this.radioButton_local = new System.Windows.Forms.RadioButton();
            this.radioButton_global = new System.Windows.Forms.RadioButton();
            this.checkBox_O = new System.Windows.Forms.CheckBox();
            this.button_serkal = new System.Windows.Forms.Button();
            this.checkBox_y = new System.Windows.Forms.CheckBox();
            this.checkBox_x = new System.Windows.Forms.CheckBox();
            this.button_povorot = new System.Windows.Forms.Button();
            this.button_razmer_x = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.выйтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отрезокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.треугольникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.четырехугольникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.правкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограмеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Exit_program = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button_Add_Cadr = new System.Windows.Forms.Button();
            this.button_Delete_card = new System.Windows.Forms.Button();
            this.Cadr_Text = new System.Windows.Forms.Label();
            this.All_cadr_text = new System.Windows.Forms.Label();
            this.button_Next_cadr = new System.Windows.Forms.Button();
            this.button_Prev_cadr = new System.Windows.Forms.Button();
            this.button_move_cadr = new System.Windows.Forms.Button();
            this.textBox_Move_x = new System.Windows.Forms.TextBox();
            this.textBox_Move_y = new System.Windows.Forms.TextBox();
            this.textBox_Gradus = new System.Windows.Forms.TextBox();
            this.textBox_Zoom_x = new System.Windows.Forms.TextBox();
            this.textBox_Zoom_y = new System.Windows.Forms.TextBox();
            this.textBox_Cadr = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(4, 32);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(765, 516);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // button_add2
            // 
            this.button_add2.Location = new System.Drawing.Point(777, 32);
            this.button_add2.Margin = new System.Windows.Forms.Padding(4);
            this.button_add2.Name = "button_add2";
            this.button_add2.Size = new System.Drawing.Size(139, 36);
            this.button_add2.TabIndex = 1;
            this.button_add2.Text = "Создать отрезок";
            this.button_add2.UseVisualStyleBackColor = true;
            this.button_add2.Click += new System.EventHandler(this.button_add2_Click);
            // 
            // button_add3
            // 
            this.button_add3.Location = new System.Drawing.Point(917, 32);
            this.button_add3.Margin = new System.Windows.Forms.Padding(4);
            this.button_add3.Name = "button_add3";
            this.button_add3.Size = new System.Drawing.Size(170, 36);
            this.button_add3.TabIndex = 2;
            this.button_add3.Text = "Создать треугольник";
            this.button_add3.UseVisualStyleBackColor = true;
            this.button_add3.Click += new System.EventHandler(this.button_add3_Click);
            // 
            // button_add4
            // 
            this.button_add4.Location = new System.Drawing.Point(1087, 32);
            this.button_add4.Margin = new System.Windows.Forms.Padding(4);
            this.button_add4.Name = "button_add4";
            this.button_add4.Size = new System.Drawing.Size(196, 36);
            this.button_add4.TabIndex = 3;
            this.button_add4.Text = "Создать четырехугольник";
            this.button_add4.UseVisualStyleBackColor = true;
            this.button_add4.Click += new System.EventHandler(this.button_add4_Click);
            // 
            // button_del
            // 
            this.button_del.Location = new System.Drawing.Point(777, 109);
            this.button_del.Margin = new System.Windows.Forms.Padding(4);
            this.button_del.Name = "button_del";
            this.button_del.Size = new System.Drawing.Size(506, 31);
            this.button_del.TabIndex = 4;
            this.button_del.Text = "Удалить";
            this.button_del.UseVisualStyleBackColor = true;
            this.button_del.Click += new System.EventHandler(this.button_del_Click);
            // 
            // button_sdvig_x
            // 
            this.button_sdvig_x.Location = new System.Drawing.Point(1087, 153);
            this.button_sdvig_x.Margin = new System.Windows.Forms.Padding(4);
            this.button_sdvig_x.Name = "button_sdvig_x";
            this.button_sdvig_x.Size = new System.Drawing.Size(196, 26);
            this.button_sdvig_x.TabIndex = 12;
            this.button_sdvig_x.Text = "Перемещение";
            this.button_sdvig_x.UseVisualStyleBackColor = true;
            this.button_sdvig_x.Click += new System.EventHandler(this.Move_Element);
            // 
            // radioButton_local
            // 
            this.radioButton_local.AutoSize = true;
            this.radioButton_local.Location = new System.Drawing.Point(954, 80);
            this.radioButton_local.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_local.Name = "radioButton_local";
            this.radioButton_local.Size = new System.Drawing.Size(159, 21);
            this.radioButton_local.TabIndex = 15;
            this.radioButton_local.TabStop = true;
            this.radioButton_local.Text = "Локальная система";
            this.radioButton_local.UseVisualStyleBackColor = true;
            // 
            // radioButton_global
            // 
            this.radioButton_global.AutoSize = true;
            this.radioButton_global.Location = new System.Drawing.Point(780, 80);
            this.radioButton_global.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_global.Name = "radioButton_global";
            this.radioButton_global.Size = new System.Drawing.Size(166, 21);
            this.radioButton_global.TabIndex = 16;
            this.radioButton_global.TabStop = true;
            this.radioButton_global.Text = "Глобальная система";
            this.radioButton_global.UseVisualStyleBackColor = true;
            // 
            // checkBox_O
            // 
            this.checkBox_O.AutoSize = true;
            this.checkBox_O.Location = new System.Drawing.Point(916, 273);
            this.checkBox_O.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_O.Name = "checkBox_O";
            this.checkBox_O.Size = new System.Drawing.Size(154, 21);
            this.checkBox_O.TabIndex = 22;
            this.checkBox_O.Text = "Начало координат";
            this.checkBox_O.UseVisualStyleBackColor = true;
            this.checkBox_O.CheckedChanged += new System.EventHandler(this.checkBox_O_CheckedChanged);
            // 
            // button_serkal
            // 
            this.button_serkal.Location = new System.Drawing.Point(1087, 267);
            this.button_serkal.Margin = new System.Windows.Forms.Padding(4);
            this.button_serkal.Name = "button_serkal";
            this.button_serkal.Size = new System.Drawing.Size(196, 31);
            this.button_serkal.TabIndex = 21;
            this.button_serkal.Text = "Зеркалирование";
            this.button_serkal.UseVisualStyleBackColor = true;
            this.button_serkal.Click += new System.EventHandler(this.button_mirror_Click);
            // 
            // checkBox_y
            // 
            this.checkBox_y.AutoSize = true;
            this.checkBox_y.Location = new System.Drawing.Point(850, 273);
            this.checkBox_y.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_y.Name = "checkBox_y";
            this.checkBox_y.Size = new System.Drawing.Size(63, 21);
            this.checkBox_y.TabIndex = 20;
            this.checkBox_y.Text = "ось у";
            this.checkBox_y.UseVisualStyleBackColor = true;
            this.checkBox_y.CheckedChanged += new System.EventHandler(this.checkBox_y_CheckedChanged);
            // 
            // checkBox_x
            // 
            this.checkBox_x.AutoSize = true;
            this.checkBox_x.Location = new System.Drawing.Point(780, 273);
            this.checkBox_x.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_x.Name = "checkBox_x";
            this.checkBox_x.Size = new System.Drawing.Size(62, 21);
            this.checkBox_x.TabIndex = 19;
            this.checkBox_x.Text = "ось х";
            this.checkBox_x.UseVisualStyleBackColor = true;
            this.checkBox_x.CheckedChanged += new System.EventHandler(this.checkBox_x_CheckedChanged);
            // 
            // button_povorot
            // 
            this.button_povorot.Location = new System.Drawing.Point(1087, 228);
            this.button_povorot.Margin = new System.Windows.Forms.Padding(4);
            this.button_povorot.Name = "button_povorot";
            this.button_povorot.Size = new System.Drawing.Size(196, 31);
            this.button_povorot.TabIndex = 23;
            this.button_povorot.Text = "Поворот";
            this.button_povorot.UseVisualStyleBackColor = true;
            this.button_povorot.Click += new System.EventHandler(this.button_povorot_Click);
            // 
            // button_razmer_x
            // 
            this.button_razmer_x.Location = new System.Drawing.Point(1087, 194);
            this.button_razmer_x.Margin = new System.Windows.Forms.Padding(4);
            this.button_razmer_x.Name = "button_razmer_x";
            this.button_razmer_x.Size = new System.Drawing.Size(196, 26);
            this.button_razmer_x.TabIndex = 26;
            this.button_razmer_x.Text = "Масштабирование";
            this.button_razmer_x.UseVisualStyleBackColor = true;
            this.button_razmer_x.Click += new System.EventHandler(this.button_zoom);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 396);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 17);
            this.label3.TabIndex = 25;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.добавитьToolStripMenuItem,
            this.правкаToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1288, 28);
            this.menuStrip1.TabIndex = 30;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.toolStripSeparator2,
            this.сохранитьToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem,
            this.toolStripSeparator1,
            this.выйтиToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(187, 24);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(184, 6);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(187, 24);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(187, 24);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как...";
            this.сохранитьКакToolStripMenuItem.Click += new System.EventHandler(this.сохранитьКакToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(184, 6);
            // 
            // выйтиToolStripMenuItem
            // 
            this.выйтиToolStripMenuItem.Name = "выйтиToolStripMenuItem";
            this.выйтиToolStripMenuItem.Size = new System.Drawing.Size(187, 24);
            this.выйтиToolStripMenuItem.Text = "Выйти";
            this.выйтиToolStripMenuItem.Click += new System.EventHandler(this.выйтиToolStripMenuItem_Click);
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отрезокToolStripMenuItem,
            this.треугольникToolStripMenuItem,
            this.четырехугольникToolStripMenuItem});
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            // 
            // отрезокToolStripMenuItem
            // 
            this.отрезокToolStripMenuItem.Name = "отрезокToolStripMenuItem";
            this.отрезокToolStripMenuItem.Size = new System.Drawing.Size(200, 24);
            this.отрезокToolStripMenuItem.Text = "Отрезок";
            this.отрезокToolStripMenuItem.Click += new System.EventHandler(this.отрезокToolStripMenuItem_Click);
            // 
            // треугольникToolStripMenuItem
            // 
            this.треугольникToolStripMenuItem.Name = "треугольникToolStripMenuItem";
            this.треугольникToolStripMenuItem.Size = new System.Drawing.Size(200, 24);
            this.треугольникToolStripMenuItem.Text = "Треугольник";
            this.треугольникToolStripMenuItem.Click += new System.EventHandler(this.треугольникToolStripMenuItem_Click);
            // 
            // четырехугольникToolStripMenuItem
            // 
            this.четырехугольникToolStripMenuItem.Name = "четырехугольникToolStripMenuItem";
            this.четырехугольникToolStripMenuItem.Size = new System.Drawing.Size(200, 24);
            this.четырехугольникToolStripMenuItem.Text = "Четырехугольник";
            this.четырехугольникToolStripMenuItem.Click += new System.EventHandler(this.четырехугольникToolStripMenuItem_Click);
            // 
            // правкаToolStripMenuItem
            // 
            this.правкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.очиститьToolStripMenuItem});
            this.правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            this.правкаToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.правкаToolStripMenuItem.Text = "Правка";
            // 
            // очиститьToolStripMenuItem
            // 
            this.очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            this.очиститьToolStripMenuItem.Size = new System.Drawing.Size(142, 24);
            this.очиститьToolStripMenuItem.Text = "Очистить";
            this.очиститьToolStripMenuItem.Click += new System.EventHandler(this.очиститьToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограмеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограмеToolStripMenuItem
            // 
            this.оПрограмеToolStripMenuItem.Name = "оПрограмеToolStripMenuItem";
            this.оПрограмеToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.оПрограмеToolStripMenuItem.Text = "О програме";
            this.оПрограмеToolStripMenuItem.Click += new System.EventHandler(this.оПрограмеToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(777, 158);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 17);
            this.label2.TabIndex = 31;
            this.label2.Text = "X:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(933, 158);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 17);
            this.label4.TabIndex = 32;
            this.label4.Text = "Y:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(933, 200);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 17);
            this.label5.TabIndex = 33;
            this.label5.Text = "Y:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(777, 199);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 17);
            this.label6.TabIndex = 34;
            this.label6.Text = "X:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(777, 235);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 17);
            this.label7.TabIndex = 35;
            this.label7.Text = "Угол поворота:";
            // 
            // Exit_program
            // 
            this.Exit_program.Location = new System.Drawing.Point(777, 517);
            this.Exit_program.Margin = new System.Windows.Forms.Padding(4);
            this.Exit_program.Name = "Exit_program";
            this.Exit_program.Size = new System.Drawing.Size(506, 31);
            this.Exit_program.TabIndex = 36;
            this.Exit_program.Text = "Выход из программы";
            this.Exit_program.UseVisualStyleBackColor = true;
            this.Exit_program.Click += new System.EventHandler(this.Exit_program_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Image = global::paint.Properties.Resources._35769af2909a9593b22f8b832ae7600e;
            this.pictureBox2.Location = new System.Drawing.Point(1075, 313);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(208, 178);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 37;
            this.pictureBox2.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(901, 157);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 17);
            this.label8.TabIndex = 39;
            this.label8.Text = "px";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1056, 157);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 17);
            this.label9.TabIndex = 41;
            this.label9.Text = "px";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(776, 460);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(271, 31);
            this.button1.TabIndex = 45;
            this.button1.Text = "Просмотр";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_Add_Cadr
            // 
            this.button_Add_Cadr.Location = new System.Drawing.Point(776, 382);
            this.button_Add_Cadr.Margin = new System.Windows.Forms.Padding(4);
            this.button_Add_Cadr.Name = "button_Add_Cadr";
            this.button_Add_Cadr.Size = new System.Drawing.Size(133, 31);
            this.button_Add_Cadr.TabIndex = 46;
            this.button_Add_Cadr.Text = "Добавить кадр";
            this.button_Add_Cadr.UseVisualStyleBackColor = true;
            this.button_Add_Cadr.Click += new System.EventHandler(this.button_Add_Cadr_Click);
            // 
            // button_Delete_card
            // 
            this.button_Delete_card.Location = new System.Drawing.Point(776, 421);
            this.button_Delete_card.Margin = new System.Windows.Forms.Padding(4);
            this.button_Delete_card.Name = "button_Delete_card";
            this.button_Delete_card.Size = new System.Drawing.Size(133, 31);
            this.button_Delete_card.TabIndex = 47;
            this.button_Delete_card.Text = "Удалить кадр";
            this.button_Delete_card.UseVisualStyleBackColor = true;
            this.button_Delete_card.Click += new System.EventHandler(this.button_Delete_card_Click);
            // 
            // Cadr_Text
            // 
            this.Cadr_Text.AutoSize = true;
            this.Cadr_Text.Location = new System.Drawing.Point(777, 315);
            this.Cadr_Text.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Cadr_Text.Name = "Cadr_Text";
            this.Cadr_Text.Size = new System.Drawing.Size(110, 17);
            this.Cadr_Text.TabIndex = 48;
            this.Cadr_Text.Text = "Текщий кадр: 1";
            // 
            // All_cadr_text
            // 
            this.All_cadr_text.AutoSize = true;
            this.All_cadr_text.Location = new System.Drawing.Point(777, 345);
            this.All_cadr_text.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.All_cadr_text.Name = "All_cadr_text";
            this.All_cadr_text.Size = new System.Drawing.Size(111, 17);
            this.All_cadr_text.TabIndex = 49;
            this.All_cadr_text.Text = "Всего кадров: 1";
            // 
            // button_Next_cadr
            // 
            this.button_Next_cadr.Location = new System.Drawing.Point(916, 382);
            this.button_Next_cadr.Margin = new System.Windows.Forms.Padding(4);
            this.button_Next_cadr.Name = "button_Next_cadr";
            this.button_Next_cadr.Size = new System.Drawing.Size(133, 31);
            this.button_Next_cadr.TabIndex = 50;
            this.button_Next_cadr.Text = "Следущий";
            this.button_Next_cadr.UseVisualStyleBackColor = true;
            this.button_Next_cadr.Click += new System.EventHandler(this.button_Next_cadr_Click);
            // 
            // button_Prev_cadr
            // 
            this.button_Prev_cadr.Location = new System.Drawing.Point(916, 421);
            this.button_Prev_cadr.Margin = new System.Windows.Forms.Padding(4);
            this.button_Prev_cadr.Name = "button_Prev_cadr";
            this.button_Prev_cadr.Size = new System.Drawing.Size(133, 31);
            this.button_Prev_cadr.TabIndex = 51;
            this.button_Prev_cadr.Text = "Предыдущий";
            this.button_Prev_cadr.UseVisualStyleBackColor = true;
            this.button_Prev_cadr.Click += new System.EventHandler(this.button_Prev_cadr_Click);
            // 
            // button_move_cadr
            // 
            this.button_move_cadr.Location = new System.Drawing.Point(914, 338);
            this.button_move_cadr.Margin = new System.Windows.Forms.Padding(4);
            this.button_move_cadr.Name = "button_move_cadr";
            this.button_move_cadr.Size = new System.Drawing.Size(133, 31);
            this.button_move_cadr.TabIndex = 53;
            this.button_move_cadr.Text = "Перейти";
            this.button_move_cadr.UseVisualStyleBackColor = true;
            this.button_move_cadr.Click += new System.EventHandler(this.button_move_cadr_Click);
            // 
            // textBox_Move_x
            // 
            this.textBox_Move_x.Location = new System.Drawing.Point(809, 155);
            this.textBox_Move_x.Name = "textBox_Move_x";
            this.textBox_Move_x.Size = new System.Drawing.Size(89, 22);
            this.textBox_Move_x.TabIndex = 54;
            this.textBox_Move_x.Text = "0";
            this.textBox_Move_x.TextChanged += new System.EventHandler(this.textBox_Move_x_TextChanged);
            // 
            // textBox_Move_y
            // 
            this.textBox_Move_y.Location = new System.Drawing.Point(960, 155);
            this.textBox_Move_y.Name = "textBox_Move_y";
            this.textBox_Move_y.Size = new System.Drawing.Size(89, 22);
            this.textBox_Move_y.TabIndex = 55;
            this.textBox_Move_y.Text = "0";
            this.textBox_Move_y.TextChanged += new System.EventHandler(this.textBox_Move_y_TextChanged);
            // 
            // textBox_Gradus
            // 
            this.textBox_Gradus.Location = new System.Drawing.Point(933, 232);
            this.textBox_Gradus.Name = "textBox_Gradus";
            this.textBox_Gradus.Size = new System.Drawing.Size(116, 22);
            this.textBox_Gradus.TabIndex = 56;
            this.textBox_Gradus.Text = "0";
            this.textBox_Gradus.TextChanged += new System.EventHandler(this.textBox_Gradus_TextChanged);
            // 
            // textBox_Zoom_x
            // 
            this.textBox_Zoom_x.Location = new System.Drawing.Point(809, 197);
            this.textBox_Zoom_x.Name = "textBox_Zoom_x";
            this.textBox_Zoom_x.Size = new System.Drawing.Size(89, 22);
            this.textBox_Zoom_x.TabIndex = 57;
            this.textBox_Zoom_x.Text = "1";
            this.textBox_Zoom_x.TextChanged += new System.EventHandler(this.textBox_Zoom_x_TextChanged);
            // 
            // textBox_Zoom_y
            // 
            this.textBox_Zoom_y.Location = new System.Drawing.Point(960, 196);
            this.textBox_Zoom_y.Name = "textBox_Zoom_y";
            this.textBox_Zoom_y.Size = new System.Drawing.Size(89, 22);
            this.textBox_Zoom_y.TabIndex = 58;
            this.textBox_Zoom_y.Text = "1";
            this.textBox_Zoom_y.TextChanged += new System.EventHandler(this.textBox_Zoom_y_TextChanged);
            // 
            // textBox_Cadr
            // 
            this.textBox_Cadr.Location = new System.Drawing.Point(914, 312);
            this.textBox_Cadr.Name = "textBox_Cadr";
            this.textBox_Cadr.Size = new System.Drawing.Size(133, 22);
            this.textBox_Cadr.TabIndex = 59;
            this.textBox_Cadr.Text = "1";
            this.textBox_Cadr.TextChanged += new System.EventHandler(this.textBox_Cadr_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1288, 553);
            this.Controls.Add(this.textBox_Cadr);
            this.Controls.Add(this.textBox_Zoom_y);
            this.Controls.Add(this.textBox_Zoom_x);
            this.Controls.Add(this.textBox_Gradus);
            this.Controls.Add(this.textBox_Move_y);
            this.Controls.Add(this.textBox_Move_x);
            this.Controls.Add(this.button_move_cadr);
            this.Controls.Add(this.button_Prev_cadr);
            this.Controls.Add(this.button_Next_cadr);
            this.Controls.Add(this.All_cadr_text);
            this.Controls.Add(this.Cadr_Text);
            this.Controls.Add(this.button_Delete_card);
            this.Controls.Add(this.button_Add_Cadr);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.Exit_program);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button_razmer_x);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_povorot);
            this.Controls.Add(this.checkBox_O);
            this.Controls.Add(this.button_serkal);
            this.Controls.Add(this.checkBox_y);
            this.Controls.Add(this.checkBox_x);
            this.Controls.Add(this.radioButton_global);
            this.Controls.Add(this.radioButton_local);
            this.Controls.Add(this.button_sdvig_x);
            this.Controls.Add(this.button_del);
            this.Controls.Add(this.button_add4);
            this.Controls.Add(this.button_add3);
            this.Controls.Add(this.button_add2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Лабораторная работа по компьютерной графике";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_add2;
        private System.Windows.Forms.Button button_add3;
        private System.Windows.Forms.Button button_add4;
        private System.Windows.Forms.Button button_del;
        private System.Windows.Forms.Button button_sdvig_x;
        private System.Windows.Forms.RadioButton radioButton_local;
        private System.Windows.Forms.RadioButton radioButton_global;
        private System.Windows.Forms.CheckBox checkBox_O;
        private System.Windows.Forms.Button button_serkal;
        private System.Windows.Forms.CheckBox checkBox_y;
        private System.Windows.Forms.CheckBox checkBox_x;
        private System.Windows.Forms.Button button_povorot;
        private System.Windows.Forms.Button button_razmer_x;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выйтиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограмеToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Exit_program;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отрезокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem треугольникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem четырехугольникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem правкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очиститьToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_Add_Cadr;
        private System.Windows.Forms.Button button_Delete_card;
        private System.Windows.Forms.Label Cadr_Text;
        private System.Windows.Forms.Label All_cadr_text;
        private System.Windows.Forms.Button button_Next_cadr;
        private System.Windows.Forms.Button button_Prev_cadr;
        private System.Windows.Forms.Button button_move_cadr;
        private System.Windows.Forms.TextBox textBox_Move_x;
        private System.Windows.Forms.TextBox textBox_Move_y;
        private System.Windows.Forms.TextBox textBox_Gradus;
        private System.Windows.Forms.TextBox textBox_Zoom_x;
        private System.Windows.Forms.TextBox textBox_Zoom_y;
        private System.Windows.Forms.TextBox textBox_Cadr;
    }
}

