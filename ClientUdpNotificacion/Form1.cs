using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientUdpNotificacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            client.MensajeEnviado += Client_MensajeEnviado;
            client.NotificacionEnviada += Client_NotificacionEnviada;
            client.AlertaEnviada += Client_AlertaEnviada;
        }
        ClientUdp client = new ClientUdp();
        Icon alertaicon = new Icon("Assets/alerta.ico");
        Icon mensajeicon = new Icon("Assets/mensaje.ico");
        Icon notificacionicon = new Icon("Assets/notificacion.ico");
        private void Form1_Load(object sender, EventArgs e)
        {
          
            client.Iniciar();
        }
        private void Client_AlertaEnviada(string obj)
        {
            //metodo privado para invocar, ya que esta en otro hilo.
            ntfIcon.Icon = alertaicon;
            ntfIcon.Text = "Alerta de ING JULIO";
            ntfIcon.Visible = true;
            ntfIcon.BalloonTipText = obj;
            ntfIcon.BalloonTipTitle = "Alerta";
            ntfIcon.ShowBalloonTip(200);
        }
        private void Client_NotificacionEnviada(string obj)
        {
            //metodo privado para invocar, ya que esta en otro hilo.
            ntfIcon.Icon = notificacionicon;
            ntfIcon.Text = "Notificación de ING JULIO";
            ntfIcon.Visible = true;
            ntfIcon.BalloonTipText = obj;
            ntfIcon.BalloonTipTitle = "Notificación";      
            ntfIcon.ShowBalloonTip(200);
        }
        private void Client_MensajeEnviado(string obj)
        {
            //metodo privado para invocar, ya que esta en otro hilo.
            Invoke((Action)(() =>
            {
                ntfIcon.Icon = mensajeicon;
                ntfIcon.Text = "Mensaje de ING JULIO";
                ntfIcon.Visible = true;
                ntfIcon.BalloonTipText = obj;
                ntfIcon.BalloonTipTitle = "Mensaje";
                ntfIcon.ShowBalloonTip(200);
            }));
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
