using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Flappy_Bird_By_JU
{
    public class JEDropdawnMenu : ContextMenuStrip
    {
        //Fields
        private bool isMainMenu;
        private int menuItemHeight = 25;
        private Color menuItemTextColor = Color.Navy;
        private Color primaryColor = Color.White;
        private Bitmap menuItemHeaderSize;
        //Properties
        [Category("JEControls")]
        [Browsable(false)]
        public bool IsMainMenu
        {
            get
            {
                return isMainMenu;
            }

            set
            {
                isMainMenu = value;
            }
        }
        [Category("JEControls")]
        [Browsable(false)]
        public int MenuItemHeight
        {
            get
            {
                return menuItemHeight;
            }

            set
            {
                menuItemHeight = value;
            }
        }
        [Category("JEControls")]
        [Browsable(false)]
        public Color MenuItemTextColor
        {
            get
            {
                return menuItemTextColor;
            }

            set
            {
                menuItemTextColor = value;
            }
        }
        [Category("JEControls")]
        [Browsable(false)]
        public Color PrimaryColor
        {
            get
            {
                return primaryColor;
            }

            set
            {
                primaryColor = value;
            }
        }
        [Category("JEControls")]
        [Browsable(false)]
        public Bitmap MenuItemHeaderSize
        {
            get
            {
                return menuItemHeaderSize;
            }

            set
            {
                menuItemHeaderSize = value;
            }
        }

        //Constructer
        public JEDropdawnMenu(IContainer container) :
            base(container)
        {

        }

        //Private Method
        private void LoadMenuItemAppearance()
        {
            if (IsMainMenu)
            {
                menuItemHeaderSize = new Bitmap(25, 45);
                MenuItemTextColor = Color.Gainsboro;
            }
            else
            {
                menuItemHeaderSize = new Bitmap(15, menuItemHeight);
            }
            foreach (ToolStripMenuItem menuItem1 in this.Items)
            {
                menuItem1.ForeColor = menuItemTextColor;
                menuItem1.ImageScaling = ToolStripItemImageScaling.None;
                if (menuItem1.Image == null) menuItem1.Image = menuItemHeaderSize;

                foreach (ToolStripMenuItem menuItem2 in menuItem1.DropDownItems)
                {
                    menuItem2.ForeColor = menuItemTextColor;
                    menuItem2.ImageScaling = ToolStripItemImageScaling.None;
                    if (menuItem2.Image == null) menuItem2.Image = menuItemHeaderSize;

                    foreach (ToolStripMenuItem menuItem3 in menuItem2.DropDownItems)
                    {
                        menuItem3.ForeColor = menuItemTextColor;
                        menuItem3.ImageScaling = ToolStripItemImageScaling.None;
                        if (menuItem3.Image == null) menuItem3.Image = menuItemHeaderSize;

                        foreach (ToolStripMenuItem menuItem4 in menuItem3.DropDownItems)
                        {
                            menuItem4.ForeColor = menuItemTextColor;
                            menuItem4.ImageScaling = ToolStripItemImageScaling.None;
                            if (menuItem4.Image == null) menuItem4.Image = menuItemHeaderSize;
                            //Level 5++
                        }
                    }
                }
            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (this.DesignMode == false)
            {
                LoadMenuItemAppearance();
                this.Renderer = new MenuRenderer(isMainMenu, primaryColor, menuItemTextColor);
            }
        }
    }
}
