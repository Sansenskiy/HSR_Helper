using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WindowsFormsApp1.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static WindowsFormsApp1.Form1;

namespace WindowsFormsApp1.Functions
{
    public class functions
    {
        public static void Wait_Pixel(Color Seak_Pixel, int Pos_X, int Pos_Y, int Time)
        {
            var process = Process.GetProcessesByName("StarRail").FirstOrDefault();
            var hwnd = process.MainWindowHandle;
            GetWindowRect(hwnd, out var rect);
            for (Color pixel = Color.FromArgb(0, 0, 0, 0); Seak_Pixel != pixel;)
            {
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    Thread.Sleep(Time);
                    using (var graphics = Graphics.FromImage(image))
                    {
                        Size screen = new Size(1280, 750);
                        graphics.CopyFromScreen(rect.Left + 8, rect.Top, 0, 0, screen);
                        pixel = image.GetPixel(Pos_X, Pos_Y);
                    }
                }
            }

        }

        public static void Wait_Another_Pixel(Color Seak_Pixel, int Pos_X, int Pos_Y, int Time)
        {
            var process = Process.GetProcessesByName("StarRail").FirstOrDefault();
            var hwnd = process.MainWindowHandle;
            GetWindowRect(hwnd, out var rect);
            for (Color pixel = Color.FromArgb(0, 0, 0, 0); Seak_Pixel == pixel;)
            {
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    Thread.Sleep(Time);
                    using (var graphics = Graphics.FromImage(image))
                    {
                        Size screen = new Size(1280, 750);
                        graphics.CopyFromScreen(rect.Left + 8, rect.Top, 0, 0, screen);
                        pixel = image.GetPixel(Pos_X, Pos_Y);
                    }
                }
            }

        }

        public static Color Get_Pixel(int Pos_X, int Pos_Y)
        {
            var process = Process.GetProcessesByName("StarRail").FirstOrDefault();
            var hwnd = process.MainWindowHandle;
            GetWindowRect(hwnd, out var rect);
            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
            {
                Thread.Sleep(400);
                using (var graphics = Graphics.FromImage(image))
                {
                    Size screen = new Size(1280, 750);
                    graphics.CopyFromScreen(rect.Left + 8, rect.Top, 0, 0, screen);
                    Color pixel = image.GetPixel(Pos_X, Pos_Y);
                    return pixel;
                }
            }
        }

        public static void Sepal_Destruction(int num, int imagenum, string folder)
        {
            var process = Process.GetProcessesByName("StarRail").FirstOrDefault();
            var hwnd = process.MainWindowHandle;
            GetWindowRect(hwnd, out var rect);
            int fuse = 0;
            MyMouseMove(rect.Left + 643, rect.Top + 374);
            Thread.Sleep(200);
            PlayerMove("lmb");
            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
            PlayerMove("f4");
            for (Color pixel = Color.FromArgb(0, 0, 0, 0); Settings.Default.Survival_Index != pixel;)
            {
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    Thread.Sleep(200);
                    using (var graphics = Graphics.FromImage(image))
                    {
                        Size screen = new Size(1280, 750);
                        graphics.CopyFromScreen(rect.Left + 8, rect.Top, 0, 0, screen);
                        pixel = image.GetPixel(510, 180);
                    }
                    if (pixel != Settings.Default.Survival_Index)
                    {
                        pixel = image.GetPixel(300, 185);
                        if (pixel == Settings.Default.Daily_Workout_Menu)
                        {
                            MyMouseMove(rect.Left + 488, rect.Top + 165);
                            PlayerMove("lmb");
                        }
                    }
                }
            }
            Wait_Pixel(Settings.Default.Virtual_Universe_Button, 460, 245, 200);
            MyMouseMove(rect.Left + 408, rect.Top + 420);
            Thread.Sleep(200);
            PlayerMove("lmb");           
            Wait_Pixel(Settings.Default.Sepal_Crimson_Button, 460, 410, 200);
            MyMouseMove(rect.Left + 998, rect.Top + 285);
            Thread.Sleep(200);
            PlayerMove("lmb");
            Wait_Pixel(Settings.Default.Fights_Slider, 890, 630, 200);
            Thread.Sleep(200);
            if (num > 0)
            {
                switch (num)
                {
                    case 1:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        Thread.Sleep(200);
                        PlayerMove("lmb");
                        PlayerMove("lmb");
                        break;
                    case 2:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 2; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                    case 3:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 3; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                    case 4:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 4; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                    case 5:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 5; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                }
            }
            MyMouseMove(rect.Left + 1088, rect.Top + 685);
            Thread.Sleep(200);
            PlayerMove("lmb");
            Wait_Pixel(Color.FromArgb(255, 228, 202, 147), 45, 87, 200);
            MyMouseMove(rect.Left + 1123, rect.Top + 685);
            Thread.Sleep(200);
            PlayerMove("lmb");
            for (Color pixel = Color.FromArgb(0, 0, 0, 0); Settings.Default.Fight_Ended_Trigger != pixel;)
            {
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    Thread.Sleep(500);
                    using (var graphics = Graphics.FromImage(image))
                    {
                        Size screen = new Size(1280, 750);
                        graphics.CopyFromScreen(rect.Left + 8, rect.Top, 0, 0, screen);
                        pixel = image.GetPixel(970, 663);
                    }
                    if (pixel != Settings.Default.Fight_Ended_Trigger)
                    {
                        fuse = 0;
                    }
                    if (pixel == Settings.Default.Fight_Ended_Trigger)
                    {
                        if (fuse < 1)
                        {
                            pixel = Color.FromArgb(255, 0, 0, 0);
                            fuse++;
                        }
                    }
                }
            }
            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
            {
                using (var graphics = Graphics.FromImage(image))
                {
                    Size screen = new Size(1280, 750);
                    graphics.CopyFromScreen(rect.Left + 8, rect.Top, 0, 0, screen);
                    image.Save(folder + @"\" + imagenum + @".png", ImageFormat.Png);
                }
            }
            Thread.Sleep(200);
            MyMouseMove(rect.Left + 488, rect.Top + 660);
            Thread.Sleep(200);
            PlayerMove("lmb");
        }

        public static void Sepal_Сonservation(int num, int imagenum, string folder)
        {
            var process = Process.GetProcessesByName("StarRail").FirstOrDefault();
            var hwnd = process.MainWindowHandle;
            GetWindowRect(hwnd, out var rect);
            int fuse = 0;
            MyMouseMove(rect.Left + 643, rect.Top + 374);
            Thread.Sleep(200);
            PlayerMove("lmb");
            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
            PlayerMove("f4");
            for (Color pixel = Color.FromArgb(0, 0, 0, 0); Settings.Default.Survival_Index != pixel;)
            {
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    Thread.Sleep(200);
                    using (var graphics = Graphics.FromImage(image))
                    {
                        Size screen = new Size(1280, 750);
                        graphics.CopyFromScreen(rect.Left + 8, rect.Top, 0, 0, screen);
                        pixel = image.GetPixel(510, 180);
                    }
                    if (pixel != Color.FromArgb(255, 224, 224, 224))
                    {
                        pixel = image.GetPixel(300, 185);
                        if (pixel == Settings.Default.Daily_Workout_Menu)
                        {
                            MyMouseMove(rect.Left + 488, rect.Top + 165);
                            PlayerMove("lmb");
                        }
                    }
                }
            }
            Wait_Pixel(Settings.Default.Virtual_Universe_Button, 460, 245, 200);
            MyMouseMove(rect.Left + 408, rect.Top + 420);
            Thread.Sleep(200);
            PlayerMove("lmb");
            Wait_Pixel(Settings.Default.Sepal_Crimson_Button, 460, 410, 200);
            MyMouseMove(rect.Left + 998, rect.Top + 405);
            Thread.Sleep(200);
            PlayerMove("lmb");
            Wait_Pixel(Settings.Default.Fights_Slider, 890, 630, 200);
            Thread.Sleep(200);
            if (num > 0)
            {
                switch (num)
                {
                    case 1:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        Thread.Sleep(200);
                        PlayerMove("lmb");
                        PlayerMove("lmb");
                        break;
                    case 2:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 2; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                    case 3:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 3; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                    case 4:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 4; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                    case 5:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 5; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                }
            }
            MyMouseMove(rect.Left + 1088, rect.Top + 685);
            Thread.Sleep(200);
            PlayerMove("lmb");
            Wait_Pixel(Color.FromArgb(255, 228, 202, 147), 45, 87, 200);
            MyMouseMove(rect.Left + 1123, rect.Top + 685);
            Thread.Sleep(200);
            PlayerMove("lmb");
            for (Color pixel = Color.FromArgb(0, 0, 0, 0); Settings.Default.Fight_Ended_Trigger != pixel;)
            {
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    Thread.Sleep(500);
                    using (var graphics = Graphics.FromImage(image))
                    {
                        Size screen = new Size(1280, 750);
                        graphics.CopyFromScreen(rect.Left + 8, rect.Top, 0, 0, screen);
                        pixel = image.GetPixel(970, 663);
                    }
                    if (pixel != Settings.Default.Fight_Ended_Trigger)
                    {
                        fuse = 0;
                    }
                    if (pixel == Settings.Default.Fight_Ended_Trigger)
                    {
                        if (fuse < 1)
                        {
                            pixel = Color.FromArgb(255, 0, 0, 0);
                            fuse++;
                        }
                    }
                }
            }
            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
            {
                using (var graphics = Graphics.FromImage(image))
                {
                    Size screen = new Size(1280, 750);
                    graphics.CopyFromScreen(rect.Left + 8, rect.Top, 0, 0, screen);
                    image.Save(folder + @"\" + imagenum + @".png", ImageFormat.Png);
                }
            }
            Thread.Sleep(200);
            MyMouseMove(rect.Left + 488, rect.Top + 660);
            Thread.Sleep(200);
            PlayerMove("lmb");
        }

        public static void Sepal_Hunting(int num, int imagenum, string folder)
        {
            var process = Process.GetProcessesByName("StarRail").FirstOrDefault();
            var hwnd = process.MainWindowHandle;
            GetWindowRect(hwnd, out var rect);
            int fuse = 0;
            MyMouseMove(rect.Left + 643, rect.Top + 374);
            Thread.Sleep(200);
            PlayerMove("lmb");
            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
            PlayerMove("f4");
            for (Color pixel = Color.FromArgb(0, 0, 0, 0); Settings.Default.Survival_Index != pixel;)
            {
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    Thread.Sleep(200);
                    using (var graphics = Graphics.FromImage(image))
                    {
                        Size screen = new Size(1280, 750);
                        graphics.CopyFromScreen(rect.Left + 8, rect.Top, 0, 0, screen);
                        pixel = image.GetPixel(510, 180);
                    }
                    if (pixel != Settings.Default.Survival_Index)
                    {
                        pixel = image.GetPixel(300, 185);
                        if (pixel == Settings.Default.Daily_Workout_Menu)
                        {
                            MyMouseMove(rect.Left + 488, rect.Top + 165);
                            PlayerMove("lmb");
                        }
                    }
                }
            }
            Wait_Pixel(Settings.Default.Virtual_Universe_Button, 460, 245, 200);
            MyMouseMove(rect.Left + 408, rect.Top + 420);
            Thread.Sleep(200);
            PlayerMove("lmb");
            Wait_Pixel(Settings.Default.Sepal_Crimson_Button, 460, 410, 200);
            MyMouseMove(rect.Left + 998, rect.Top + 525);
            Thread.Sleep(200);
            PlayerMove("lmb");
            Wait_Pixel(Settings.Default.Fights_Slider, 890, 630, 200);
            Thread.Sleep(200);
            if (num > 0)
            {
                switch (num)
                {
                    case 1:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        Thread.Sleep(200);
                        PlayerMove("lmb");
                        PlayerMove("lmb");
                        break;
                    case 2:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 2; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                    case 3:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 3; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                    case 4:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 4; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                    case 5:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 5; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                }
            }
            MyMouseMove(rect.Left + 1088, rect.Top + 685);
            Thread.Sleep(200);
            PlayerMove("lmb");
            Wait_Pixel(Color.FromArgb(255, 228, 202, 147), 45, 87, 200);
            MyMouseMove(rect.Left + 1123, rect.Top + 685);
            Thread.Sleep(200);
            PlayerMove("lmb");
            for (Color pixel = Color.FromArgb(0, 0, 0, 0); Settings.Default.Fight_Ended_Trigger != pixel;)
            {
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    Thread.Sleep(500);
                    using (var graphics = Graphics.FromImage(image))
                    {
                        Size screen = new Size(1280, 750);
                        graphics.CopyFromScreen(rect.Left + 8, rect.Top, 0, 0, screen);
                        pixel = image.GetPixel(970, 663);
                    }
                    if (pixel != Settings.Default.Fight_Ended_Trigger)
                    {
                        fuse = 0;
                    }
                    if (pixel == Settings.Default.Fight_Ended_Trigger)
                    {
                        if (fuse < 1)
                        {
                            pixel = Color.FromArgb(255, 0, 0, 0);
                            fuse++;
                        }
                    }
                }
            }
            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
            {
                using (var graphics = Graphics.FromImage(image))
                {
                    Size screen = new Size(1280, 750);
                    graphics.CopyFromScreen(rect.Left + 8, rect.Top, 0, 0, screen);
                    image.Save(folder + @"\" + imagenum + @".png", ImageFormat.Png);
                }
            }
            Thread.Sleep(200);
            MyMouseMove(rect.Left + 488, rect.Top + 660);
            Thread.Sleep(200);
            PlayerMove("lmb");
        }

        public static void Sepal_Abundance(int num, int imagenum, string folder)
        {
            var process = Process.GetProcessesByName("StarRail").FirstOrDefault();
            var hwnd = process.MainWindowHandle;
            GetWindowRect(hwnd, out var rect);
            int fuse = 0;
            MyMouseMove(rect.Left + 643, rect.Top + 374);
            Thread.Sleep(200);
            PlayerMove("lmb");
            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
            PlayerMove("f4");
            for (Color pixel = Color.FromArgb(0, 0, 0, 0); Settings.Default.Survival_Index != pixel;)
            {
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    Thread.Sleep(200);
                    using (var graphics = Graphics.FromImage(image))
                    {
                        Size screen = new Size(1280, 750);
                        graphics.CopyFromScreen(rect.Left + 8, rect.Top, 0, 0, screen);
                        pixel = image.GetPixel(510, 180);
                    }
                    if (pixel != Settings.Default.Survival_Index)
                    {
                        pixel = image.GetPixel(300, 185);
                        if (pixel == Settings.Default.Daily_Workout_Menu)
                        {
                            MyMouseMove(rect.Left + 488, rect.Top + 165);
                            PlayerMove("lmb");
                        }
                    }
                }
            }
            Wait_Pixel(Settings.Default.Virtual_Universe_Button, 460, 245, 200);
            MyMouseMove(rect.Left + 408, rect.Top + 420);
            Thread.Sleep(200);
            PlayerMove("lmb");
            Wait_Pixel(Settings.Default.Sepal_Crimson_Button, 460, 410, 200);
            MyMouseMove(rect.Left + 998, rect.Top + 285);
            Thread.Sleep(200);
            for (int i = 0; i != 18; PlayerMove("wld"), i++) ;
            Thread.Sleep(200);
            PlayerMove("lmb");
            Wait_Pixel(Settings.Default.Fights_Slider, 890, 630, 200);
            Thread.Sleep(200);
            if (num > 0)
            {
                switch (num)
                {
                    case 1:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        Thread.Sleep(200);
                        PlayerMove("lmb");
                        PlayerMove("lmb");
                        break;
                    case 2:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 2; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                    case 3:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 3; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                    case 4:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 4; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                    case 5:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 5; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                }
            }
            MyMouseMove(rect.Left + 1088, rect.Top + 685);
            Thread.Sleep(200);
            PlayerMove("lmb");
            Wait_Pixel(Color.FromArgb(255, 228, 202, 147), 45, 87, 200);
            MyMouseMove(rect.Left + 1123, rect.Top + 685);
            Thread.Sleep(200);
            PlayerMove("lmb");
            for (Color pixel = Color.FromArgb(0, 0, 0, 0); Settings.Default.Fight_Ended_Trigger != pixel;)
            {
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    Thread.Sleep(500);
                    using (var graphics = Graphics.FromImage(image))
                    {
                        Size screen = new Size(1280, 750);
                        graphics.CopyFromScreen(rect.Left + 8, rect.Top, 0, 0, screen);
                        pixel = image.GetPixel(970, 663);
                    }
                    if (pixel != Settings.Default.Fight_Ended_Trigger)
                    {
                        fuse = 0;
                    }
                    if (pixel == Settings.Default.Fight_Ended_Trigger)
                    {
                        if (fuse < 1)
                        {
                            pixel = Color.FromArgb(255, 0, 0, 0);
                            fuse++;
                        }
                    }
                }
            }
            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
            {
                using (var graphics = Graphics.FromImage(image))
                {
                    Size screen = new Size(1280, 750);
                    graphics.CopyFromScreen(rect.Left + 8, rect.Top, 0, 0, screen);
                    image.Save(folder + @"\" + imagenum + @".png", ImageFormat.Png);
                }
            }
            Thread.Sleep(200);
            MyMouseMove(rect.Left + 488, rect.Top + 660);
            Thread.Sleep(200);
            PlayerMove("lmb");
        }

        public static void Sepal_Erudition(int num, int imagenum, string folder)
        {
            var process = Process.GetProcessesByName("StarRail").FirstOrDefault();
            var hwnd = process.MainWindowHandle;
            GetWindowRect(hwnd, out var rect);
            int fuse = 0;
            MyMouseMove(rect.Left + 643, rect.Top + 374);
            Thread.Sleep(200);
            PlayerMove("lmb");
            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
            PlayerMove("f4");
            for (Color pixel = Color.FromArgb(0, 0, 0, 0); Settings.Default.Survival_Index != pixel;)
            {
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    Thread.Sleep(200);
                    using (var graphics = Graphics.FromImage(image))
                    {
                        Size screen = new Size(1280, 750);
                        graphics.CopyFromScreen(rect.Left + 8, rect.Top, 0, 0, screen);
                        pixel = image.GetPixel(510, 180);
                    }
                    if (pixel != Settings.Default.Survival_Index)
                    {
                        pixel = image.GetPixel(300, 185);
                        if (pixel == Settings.Default.Daily_Workout_Menu)
                        {
                            MyMouseMove(rect.Left + 488, rect.Top + 165);
                            PlayerMove("lmb");
                        }
                    }
                }
            }
            Wait_Pixel(Settings.Default.Virtual_Universe_Button, 460, 245, 200);
            MyMouseMove(rect.Left + 408, rect.Top + 420);
            Thread.Sleep(200);
            PlayerMove("lmb");
            Wait_Pixel(Settings.Default.Sepal_Crimson_Button, 460, 410, 200);
            MyMouseMove(rect.Left + 998, rect.Top + 405);
            Thread.Sleep(200);
            for (int i = 0; i != 18; PlayerMove("wld"), i++) ;
            Thread.Sleep(200);
            PlayerMove("lmb");
            Wait_Pixel(Settings.Default.Fights_Slider, 890, 630, 200);
            Thread.Sleep(200);
            if (num > 0)
            {
                switch (num)
                {
                    case 1:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        Thread.Sleep(200);
                        PlayerMove("lmb");
                        PlayerMove("lmb");
                        break;
                    case 2:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 2; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                    case 3:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 3; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                    case 4:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 4; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                    case 5:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 5; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                }
            }
            MyMouseMove(rect.Left + 1088, rect.Top + 685);
            Thread.Sleep(200);
            PlayerMove("lmb");
            Wait_Pixel(Color.FromArgb(255, 228, 202, 147), 45, 87, 200);
            MyMouseMove(rect.Left + 1123, rect.Top + 685);
            Thread.Sleep(200);
            PlayerMove("lmb");
            for (Color pixel = Color.FromArgb(0, 0, 0, 0); Settings.Default.Fight_Ended_Trigger != pixel;)
            {
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    Thread.Sleep(500);
                    using (var graphics = Graphics.FromImage(image))
                    {
                        Size screen = new Size(1280, 750);
                        graphics.CopyFromScreen(rect.Left + 8, rect.Top, 0, 0, screen);
                        pixel = image.GetPixel(970, 663);
                    }
                    if (pixel != Settings.Default.Fight_Ended_Trigger)
                    {
                        fuse = 0;
                    }
                    if (pixel == Settings.Default.Fight_Ended_Trigger)
                    {
                        if (fuse < 1)
                        {
                            pixel = Color.FromArgb(255, 0, 0, 0);
                            fuse++;
                        }
                    }
                }
            }
            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
            {
                using (var graphics = Graphics.FromImage(image))
                {
                    Size screen = new Size(1280, 750);
                    graphics.CopyFromScreen(rect.Left + 8, rect.Top, 0, 0, screen);
                    image.Save(folder + @"\" + imagenum + @".png", ImageFormat.Png);
                }
            }
            Thread.Sleep(200);
            MyMouseMove(rect.Left + 488, rect.Top + 660);
            Thread.Sleep(200);
            PlayerMove("lmb");
        }

        public static void Sepal_Harmony(int num, int imagenum, string folder)
        {
            var process = Process.GetProcessesByName("StarRail").FirstOrDefault();
            var hwnd = process.MainWindowHandle;
            GetWindowRect(hwnd, out var rect);
            int fuse = 0;
            MyMouseMove(rect.Left + 643, rect.Top + 374);
            Thread.Sleep(200);
            PlayerMove("lmb");
            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
            PlayerMove("f4");
            for (Color pixel = Color.FromArgb(0, 0, 0, 0); Settings.Default.Survival_Index != pixel;)
            {
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    Thread.Sleep(200);
                    using (var graphics = Graphics.FromImage(image))
                    {
                        Size screen = new Size(1280, 750);
                        graphics.CopyFromScreen(rect.Left + 8, rect.Top, 0, 0, screen);
                        pixel = image.GetPixel(510, 180);
                    }
                    if (pixel != Settings.Default.Survival_Index)
                    {
                        pixel = image.GetPixel(300, 185);
                        if (pixel == Settings.Default.Daily_Workout_Menu)
                        {
                            MyMouseMove(rect.Left + 488, rect.Top + 165);
                            PlayerMove("lmb");
                        }
                    }
                }
            }
            Wait_Pixel(Settings.Default.Virtual_Universe_Button, 460, 245, 200);
            MyMouseMove(rect.Left + 408, rect.Top + 420);
            Thread.Sleep(200);
            PlayerMove("lmb");
            Wait_Pixel(Settings.Default.Sepal_Crimson_Button, 460, 410, 200);
            MyMouseMove(rect.Left + 998, rect.Top + 525);
            Thread.Sleep(200);
            for (int i = 0; i != 18; PlayerMove("wld"), i++) ;
            Thread.Sleep(200);
            PlayerMove("lmb");
            Wait_Pixel(Settings.Default.Fights_Slider, 890, 630, 200);
            Thread.Sleep(200);
            if (num > 0)
            {
                switch (num)
                {
                    case 1:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        Thread.Sleep(200);
                        PlayerMove("lmb");
                        PlayerMove("lmb");
                        break;
                    case 2:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 2; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                    case 3:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 3; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                    case 4:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 4; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                    case 5:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 5; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                }
            }
            MyMouseMove(rect.Left + 1088, rect.Top + 685);
            Thread.Sleep(200);
            PlayerMove("lmb");
            Wait_Pixel(Color.FromArgb(255, 228, 202, 147), 45, 87, 200);
            MyMouseMove(rect.Left + 1123, rect.Top + 685);
            Thread.Sleep(200);
            PlayerMove("lmb");
            for (Color pixel = Color.FromArgb(0, 0, 0, 0); Settings.Default.Fight_Ended_Trigger != pixel;)
            {
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    Thread.Sleep(500);
                    using (var graphics = Graphics.FromImage(image))
                    {
                        Size screen = new Size(1280, 750);
                        graphics.CopyFromScreen(rect.Left + 8, rect.Top, 0, 0, screen);
                        pixel = image.GetPixel(970, 663);
                    }
                    if (pixel != Settings.Default.Fight_Ended_Trigger)
                    {
                        fuse = 0;
                    }
                    if (pixel == Settings.Default.Fight_Ended_Trigger)
                    {
                        if (fuse < 1)
                        {
                            pixel = Color.FromArgb(255, 0, 0, 0);
                            fuse++;
                        }
                    }
                }
            }
            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
            {
                using (var graphics = Graphics.FromImage(image))
                {
                    Size screen = new Size(1280, 750);
                    graphics.CopyFromScreen(rect.Left + 8, rect.Top, 0, 0, screen);
                    image.Save(folder + @"\" + imagenum + @".png", ImageFormat.Png);
                }
            }
            Thread.Sleep(200);
            MyMouseMove(rect.Left + 488, rect.Top + 660);
            Thread.Sleep(200);
            PlayerMove("lmb");
        }

        public static void Sepal_Nothingnessy(int num, int imagenum, string folder)
        {
            var process = Process.GetProcessesByName("StarRail").FirstOrDefault();
            var hwnd = process.MainWindowHandle;
            GetWindowRect(hwnd, out var rect);
            int fuse = 0;
            MyMouseMove(rect.Left + 643, rect.Top + 374);
            Thread.Sleep(200);
            PlayerMove("lmb");
            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
            PlayerMove("f4");
            for (Color pixel = Color.FromArgb(0, 0, 0, 0); Settings.Default.Survival_Index != pixel;)
            {
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    Thread.Sleep(200);
                    using (var graphics = Graphics.FromImage(image))
                    {
                        Size screen = new Size(1280, 750);
                        graphics.CopyFromScreen(rect.Left + 8, rect.Top, 0, 0, screen);
                        pixel = image.GetPixel(510, 180);
                    }
                    if (pixel != Settings.Default.Survival_Index)
                    {
                        pixel = image.GetPixel(300, 185);
                        if (pixel == Settings.Default.Daily_Workout_Menu)
                        {
                            MyMouseMove(rect.Left + 488, rect.Top + 165);
                            PlayerMove("lmb");
                        }
                    }
                }
            }
            Wait_Pixel(Settings.Default.Virtual_Universe_Button, 460, 245, 200);
            MyMouseMove(rect.Left + 408, rect.Top + 420);
            Thread.Sleep(200);
            PlayerMove("lmb");
            Wait_Pixel(Settings.Default.Sepal_Crimson_Button, 460, 410, 200);
            MyMouseMove(rect.Left + 998, rect.Top + 565);
            Thread.Sleep(200);
            for (int i = 0; i != 22; PlayerMove("wld"), i++) ;
            Thread.Sleep(200);
            PlayerMove("lmb");
            Wait_Pixel(Settings.Default.Fights_Slider, 890, 630, 200);
            Thread.Sleep(200);
            if (num > 0)
            {
                switch (num)
                {
                    case 1:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        Thread.Sleep(200);
                        PlayerMove("lmb");
                        PlayerMove("lmb");
                        break;
                    case 2:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 2; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                    case 3:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 3; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                    case 4:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 4; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                    case 5:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 5; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                }
            }
            MyMouseMove(rect.Left + 1088, rect.Top + 685);
            Thread.Sleep(200);
            PlayerMove("lmb");
            Wait_Pixel(Color.FromArgb(255, 228, 202, 147), 45, 87, 200);
            MyMouseMove(rect.Left + 1123, rect.Top + 685);
            Thread.Sleep(200);
            PlayerMove("lmb");
            for (Color pixel = Color.FromArgb(0, 0, 0, 0); Settings.Default.Fight_Ended_Trigger != pixel;)
            {
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    Thread.Sleep(500);
                    using (var graphics = Graphics.FromImage(image))
                    {
                        Size screen = new Size(1280, 750);
                        graphics.CopyFromScreen(rect.Left + 8, rect.Top, 0, 0, screen);
                        pixel = image.GetPixel(970, 663);
                    }
                    if (pixel != Settings.Default.Fight_Ended_Trigger)
                    {
                        fuse = 0;
                    }
                    if (pixel == Settings.Default.Fight_Ended_Trigger)
                    {
                        if (fuse < 1)
                        {
                            pixel = Color.FromArgb(255, 0, 0, 0);
                            fuse++;
                        }
                    }
                }
            }
            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
            {
                using (var graphics = Graphics.FromImage(image))
                {
                    Size screen = new Size(1280, 750);
                    graphics.CopyFromScreen(rect.Left + 8, rect.Top, 0, 0, screen);
                    image.Save(folder + @"\" + imagenum + @".png", ImageFormat.Png);
                }
            }
            Thread.Sleep(200);
            MyMouseMove(rect.Left + 488, rect.Top + 660);
            Thread.Sleep(200);
            PlayerMove("lmb");
        }

        public static void Sepal_Person_EXP(int num, int imagenum, string folder)
        {
            var process = Process.GetProcessesByName("StarRail").FirstOrDefault();
            var hwnd = process.MainWindowHandle;
            int fuse = 0;
            GetWindowRect(hwnd, out var rect);
            MyMouseMove(rect.Left + 643, rect.Top + 374);
            Thread.Sleep(200);
            PlayerMove("lmb");
            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
            PlayerMove("f4");
            for (Color pixel = Color.FromArgb(0, 0, 0, 0); Settings.Default.Survival_Index != pixel;)
            {
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    Thread.Sleep(200);
                    using (var graphics = Graphics.FromImage(image))
                    {
                        Size screen = new Size(1280, 750);
                        graphics.CopyFromScreen(rect.Left + 8, rect.Top, 0, 0, screen);
                        pixel = image.GetPixel(510, 180);
                    }
                    if (pixel != Settings.Default.Survival_Index)
                    {
                        pixel = image.GetPixel(300, 185);
                        if (pixel == Settings.Default.Daily_Workout_Menu)
                        {
                            MyMouseMove(rect.Left + 488, rect.Top + 165);
                            PlayerMove("lmb");
                        }
                    }
                }
            }
            Wait_Pixel(Settings.Default.Virtual_Universe_Button, 460, 245, 200);
            MyMouseMove(rect.Left + 408, rect.Top + 330);
            Thread.Sleep(200);
            PlayerMove("lmb");
            Wait_Pixel(Settings.Default.Sepal_Gold_Button, 460, 330, 200);
            MyMouseMove(rect.Left + 998, rect.Top + 285);
            Thread.Sleep(200);
            PlayerMove("lmb");
            Wait_Pixel(Settings.Default.Fights_Slider, 890, 630, 200);
            Thread.Sleep(200);
            if (num > 0)
            {
                switch (num)
                {
                    case 1:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        Thread.Sleep(200);
                        PlayerMove("lmb");
                        PlayerMove("lmb");
                        break;
                    case 2:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 2; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                    case 3:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 3; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                    case 4:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 4; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                    case 5:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 5; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                }
            }
            MyMouseMove(rect.Left + 1088, rect.Top + 685);
            Thread.Sleep(200);
            PlayerMove("lmb");
            Wait_Pixel(Color.FromArgb(255, 228, 202, 147), 45, 87, 200);
            MyMouseMove(rect.Left + 1123, rect.Top + 685);
            Thread.Sleep(200);
            PlayerMove("lmb");
            for (Color pixel = Color.FromArgb(0, 0, 0, 0); Settings.Default.Fight_Ended_Trigger != pixel;)
            {
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    Thread.Sleep(500);
                    using (var graphics = Graphics.FromImage(image))
                    {
                        Size screen = new Size(1280, 750);
                        graphics.CopyFromScreen(rect.Left + 8, rect.Top, 0, 0, screen);
                        pixel = image.GetPixel(970, 663);
                    }
                    if (pixel != Settings.Default.Fight_Ended_Trigger)
                    {
                        fuse = 0;
                    }
                    if (pixel == Settings.Default.Fight_Ended_Trigger)
                    {
                        if (fuse < 1)
                        {
                            pixel = Color.FromArgb(255, 0, 0, 0);
                            fuse++;
                        }
                    }
                }
            }
            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
            {
                using (var graphics = Graphics.FromImage(image))
                {
                    Size screen = new Size(1280, 750);
                    graphics.CopyFromScreen(rect.Left + 8, rect.Top, 0, 0, screen);
                    image.Save(folder + @"\" + imagenum + @".png", ImageFormat.Png);
                }
            }
            Thread.Sleep(200);
            MyMouseMove(rect.Left + 488, rect.Top + 660);
            Thread.Sleep(200);
            PlayerMove("lmb");
        }

        public static void Sepal_Weapon_EXP(int num, int imagenum, string folder)
        {
            var process = Process.GetProcessesByName("StarRail").FirstOrDefault();
            var hwnd = process.MainWindowHandle;
            GetWindowRect(hwnd, out var rect);
            int fuse = 0;
            MyMouseMove(rect.Left + 643, rect.Top + 374);
            Thread.Sleep(200);
            PlayerMove("lmb");
            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
            PlayerMove("f4");
            for (Color pixel = Color.FromArgb(0, 0, 0, 0); Settings.Default.Survival_Index != pixel;)
            {
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    Thread.Sleep(200);
                    using (var graphics = Graphics.FromImage(image))
                    {
                        Size screen = new Size(1280, 750);
                        graphics.CopyFromScreen(rect.Left + 8, rect.Top, 0, 0, screen);
                        pixel = image.GetPixel(510, 180);
                    }
                    if (pixel != Settings.Default.Survival_Index)
                    {
                        pixel = image.GetPixel(300, 185);
                        if (pixel == Settings.Default.Daily_Workout_Menu)
                        {
                            MyMouseMove(rect.Left + 488, rect.Top + 165);
                            PlayerMove("lmb");
                        }
                    }
                }
            }
            Wait_Pixel(Settings.Default.Virtual_Universe_Button, 460, 245, 200);
            MyMouseMove(rect.Left + 408, rect.Top + 330);
            Thread.Sleep(200);
            PlayerMove("lmb");
            Wait_Pixel(Settings.Default.Sepal_Gold_Button, 460, 330, 200);
            MyMouseMove(rect.Left + 998, rect.Top + 405);
            Thread.Sleep(200);
            PlayerMove("lmb");
            Wait_Pixel(Settings.Default.Fights_Slider, 890, 630, 200);
            Thread.Sleep(200);
            if (num > 0)
            {
                switch (num)
                {
                    case 1:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        Thread.Sleep(200);
                        PlayerMove("lmb");
                        PlayerMove("lmb");
                        break;
                    case 2:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 2; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                    case 3:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 3; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                    case 4:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 4; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                    case 5:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 5; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                }
            }
            MyMouseMove(rect.Left + 1088, rect.Top + 685);
            Thread.Sleep(200);
            PlayerMove("lmb");
            Wait_Pixel(Color.FromArgb(255, 228, 202, 147), 45, 87, 200);
            MyMouseMove(rect.Left + 1123, rect.Top + 685);
            Thread.Sleep(200);
            PlayerMove("lmb");
            for (Color pixel = Color.FromArgb(0, 0, 0, 0); Settings.Default.Fight_Ended_Trigger != pixel;)
            {
                int i = 0;
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    Thread.Sleep(500);
                    using (var graphics = Graphics.FromImage(image))
                    {
                        Size screen = new Size(1280, 750);
                        graphics.CopyFromScreen(rect.Left + 8, rect.Top, 0, 0, screen);
                        pixel = image.GetPixel(970, 663);
                    }
                    if (pixel != Settings.Default.Fight_Ended_Trigger)
                    {
                        fuse = 0;
                    }
                    if (pixel == Settings.Default.Fight_Ended_Trigger)
                    {
                        if (fuse < 1)
                        {
                            pixel = Color.FromArgb(255, 0, 0, 0);
                            fuse++;
                        }
                    }
                }
            }
            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
            {
                using (var graphics = Graphics.FromImage(image))
                {
                    Size screen = new Size(1280, 750);
                    graphics.CopyFromScreen(rect.Left + 8, rect.Top, 0, 0, screen);
                    image.Save(folder + @"\" + imagenum + @".png", ImageFormat.Png);
                }
            }
            Thread.Sleep(200);
            MyMouseMove(rect.Left + 488, rect.Top + 660);
            Thread.Sleep(200);
            PlayerMove("lmb");
        }

        public static void Sepal_Money(int num, int imagenum, string folder)
        {
            var process = Process.GetProcessesByName("StarRail").FirstOrDefault();
            var hwnd = process.MainWindowHandle;
            GetWindowRect(hwnd, out var rect);
            int fuse = 0;
            MyMouseMove(rect.Left + 643, rect.Top + 374);
            Thread.Sleep(200);
            PlayerMove("lmb");
            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
            PlayerMove("f4");
            for (Color pixel = Color.FromArgb(0, 0, 0, 0); Settings.Default.Survival_Index != pixel;)
            {
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    Thread.Sleep(200);
                    using (var graphics = Graphics.FromImage(image))
                    {
                        Size screen = new Size(1280, 750);
                        graphics.CopyFromScreen(rect.Left + 8, rect.Top, 0, 0, screen);
                        pixel = image.GetPixel(510, 180);
                    }
                    if (pixel != Settings.Default.Survival_Index)
                    {
                        pixel = image.GetPixel(300, 185);
                        if (pixel == Settings.Default.Daily_Workout_Menu)
                        {
                            MyMouseMove(rect.Left + 488, rect.Top + 165);
                            PlayerMove("lmb");
                        }
                    }
                }
            }
            Wait_Pixel(Settings.Default.Virtual_Universe_Button, 460, 245, 200);
            MyMouseMove(rect.Left + 408, rect.Top + 330);
            Thread.Sleep(200);
            PlayerMove("lmb");
            Wait_Pixel(Settings.Default.Sepal_Gold_Button, 460, 330, 200);
            MyMouseMove(rect.Left + 998, rect.Top + 525);
            Thread.Sleep(200);
            PlayerMove("lmb");
            Wait_Pixel(Settings.Default.Fights_Slider, 890, 630, 200);
            Thread.Sleep(200);
            if (num > 0)
            {
                switch (num)
                {
                    case 1:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        Thread.Sleep(200);
                        PlayerMove("lmb");
                        PlayerMove("lmb");
                        break;
                    case 2:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 2; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                    case 3:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 3; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                    case 4:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 4; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                    case 5:
                        MyMouseMove(rect.Left + 1238, rect.Top + 630);
                        PlayerMove("lmb");
                        for (int i = 0; i != 5; i++)
                        {
                            Thread.Sleep(200);
                            PlayerMove("lmb");
                        }
                        break;
                }
            }
            MyMouseMove(rect.Left + 1088, rect.Top + 685);
            Thread.Sleep(200);
            PlayerMove("lmb");
            Wait_Pixel(Color.FromArgb(255, 228, 202, 147), 45, 87, 200);
            MyMouseMove(rect.Left + 1123, rect.Top + 685);
            Thread.Sleep(200);
            PlayerMove("lmb");
            for (Color pixel = Color.FromArgb(0, 0, 0, 0); Settings.Default.Fight_Ended_Trigger != pixel;)
            {
                using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
                {
                    Thread.Sleep(500);
                    using (var graphics = Graphics.FromImage(image))
                    {
                        Size screen = new Size(1280, 750);
                        graphics.CopyFromScreen(rect.Left + 8, rect.Top, 0, 0, screen);
                        pixel = image.GetPixel(970, 663);
                    }
                    if (pixel != Settings.Default.Fight_Ended_Trigger)
                    {
                        fuse = 0;
                    }
                    if (pixel == Settings.Default.Fight_Ended_Trigger)
                    {
                        if (fuse < 1)
                        {
                            pixel = Color.FromArgb(255, 0, 0, 0);
                            fuse++;
                        }
                    }
                }
            }
            using (var image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top))
            {
                using (var graphics = Graphics.FromImage(image))
                {
                    Size screen = new Size(1280, 750);
                    graphics.CopyFromScreen(rect.Left + 8, rect.Top, 0, 0, screen);
                    image.Save(folder + @"\" + imagenum + @".png", ImageFormat.Png);
                }
            }
            Thread.Sleep(200);
            MyMouseMove(rect.Left + 488, rect.Top + 660);
            Thread.Sleep(200);
            PlayerMove("lmb");
        }

        public static void Debug_Mode()
        {
            var process = Process.GetProcessesByName("StarRail").FirstOrDefault();
            var hwnd = process.MainWindowHandle;
            GetWindowRect(hwnd, out var rect);
            int fuse = 0;
            MyMouseMove(rect.Left + 643, rect.Top + 374);
            Thread.Sleep(200);
            PlayerMove("lmb");
            {
                MessageBox.Show(
                "Нажмите ок, когда игра будет в стартовом положении",
                "Отладка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            }
            Settings.Default["Phone_Ico_TopLeft"] = functions.Get_Pixel(28, 75);
            PlayerMove("f4");
            {
                MessageBox.Show(
                "Откройте меню 'Ежедневная тренеровка' и нажмите ок",
                "Отладка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            }
            Settings.Default["Daily_Workout_Menu"] = functions.Get_Pixel(300, 185);
            {
                MessageBox.Show(
                "Откройте меню 'Индекс вышиваемости' и нажмите ок",
                "Отладка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            }
            Settings.Default["Survival_Index"] = functions.Get_Pixel(510, 180);
            Settings.Default["Virtual_Universe_Button"] = functions.Get_Pixel(460, 245);
            MyMouseMove(rect.Left + 408, rect.Top + 330);
            Thread.Sleep(200);
            PlayerMove("lmb");
            {
                MessageBox.Show(
                "Нажмите ок, когда вкладка 'Чажелист (золотой)' будет открыта",
                "Отладка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            }
            Settings.Default["Sepal_Gold_Button"] = functions.Get_Pixel(460, 330);
            MyMouseMove(rect.Left + 408, rect.Top + 420);
            Thread.Sleep(200);
            PlayerMove("lmb");
            {
                MessageBox.Show(
                "Нажмите ок, когда вкладка 'Чажелист (багровый)' будет открыта",
                "Отладка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            }
            Settings.Default["Sepal_Crimson_Button"] = functions.Get_Pixel(460, 410);
            MyMouseMove(rect.Left + 998, rect.Top + 285);
            Thread.Sleep(200);
            PlayerMove("lmb");
            {
                MessageBox.Show(
                "Нажмите ок, когда персонаж будет телепортирован и откроется меню перед битвой",
                "Отладка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            }
            Settings.Default["Fights_Slider"] = functions.Get_Pixel(890, 630);
            Settings.Default["Fight_Ended_Trigger"] = functions.Get_Pixel(1245, 631);
            MyMouseMove(rect.Left + 1088, rect.Top + 685);
            Thread.Sleep(200);
            PlayerMove("lmb");
            {
                MessageBox.Show(
                "Нажмите ок, когда будет загружено меню выбора групп",
                "Отладка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            }
            Settings.Default["Fight_Group_Ico"] = functions.Get_Pixel(45, 87);
            Settings.Default.Save();
            PlayerMove("esc");
            functions.Wait_Pixel(Settings.Default.Fights_Slider, 890, 630, 200);
            Thread.Sleep(200);
            PlayerMove("esc");
            functions.Wait_Pixel(Settings.Default.Phone_Ico_TopLeft, 28, 75, 200);
            {
                MessageBox.Show(
                "Отладка успешно завершена, можете запускать программу в обычном режиме",
                "Отладка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}
