using System.Diagnostics;
using System.Text.RegularExpressions;
using Renci.SshNet;

#pragma warning disable CS8622

namespace silo_connect
{
    public partial class Form1 : Form
    {
        private const string HistoryFile = "server_history.txt";
        private SshClient? client;

        public Form1()
        {
            InitializeComponent();
            LoadServerHistory();
            cmbServerIP.SelectedIndexChanged += CmbServerIP_SelectedIndexChanged;
            cmbSocks5Port.KeyPress += CmbSocks5Port_KeyPress;
            cmbServerIP.KeyPress += CmbServerIP_KeyPress;
        }

        private void LoadServerHistory()
        {
            if (File.Exists(HistoryFile))
            {
                var lines = File.ReadAllLines(HistoryFile);
                foreach (var line in lines)
                {
                    var parts = line.Split(':');
                    if (parts.Length == 2)
                    {
                        if (!cmbServerIP.Items.Contains(parts[0]))
                        {
                            cmbServerIP.Items.Add(parts[0]);
                        }
                        if (!cmbSocks5Port.Items.Contains(parts[1]))
                        {
                            cmbSocks5Port.Items.Add(parts[1]);
                        }
                    }
                }
            }
        }

        private void SaveServerHistory()
        {
            using var writer = new StreamWriter(HistoryFile);
            foreach (var item in cmbServerIP.Items)
            {
                var port = cmbSocks5Port.Items.Count > 0 ? cmbSocks5Port.Items[0]?.ToString() ?? "0" : "0";
                writer.WriteLine($"{item}:{port}");
            }
        }

        private void CmbServerIP_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbServerIP.SelectedItem is string selectedEntry)
            {
                var parts = selectedEntry.Split(':');
                if (parts.Length == 2)
                {
                    cmbServerIP.Text = parts[0];
                    cmbSocks5Port.Text = parts[1];
                }
            }
        }

        private void CmbServerIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void CmbSocks5Port_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void StartSSHConnection(string serverIP, string socksPort, string username, string password)
        {
            txtStatus.AppendText($"Connecting to {serverIP}:{socksPort}..." + Environment.NewLine);

            try
            {
                client = new SshClient(serverIP, username, password);
                client.Connect();

                if (client.IsConnected)
                {
                    txtStatus.AppendText("SSH connection established successfully!" + Environment.NewLine);
                    var dynamicPortForwarding = new ForwardedPortDynamic("127.0.0.1", uint.Parse(socksPort));
                    client.AddForwardedPort(dynamicPortForwarding);
                    dynamicPortForwarding.Start();
                    txtStatus.AppendText($"SOCKS5 proxy started successfully on port {socksPort}." + Environment.NewLine);
                }
                else
                {
                    txtStatus.AppendText("SSH connection failed!" + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                txtStatus.AppendText($"Error establishing SSH connection: {ex.Message}" + Environment.NewLine);
            }

            txtStatus.SelectionStart = txtStatus.Text.Length;
            txtStatus.ScrollToCaret();
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            var input = cmbServerIP.Text;
            var ipPattern = @"^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\." +
                            @"(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\." +
                            @"(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\." +
                            @"(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";

            if (!Regex.IsMatch(input, ipPattern))
            {
                MessageBox.Show("Invalid IP address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbServerIP.Text = string.Empty;
                return;
            }

            var credentialsForm = new Form2();
            if (credentialsForm.ShowDialog() == DialogResult.OK)
            {
                var username = credentialsForm.Username;
                var password = credentialsForm.Password;

                StartSSHConnection(cmbServerIP.Text, cmbSocks5Port.Text, username, password);

                if (!cmbServerIP.Items.Contains(cmbServerIP.Text))
                {
                    cmbServerIP.Items.Insert(0, cmbServerIP.Text);
                    if (cmbServerIP.Items.Count > 3)
                        cmbServerIP.Items.RemoveAt(cmbServerIP.Items.Count - 1);
                }

                if (!cmbSocks5Port.Items.Contains(cmbSocks5Port.Text))
                {
                    cmbSocks5Port.Items.Insert(0, cmbSocks5Port.Text);
                    if (cmbSocks5Port.Items.Count > 3)
                        cmbSocks5Port.Items.RemoveAt(cmbSocks5Port.Items.Count - 1);
                }
            }
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            if (client != null && client.IsConnected)
            {
                client.Disconnect();
                txtStatus.AppendText("Disconnected from SSH server." + Environment.NewLine);

                var port = int.Parse(cmbSocks5Port.Text);
                Task.Run(() => MonitorProxyConnection(port));
            }
            else
            {
                txtStatus.AppendText("Disconnected" + Environment.NewLine);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            SaveServerHistory();
            this.Close();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var message = "SSH SocksV5 Proxy Connect - Version 1.0\n" +
                          "Developed by Gianni Perez ©2024\n" +
                          "Visit me at www.skylabus.tech";
            MessageBox.Show(message, "About");
        }

        private void MonitorProxyConnection(int port)
        {
            while (true)
            {
                if (IsPortClosed(port))
                {
                    Invoke(new Action(() => txtStatus.AppendText($"Proxy on port {port} is now closed." + Environment.NewLine)));
                    break;
                }

                Invoke(new Action(() => txtStatus.AppendText($"Proxy on port {port} is still open, closing..." + Environment.NewLine)));
                Task.Delay(TimeSpan.FromMinutes(1)).Wait();
            }
        }

        static private bool IsPortClosed(int port)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "netstat",
                Arguments = "-an",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = Process.Start(startInfo);
            if (process == null)
            {
                return false;
            }

            using var reader = process.StandardOutput;
            string result = reader.ReadToEnd();
            return !result.Contains($":{port}");
        }
    }
}
