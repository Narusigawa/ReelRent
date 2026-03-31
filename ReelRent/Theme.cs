using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ReelRent
{
    public static class Theme
    {
        // Основной тёмный фон (26, 22, 45)
        public static Color BackColor = Color.FromArgb(26, 22, 45);
        // Панель (светлее основного фона)
        public static Color PanelColor = Color.FromArgb(45, 38, 72);
        // Кнопки – прозрачные (фон не виден)
        public static Color ButtonBackColor = Color.Transparent;
        // Акцентный оранжевый при наведении (227, 136, 82)
        public static Color ButtonHoverColor = Color.FromArgb(227, 136, 82);
        // Основной цвет текста (светлый)
        public static Color ForeColor = Color.FromArgb(245, 239, 225);
        // Цвет для логотипа и акцентных надписей (бежевый)
        public static Color AccentForeColor = Color.FromArgb(245, 239, 225);
        // Шрифт по умолчанию
        public static Font DefaultFont = new Font("Segoe UI", 10);
    }
}
