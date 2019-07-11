using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;

namespace PublicApi
{
    public class MessageTool
    {
        TcpClient Client;
        public event Action<SM> Receive;
        private BinaryFormatter formatter = new BinaryFormatter();
        private Action<string> end;
        public void End(Action<string> end)
        {
            this.end = end;
        }
        public MessageTool(TcpClient Client)
        {
            this.Client = Client;
            if (this.Client != null && this.Client.Connected)
            {
                Thread th = new Thread(() =>
                {
                    try
                    {
                        NetworkStream ns = Client.GetStream();
                        ns.ReadTimeout = 40 * 1000;
                        byte[] bytes = new byte[1024];
                        int recv;
                        do
                        {
                            recv = ns.Read(bytes, 0, bytes.Length);
                            MemoryStream stream = new MemoryStream(bytes, 0, recv);
                            SM sm = (SM)formatter.Deserialize(stream);
                            if (Receive != null && !"ping".Equals(sm.Type))
                            {
                                Receive(sm);
                            }
                        } while (recv != 0);
                        ns.Close();
                        Client.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    if (end != null) { end(""); }
                });
                th.Start();
                Thread th2 = new Thread(() =>
                {
                    try
                    {
                        while (Client.Connected)
                        {
                            SM sm = new SM();
                            sm.Type = "ping";
                            Send(sm);
                            Thread.Sleep(30 * 1000);
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                });
                th2.Start();
            }
        }
        public void Send(SM msg)
        {
            try
            {
                NetworkStream ns = Client.GetStream();
                ns.WriteTimeout = 3 * 1000;
                MemoryStream stream = new MemoryStream();
                formatter.Serialize(stream, msg);
                stream.Seek(0, SeekOrigin.Begin);
                byte[] buffer = new byte[(int)stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                stream.Close();
                ns.Write(buffer, 0, buffer.Length);
                ns.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
