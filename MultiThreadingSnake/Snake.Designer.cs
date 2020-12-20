
namespace MultiThreadingSnake
{
    partial class Main
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.FoodLabel = new System.Windows.Forms.Label();
            this.BackGround = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Font = new System.Drawing.Font("Microsoft PhagsPa", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreLabel.Location = new System.Drawing.Point(12, 9);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(76, 24);
            this.ScoreLabel.TabIndex = 0;
            this.ScoreLabel.Text = "Score: 0";
            this.ScoreLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // FoodLabel
            // 
            this.FoodLabel.BackColor = System.Drawing.Color.Red;
            this.FoodLabel.Location = new System.Drawing.Point(446, 193);
            this.FoodLabel.Name = "FoodLabel";
            this.FoodLabel.Size = new System.Drawing.Size(20, 20);
            this.FoodLabel.TabIndex = 1;
            // 
            // BackGround
            // 
            this.BackGround.BackColor = System.Drawing.Color.Transparent;
            this.BackGround.Location = new System.Drawing.Point(0, 60);
            this.BackGround.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.BackGround.Name = "BackGround";
            this.BackGround.Size = new System.Drawing.Size(1000, 700);
            this.BackGround.TabIndex = 0;
            this.BackGround.Text = "label1";
            this.BackGround.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1024, 681);
            this.Controls.Add(this.FoodLabel);
            this.Controls.Add(this.ScoreLabel);
            this.Controls.Add(this.BackGround);
            this.Font = new System.Drawing.Font("Microsoft PhagsPa", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MultiThreadingSnake";
            this.Load += new System.EventHandler(this.Main_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainInput);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ScoreLabel;
        public System.Windows.Forms.Label FoodLabel;
        private System.Windows.Forms.Label BackGround;
    }
}

