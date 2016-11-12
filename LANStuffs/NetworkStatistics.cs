using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Diagnostics;

namespace LANStuffs
{
    public partial class NetworkStatistics : Form
    {
        IPGlobalProperties igp;
        NetworkInterface[] nint;
        IPv4InterfaceStatistics ipv4_stats;

        long sent_init_bytes = 0;
        long received_init_bytes = 0;
        long total_init_bytes = 0;

        public NetworkStatistics()
        {
            InitializeComponent();
        }

        private void NetworkStatistics_Load(object sender, EventArgs e)
        {
            igp = IPGlobalProperties.GetIPGlobalProperties();
            nint = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface n in nint)
            {
                ddl_nwInterfaces.Items.Add(n.Description);
            }
            ddl_nwInterfaces.SelectedIndex = 0;
            ipv4_stats = nint[ddl_nwInterfaces.SelectedIndex].GetIPv4Statistics();
            
            
            sent_init_bytes = ipv4_stats.BytesSent;
            received_init_bytes = ipv4_stats.BytesReceived;
            total_init_bytes = sent_init_bytes + received_init_bytes;

            timer1.Start();
            timer2.Start();

            performanceGraph1.start();
        }

        private void ddl_nwInterfaces_SelectedIndexChanged(object sender, EventArgs e)
        {

            listView1.Items.Clear();
            listView1.Items.Add(nint[ddl_nwInterfaces.SelectedIndex].Name);            
            listView1.Items.Add(nint[ddl_nwInterfaces.SelectedIndex].Id);
            listView1.Items.Add(nint[ddl_nwInterfaces.SelectedIndex].NetworkInterfaceType.ToString());
            listView1.Items.Add(nint[ddl_nwInterfaces.SelectedIndex].OperationalStatus.ToString());
            listView1.Items.Add(nint[ddl_nwInterfaces.SelectedIndex].Speed.ToString() + " KB / Sec.");
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                listView1.Items[i].Group = listView1.Groups[i];
            }

            ipv4_stats = nint[ddl_nwInterfaces.SelectedIndex].GetIPv4Statistics();

            //DNS Addresses//
            int dns_count = nint[ddl_nwInterfaces.SelectedIndex].GetIPProperties().DnsAddresses.Count;
            if (!dns_count.Equals(0))
            {
                ListViewGroup dns_group = new ListViewGroup("DNS Addresses"); 
                listView1.Groups.Add(dns_group);
                for (int i = 0; i < dns_count; i++)
                {
                    ListViewItem dns_item = listView1.Items.Add(nint[ddl_nwInterfaces.SelectedIndex].GetIPProperties().DnsAddresses[i].ToString());
                    dns_item.Group = dns_group;                    
                }
            }
            //

            //Gateway Addresses//
            int gateway_count = nint[ddl_nwInterfaces.SelectedIndex].GetIPProperties().GatewayAddresses.Count;
            if (!gateway_count.Equals(0))
            {
                ListViewGroup gateway_group = new ListViewGroup("Gateway Addresses");
                listView1.Groups.Add(gateway_group);
                for (int i = 0; i < gateway_count; i++)
                {
                    ListViewItem gateway_item = listView1.Items.Add(nint[ddl_nwInterfaces.SelectedIndex].GetIPProperties().GatewayAddresses[i].ToString());
                    gateway_item.Group = gateway_group;
                }
            }
            //
            
            //WINS server addresses//
            int wins_count = nint[ddl_nwInterfaces.SelectedIndex].GetIPProperties().WinsServersAddresses.Count;
            if (!wins_count.Equals(0))
            {
                ListViewGroup wins_group = new ListViewGroup("WINS Server Addresses");
                listView1.Groups.Add(wins_group);
                for (int i = 0; i < wins_count; i++)
                {
                    ListViewItem wins_item = listView1.Items.Add(nint[ddl_nwInterfaces.SelectedIndex].GetIPProperties().WinsServersAddresses[i].ToString());
                    wins_item.Group = wins_group;
                }
            }
            //
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ipv4_stats = nint[ddl_nwInterfaces.SelectedIndex].GetIPv4Statistics();

            long sent = ipv4_stats.BytesSent;
            sent = sent / 1024;
            if (sent <= 1023)
            {
                lbl_bytes_sent.Text = sent.ToString() + " KB";
            }
            else if (sent >= 1024 && sent < (1024 * 1024 - 1))
            {
                sent = sent / 1024;
                lbl_bytes_sent.Text = Convert.ToString(Math.Round(Convert.ToDecimal(sent), 4)) + " MB";
            }
            else if (sent >= (1024 * 1024) && sent < (1024 * 1024 * 1024 - 1))
            {
                sent = sent / (1024 * 1024);
                lbl_bytes_sent.Text = Convert.ToString(Math.Round(Convert.ToDecimal(sent), 4)) + " GB";
            }

            long received = ipv4_stats.BytesReceived;
            received = received / 1024;
            if (received <= 1023)
            {
                lbl_bytes_received.Text = received.ToString() + " KB";
            }
            else if (received >= 1024 && received < (1024 * 1024 - 1))
            {
                received = received / 1024;
                lbl_bytes_received.Text = Convert.ToString(Math.Round(Convert.ToDecimal(received), 4)) + " MB";
            }
            else if (received >= (1024 * 1024) && received < (1024 * 1024 * 1024 - 1))
            {
                received = received / (1024 * 1024);
                lbl_bytes_received.Text = Convert.ToString(Math.Round(Convert.ToDecimal(received), 4)) + " GB";
            }


            long total = ipv4_stats.BytesSent + ipv4_stats.BytesReceived;
            total = total / 1024;
            if (total <= 1023)
            {
                lbl_bytes_total.Text = total.ToString() + " KB";
            }
            else if (total >= 1024 && total < (1024 * 1024 - 1))
            {
                total = total / 1024;
                lbl_bytes_total.Text = Convert.ToString(Math.Round(Convert.ToDecimal(total), 4)) + " MB";
            }
            else if (total >= (1024 * 1024) && total < (1024 * 1024 * 1024 - 1))
            {
                total = total / (1024 * 1024);
                lbl_bytes_total.Text = Convert.ToString(Math.Round(Convert.ToDecimal(total), 4)) + " GB";
            }
            
        }

        private void NetworkStatistics_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        public static long baudRate(int network_interface_index)
        {
            NetworkInterface[] ni = NetworkInterface.GetAllNetworkInterfaces();
            IPv4InterfaceStatistics ipv4stats = ni[network_interface_index].GetIPv4Statistics();
            long init_bytes = ipv4stats.BytesReceived + ipv4stats.BytesSent;
            long end_bytes = init_bytes;
            
            end_bytes = (ipv4stats.BytesReceived + ipv4stats.BytesSent) - init_bytes;
            return end_bytes / 1024;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            decimal sent_end_bytes = Convert.ToDecimal(ipv4_stats.BytesSent - sent_init_bytes);
            decimal sent_rate = (sent_end_bytes * 2) / 1024;
            if (ipv4_stats.BytesSent == 0 || sent_init_bytes == 0)
            {
                lbl_sending_baud_rate.Text = "0 KB / Sec.";
            }
            else
            {
                lbl_sending_baud_rate.Text = Convert.ToString(Math.Round(sent_rate, 2)) + " KB / Sec.";
            }
            sent_init_bytes = ipv4_stats.BytesSent;


            decimal received_end_bytes = Convert.ToDecimal(ipv4_stats.BytesReceived - received_init_bytes);
            decimal received_rate = (received_end_bytes * 2) / 1024;
            if (ipv4_stats.BytesReceived == 0 || received_init_bytes == 0)
            {
                lbl_receiving_baud_rate.Text = "0 KB / Sec.";
            }
            else
            {
                lbl_receiving_baud_rate.Text = Convert.ToString(Math.Round(received_rate, 2)) + " KB / Sec.";
            }
            received_init_bytes = ipv4_stats.BytesReceived;


            decimal total_end_bytes = Convert.ToDecimal((ipv4_stats.BytesReceived + ipv4_stats.BytesSent) - total_init_bytes);
            decimal total_rate = (total_end_bytes * 2) / 1024;
            if ((ipv4_stats.BytesReceived + ipv4_stats.BytesSent) == 0 || total_init_bytes == 0)
            {
                lbl_total_baud_rate.Text = "0 KB / Sec.";
            }
            else
            {
                lbl_total_baud_rate.Text = Convert.ToString(Math.Round(total_rate, 2)) + " KB / Sec.";
                if (performanceGraph1.MaxY < Convert.ToInt32(total_rate))
                {
                    performanceGraph1.MaxY = Convert.ToInt32(total_rate);
                }
                performanceGraph1.CurrentValue = Convert.ToInt32(total_rate);
            }
            total_init_bytes = ipv4_stats.BytesReceived + ipv4_stats.BytesSent;
            timer2.Start();
        }
    }
}