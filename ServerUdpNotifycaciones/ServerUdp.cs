using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerUdpNotifycaciones
{
   public class ServerUdp
    {
        UdpClient server = new UdpClient() { EnableBroadcast = true };
        
     
           
        public void Enviar(string mensaje, string tipo)
        {

           
                string datos = $"{mensaje}|{tipo}";
                byte[] buffer = Encoding.UTF8.GetBytes(datos);
                server.Send(buffer, buffer.Length, new IPEndPoint(IPAddress.Broadcast, 8000));
           
        

        }
    }
}
