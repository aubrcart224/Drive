using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drive
{
    public partial class endScreen : UserControl
    {
        public endScreen()
        {
            InitializeComponent();
            endTextLable.Text = $"Your Score Was{GameScreen.score}";
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            // back to menu screen 
            MenuScreen ms = new MenuScreen();
            this.Controls.Add(ms);

            ms.Location = new Point((this.Width - ms.Width) / 2, (this.Height - ms.Height) / 2);
        }
    }
}
