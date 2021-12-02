using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing;

namespace UDP_Server
{
    class UDPServer
    {
        private Socket ServerSocket;
        private IPAddress IP;
        private int PORT;
        private EndPoint emip = new IPEndPoint(IPAddress.Any, 0);
        private List<EndPoint> ClientEndPoints;
        private byte[] request;
        private int buffer_size;
        private RichTextBox ConsoleServer, ClientStatus;
        public void Stop()
        {
            foreach (EndPoint e in ClientEndPoints)
            {
                string stop = "Dong Sever";
                byte[] response = Encoding.UTF8.GetBytes(stop);
                ServerSocket.BeginSendTo(response, 0, response.Length, SocketFlags.None, e, new AsyncCallback(SendCallback), null);
            }
            UDPinvoke_ConsoleStatus("Server Stopped", ConsoleServer);
            // bộ đếm thời gian
            ServerSocket.Shutdown(SocketShutdown.Both);
            ServerSocket.Close();
        }
        public UDPServer(IPAddress ip, int port, int buf, RichTextBox listClient, RichTextBox consoleServer)
        {
            IP = ip;
            PORT = port;
            ClientEndPoints = new List<EndPoint>();
            buffer_size = buf;
            request = new byte[buffer_size];
            ClientStatus = listClient;
            ConsoleServer = consoleServer;
        }

        public void run()
        {
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            ServerSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.ReuseAddress, true);

            if (ServerSocket == null)
            {
                MessageBox.Show("Error creating socket!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                ServerSocket.Bind(new IPEndPoint(IP, PORT));
            }
            catch (Exception except)
            {
                MessageBox.Show(except.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UDPinvoke_ConsoleStatus("Server is running...", ConsoleServer);
            ServerSocket.BeginReceiveFrom(request, 0, buffer_size, SocketFlags.None, ref emip, ReceiveCallback, null);
        }

        private void ReceiveCallback(IAsyncResult AR)
        {
            int rcvSize;
            emip = new IPEndPoint(IPAddress.Any, 0);

            try
            {
                DateTime time = DateTime.Now;

                rcvSize = ServerSocket.EndReceiveFrom(AR, ref emip);
                UDPinvoke_ClientStatus(emip.ToString() + " sent a request at " + time + "\n", ClientStatus);
            }
            catch (Exception)
            {
                //UDPinvoke_ClientStatus("Client disconnected\n", ConsoleServer);
                ClientEndPoints.Remove(emip);
                return;
            }
            if (!ClientEndPoints.Contains(emip))
            {
                ClientEndPoints.Add(emip);
            }

            byte[] req = new byte[rcvSize];
            Array.Copy(request, req, rcvSize);
            string jsonReq = Encoding.UTF8.GetString(req);

            Dictionary<string, string> Objs = new Dictionary<string, string>();
            Objs = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonReq);

            try
            {
                if (Objs.ContainsKey("proceed") == false) return;

                // {"proceed": "option", "codePro": "01"}
                if (Objs["proceed"] == "option")
                {
                    if (Objs["codePro"] == "")  // Lấy tỉnh
                    {
                        string responseStr = fetch_OptionProvinces();
                        responseStr = "{\"proceed\":\"option\",\"type\":\"province\",\"data\":" + responseStr + "}";

                        byte[] resData = Encoding.UTF8.GetBytes(responseStr);
                        ServerSocket.BeginSendTo(resData, 0, resData.Length, SocketFlags.None, emip,
                            new AsyncCallback(SendCallback), null);
                    }
                    else                        // Lấy huyện/quận
                    {
                        string responseStr = fetch_OptionDistricts(Objs["codePro"]);
                        string resData = "{\"proceed\":\"option\",\"type\":\"district\",\"data\":" + responseStr + "}";

                        byte[] response = Encoding.UTF8.GetBytes(resData);
                        ServerSocket.BeginSendTo(response, 0, response.Length, SocketFlags.None, emip,
                            new AsyncCallback(SendCallback), null);
                    }
                }

                // {"proceed": "filter", "codePro": "01", "codeDis": "0101"}
                else if (Objs["proceed"] == "filter")
                {
                    // request bị lỗi codePro
                    if (Objs["codePro"] == "") return;

                    int codeP = Int32.Parse(Objs["codePro"]);
                    int codeD;
                    if (Objs["codeDis"] != "")
                        codeD = Int32.Parse(Objs["codeDis"]);
                    else codeD = 0;

                    string responseStr = fetch_Places(codeP, codeD);
                    if (responseStr == "")
                        responseStr = "{}";
                    string resData = "{\"proceed\":\"filter\",\"data\":" + responseStr + "}";

                    byte[] response = Encoding.UTF8.GetBytes(resData);
                    ServerSocket.BeginSendTo(response, 0, response.Length, SocketFlags.None, emip,
                        new AsyncCallback(SendCallback), null);
                }

                // {"proceed": "search", "key": "KDL"}
                else if (Objs["proceed"] == "search")
                {
                    string responseStr = search_place(Objs["key"]);
                    if (responseStr == "")
                        responseStr = "{}";
                    string resData = "{\"proceed\":\"search\",\"data\":" + responseStr + "}";

                    byte[] response = Encoding.UTF8.GetBytes(resData);
                    ServerSocket.BeginSendTo(response, 0, response.Length, SocketFlags.None, emip,
                        new AsyncCallback(SendCallback), null);
                }

                // {"proceed": "detail", "code": "010101"}
                else if (Objs["proceed"] == "detail")
                {   
                    string responseStr = fetch_Detail(Objs["code"]);
                    if (responseStr == null)
                        responseStr = "{}";
                    string resData = "{\"proceed\":\"detail\",\"data\":" + responseStr + "}";
                    byte[] response = Encoding.UTF8.GetBytes(resData);
                    ServerSocket.BeginSendTo(response, 0, response.Length, SocketFlags.None, emip,
                        new AsyncCallback(SendCallback), null);
                }

                // {"proceed": "img", "code": "01010101"}
                else if (Objs["proceed"] == "img")
                {
                    string responseStr = fetch_Image(Objs["code"]);
                    if (responseStr == null)
                        responseStr = "{}";
                    string resData = "{\"proceed\":\"img\",\"data\":" + responseStr + "}";
                    byte[] response = Encoding.UTF8.GetBytes(resData);
                    ServerSocket.BeginSendTo(response, 0, response.Length, SocketFlags.None, emip,
                        new AsyncCallback(SendCallback), null);
                }

                else if (Objs["proceed"] == "clientClose")
                {
                    ClientEndPoints.Remove(emip);
                    UDPinvoke_ClientStatus(emip.ToString() + " closed at " + DateTime.Now + "\n", ClientStatus);
                }
            }
            catch (SocketException) { }
            catch (ObjectDisposedException) { } 

            Array.Clear(request, 0, buffer_size);
            ServerSocket.BeginReceiveFrom(request, 0, buffer_size, SocketFlags.None, ref emip, ReceiveCallback, null);
            return;
        }

        private void SendCallback(IAsyncResult AR)
        {
            try
            {
                ServerSocket.EndSend(AR);
            }
            catch (SocketException except)
            {
                MessageBox.Show(except.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ObjectDisposedException except)
            {
                MessageBox.Show(except.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void UDPinvoke_ConsoleStatus(string text, RichTextBox textBoxcur)
        {
            if (textBoxcur.IsDisposed == false)
            {
                textBoxcur.Invoke(new MethodInvoker(delegate
                {
                    textBoxcur.Text = text;
                }));
            }
        }

        void UDPinvoke_ClientStatus(string text, RichTextBox textBoxcur)
        {
            if (textBoxcur.IsDisposed == false)
            {
                textBoxcur.Invoke(new MethodInvoker(delegate
                {
                    textBoxcur.Text = text + textBoxcur.Text;
                }));
            }
        }

        // Fetch dữ liệu từ Database
        private static JObject fetch_Database(string filename = "tourist.json")
        {
            if (Directory.Exists("Database/") == false) Directory.CreateDirectory("Database/");
            if (File.Exists(@"Database/" + filename) == false)
            {
                MessageBox.Show("Error finding database!");
                return null;
            }

            string data = File.ReadAllText("Database/" + filename);
            if (!string.IsNullOrEmpty(data) && !string.IsNullOrWhiteSpace(data))
            {
                JObject DB = JObject.Parse(data);

                return DB;
            }
            return null;
        }

        // Fetch option Provinces
        public string fetch_OptionProvinces()
        {
            string provinces = "";

            JObject DB = fetch_Database();
            for (var i = 1; i < 64; i++)
            {
                string codePro = (i < 10) ? "0" + i.ToString() : i.ToString();
                provinces += "\"" + DB[codePro]["name"].ToString() + "\":\"" + codePro + "\",";
            }

            provinces = provinces.Remove(provinces.Length - 1, 1);
            provinces = "{" + provinces + "}";
            //MessageBox.Show(provinces);
            return provinces;
        }

        // Fetch option Districts
        public string fetch_OptionDistricts(string codePro)
        {
            int intPro = Int16.Parse(codePro);
            if (intPro < 1 || intPro > 63)
                return null;
            string districts = "";

            JObject DB = fetch_Database();
            int codeDis_cur = Int32.Parse(DB[codePro]["district"][0]["codeCurrent"].ToString());

            for (int j = intPro * 100 + 1; j < codeDis_cur; j++)
            {
                string codeDis = (j < 1000) ? "0" + j.ToString() : j.ToString();
                districts += "\"" + DB[codePro]["district"][0][codeDis]["name_with_type"].ToString() + "\":\"" + codeDis + "\",";
            }

            districts = districts.Remove(districts.Length - 1, 1);
            districts = "{" + districts + "}";
            //MessageBox.Show(districts);
            return districts;
        }

        // Get các địa điểm theo mã tỉnh, mã huyện hoặc mặc định
        private static string fetch_Places(int province, int district)
        {
            List<Dictionary<string, string>> places = new List<Dictionary<string, string>>();

            JObject DB = fetch_Database();
            string json = "";

            int i = province == 0 ? 1 : province; //nếu province=0 thì lấy danh sách mặc định, ngược lại lấy theo mã tỉnh
            for (; i < 64; i++)
            {
                string codePro = i < 10 ? "0" + i.ToString() : i.ToString();

                int codeDis_cur = Int32.Parse(DB[codePro]["district"][0]["codeCurrent"].ToString());
                int j = district == 0 ? i * 100 + 1 : district; //nếu district=0 thì lấy danh sách mặc định, ngược lại lấy theo mã huyện
                for (; j < codeDis_cur; j++)
                {
                    string codeDis = (j < 1000) ? ("0" + j.ToString()) : j.ToString();

                    int codeTra_cur = Int32.Parse(DB[codePro]["district"][0][codeDis]["travel"][0]["codeCurrent"].ToString());
                    for (var k = codeTra_cur - 1; k > Int32.Parse(codeDis) * 100; k--)
                    {
                        string codeT = k.ToString();
                        if (k < 100000) codeT = "0" + codeT;

                        Dictionary<string, string> detail = new Dictionary<string, string>();

                        detail.Add("name", DB[codePro]["district"][0][codeDis]["travel"][0][codeT]["name"].ToString());
                        detail.Add("coord", (DB[codePro]["district"][0][codeDis]["travel"][0][codeT]["coord"][0].ToString() + ", " +
                            DB[codePro]["district"][0][codeDis]["travel"][0][codeT]["coord"][1].ToString()));
                        detail.Add("description", DB[codePro]["district"][0][codeDis]["travel"][0][codeT]["description"].ToString());
                        detail.Add("code", codeT);

                        places.Add(detail);
                        json = JsonConvert.SerializeObject(places);
                        //MessageBox.Show(json);
                    }

                    if (district != 0)
                        return json;
                }
                if (province != 0)
                    return json;
            }
            return json;
        }

        // Fetch chi tiết của 1 place dựa vào mã place
        private static string fetch_Detail(string codeT)
        {
            JObject DB = fetch_Database();
            string codeP = codeT.Substring(0, 2);
            string codeD = codeT.Substring(0, 4);

            if (Int32.Parse(codeT) >= Int32.Parse(DB[codeP]["district"][0][codeD]["travel"][0]["codeCurrent"].ToString()))
                return "";

            Dictionary<string, string> detail = new Dictionary<string, string>();
            int nImg = DB[codeP]["district"][0][codeD]["travel"][0][codeT]["img"].ToString().Split(',').Length;

            detail.Add("name", DB[codeP]["district"][0][codeD]["travel"][0][codeT]["name"].ToString());
            detail.Add("coord", (DB[codeP]["district"][0][codeD]["travel"][0][codeT]["coord"][0].ToString() + "," +
                DB[codeP]["district"][0][codeD]["travel"][0][codeT]["coord"][1].ToString()));
            detail.Add("description", DB[codeP]["district"][0][codeD]["travel"][0][codeT]["description"].ToString());
            detail.Add("code", codeT);
            detail.Add("img", nImg.ToString());

            string json = JsonConvert.SerializeObject(detail);

            // MessageBox.Show(json);
            return json;
        }

        // Fetch image
        private static string fetch_Image(string codeImg)
        {
            if (codeImg.Length < 8) return "";
            if (File.Exists(@"Database/img/" + codeImg + ".png") == false)
                return "";

            //byte[] imgArr = System.IO.File.ReadAllBytes("Database/img/" + codeImg + ".png");
            //string imgStr = Convert.ToBase64String(imgArr);

            MemoryStream msImg = new MemoryStream();
            Bitmap bmImg = new Bitmap("Database/img/" + codeImg + ".png");
            bmImg.Save(msImg, ImageFormat.Jpeg); // nén về JPEG
            string imgStr = msImg.ToArray().ToString();
            bmImg.Dispose();
            msImg.Close();

            return imgStr;
        }

        // Tìm kiếm 1 địa điểm dựa vào tên do user nhập
        private static string search_place(string placeName)
        {
            List<Dictionary<string, string>> places = new List<Dictionary<string, string>>();

            string json = "";
            JObject DB = fetch_Database();

            // Lấy alphabet 
            string dataStr = System.IO.File.ReadAllText("Database/Alphabet.json");
            Dictionary<string, char> Alpha = new Dictionary<string, char>();
            Alpha = JsonConvert.DeserializeObject<Dictionary<string, char>>(dataStr);

            placeName = placeName.ToUpper();
            for (int l = 0; l < placeName.Length; l++)
            {
                if (Alpha.ContainsKey(placeName[l].ToString()))
                    placeName = placeName.Replace(placeName[l], Alpha[placeName[l].ToString()]);
            }
            string[] keys = placeName.Split(' ');

            for (int i = 1; i < 64; i++)
            {
                string codeP = i < 10 ? "0" + i.ToString() : i.ToString();

                int codeDis_cur = Int32.Parse(DB[codeP]["district"][0]["codeCurrent"].ToString());
                for (int j = i * 100 + 1; j < codeDis_cur; j++)
                {
                    string codeD = (j < 1000) ? ("0" + j.ToString()) : j.ToString();

                    int codeTra_cur = Int32.Parse(DB[codeP]["district"][0][codeD]["travel"][0]["codeCurrent"].ToString());

                    for (var k = codeTra_cur - 1; k > Int32.Parse(codeD) * 100; k--)
                    {
                        string codeT = (k < 100000) ? "0" + k.ToString() : k.ToString();
                        int cnt = 0;
                        foreach (string key in keys)
                        {
                            if (DB[codeP]["district"][0][codeD]["travel"][0][codeT]["nameSlug"].ToString().ToUpper().IndexOf(key) >= 0)
                                cnt++;
                        }

                        if (cnt / (double)keys.Length >= 0.5
                            || cnt / (double)DB[codeP]["district"][0][codeD]["travel"][0][codeT]["nameSlug"].ToString().Split(' ').Length >= 0.5)
                        {
                            Dictionary<string, string> detail = new Dictionary<string, string>();

                            detail.Add("name", DB[codeP]["district"][0][codeD]["travel"][0][codeT]["name"].ToString());
                            detail.Add("coord", (DB[codeP]["district"][0][codeD]["travel"][0][codeT]["coord"][0].ToString() + "," +
                                DB[codeP]["district"][0][codeD]["travel"][0][codeT]["coord"][1].ToString()));
                            detail.Add("description", DB[codeP]["district"][0][codeD]["travel"][0][codeT]["description"].ToString());
                            detail.Add("code", codeT);

                            places.Add(detail);
                            json = JsonConvert.SerializeObject(places);
                        }
                    }
                }
            }
            //MessageBox.Show(json);
            return json;
        }


        /******************************************************************
         *                      CÁC HÀM TẠO DATABASE
         * ****************************************************************/
        // Lấy dữ liệu từ link web (sử dụng lần đầu tạo DB JSON)
        private static string getDataFromLink(string link)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(link);
            httpWebRequest.Method = WebRequestMethods.Http.Get;
            httpWebRequest.Accept = "application/json";
            WebResponse response = httpWebRequest.GetResponse();
            string resString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return resString;
        }

        // Tạo DB JSON lần đầu tiên
        private static void createTouristDB()
        {
            if (Directory.Exists("Database/") == false) Directory.CreateDirectory("Database/");

            // Lấy danh sách tỉnh
            string resProvinceStr = getDataFromLink("https://raw.githubusercontent.com/sunrise1002/hanhchinhVN/master/dist/tinh_tp.json");// = File.ReadAllText("Database/province.json");
            //MessageBox.Show(resProvinceStr);
            Dictionary<string, Dictionary<string, string>> provinces = new Dictionary<string, Dictionary<string, string>>();
            provinces = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(resProvinceStr);

            string dataStr = "{";
            int codeP = 01, codeD;
            foreach (KeyValuePair<string, Dictionary<string, string>> province in provinces)
            {
                codeD = 01;
                string codePro = codeP < 10 ? "0" + codeP.ToString() : codeP.ToString();
                dataStr += "\"" + codePro + "\":" +
                    "{" +
                    "\"name\":\"" + province.Value["name"] + "\"," +
                    "\"type\":\"" + province.Value["type"] + "\"," +
                    "\"code\":\"" + codePro + "\"," +
                    "\"district\":[{";

                // Lấy danh sách quận/huyện
                string linkDistrict = "https://raw.githubusercontent.com/sunrise1002/hanhchinhVN/master/dist/quan-huyen/" + province.Value["code"] + ".json";
                string resDistrictStr = getDataFromLink(linkDistrict); //File.ReadAllText("Database/District/"+ province.Value["code"] +".json");
                //MessageBox.Show(resDistrictStr);
                Dictionary<string, Dictionary<string, string>> districts = new Dictionary<string, Dictionary<string, string>>();
                districts = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(resDistrictStr);
                //MessageBox.Show(province.Value["name"]);
                string codeDis;
                foreach (KeyValuePair<string, Dictionary<string, string>> district in districts)
                {
                    codeDis = codeD < 10 ? "0" + codeD.ToString() : codeD.ToString();
                    dataStr += "\"" + codePro + codeDis + "\":" +
                    "{" +
                    "\"name\":\"" + district.Value["name"] + "\"," +
                    "\"name_with_type\":\"" + district.Value["name_with_type"] + "\"," +
                    "\"type\":\"" + district.Value["type"] + "\"," +
                    "\"code\":\"" + codePro + codeDis + "\"," +
                    "\"travel\":[{" +
                    "\"codeCurrent\":\"" + codePro + codeDis + "01\"" +
                    "}]" +
                    "},";

                    //MessageBox.Show(district.Value["name"], "\n");
                    codeD++;
                    //return;
                }
                codeDis = codeD < 10 ? "0" + codeD.ToString() : codeD.ToString();
                dataStr += "\"codeCurrent\":\"" + codePro + codeDis + "\"";
                dataStr += "}]},";
                codeP++;
            }
            dataStr = dataStr.Remove(dataStr.Length - 1, 1);
            dataStr += "}";
            JObject DB = JObject.Parse(dataStr);

            File.WriteAllText("Database/tourist2.json", DB.ToString());
            MessageBox.Show("Successfully!");
        }

        // Thêm 1 địa điểm (sử dụng để tạo DB JSON)
        public bool addPlace(string pro, string dis, string name, string vi, string kinh, string discrip,
            List<byte[]> listImage)
        {
            if (Directory.Exists("Database") == false) MessageBox.Show("No file!");

            bool flag_success = false;
            int listSize = listImage.Count;
            string dataStr = System.IO.File.ReadAllText("Database/tourist.json");
            JObject DB = JObject.Parse(dataStr);

            // Lấy alphabet 
            dataStr = System.IO.File.ReadAllText("Database/Alphabet.json");
            Dictionary<string, char> Alpha = new Dictionary<string, char>();
            Alpha = JsonConvert.DeserializeObject<Dictionary<string, char>>(dataStr);

            for (var i = 1; i < 64; i++)
            {
                string codePro = i < 10 ? "0" + i.ToString() : i.ToString();
                // Xác định tỉnh/TP
                if (string.Compare(DB[codePro]["name"].ToString(), pro) == 0)
                {
                    //MessageBox.Show(DB[codePro]["district"][0]["codeCurrent"].ToString());
                    int codeDis_cur = Int32.Parse(DB[codePro]["district"][0]["codeCurrent"].ToString());

                    for (int j = i * 100 + 1; j < codeDis_cur; j++)
                    {
                        string codeDis = j < 1000 ? "0" + j.ToString() : j.ToString();
                        // Xác định quận/ huyện
                        if (string.Compare(DB[codePro]["district"][0][codeDis]["name_with_type"].ToString(), dis) == 0)
                        {
                            int codeTra_cur = Int32.Parse(DB[codePro]["district"][0][codeDis]["travel"][0]["codeCurrent"].ToString());
                            string codeT = codeTra_cur < 100000 ? "0" + codeTra_cur.ToString() : codeTra_cur.ToString();
                            string codeT_cur = (codeTra_cur + 1) < 100000 ? "0" + (codeTra_cur + 1).ToString() : (codeTra_cur + 1).ToString();
                            string imgStr = "[";

                            // chuyển về tên không dấu
                            string nameSlug = name.ToUpper();
                            for (int l = 0; l < nameSlug.Length; l++)
                            {
                                if (Alpha.ContainsKey(nameSlug[l].ToString()))
                                    nameSlug = nameSlug.Replace(nameSlug[l], Alpha[nameSlug[l].ToString()]);
                            }

                            // save ảnh
                            for (int k = 1; k <= listSize; k++)
                            {
                                string codeImg = k < 10 ? (codeT + "0" + k.ToString()) : codeT + k.ToString();
                                imgStr += "\"Database/img/" + codeImg + ".png\",";
                                // save png
                                using (var imageFile = new FileStream(@"Database/img/" + codeImg + @".png", FileMode.Create))
                                {
                                    imageFile.Write(listImage[k - 1], 0, listImage[k - 1].Length);
                                    imageFile.Flush();
                                }
                            }
                            imgStr.Remove(imgStr.Length - 1, 1);
                            imgStr += ']';

                            DB[codePro]["district"][0][codeDis]["travel"][0]["codeCurrent"] = codeT_cur;
                            string Data = DB[codePro]["district"][0][codeDis]["travel"][0].ToString().Remove(0, 1);
                            Data = "{\"" + codeT + "\": {" +
                                "\"name\": \"" + name + "\"," +
                                "\"nameSlug\": \"" + nameSlug + "\"," +
                                "\"coord\": [\"" + vi + "\",\"" + kinh + "\"]," +
                                "\"description\": \"" + discrip + "\"," +
                                "\"code\": \"" + codeT + "\"," +
                                "\"img\":" + imgStr +
                                "}," + Data;

                            JToken jsonData = JToken.Parse(Data);
                            MessageBox.Show(jsonData.ToString());
                            DB[codePro]["district"][0][codeDis]["travel"][0].Replace(jsonData);
                            flag_success = true;
                            //MessageBox.Show(DB[codePro]["district"][0][codeDis].ToString());
                        }
                    }
                }
            }
            if (!flag_success)
            {
                MessageBox.Show("No find province/district in database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            File.WriteAllText("Database/tourist.json", DB.ToString());
            MessageBox.Show("Successfully!");
            return true;
        }
    }
}
