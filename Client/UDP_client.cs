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

        // Check connection
        private bool connect()
        {
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            if (ClientSocket == null)
            {
                MessageBox.Show("Client cannot create socket !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            ClientSocket.Connect(IpAdd, port);

            try
            {
                SendRequest("{}");
                ReceiveData();
            }
            catch (SocketException)
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
            string req = "{ \"proceed\": \"optionPro\",\"byte\":\"-1\"}";
            SendRequest(req);
        }

        public void requestOption_Districts(string codeD)
        {
            string req = "{ \"proceed\": \"optionDis\",\"byte\":\"-1\", \"codePro\": \"" + codeD + "\"}";
            
            SendRequest(req);
        }
        public void requestPlacesList_Filter(string pro, string dis)
        {
            string req = "{\"proceed\": \"filter\",\"byte\":\"-1\", \"codePro\":\"" + pro + "\", \"codeDis\": \"" + dis + "\"}";
            SendRequest(req);
        }
        public void requestPlacesList_Search(string tourist_area)
        {
            string req = "{\"proceed\": \"search\",\"byte\":\"-1\",\"key\":\"" + tourist_area + "\"}";
            SendRequest(req);
        }
        public void requestPlacesList_Detail(string code)
        {
            string req = "{\"proceed\": \"detail\",\"byte\":\"-1\", \"code\":\"" + code + "\"}";
            SendRequest(req);
        }
        public void requestPlacesList_Image(string code)
        {
            string req = "{\"proceed\": \"img\",\"byte\":\"-1\", \"code\":\"" + code + "\"}";
            SendRequest(req);
        }

        // Nhận dữ liệu của gói tin
        private string ReceiveData()
        {
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint remote = (EndPoint)sender;
            byte[] resBuff = new byte[buff_size];

            int nBytes = ClientSocket.ReceiveFrom(resBuff, ref remote);
            
            byte[] bytes = new byte[nBytes];
            Array.Copy(resBuff, bytes, nBytes);

            JObject Objs = JObject.Parse(Encoding.UTF8.GetString(bytes));

            if (!Objs.ContainsKey("totalBytes"))
                return Objs.ToString();

            int totalBytes = Int32.Parse(Objs["totalBytes"].ToString());
            string data = "";
            
            int byteCur = 0;
            while (byteCur < totalBytes)
            {
                string req = "{\"proceed\":\"" + Objs["proceed"].ToString() + "\",\"byte\":\"" + byteCur.ToString() + "\"}";
                Thread.Sleep(1);

                SendRequest(req);

                resBuff = new byte[buff_size];
                nBytes = ClientSocket.ReceiveFrom(resBuff, ref remote);
                
                bytes = new byte[nBytes];
                Array.Copy(resBuff, bytes, nBytes);
                data += Encoding.UTF8.GetString(bytes);

                byteCur = byteCur + Encoding.UTF8.GetString(bytes).Length;
            }
            
            return data;
        }

        public void ReceiveResponse()
        {
            try
            {
                string response = ReceiveData();
                //MessageBox.Show(response);

                JObject Objs = JObject.Parse(response);

                if (Objs.ContainsKey("proceed") == false) return;

                if (Objs["proceed"].ToString() == "optionPro")
                {
                    provinces = new Dictionary<string, string>();
                    provinces = JsonConvert.DeserializeObject<Dictionary<string, string>>(Objs["data"].ToString());
                }
                else if (Objs["proceed"].ToString() == "optionDis")
                {
                    districts = new Dictionary<string, string>();
                    districts = JsonConvert.DeserializeObject<Dictionary<string, string>>(Objs["data"].ToString());
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
                    location = new Dictionary<string, string>();
                    location = JsonConvert.DeserializeObject<Dictionary<string, string>>(Objs["data"].ToString());
                }
                else if (Objs["proceed"].ToString() == "img")
                {
                    image = Objs["data"].ToString();
                }
                else if (Objs["proceed"].ToString() == "serverClose")
                {
                    MessageBox.Show("Server closed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    disconnect();
                    Application.Restart();
                }
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
                ClientSocket.Close();
                ClientSocket = null;
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