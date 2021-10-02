//using GSF.Communication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientUdpNotificacion
{
  public class ClientUdp
    {

        UdpClient listener;
        public string Tipo { get; set; }
        public event Action<string>MensajeEnviado, NotificacionEnviada, AlertaEnviada;


        public void Iniciar()
        {
                Task.Run(() =>
                {
                    IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 8000);
                    listener = new UdpClient();
                    listener.EnableBroadcast = true;
                    listener.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                    listener.Client.Bind(new IPEndPoint(IPAddress.Any, 8000));
                    
                    try
                    {
                       

                    while (true)
                    {
                        byte[] buffer = listener.Receive(ref RemoteIpEndPoint);

                        string datos = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                        var infos = datos.Split('|');
                        if (infos[1] == "Mensaje")
                            {
                                Tipo = infos[1];
                                MensajeEnviado(infos[0]);
                            }
                            if (infos[1] == "Notificación")
                            {
                                Tipo = infos[1];
                                NotificacionEnviada(infos[0]);
                               
                            }
                            if (infos[1] == "Alerta")
                            {
                                Tipo = infos[1];
                                AlertaEnviada(infos[0]);
                            }
                        }
                    }
                    catch (SocketException  )
                    {
                       
                    }
                });
        }
    }
}
