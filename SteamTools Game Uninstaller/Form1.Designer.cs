namespace SteamTools_Game_Uninstaller
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_list_game = new Guna.UI2.WinForms.Guna2Panel();
            this.reload_list_game = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.restart_steam = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // panel_list_game
            // 
            this.panel_list_game.BorderColor = System.Drawing.Color.Black;
            this.panel_list_game.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_list_game.FillColor = System.Drawing.Color.Transparent;
            this.panel_list_game.Location = new System.Drawing.Point(0, 0);
            this.panel_list_game.Name = "panel_list_game";
            this.panel_list_game.Size = new System.Drawing.Size(800, 380);
            this.panel_list_game.TabIndex = 0;
            // 
            // reload_list_game
            // 
            this.reload_list_game.BorderColor = System.Drawing.Color.Gray;
            this.reload_list_game.BorderThickness = 1;
            this.reload_list_game.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.reload_list_game.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.reload_list_game.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.reload_list_game.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.reload_list_game.FillColor = System.Drawing.Color.Transparent;
            this.reload_list_game.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.reload_list_game.ForeColor = System.Drawing.Color.Black;
            this.reload_list_game.Location = new System.Drawing.Point(12, 393);
            this.reload_list_game.Name = "reload_list_game";
            this.reload_list_game.Size = new System.Drawing.Size(104, 45);
            this.reload_list_game.TabIndex = 1;
            this.reload_list_game.Text = "Reload";
            this.reload_list_game.Click += new System.EventHandler(this.reload_list_game_Click);
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillColor = System.Drawing.Color.Black;
            this.guna2Separator1.Location = new System.Drawing.Point(0, 377);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(808, 10);
            this.guna2Separator1.TabIndex = 2;
            // 
            // restart_steam
            // 
            this.restart_steam.BorderColor = System.Drawing.Color.Gray;
            this.restart_steam.BorderThickness = 1;
            this.restart_steam.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.restart_steam.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.restart_steam.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.restart_steam.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.restart_steam.FillColor = System.Drawing.Color.Transparent;
            this.restart_steam.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.restart_steam.ForeColor = System.Drawing.Color.Black;
            this.restart_steam.Location = new System.Drawing.Point(658, 393);
            this.restart_steam.Name = "restart_steam";
            this.restart_steam.Size = new System.Drawing.Size(130, 45);
            this.restart_steam.TabIndex = 3;
            this.restart_steam.Text = "Restart Steam";
            this.restart_steam.Click += new System.EventHandler(this.restart_steam_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.restart_steam);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.reload_list_game);
            this.Controls.Add(this.panel_list_game);
            this.Name = "Form1";
            this.Text = "SteamTools Game Uninstaller by Lechatblanc | https://discord.gg/9p4q3KWA4K";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panel_list_game;
        private Guna.UI2.WinForms.Guna2Button reload_list_game;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Button restart_steam;
    }
}

