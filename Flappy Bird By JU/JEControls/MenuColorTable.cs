using System.Drawing;
using System.Windows.Forms;

namespace Flappy_Bird_By_JU

{
    public class MenuColorTable : ProfessionalColorTable
    {
        //Fields
        private Color backColor;
        private Color leftColumnColor;
        private Color borderColor;
        private Color menuItemBorderColor;
        private Color menuItemSelectionColor;

        public MenuColorTable(bool isMainMenu, Color primaryColor)
        {
            if (isMainMenu)
            {
                backColor = Color.FromArgb(37, 39, 60);
                leftColumnColor = Color.FromArgb(32, 33, 51);
                borderColor = Color.FromArgb(32, 33, 51);
                menuItemBorderColor = primaryColor;
                menuItemSelectionColor = primaryColor;
            }
            else
            {
                backColor = Color.White;
                leftColumnColor = Color.LightGray;
                borderColor = Color.LightGray;
                menuItemBorderColor = primaryColor;
                menuItemSelectionColor = primaryColor;
            }
        }
        //Override
        public override Color ToolStripDropDownBackground
        {
            get
            {
                return backColor;
            }
        }
        public override Color MenuBorder
        {
            get
            {
                return borderColor;
            }
        }
        public override Color MenuItemBorder
        {
            get
            {
                return menuItemBorderColor;
            }
        }
        public override Color MenuItemSelected
        {
            get
            {
                return menuItemSelectionColor;
            }
        }
        public override Color ImageMarginGradientBegin
        {
            get
            {
                return leftColumnColor;
            }
        }
        public override Color ImageMarginGradientMiddle
        {
            get
            {
                return leftColumnColor;
            }
        }
        public override Color ImageMarginGradientEnd
        {
            get
            {
                return leftColumnColor;
            }
        }
    }
}