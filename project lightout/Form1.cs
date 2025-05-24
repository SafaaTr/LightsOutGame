using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace endlightout
{
    public partial class Form1 : Form
    {
        private LightsOutGame game;//كائن(يدير تشغيلها
        private int gridSize= 3 ;
        private int moveCount = 0;
        private Label movesLabel;
        private Button newGameButton;
        private Button[,] buttons;  //مصفوفة الازرار
        private int totalGames = 0;
        private int solvedGames = 0;    //متغير لحفظ الاحصائات
        private int unsolvedGames = 0;
        private Random random = new Random();
        //كائن لإنشاء حالات عشوائية للعبة.
        private ComboBox gridSizeSelector;

        public Form1()
        {
            InitializeComponent();
            SetupUI();
            StartGame(4);
        }
        private void GridSizeSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null && comboBox.SelectedItem != null)
            {
                gridSize = int.Parse(comboBox.SelectedItem.ToString()); // تحديث حجم الشبكة
                StartGame(gridSize); //  إعادة تشغيل اللعبة بالحجم الجديد
            }
        }

        private void ResetGame() //عداد
        {
            moveCount = 0;
            movesLabel.Text = "Moves: 0";

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    buttons[i, j].BackColor = random.Next(2) == 0 ? Color.Black : Color.Yellow;
                }
            }
        }
        private void SetupUI()
        {
            ComboBox gridSizeSelector = new ComboBox
            {
                Location = new Point(10, 10), 
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            // خيارات الأحجام
            gridSizeSelector.Items.AddRange(new object[] { "3", "4", "5", "6" });

            // عند تغيير `gridSize` وإعادة تشغيل اللعبة
            gridSizeSelector.SelectedIndexChanged += (s, e) =>
            {
                gridSize = int.Parse(gridSizeSelector.SelectedItem.ToString());
                StartGame(gridSize);
            };
            gridSizeSelector.SelectedIndexChanged += GridSizeSelector_SelectedIndexChanged;


            this.Controls.Add(gridSizeSelector); //  تأكد من إضافته إلى `Controls`


            movesLabel = new Label
            {
                Text = "Moves: 0",
                Location = new Point(20, 45),
                AutoSize = true
            };
            this.Controls.Add(movesLabel);

            newGameButton = new Button
            {
                Text = "New Game",
                Location = new Point(300, 10),
                Size = new Size(80, 30)
            };
            newGameButton.Click += NewGameButton_Click;
            this.Controls.Add(newGameButton);

            Button btn3x3 = new Button
            {
                Text = "3x3",
                Location = new Point(10, 40),
                Size = new Size(60, 30)
            };
            btn3x3.Click += (s, e) => StartGame(3);

            Button btn4x4 = new Button
            {
                Text = "4x4",
                Location = new Point(80, 40),
                Size = new Size(60, 30)
            };
            btn4x4.Click += (s, e) => StartGame(4);

            Button btn5x5 = new Button
            {
                Text = "5x5",
                Location = new Point(150, 40),
                Size = new Size(60, 30)
            };
            btn5x5.Click += (s, e) => StartGame(5);
            // إضافة الأزرار إلى النموذج
            this.Controls.Add(btn3x3);
            this.Controls.Add(btn4x4);
            this.Controls.Add(btn5x5);


        }
        private void StartGame(int size)
        {
            gridSize = size; //  تحديث الحجم بناءً على اختيار المستخدم
            //game = new LightsOutGame(gridSize);
            game = new LightsOutGame(gridSize);
            moveCount = 0;
            movesLabel.Text = "Moves: 0";
            CreateGridUI(); //  إعادة إنشاء الشبكة بالحجم الجديد
            game.SetInitialWinningState(); //  إعداد الشبكة بوضعية قابلة للفوز
        }
        private void ToggleButton(int x, int y)
        {
            buttons[x, y].BackColor = buttons[x, y].BackColor == Color.Yellow ? Color.Black : Color.Yellow;
        }
        private void ToggleLights(int x, int y)
        {
            if (x < 0 || x >= gridSize || y < 0 || y >= gridSize) return;

            moveCount++;
            movesLabel.Text = $"Moves: {moveCount}";

            ToggleButton(x, y);
            // تبديل حالة الأزرار المجاورة بطريقة صحيحة
            //if (x > 0) ToggleButton(x - 1, y);
            //if (x < gridSize - 1) ToggleButton(x + 1, y);
            //if (y > 0) ToggleButton(x, y - 1);
            //if (y < gridSize - 1) ToggleButton(x, y + 1);

            // تبديل الأزرار المجاورة فقط إذا كان ذلك ضروريًا لحل الشبكة
            if (x > 0 && game.Grid[x - 1, y]) ToggleButton(x - 1, y);
            if (x < gridSize - 1 && game.Grid[x + 1, y]) ToggleButton(x + 1, y);
            if (y > 0 && game.Grid[x, y - 1]) ToggleButton(x, y - 1);
            if (y < gridSize - 1 && game.Grid[x, y + 1]) ToggleButton(x, y + 1);

            // تحقق من الفوز بعد كل حركة
            if (game.CheckForWin())
            {
                string message = " مبروك، لقد فزت!";
                MessageBox.Show(" مبروك، لقد فزت!", "الفوز");

                if (moveCount < 10)
                {
                    message += "\n رائع! لقد فزت بأقل من 10 خطوات، أنت محترف!";
                }
                // تعطيل جميع الأزرار بعد الفوز
                foreach (Button btn in buttons)
                {
                    btn.Enabled = false;
                }
            }
            CheckWinCondition();
        }
        private void CreateGridUI()
        {
            this.Controls.Clear(); //  مسح العناصر السابقة

            // إعادة إضافة القائمة المنسدلة بعد المسح
            this.Controls.Add(gridSizeSelector);
            // إعادة إضافة عداد الحركات
            this.Controls.Add(movesLabel);

            this.Controls.Add(newGameButton);

            buttons = new Button[gridSize, gridSize];
            int buttonSize = gridSize == 3 ? 100 : gridSize == 4 ? 80 : 60; //  تحديد حجم الزر

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    Button btn = new Button
                    {
                        Size = new Size(buttonSize, buttonSize),
                        Location = new Point(50 + j * buttonSize, 60 + i * buttonSize),
                        BackColor = game.Grid[i, j] ? Color.Yellow : Color.Black
                    };

                    int x = i, y = j;
                    btn.Click += (s, e) => ToggleLights(x, y);

                    buttons[i, j] = btn;
                    this.Controls.Add(btn);
                }
            }
        }
        private void ShowReport()  ///عرض الرسالة
        {
            ReportForm report = new ReportForm(totalGames, solvedGames, unsolvedGames);
            report.ShowDialog();
        }
        private void CheckWinCondition()
        {
            if (moveCount > 30) //  الحد الأقصى للحركات
            {
                MessageBox.Show("لقد خسرت! حاول مجددًا.");
                unsolvedGames++;
                totalGames++;
                ShowReport();
                return;
            }

            foreach (var btn in buttons)
            {
                if (btn.BackColor == Color.Yellow)
                    return; // لا يزال هناك ضوء مشغل، لم يفز اللاعب بعد
            }

            MessageBox.Show($"تهانينا! لقد فزت بعد {moveCount} حركة.");
            solvedGames++;
            totalGames++;
            ShowReport();
        }
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            totalGames++;
            ResetGame();
            ShowReport();
        }
       

    }


}
