using FrbaHotel.AbmHotel.Model;
using System.ComponentModel;
using System.Windows.Forms;

namespace FrbaHotel.AbmHotel
{
    public partial class Listado : Form
    {
        HotelesRepository hotelesRepository = new HotelesRepository();

        public Listado()
        {
            InitializeComponent();

            this.hotelesGridView.DataSource = hotelesRepository.Hoteles;

            hotelesRepository.Refresh();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            Insertar ins = new Insertar(1);
            ins.ShowDialog();
            this.Hide();
        }
    }
}
