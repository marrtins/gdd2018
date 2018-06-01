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
    }
}
