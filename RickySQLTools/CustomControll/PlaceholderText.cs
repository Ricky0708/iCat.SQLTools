using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RickySQLTools.CustomControll
{
    public class PlaceholderText : TextBox
    {

        public string PlaceHolder
        {
            get { return lblHolder.Text; }
            set { lblHolder.Text = value; }
        }

        Label lblHolder;
        public PlaceholderText()
        {
            lblHolder = new Label();
            lblHolder.Name = "Holder";
            PlaceHolder  = "Write something here for filter";
            lblHolder.AutoSize = true;
            lblHolder.Location = new System.Drawing.Point(0, 0);
            lblHolder.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(136)));

            this.BackColor = System.Drawing.SystemColors.Info;
            Controls.Add(lblHolder);
            SetEvent();
   
        }

        private void SetEvent()
        {
            lblHolder.Click += (sender, e) =>
            {
                lblHolder.Hide();
                this.Focus();
            };

            this.GotFocus += PlaceholderText_GotFocus;
            this.LostFocus += PlaceholderText_LostFocus;
        }

        private void PlaceholderText_LostFocus(object sender, EventArgs e)
        {
            if (this.Text =="")
            {
                lblHolder.Show();
            }
        }

        private void PlaceholderText_GotFocus(object sender, EventArgs e)
        {
            lblHolder.Hide();
        }
    }
}
