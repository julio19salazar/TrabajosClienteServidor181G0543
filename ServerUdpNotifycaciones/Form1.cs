using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerUdpNotifycaciones
{
    public partial class frmServidor : Form
    {
        public frmServidor()
        {
            InitializeComponent();
        }
        ServerUdp server = new ServerUdp();
        private void btnEnviar_Click(object sender, EventArgs e)
        {



            if (!string.IsNullOrWhiteSpace(rtbMensaje.Text) && cmbTipos.SelectedIndex >= 0)
            {
                server.Enviar(rtbMensaje.Text, cmbTipos.Text);
            }
            else
            {
                MessageBox.Show("Rellene los campos");
            }
        }

        private void frmServidor_Load(object sender, EventArgs e)
        {
                 }
    }
}
