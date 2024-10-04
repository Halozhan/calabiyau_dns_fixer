using CalabiyauServerNodeSwitcher.Models;
using CalabiyauServerNodeSwitcher.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CalabiyauServerNodeSwitcher.ViewModels
{
    public class ServerListViewModel : ObservableObject
    {
        public ServerListViewModel()
        {
            InitServerList();
            GroupButtonCommand = new RelayCommand(ExecuteGroupButtonCommand);
            Task.Run(() => UpdatePingEach());
            Task.Run(() => UpdateServerSelection());
        }

        private List<ServerInfo> _chongqingServerList = new List<ServerInfo>();
        public List<ServerInfo> ChongqingServerList
        {
            get => _chongqingServerList;
            set => SetProperty(ref _chongqingServerList, value);
        }

        private List<ServerInfo> _tianjinServerList = new List<ServerInfo>();
        public List<ServerInfo> TianjinServerList
        {
            get => _tianjinServerList;
            set => SetProperty(ref _tianjinServerList, value);
        }

        private List<ServerInfo> _nanjingServerList = new List<ServerInfo>();
        public List<ServerInfo> NanjingServerList
        {
            get => _nanjingServerList;
            set => SetProperty(ref _nanjingServerList, value);
        }

        private List<ServerInfo> _guangzhouServerList = new List<ServerInfo>();
        public List<ServerInfo> GuangzhouServerList
        {
            get => _guangzhouServerList;
            set => SetProperty(ref _guangzhouServerList, value);
        }

        private void InitServerList()
        {
            // chongqing
            ChongqingServerList = new List<ServerInfo>
            {
                new ServerInfo { IPAddress = "111.10.11.250", Ping = new Ping(), IsSelected = false, Domain = "ds-cq-1.klbq.qq.com" },
                new ServerInfo { IPAddress = "111.10.11.73", Ping = new Ping(), IsSelected = false, Domain = "ds-cq-1.klbq.qq.com" },
                new ServerInfo { IPAddress = "113.250.9.54", Ping = new Ping(), IsSelected = false, Domain = "ds-cq-1.klbq.qq.com" },
                new ServerInfo { IPAddress = "113.250.9.56", Ping = new Ping(), IsSelected = false, Domain = "ds-cq-1.klbq.qq.com" },
                new ServerInfo { IPAddress = "175.27.48.249", Ping = new Ping(), IsSelected = false, Domain = "ds-cq-1.klbq.qq.com" },
                new ServerInfo { IPAddress = "175.27.49.194", Ping = new Ping(), IsSelected = false, Domain = "ds-cq-1.klbq.qq.com" },
                new ServerInfo { IPAddress = "43.159.233.98", Ping = new Ping(), IsSelected = false, Domain = "ds-cq-1.klbq.qq.com" },
                new ServerInfo { IPAddress = "58.144.164.43", Ping = new Ping(), IsSelected = false, Domain = "ds-cq-1.klbq.qq.com" },
                new ServerInfo { IPAddress = "58.144.164.50", Ping = new Ping(), IsSelected = false, Domain = "ds-cq-1.klbq.qq.com" }
            };

            string chongqingIP = HostsManager.Instance.GetIPAddress("ds-cq-1.klbq.qq.com");

            foreach (ServerInfo serverInfo in ChongqingServerList)
            {
                if (serverInfo.IPAddress == chongqingIP)
                {
                    serverInfo.IsSelected = true;
                }
            }


            // tianjin
            TianjinServerList = new List<ServerInfo>
            {
                new ServerInfo { IPAddress = "109.244.173.239", Ping = new Ping(), IsSelected = false, Domain = "ds-tj-1.klbq.qq.com" },
                new ServerInfo { IPAddress = "109.244.173.251", Ping = new Ping(), IsSelected = false, Domain = "ds-tj-1.klbq.qq.com" },
                new ServerInfo { IPAddress = "111.30.170.175", Ping = new Ping(), IsSelected = false, Domain = "ds-tj-1.klbq.qq.com" },
                new ServerInfo { IPAddress = "111.33.110.226", Ping = new Ping(), IsSelected = false, Domain = "ds-tj-1.klbq.qq.com" },
                new ServerInfo { IPAddress = "116.130.228.105", Ping = new Ping(), IsSelected = false, Domain = "ds-tj-1.klbq.qq.com" },
                new ServerInfo { IPAddress = "116.130.229.177", Ping = new Ping(), IsSelected = false, Domain = "ds-tj-1.klbq.qq.com" },
                new ServerInfo { IPAddress = "123.151.54.47", Ping = new Ping(), IsSelected = false, Domain = "ds-tj-1.klbq.qq.com" },
                new ServerInfo { IPAddress = "42.81.194.60", Ping = new Ping(), IsSelected = false, Domain = "ds-tj-1.klbq.qq.com" },
                new ServerInfo { IPAddress = "43.159.233.14", Ping = new Ping(), IsSelected = false, Domain = "ds-tj-1.klbq.qq.com" }
            };

            string tianjinIP = HostsManager.Instance.GetIPAddress("ds-tj-1.klbq.qq.com");

            foreach (ServerInfo serverInfo in TianjinServerList)
            {
                if (serverInfo.IPAddress == tianjinIP)
                {
                    serverInfo.IsSelected = true;
                }
            }


            // guangzhou
            GuangzhouServerList = new List<ServerInfo>
            {
                new ServerInfo { IPAddress = "120.232.24.96", Ping = new Ping(), IsSelected = false, Domain = "ds-gz-1.klbq.qq.com" },
                new ServerInfo { IPAddress = "120.233.18.175", Ping = new Ping(), IsSelected = false, Domain = "ds-gz-1.klbq.qq.com" },
                new ServerInfo { IPAddress = "14.29.103.46", Ping = new Ping(), IsSelected = false, Domain = "ds-gz-1.klbq.qq.com" },
                new ServerInfo { IPAddress = "157.148.58.53", Ping = new Ping(), IsSelected = false, Domain = "ds-gz-1.klbq.qq.com" },
                new ServerInfo { IPAddress = "157.255.4.48", Ping = new Ping(), IsSelected = false, Domain = "ds-gz-1.klbq.qq.com" },
                new ServerInfo { IPAddress = "183.47.107.193", Ping = new Ping(), IsSelected = false, Domain = "ds-gz-1.klbq.qq.com" },
                new ServerInfo { IPAddress = "43.139.252.183", Ping = new Ping(), IsSelected = false, Domain = "ds-gz-1.klbq.qq.com" },
                new ServerInfo { IPAddress = "43.141.58.200", Ping = new Ping(), IsSelected = false, Domain = "ds-gz-1.klbq.qq.com" },
                new ServerInfo { IPAddress = "43.159.233.178", Ping = new Ping(), IsSelected = false, Domain = "ds-gz-1.klbq.qq.com" }
            };

            string guangzhouIP = HostsManager.Instance.GetIPAddress("ds-gz-1.klbq.qq.com");

            foreach (ServerInfo serverInfo in GuangzhouServerList)
            {
                if (serverInfo.IPAddress == guangzhouIP)
                {
                    serverInfo.IsSelected = true;
                }
            }



            // nanjing
            NanjingServerList = new List<ServerInfo>
            {
                new ServerInfo { IPAddress = "112.80.183.27", Ping = new Ping(), IsSelected = false, Domain = "ds-nj-1.klbq.qq.com" },
                new ServerInfo { IPAddress = "121.229.92.16", Ping = new Ping(), IsSelected = false, Domain = "ds-nj-1.klbq.qq.com" },
                new ServerInfo { IPAddress = "180.110.193.185", Ping = new Ping(), IsSelected = false, Domain = "ds-nj-1.klbq.qq.com" },
                new ServerInfo { IPAddress = "182.50.15.118", Ping = new Ping(), IsSelected = false, Domain = "ds-nj-1.klbq.qq.com" },
                new ServerInfo { IPAddress = "36.155.164.82", Ping = new Ping(), IsSelected = false, Domain = "ds-nj-1.klbq.qq.com" },
                new ServerInfo { IPAddress = "36.155.183.208", Ping = new Ping(), IsSelected = false, Domain = "ds-nj-1.klbq.qq.com" },
                new ServerInfo { IPAddress = "43.141.129.109", Ping = new Ping(), IsSelected = false, Domain = "ds-nj-1.klbq.qq.com" },
                new ServerInfo { IPAddress = "43.141.129.21", Ping = new Ping(), IsSelected = false, Domain = "ds-nj-1.klbq.qq.com" },
                new ServerInfo { IPAddress = "43.159.233.198", Ping = new Ping(), IsSelected = false, Domain = "ds-nj-1.klbq.qq.com" }
            };
            string nanjingIP = HostsManager.Instance.GetIPAddress("ds-nj-1.klbq.qq.com");

            foreach (ServerInfo serverInfo in NanjingServerList)
            {
                if (serverInfo.IPAddress == nanjingIP)
                {
                    serverInfo.IsSelected = true;
                }
            }
        }

        private void UpdatePingEach()
        {
            var allServers = new List<ServerInfo>();
            allServers.AddRange(ChongqingServerList);
            allServers.AddRange(TianjinServerList);
            allServers.AddRange(GuangzhouServerList);
            allServers.AddRange(NanjingServerList);

            foreach (ServerInfo serverInfo in allServers)
            {
                Task.Run(() => UpdatePing(serverInfo));
            }
        }

        private static async void UpdatePing(ServerInfo serverInfo)
        {
            const ushort SECOND = 1000;
            const ushort PACKET_PER_SECOND = 100;
            const uint REFRESH_INTERVAL = 25;
            const ushort PING_INTERVAL = SECOND / PACKET_PER_SECOND;
            const ushort PORT = 6001;
            var udpClient = new GetUDPPingTime(serverInfo.IPAddress, PORT);

            while (true)
            {
                for (int i = 0; i < REFRESH_INTERVAL; i++)
                {
                    serverInfo.Ping.AddPing = udpClient.QueryPing();
                    await Task.Delay(PING_INTERVAL);
                }
                udpClient.ClientClose();
            }
        }

        private void UpdateServerSelection()
        {
            const int UPDATE_INTERVAL = 250;
            while (true)
            {
                Task.Delay(UPDATE_INTERVAL).Wait();
                SelectLowestScoreServer(ChongqingServerList);
                SelectLowestScoreServer(TianjinServerList);
                SelectLowestScoreServer(GuangzhouServerList);
                SelectLowestScoreServer(NanjingServerList);
            }
        }

        public RelayCommand GroupButtonCommand { get; set; }
        private void ExecuteGroupButtonCommand()
        {
            var selectedServer = ChongqingServerList
                .Where(s => s.IsSelected)
                .FirstOrDefault();
            if (selectedServer != null)
            {
                ApplySelectedServer(selectedServer.IPAddress, "ds-cq-1.klbq.qq.com");
            }

            selectedServer = TianjinServerList
                .Where(s => s.IsSelected)
                .FirstOrDefault();
            if (selectedServer != null)
            {
                ApplySelectedServer(selectedServer.IPAddress, "ds-tj-1.klbq.qq.com");
            }

            selectedServer = GuangzhouServerList
                .Where(s => s.IsSelected)
                .FirstOrDefault();
            if (selectedServer != null)
            {
                ApplySelectedServer(selectedServer.IPAddress, "ds-gz-1.klbq.qq.com");
            }

            selectedServer = NanjingServerList
                .Where(s => s.IsSelected)
                .FirstOrDefault();
            if (selectedServer != null)
            {
                ApplySelectedServer(selectedServer.IPAddress, "ds-nj-1.klbq.qq.com");
            }
        }

        private static void ApplySelectedServer(string ipAddress, string domain)
        {
            HostsManager.Instance.ChangeDomain(ipAddress, domain);
        }

        private static void SelectLowestScoreServer(List<ServerInfo> serverInfoList)
        {
            var lowestScoreServer = serverInfoList
                .Where(s => s.Ping.Score >= 0)
                .OrderBy(s => s.Ping.Score).FirstOrDefault();

            if (lowestScoreServer != null)
            {
                foreach (var server in serverInfoList)
                {
                    server.IsSelected = server == lowestScoreServer;
                }
                ApplySelectedServer(lowestScoreServer.IPAddress, lowestScoreServer.Domain);
            }
        }
    }
}
