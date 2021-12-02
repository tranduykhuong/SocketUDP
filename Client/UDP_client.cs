using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Client
{
    public class UDP_client
    {
        public UDP_client(string IP, int _port, int buffer_len = 10485760)
        {
            IpAdd = IPAddress.Parse(IP);
            port = _port;
            buff_size = buffer_len;
            ClientSocket = null;
        }
        public bool run()
        {
            if (connect() == false) return false;
            else
            {
                MessageBox.Show("Connected to server successfully", "Connected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
        }

        private bool connect()
        {
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            if (ClientSocket == null)
            {
                MessageBox.Show("Client cannot create socket !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            ClientSocket.Connect(IpAdd, port);

            if (!(ClientSocket.Connected))
            {
                MessageBox.Show("Client cannot connect to server !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public void SendRequest(string request)
        {
            try
            {
                IPEndPoint ipEndPoint = new IPEndPoint(IpAdd, port);

                byte[] buffer = Encoding.UTF8.GetBytes(request);
                ClientSocket.SendTo(buffer, buffer.Length, SocketFlags.None, ipEndPoint);
            }
            catch { }
        }

        public void requestOption_Provinces()
        {
            string req = "{ \"proceed\": \"option\", \"codePro\": \"\"}";
            SendRequest(req);
        }

        public void requestOption_Districts(string codeD)
        {
            string req = "{ \"proceed\": \"option\", \"codePro\": \"" + codeD + "\"}";
            SendRequest(req);
        }

        public void requestPlacesList_Filter(string pro, string dis)
        {
            string req = "{\"proceed\": \"filter\", \"codePro\":\"" + pro + "\", \"codeDis\": \"" + dis + "\"}";
            SendRequest(req);
        }
        public void requestPlacesList_Search(string tourist_area)
        {
            string req = "{\"proceed\": \"search\", \"key\":\"" + tourist_area + "\"}";
            SendRequest(req);
        }
        public void requestPlacesList_Detail(string code)
        {
            string req = "{\"proceed\": \"detail\", \"code\":\"" + code + "\"}";
            SendRequest(req);
        }
        public void requestPlacesList_Image(string code)
        {
            string req = "{\"proceed\": \"img\", \"code\":\"" + code + "\"}";
            SendRequest(req);
        }

        public void ReceiveResponse()
        {
            try
            {
                IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
                EndPoint remote = (EndPoint)sender;
                byte[] resBuff = new byte[buff_size];
                int bytes = ClientSocket.ReceiveFrom(resBuff, ref remote);

                byte[] data = new byte[bytes];
                Array.Copy(resBuff, data, bytes);
                string response = Encoding.UTF8.GetString(data);
                //MessageBox.Show(response);
                JObject Objs = JObject.Parse(response);
                //MessageBox.Show(Objs.ToString());
                //MessageBox.Show(Objs["data"].ToString(), remote.ToString());

                if (Objs.ContainsKey("proceed") == false) return;

                if (Objs["proceed"].ToString() == "option")
                {
                    if (Objs["type"].ToString() == "province")
                    {
                        provinces = new Dictionary<string, string>();
                        provinces = JsonConvert.DeserializeObject<Dictionary<string, string>>(Objs["data"].ToString());
                    }
                    else if (Objs["type"].ToString() == "district")
                    {
                        districts = new Dictionary<string, string>();
                        districts = JsonConvert.DeserializeObject<Dictionary<string, string>>(Objs["data"].ToString());
                    }
                }
                else if (Objs["proceed"].ToString() == "filter")
                {
                    places.Clear();
                    JToken dataToken = JsonConvert.DeserializeObject<JToken>(Objs["data"].ToString());
                    places = dataToken.Value<JArray>();
                }
                else if (Objs["proceed"].ToString() == "search")
                {
                    places.Clear();
                    JToken dataToken = JsonConvert.DeserializeObject<JToken>(Objs["data"].ToString());
                    places = dataToken.Value<JArray>();
                }
                else if (Objs["proceed"].ToString() == "detail")
                {
                    location= new Dictionary<string, string>();
                    location = JsonConvert.DeserializeObject<Dictionary<string, string>>(Objs["data"].ToString());
                }
                //else if (Objs["proceed"].ToString() == "img")
                //{
                //    image = "";
                //    MessageBox.Show("Chính");
                //    image = JsonConvert.DeserializeObject<string>(Objs["data"].ToString());
                //}
            }
            catch { }
        }

        public void disconnect()
        {
            try
            {
                string sendClose = "{ \"proceed\": \"clientClose\"}";
                SendRequest(sendClose);
                ClientSocket.Shutdown(SocketShutdown.Both);
                ClientSocket.Disconnect(false);
                GC.Collect();
            }
            catch { };
        }
        ~UDP_client()
        {
            disconnect();
        }

        private Socket ClientSocket;
        private IPAddress IpAdd;
        private int port;
        private int buff_size;
        public Dictionary<string, string> provinces;
        public Dictionary<string, string> districts;
        public Dictionary<string, string> location;
        public string image;
        public JArray places = new JArray();
    }
}