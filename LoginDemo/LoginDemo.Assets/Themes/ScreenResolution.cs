using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoginDemo.Assets.Themes
{
    public class ScreenResolution
    {

        public double PrimaryScreenWidth { get; set; }
        public double PrimaryScreenHeight { get; set; }

        public ScreenResolution()
        {
            PrimaryScreenWidth = SystemParameters.PrimaryScreenHeight * 0.8 * 400 / 900;//得到屏幕整体宽度
            PrimaryScreenHeight = SystemParameters.PrimaryScreenHeight * 0.8;//得到屏幕整体高度

        }

    }
}
