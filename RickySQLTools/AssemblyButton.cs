using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickySQLTools
{
    public class AssemblyButton : System.Windows.Forms.Button
    {
        public AssemblyButton()
        {
            base.MouseHover += new System.EventHandler(AssemblyButton_MouseHover);
            base.MouseLeave += new System.EventHandler(AssemblyButton_MouseLeave);
            base.LostFocus += new System.EventHandler(AssemblyButton_LostFocus);

            base.DoubleBuffered = true;
            base.Size = new System.Drawing.Size(85, 40);
            base.BackColor = System.Drawing.Color.LightSteelBlue;

        }
        public string AssName { get; set; }
        public string ObjectName { get; set; }

        private void AssemblyButton_MouseHover(object sender, EventArgs e)
        {
            if (!base.Focused)
            {
                base.BackColor = System.Drawing.Color.LightYellow;
            }
        }

        private void AssemblyButton_MouseLeave(object sender, EventArgs e)
        {
            if (!base.Focused)
            {
                base.BackColor = System.Drawing.Color.LightSteelBlue;
            }
        }
        private void AssemblyButton_LostFocus(object sender, EventArgs e)
        {
            base.BackColor = System.Drawing.Color.LightSteelBlue;

        }

    }
}
