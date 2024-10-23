using System.Windows.Forms;

namespace tic_tac_2
{
    public partial class Form1 : Form
    {
        private extendedControl t;
        public Form1()
        {

            InitializeComponent();
            t = new extendedControl();
            t.Visible = true;
            this.Controls.Add(t);
        }
    }
}
