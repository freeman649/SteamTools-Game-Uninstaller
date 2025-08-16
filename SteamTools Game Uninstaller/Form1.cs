using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamTools_Game_Uninstaller
{
    public partial class Form1 : Form
    {
        private string depotPath = @"C:\Program Files (x86)\Steam\config\depotcache";
        private string pluginPath = @"C:\Program Files (x86)\Steam\config\stplug-in";

        private VScrollBar vScrollBar1 = new VScrollBar();

        public Form1()
        {
            InitializeComponent();
            panel_list_game.AutoScroll = false;
            panel_list_game.Controls.Clear();

            vScrollBar1.Dock = DockStyle.Right;
            vScrollBar1.Scroll += VScrollBar1_Scroll;
            vScrollBar1.Enabled = true;
            panel_list_game.Controls.Add(vScrollBar1);
        }

        private async void reload_list_game_Click(object sender, EventArgs e)
        {
            var toRemove = panel_list_game.Controls.OfType<Panel>().ToList();
            foreach (var p in toRemove) panel_list_game.Controls.Remove(p);

            string[] depotFiles = Directory.Exists(depotPath) ? Directory.GetFiles(depotPath) : Array.Empty<string>();
            string[] pluginFiles = Directory.Exists(pluginPath) ? Directory.GetFiles(pluginPath) : Array.Empty<string>();

            var appIds = depotFiles.Select(f => Path.GetFileNameWithoutExtension(f))
                                   .Concat(pluginFiles.Select(f => Path.GetFileNameWithoutExtension(f)))
                                   .Distinct()
                                   .ToList();

            if (appIds.Count == 0)
            {
                MessageBox.Show("No games found.");
                return;
            }

            foreach (var appId in appIds)
            {
                string gameName = await GetGameNameFromSteam(appId);
                if (string.IsNullOrEmpty(gameName))
                    continue;
                AddGamePanel(gameName, appId);
            }

            UpdateScrollBar();
        }

        private void AddGamePanel(string gameName, string appId)
        {
            int panelHeight = 60;
            int index = panel_list_game.Controls.OfType<Panel>().Count();
            int y = index * (panelHeight + 10);

            Panel panel = new Panel
            {
                Width = panel_list_game.ClientSize.Width - vScrollBar1.Width - 5,
                Height = panelHeight,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new System.Drawing.Point(0, y),
                Tag = y
            };

            Label lbl = new Label
            {
                Text = gameName,
                AutoSize = true,
                Location = new System.Drawing.Point(10, 20)
            };

            Button btn = new Button
            {
                Text = "Delete",
                Width = 80,
                Location = new System.Drawing.Point(panel.Width - 100, 15),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            btn.Click += (s, e) =>
            {
                try
                {
                    string message = "";

                    var depotFiles = Directory.GetFiles(depotPath, $"*{appId}*");
                    foreach (var file in depotFiles)
                    {
                        File.Delete(file);
                        message += $"Deleted {Path.GetFileName(file)} from depotcache. ";
                    }

                    var pluginFiles = Directory.GetFiles(pluginPath, $"*{appId}*");
                    foreach (var file in pluginFiles)
                    {
                        File.Delete(file);
                        message += $"Deleted {Path.GetFileName(file)} from stplug-in. ";
                    }

                    if (message == "") message = "No files deleted.";
                    MessageBox.Show($"{gameName} — {message}");

                    panel_list_game.Controls.Remove(panel);
                    ReorderPanels();
                    UpdateScrollBar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Delete error: {ex.Message}");
                }
            };

            panel.Controls.Add(lbl);
            panel.Controls.Add(btn);
            panel_list_game.Controls.Add(panel);
            panel.BringToFront();
        }

        private void ReorderPanels()
        {
            int y = 0;
            foreach (var ctrl in panel_list_game.Controls.OfType<Panel>())
            {
                ctrl.Tag = y;
                ctrl.Location = new System.Drawing.Point(0, y - vScrollBar1.Value);
                y += ctrl.Height + 10;
            }
        }

        private void UpdateScrollBar()
        {
            int totalHeight = panel_list_game.Controls.OfType<Panel>().Sum(p => p.Height + 10);
            int visibleHeight = panel_list_game.ClientSize.Height;

            vScrollBar1.Minimum = 0;
            vScrollBar1.Maximum = Math.Max(0, totalHeight - 1);
            vScrollBar1.LargeChange = visibleHeight;
            vScrollBar1.SmallChange = 20;
            vScrollBar1.Enabled = true;
        }

        private void VScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            foreach (var ctrl in panel_list_game.Controls.OfType<Panel>())
            {
                int baseY = (int)ctrl.Tag;
                ctrl.Location = new System.Drawing.Point(0, baseY - vScrollBar1.Value);
            }
        }

        private async Task<string> GetGameNameFromSteam(string appId)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"https://store.steampowered.com/api/appdetails?appids={appId}";
                    string json = await client.GetStringAsync(url);
                    JObject data = JObject.Parse(json);

                    if (data[appId]?["success"]?.ToObject<bool>() == true)
                        return data[appId]["data"]["name"]?.ToString();
                }
            }
            catch { }
            return null;
        }
        private void restart_steam_Click(object sender, EventArgs e)
        {
            try
            {
                // Kill Steam
                var steamProcs = Process.GetProcessesByName("Steam");
                foreach (var p in steamProcs) p.Kill();

                // Wait a bit
                Task.Delay(2000).Wait();

                // Start Steam
                Process.Start(@"C:\Program Files (x86)\Steam\Steam.exe");
                MessageBox.Show("Steam restarted.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to restart Steam: {ex.Message}");
            }
        }
    }
}
  
