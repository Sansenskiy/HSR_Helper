using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsApp1.Functions;
using WindowsFormsApp1.Properties;
using System.IO;
using System.Text;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox12.Text = Settings.Default["License_Key"].ToString();
        }

        public static bool drag;
        public static Point start_point;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private static System.Timers.Timer aTimer;

        [DllImport("user32.dll")]
        public static extern void keybd_event(Keys bVk, byte bScan, UInt32 dwFlags, IntPtr dwExtraInfo);

        public const UInt32 KEYEVENTF_EXTENDEDKEY = 1;
        public const UInt32 KEYEVENTF_KEYUP = 2;

        [DllImport("User32.dll")]
        static extern void mouse_event(MouseFlags dwFlags, int dx, int dy, int dwData, UIntPtr dwExtraInfo);

        [Flags]
        enum MouseFlags
        {
            Move = 0x0001, LeftDown = 0x0002, LeftUp = 0x0004, RightDown = 0x0008, RightUp = 0x0010, Absolute = 0x8000, WeelDown = 0x0800
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        [DllImport("user32.dll")]
        static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int nFlags);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left, Top, Right, Bottom;
        }

        public static void MyMouseMove(int x, int y)
        { // поставить курсор мыши в координаты x и y
            PointConverter pc = new PointConverter();

            Point pt = new Point(x, y);

            Cursor.Position = pt;
        }
        public static void PlayerMove(string direction)
        { //нажатие клавиш
            switch (direction)
            {
                case "l":
                    keybd_event(Keys.L, 0, KEYEVENTF_EXTENDEDKEY, IntPtr.Zero);
                    Thread.Sleep(100);
                    keybd_event(Keys.L, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, IntPtr.Zero);
                    break;
                case "b":
                    keybd_event(Keys.B, 0, KEYEVENTF_EXTENDEDKEY, IntPtr.Zero);
                    Thread.Sleep(100);
                    keybd_event(Keys.B, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, IntPtr.Zero);
                    break;
                case "d":
                    keybd_event(Keys.D, 0, KEYEVENTF_EXTENDEDKEY, IntPtr.Zero);
                    Thread.Sleep(100);
                    keybd_event(Keys.D, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, IntPtr.Zero);
                    break;
                case "a":
                    keybd_event(Keys.A, 0, KEYEVENTF_EXTENDEDKEY, IntPtr.Zero);
                    Thread.Sleep(100);
                    keybd_event(Keys.A, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, IntPtr.Zero);
                    break;
                case "space":
                    keybd_event(Keys.Space, 0, KEYEVENTF_EXTENDEDKEY, IntPtr.Zero);
                    Thread.Sleep(100);
                    keybd_event(Keys.Space, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, IntPtr.Zero);
                    break;
                case "e":
                    keybd_event(Keys.E, 0, KEYEVENTF_EXTENDEDKEY, IntPtr.Zero);
                    Thread.Sleep(50);
                    keybd_event(Keys.E, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, IntPtr.Zero);
                    break;
                case "f4":
                    keybd_event(Keys.F4, 0, KEYEVENTF_EXTENDEDKEY, IntPtr.Zero);
                    Thread.Sleep(50);
                    keybd_event(Keys.F4, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, IntPtr.Zero);
                    break;
                case "esc":
                    keybd_event(Keys.Escape, 0, KEYEVENTF_EXTENDEDKEY, IntPtr.Zero);
                    Thread.Sleep(50);
                    keybd_event(Keys.Escape, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, IntPtr.Zero);
                    break;
                case "lmb":
                    mouse_event(MouseFlags.LeftDown, 0, 0, 0, UIntPtr.Zero);
                    Thread.Sleep(50);
                    mouse_event(MouseFlags.LeftDown | MouseFlags.LeftUp, 0, 0, 0, UIntPtr.Zero);
                    break;
                case "wld":
                    mouse_event(MouseFlags.WeelDown, 0, 0, -120, UIntPtr.Zero);
                    break;
                case "rmb":
                    keybd_event(Keys.RButton, 0, KEYEVENTF_EXTENDEDKEY, IntPtr.Zero);
                    Thread.Sleep(50);
                    keybd_event(Keys.RButton, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, IntPtr.Zero);
                    break;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (panel2.Visible == false)
            {
                panel2.Show();
                panel3.Hide();
            }
            else
            {
                panel2.Show();
                panel3.Hide();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (panel3.Visible == false)
            {
                panel2.Hide();
                panel5.Hide();
                panel3.Show();
            }
            else
            {
                panel2.Hide();
                panel5.Hide();
                panel3.Show();
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Settings.Default["License_Key"] = textBox12.Text;
            Settings.Default.Save();
            if (textBox12.Text == License_Key)
            {
                var process = Process.GetProcessesByName("StarRail").FirstOrDefault();
                if (process == null)
                {
                    MessageBox.Show(
                    "Honkai Star Rail не запущен",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                    return;
                }
                string folder = "";
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        folder = fbd.SelectedPath;
                    }
                    else
                    {
                        MessageBox.Show(
                        "Не был выбран путь для сохранения скриншотов проверки",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
                        return;
                    }
                }
                int imagenum = 1;
                int num_destruction = 0;
                int num_conservation = 0;
                int num_hunting = 0;
                int num_money = 0;
                int num_weapon_EXP = 0;
                int num_person_EXP = 0;
                int num_harmony = 0;
                int num_erudition = 0;
                int num_abundance = 0;
                int num_nothingness = 0;
                int development_energy = 0;

                if (int.TryParse(textBox2.Text, out num_destruction))
                {
                    development_energy = development_energy + num_destruction;

                }
                if (int.TryParse(textBox3.Text, out num_conservation))
                {
                    development_energy = development_energy + num_conservation;
                }
                if (int.TryParse(textBox4.Text, out num_hunting))
                {
                    development_energy = development_energy + num_hunting;
                }
                if (int.TryParse(textBox5.Text, out num_money))
                {
                    development_energy = development_energy + num_money;
                }
                if (int.TryParse(textBox6.Text, out num_weapon_EXP))
                {
                    development_energy = development_energy + num_weapon_EXP;
                }
                if (int.TryParse(textBox7.Text, out num_person_EXP))
                {
                    development_energy = development_energy + num_person_EXP;
                }
                if (int.TryParse(textBox8.Text, out num_harmony))
                {
                    development_energy = development_energy + num_harmony;
                }
                if (int.TryParse(textBox9.Text, out num_erudition))
                {
                    development_energy = development_energy + num_erudition;
                }
                if (int.TryParse(textBox10.Text, out num_abundance))
                {
                    development_energy = development_energy + num_abundance;
                }
                if (int.TryParse(textBox11.Text, out num_nothingness))
                {
                    development_energy = development_energy + num_nothingness;
                }
                if (development_energy > 18)
                {
                    {
                        MessageBox.Show(
                        "Общее число ходок превышает 18 ",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
                        return;
                    }

                }
                var hwnd = process.MainWindowHandle;
                GetWindowRect(hwnd, out var rect);
                MyMouseMove(rect.Left + 643, rect.Top + 374);
                Thread.Sleep(200);
                PlayerMove("lmb");

                if (num_destruction > 0)
                {
                    switch (num_destruction)
                    {
                        case 1:
                            functions.Sepal_Destruction(0, imagenum, folder);
                            imagenum++;
                            break;
                        case 2:
                            functions.Sepal_Destruction(1, imagenum, folder);
                            imagenum++;
                            break;
                        case 3:
                            functions.Sepal_Destruction(2, imagenum, folder);
                            imagenum++;
                            break;
                        case 4:
                            functions.Sepal_Destruction(3, imagenum, folder);
                            imagenum++;
                            break;
                        case 5:
                            functions.Sepal_Destruction(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 6:
                            functions.Sepal_Destruction(5, imagenum, folder);
                            imagenum++;
                            break;
                        case 7:
                            functions.Sepal_Destruction(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Destruction(0, imagenum, folder);
                            imagenum++;
                            break;
                        case 8:
                            functions.Sepal_Destruction(3, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Destruction(3, imagenum, folder);
                            imagenum++;
                            break;
                        case 9:
                            functions.Sepal_Destruction(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Destruction(2, imagenum, folder);
                            imagenum++;
                            break;
                        case 10:
                            functions.Sepal_Destruction(4, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Destruction(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 11:
                            functions.Sepal_Destruction(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Destruction(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 12:
                            functions.Sepal_Destruction(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Destruction(5, imagenum, folder);
                            imagenum++;
                            break;
                        case 13:
                            functions.Sepal_Destruction(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Destruction(5, imagenum, folder);
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Destruction(0, imagenum, folder);
                            imagenum++;
                            break;
                        case 14:
                            functions.Sepal_Destruction(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Destruction(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Destruction(1, imagenum, folder);
                            imagenum++;
                            break;
                        case 15:
                            functions.Sepal_Destruction(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Destruction(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Destruction(2, imagenum, folder);
                            imagenum++;
                            break;
                        case 16:
                            functions.Sepal_Destruction(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Destruction(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Destruction(3, imagenum, folder);
                            imagenum++;
                            break;
                        case 17:
                            functions.Sepal_Destruction(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Destruction(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Destruction(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 18:
                            functions.Sepal_Destruction(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Destruction(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Destruction(5, imagenum, folder);
                            imagenum++;
                            break;
                    }
                }
                functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                if (num_conservation > 0)
                {
                    switch (num_conservation)
                    {
                        case 1:
                            functions.Sepal_Сonservation(0, imagenum, folder);
                            imagenum++;
                            break;
                        case 2:
                            functions.Sepal_Сonservation(1, imagenum, folder);
                            imagenum++;
                            break;
                        case 3:
                            functions.Sepal_Сonservation(2, imagenum, folder);
                            imagenum++;
                            break;
                        case 4:
                            functions.Sepal_Сonservation(3, imagenum, folder);
                            imagenum++;
                            break;
                        case 5:
                            functions.Sepal_Сonservation(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 6:
                            functions.Sepal_Сonservation(5, imagenum, folder);
                            imagenum++;
                            break;
                        case 7:
                            functions.Sepal_Сonservation(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Сonservation(0, imagenum, folder);
                            imagenum++;
                            break;
                        case 8:
                            functions.Sepal_Сonservation(3, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Сonservation(3, imagenum, folder);
                            imagenum++;
                            break;
                        case 9:
                            functions.Sepal_Сonservation(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Сonservation(2, imagenum, folder);
                            imagenum++;
                            break;
                        case 10:
                            functions.Sepal_Сonservation(4, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Сonservation(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 11:
                            functions.Sepal_Сonservation(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Сonservation(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 12:
                            functions.Sepal_Сonservation(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Сonservation(5, imagenum, folder);
                            imagenum++;
                            break;
                        case 13:
                            functions.Sepal_Сonservation(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Сonservation(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Сonservation(0, imagenum, folder);
                            imagenum++;
                            break;
                        case 14:
                            functions.Sepal_Сonservation(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Сonservation(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Сonservation(1, imagenum, folder);
                            imagenum++;
                            break;
                        case 15:
                            functions.Sepal_Сonservation(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Сonservation(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Сonservation(2, imagenum, folder);
                            imagenum++;
                            break;
                        case 16:
                            functions.Sepal_Сonservation(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Сonservation(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Сonservation(3, imagenum, folder);
                            imagenum++;
                            break;
                        case 17:
                            functions.Sepal_Сonservation(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Сonservation(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Сonservation(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 18:
                            functions.Sepal_Сonservation(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Сonservation(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Сonservation(5, imagenum, folder);
                            imagenum++;
                            break;
                    }
                }
                functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                if (num_hunting > 0)
                {
                    switch (num_hunting)
                    {
                        case 1:
                            functions.Sepal_Hunting(0, imagenum, folder);
                            imagenum++;
                            break;
                        case 2:
                            functions.Sepal_Hunting(1, imagenum, folder);
                            imagenum++;
                            break;
                        case 3:
                            functions.Sepal_Hunting(2, imagenum, folder);
                            imagenum++;
                            break;
                        case 4:
                            functions.Sepal_Hunting(3, imagenum, folder);
                            imagenum++;
                            break;
                        case 5:
                            functions.Sepal_Hunting(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 6:
                            functions.Sepal_Hunting(5, imagenum, folder);
                            imagenum++;
                            break;
                        case 7:
                            functions.Sepal_Hunting(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Hunting(0, imagenum, folder);
                            imagenum++;
                            break;
                        case 8:
                            functions.Sepal_Hunting(3, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Hunting(3, imagenum, folder);
                            imagenum++;
                            break;
                        case 9:
                            functions.Sepal_Hunting(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Hunting(2, imagenum, folder);
                            imagenum++;
                            break;
                        case 10:
                            functions.Sepal_Hunting(4, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Hunting(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 11:
                            functions.Sepal_Hunting(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Hunting(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 12:
                            functions.Sepal_Hunting(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Hunting(5, imagenum, folder);
                            imagenum++;
                            break;
                        case 13:
                            functions.Sepal_Hunting(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Hunting(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Hunting(0, imagenum, folder);
                            imagenum++;
                            break;
                        case 14:
                            functions.Sepal_Hunting(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Hunting(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Hunting(1, imagenum, folder);
                            imagenum++;
                            break;
                        case 15:
                            functions.Sepal_Hunting(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Hunting(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Hunting(2, imagenum, folder);
                            imagenum++;
                            break;
                        case 16:
                            functions.Sepal_Hunting(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Hunting(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Hunting(3, imagenum, folder);
                            imagenum++;
                            break;
                        case 17:
                            functions.Sepal_Hunting(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Hunting(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Hunting(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 18:
                            functions.Sepal_Hunting(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Hunting(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Hunting(5, imagenum, folder);
                            imagenum++;
                            break;
                    }
                }
                functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                if (num_abundance > 0)
                {
                    switch (num_abundance)
                    {
                        case 1:
                            functions.Sepal_Abundance(0, imagenum, folder);
                            imagenum++;
                            break;
                        case 2:
                            functions.Sepal_Abundance(1, imagenum, folder);
                            imagenum++;
                            break;
                        case 3:
                            functions.Sepal_Abundance(2, imagenum, folder);
                            imagenum++;
                            break;
                        case 4:
                            functions.Sepal_Abundance(3, imagenum, folder);
                            imagenum++;
                            break;
                        case 5:
                            functions.Sepal_Abundance(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 6:
                            functions.Sepal_Abundance(5, imagenum, folder);
                            imagenum++;
                            break;
                        case 7:
                            functions.Sepal_Abundance(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Abundance(0, imagenum, folder);
                            imagenum++;
                            break;
                        case 8:
                            functions.Sepal_Abundance(3, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Abundance(3, imagenum, folder);
                            imagenum++;
                            break;
                        case 9:
                            functions.Sepal_Abundance(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Abundance(2, imagenum, folder);
                            imagenum++;
                            break;
                        case 10:
                            functions.Sepal_Abundance(4, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Abundance(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 11:
                            functions.Sepal_Abundance(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Abundance(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 12:
                            functions.Sepal_Abundance(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Abundance(5, imagenum, folder);
                            imagenum++;
                            break;
                        case 13:
                            functions.Sepal_Abundance(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Abundance(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Abundance(0, imagenum, folder);
                            imagenum++;
                            break;
                        case 14:
                            functions.Sepal_Abundance(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Abundance(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Abundance(1, imagenum, folder);
                            imagenum++;
                            break;
                        case 15:
                            functions.Sepal_Abundance(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Abundance(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Abundance(2, imagenum, folder);
                            imagenum++;
                            break;
                        case 16:
                            functions.Sepal_Abundance(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Abundance(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Abundance(3, imagenum, folder);
                            imagenum++;
                            break;
                        case 17:
                            functions.Sepal_Abundance(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Abundance(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Abundance(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 18:
                            functions.Sepal_Abundance(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Abundance(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Abundance(5, imagenum, folder);
                            imagenum++;
                            break;
                    }
                }
                functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                if (num_erudition > 0)
                {
                    switch (num_erudition)
                    {
                        case 1:
                            functions.Sepal_Erudition(0, imagenum, folder);
                            imagenum++;
                            break;
                        case 2:
                            functions.Sepal_Erudition(1, imagenum, folder);
                            imagenum++;
                            break;
                        case 3:
                            functions.Sepal_Erudition(2, imagenum, folder);
                            imagenum++;
                            break;
                        case 4:
                            functions.Sepal_Erudition(3, imagenum, folder);
                            imagenum++;
                            break;
                        case 5:
                            functions.Sepal_Erudition(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 6:
                            functions.Sepal_Erudition(5, imagenum, folder);
                            imagenum++;
                            break;
                        case 7:
                            functions.Sepal_Erudition(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Erudition(0, imagenum, folder);
                            imagenum++;
                            break;
                        case 8:
                            functions.Sepal_Erudition(3, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Erudition(3, imagenum, folder);
                            imagenum++;
                            break;
                        case 9:
                            functions.Sepal_Erudition(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Erudition(2, imagenum, folder);
                            imagenum++;
                            break;
                        case 10:
                            functions.Sepal_Erudition(4, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Erudition(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 11:
                            functions.Sepal_Erudition(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Erudition(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 12:
                            functions.Sepal_Erudition(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Erudition(5, imagenum, folder);
                            imagenum++;
                            break;
                        case 13:
                            functions.Sepal_Erudition(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Erudition(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Erudition(0, imagenum, folder);
                            imagenum++;
                            break;
                        case 14:
                            functions.Sepal_Erudition(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Erudition(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Erudition(1, imagenum, folder);
                            imagenum++;
                            break;
                        case 15:
                            functions.Sepal_Erudition(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Erudition(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Erudition(2, imagenum, folder);
                            imagenum++;
                            break;
                        case 16:
                            functions.Sepal_Erudition(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Erudition(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Erudition(3, imagenum, folder);
                            imagenum++;
                            break;
                        case 17:
                            functions.Sepal_Erudition(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Erudition(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Erudition(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 18:
                            functions.Sepal_Erudition(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Erudition(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Erudition(5, imagenum, folder);
                            imagenum++;
                            break;
                    }
                }
                functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                if (num_harmony > 0)
                {
                    switch (num_harmony)
                    {
                        case 1:
                            functions.Sepal_Harmony(0, imagenum, folder);
                            imagenum++;
                            break;
                        case 2:
                            functions.Sepal_Harmony(1, imagenum, folder);
                            imagenum++;
                            break;
                        case 3:
                            functions.Sepal_Harmony(2, imagenum, folder);
                            imagenum++;
                            break;
                        case 4:
                            functions.Sepal_Harmony(3, imagenum, folder);
                            imagenum++;
                            break;
                        case 5:
                            functions.Sepal_Harmony(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 6:
                            functions.Sepal_Harmony(5, imagenum, folder);
                            imagenum++;
                            break;
                        case 7:
                            functions.Sepal_Harmony(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Harmony(0, imagenum, folder);
                            imagenum++;
                            break;
                        case 8:
                            functions.Sepal_Harmony(3, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Harmony(3, imagenum, folder);
                            imagenum++;
                            break;
                        case 9:
                            functions.Sepal_Harmony(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Harmony(2, imagenum, folder);
                            imagenum++;
                            break;
                        case 10:
                            functions.Sepal_Harmony(4, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Harmony(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 11:
                            functions.Sepal_Harmony(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Harmony(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 12:
                            functions.Sepal_Harmony(5, imagenum, folder); 
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Harmony(5, imagenum, folder);
                            imagenum++;
                            break;
                        case 13:
                            functions.Sepal_Harmony(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Harmony(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Harmony(0, imagenum, folder);
                            imagenum++;
                            break;
                        case 14:
                            functions.Sepal_Harmony(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Harmony(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Harmony(1, imagenum, folder);
                            imagenum++;
                            break;
                        case 15:
                            functions.Sepal_Harmony(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Harmony(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Harmony(2, imagenum, folder);
                            imagenum++;
                            break;
                        case 16:
                            functions.Sepal_Harmony(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Harmony(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Harmony(3, imagenum, folder);
                            imagenum++;
                            break;
                        case 17:
                            functions.Sepal_Harmony(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Harmony(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Harmony(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 18:
                            functions.Sepal_Harmony(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Harmony(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Harmony(5, imagenum, folder);
                            imagenum++;
                            break;
                    }
                }
                functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                if (num_nothingness > 0)
                {
                    switch (num_nothingness)
                    {
                        case 1:
                            functions.Sepal_Nothingnessy(0, imagenum, folder);
                            imagenum++;
                            break;
                        case 2:
                            functions.Sepal_Nothingnessy(1, imagenum, folder);
                            imagenum++;
                            break;
                        case 3:
                            functions.Sepal_Nothingnessy(2, imagenum, folder);
                            imagenum++;
                            break;
                        case 4:
                            functions.Sepal_Nothingnessy(3, imagenum, folder);
                            imagenum++;
                            break;
                        case 5:
                            functions.Sepal_Nothingnessy(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 6:
                            functions.Sepal_Nothingnessy(5, imagenum, folder);
                            imagenum++;
                            break;
                        case 7:
                            functions.Sepal_Nothingnessy(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Nothingnessy(0, imagenum, folder);
                            imagenum++;
                            break;
                        case 8:
                            functions.Sepal_Nothingnessy(3, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Nothingnessy(3, imagenum, folder);
                            imagenum++;
                            break;
                        case 9:
                            functions.Sepal_Nothingnessy(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Nothingnessy(2, imagenum, folder);
                            imagenum++;
                            break;
                        case 10:
                            functions.Sepal_Nothingnessy(4, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Nothingnessy(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 11:
                            functions.Sepal_Nothingnessy(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Nothingnessy(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 12:
                            functions.Sepal_Nothingnessy(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Nothingnessy(5, imagenum, folder);
                            imagenum++;
                            break;
                        case 13:
                            functions.Sepal_Nothingnessy(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Nothingnessy(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Nothingnessy(0, imagenum, folder);
                            imagenum++;
                            break;
                        case 14:
                            functions.Sepal_Nothingnessy(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            imagenum++;
                            functions.Sepal_Nothingnessy(5, imagenum, folder);
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            imagenum++;
                            functions.Sepal_Nothingnessy(1, imagenum, folder);
                            break;
                        case 15:
                            functions.Sepal_Nothingnessy(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Nothingnessy(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Nothingnessy(2, imagenum, folder);
                            imagenum++;
                            break;
                        case 16:
                            functions.Sepal_Nothingnessy(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Nothingnessy(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Nothingnessy(3, imagenum, folder);
                            imagenum++;
                            break;
                        case 17:
                            functions.Sepal_Nothingnessy(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Nothingnessy(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Nothingnessy(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 18:
                            functions.Sepal_Nothingnessy(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Nothingnessy(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Nothingnessy(5, imagenum, folder);
                            imagenum++;
                            break;
                    }
                }
                functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                if (num_person_EXP > 0)
                {
                    switch (num_person_EXP)
                    {
                        case 1:
                            functions.Sepal_Person_EXP(0, imagenum, folder);
                            imagenum++;
                            break;
                        case 2:
                            functions.Sepal_Person_EXP(1, imagenum, folder);
                            imagenum++;
                            break;
                        case 3:
                            functions.Sepal_Person_EXP(2, imagenum, folder);
                            imagenum++;
                            break;
                        case 4:
                            functions.Sepal_Person_EXP(3, imagenum, folder);
                            imagenum++;
                            break;
                        case 5:
                            functions.Sepal_Person_EXP(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 6:
                            functions.Sepal_Person_EXP(5, imagenum, folder);
                            imagenum++;
                            break;
                        case 7:
                            functions.Sepal_Person_EXP(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Person_EXP(0, imagenum, folder);
                            imagenum++;
                            break;
                        case 8:
                            functions.Sepal_Person_EXP(3, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Person_EXP(3, imagenum, folder);
                            imagenum++;
                            break;
                        case 9:
                            functions.Sepal_Person_EXP(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Person_EXP(2, imagenum, folder);
                            imagenum++;
                            break;
                        case 10:
                            functions.Sepal_Person_EXP(4, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Person_EXP(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 11:
                            functions.Sepal_Person_EXP(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Person_EXP(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 12:
                            functions.Sepal_Person_EXP(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Person_EXP(5, imagenum, folder);
                            imagenum++;
                            break;
                        case 13:
                            functions.Sepal_Person_EXP(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Person_EXP(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Person_EXP(0, imagenum, folder);
                            imagenum++;
                            break;
                        case 14:
                            functions.Sepal_Person_EXP(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Person_EXP(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Person_EXP(1, imagenum, folder);
                            imagenum++;
                            break;
                        case 15:
                            functions.Sepal_Person_EXP(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Person_EXP(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Person_EXP(2, imagenum, folder);
                            imagenum++;
                            break;
                        case 16:
                            functions.Sepal_Person_EXP(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Person_EXP(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Person_EXP(3, imagenum, folder);
                            imagenum++;
                            break;
                        case 17:
                            functions.Sepal_Person_EXP(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Person_EXP(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Person_EXP(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 18:
                            functions.Sepal_Person_EXP(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Person_EXP(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Person_EXP(5, imagenum, folder);
                            imagenum++;
                            break;
                    }
                }
                functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                if (num_weapon_EXP > 0)
                {
                    switch (num_weapon_EXP)
                    {
                        case 1:
                            functions.Sepal_Weapon_EXP(0, imagenum, folder);
                            imagenum++;
                            break;
                        case 2:
                            functions.Sepal_Weapon_EXP(1, imagenum, folder);
                            imagenum++;
                            break;
                        case 3:
                            functions.Sepal_Weapon_EXP(2, imagenum, folder);
                            imagenum++;
                            break;
                        case 4:
                            imagenum++;
                            functions.Sepal_Weapon_EXP(3, imagenum, folder);
                            break;
                        case 5:
                            functions.Sepal_Weapon_EXP(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 6:
                            functions.Sepal_Weapon_EXP(5, imagenum, folder);
                            imagenum++;
                            break;
                        case 7:
                            functions.Sepal_Weapon_EXP(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Weapon_EXP(0, imagenum, folder);
                            imagenum++;
                            break;
                        case 8:
                            functions.Sepal_Weapon_EXP(3, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Weapon_EXP(3, imagenum, folder);
                            imagenum++;
                            break;
                        case 9:
                            functions.Sepal_Weapon_EXP(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Weapon_EXP(2, imagenum, folder);
                            imagenum++;
                            break;
                        case 10:
                            functions.Sepal_Weapon_EXP(4, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Weapon_EXP(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 11:
                            functions.Sepal_Weapon_EXP(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Weapon_EXP(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 12:
                            functions.Sepal_Weapon_EXP(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Weapon_EXP(5, imagenum, folder);
                            imagenum++;
                            break;
                        case 13:
                            functions.Sepal_Weapon_EXP(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Weapon_EXP(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Weapon_EXP(0, imagenum, folder);
                            imagenum++;
                            break;
                        case 14:
                            functions.Sepal_Weapon_EXP(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Weapon_EXP(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Weapon_EXP(1, imagenum, folder);
                            imagenum++;
                            break;
                        case 15:
                            functions.Sepal_Weapon_EXP(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Weapon_EXP(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Weapon_EXP(2, imagenum, folder);
                            imagenum++;
                            break;
                        case 16:
                            functions.Sepal_Weapon_EXP(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Weapon_EXP(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Weapon_EXP(3, imagenum, folder);
                            imagenum++;
                            break;
                        case 17:
                            functions.Sepal_Weapon_EXP(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Weapon_EXP(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Weapon_EXP(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 18:
                            functions.Sepal_Weapon_EXP(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Weapon_EXP(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Weapon_EXP(5, imagenum, folder);
                            imagenum++;
                            break;
                    }
                }
                functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                if (num_money > 0)
                {
                    switch (num_money)
                    {
                        case 1:
                            functions.Sepal_Money(0, imagenum, folder);
                            imagenum++;
                            break;
                        case 2:
                            functions.Sepal_Money(1, imagenum, folder);
                            imagenum++;
                            break;
                        case 3:
                            functions.Sepal_Money(2, imagenum, folder);
                            imagenum++;
                            break;
                        case 4:
                            functions.Sepal_Money(3, imagenum, folder);
                            imagenum++;
                            break;
                        case 5:
                            functions.Sepal_Money(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 6:
                            functions.Sepal_Money(5, imagenum, folder);
                            imagenum++;
                            break;
                        case 7:
                            functions.Sepal_Money(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Money(0, imagenum, folder);
                            imagenum++;
                            break;
                        case 8:
                            functions.Sepal_Money(3, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Money(3, imagenum, folder);
                            imagenum++;
                            break;
                        case 9:
                            functions.Sepal_Money(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Money(2, imagenum, folder);
                            imagenum++;
                            break;
                        case 10:
                            functions.Sepal_Money(4, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Money(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 11:
                            functions.Sepal_Money(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Money(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 12:
                            functions.Sepal_Money(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            imagenum++;
                            functions.Sepal_Money(5, imagenum, folder);
                            break;
                        case 13:
                            functions.Sepal_Money(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Money(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Money(0, imagenum, folder);
                            imagenum++;
                            break;
                        case 14:
                            functions.Sepal_Money(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Money(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Money(1, imagenum, folder);
                            imagenum++;
                            break;
                        case 15:
                            functions.Sepal_Money(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Money(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Money(2, imagenum, folder);
                            imagenum++;
                            break;
                        case 16:
                            functions.Sepal_Money(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Money(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Money(3, imagenum, folder);
                            imagenum++;
                            break;
                        case 17:
                            functions.Sepal_Money(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Money(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Money(4, imagenum, folder);
                            imagenum++;
                            break;
                        case 18:
                            functions.Sepal_Money(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Money(5, imagenum, folder);
                            imagenum++;
                            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                            functions.Sepal_Money(5, imagenum, folder);
                            imagenum++;
                            break;
                    }
                }
                functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
                {
                    MessageBox.Show(
                    "Конец)",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                    return;
                }
            }
            else
            {
                MessageBox.Show(
                "Лицензионный ключ недействителен",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                return;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (panel5.Visible == false)
            {
                panel2.Hide();
                panel3.Hide();
                panel5.Show();
            }
            else
            {
                panel2.Hide();
                panel3.Hide();
                panel5.Show();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ManagementObjectCollection mbsList = null;
            ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select * From Win32_processor");
            mbsList = mbs.Get();
            string id = "";
            foreach (ManagementObject mo in mbsList)
            {
                id = mo["ProcessorID"].ToString();
            }

            ManagementObject dsk = new ManagementObject(@"win32_logicaldisk.deviceid=""c:""");
            dsk.Get();
            string dskid = dsk["VolumeSerialNumber"].ToString();

            string folder = "";
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    folder = fbd.SelectedPath;
                }
            }

            string path = (folder + @"\License.txt");
            using (FileStream fs = File.Create(path))
            {
                string key = id + dskid;
                key = key.Replace('0', '&');
                key = key.Replace('1', '!');
                key = key.Replace('2', '.');
                key = key.Replace('3', '*');
                key = key.Replace('4', '#');
                key = key.Replace('5', '@');
                key = key.Replace('6', '-');
                key = key.Replace('7', '%');
                key = key.Replace('8', ')');
                key = key.Replace('9', '^');
                char[] chars = key.ToCharArray();
                for (int i = 0; i < key.Length / 2; i++)
                {
                    char ch = chars[i];
                    chars[i] = chars[key.Length - i - 1];
                    chars[key.Length - i - 1] = ch;
                }
                string Coded_key = new string(chars);
                byte[] ifo = new UTF8Encoding(true).GetBytes(Coded_key);
                fs.Write(ifo, 0, ifo.Length);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings.Default["License_Key"] = textBox12.Text;
            Settings.Default.Save();
            ManagementObjectCollection mbsList = null;
            ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select * From Win32_processor");
            mbsList = mbs.Get();
            string id = "";
            foreach (ManagementObject mo in mbsList)
            {
                id = mo["ProcessorID"].ToString();
            }
            ManagementObject dsk = new ManagementObject(@"win32_logicaldisk.deviceid=""c:""");
            dsk.Get();
            string dskid = dsk["VolumeSerialNumber"].ToString();
            if (textBox12.Text == id + dskid)
            {
                var process = Process.GetProcessesByName("StarRail").FirstOrDefault();
                if (process == null)
                {
                    MessageBox.Show(
                    "Honkai Star Rail не запущен",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                    return;
                }
                functions.Debug_Mode();
            }
            else
            {
                MessageBox.Show(
                "Лицензионный ключ недействителен",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
                return;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            {
                MessageBox.Show(
                "Пасхалка от создаделя Сансенского @Sansenskiy",
                "Кыш-кыш!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}
