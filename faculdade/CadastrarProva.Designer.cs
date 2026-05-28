namespace faculdade
{
    partial class CadastrarProva
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastrarProva));
            this.CmbMatricula = new System.Windows.Forms.ComboBox();
            this.TxtNota = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbProfessor = new System.Windows.Forms.ComboBox();
            this.CmbDisciplina = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DtpDataRealizacao = new System.Windows.Forms.DateTimePicker();
            this.TextObservacao = new System.Windows.Forms.TextBox();
            this.TxtObservacao = new System.Windows.Forms.Label();
            this.BtnVoltar = new System.Windows.Forms.Button();
            this.BtnLimpar = new System.Windows.Forms.Button();
            this.BtnCadastrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CmbMatricula
            // 
            this.CmbMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMatricula.FormattingEnabled = true;
            this.CmbMatricula.Location = new System.Drawing.Point(450, 324);
            this.CmbMatricula.Name = "CmbMatricula";
            this.CmbMatricula.Size = new System.Drawing.Size(482, 37);
            this.CmbMatricula.TabIndex = 56;
            this.CmbMatricula.SelectedIndexChanged += new System.EventHandler(this.CmbMatricula_SelectedIndexChanged);
            // 
            // TxtNota
            // 
            this.TxtNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNota.Location = new System.Drawing.Point(449, 125);
            this.TxtNota.Name = "TxtNota";
            this.TxtNota.Size = new System.Drawing.Size(482, 34);
            this.TxtNota.TabIndex = 54;
            this.TxtNota.TextChanged += new System.EventHandler(this.TxtNota_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(151, 324);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 31);
            this.label5.TabIndex = 53;
            this.label5.Text = "Matricula:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(150, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(220, 31);
            this.label3.TabIndex = 52;
            this.label3.Text = "Data de Realização:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(150, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 31);
            this.label2.TabIndex = 51;
            this.label2.Text = "Nota:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkKhaki;
            this.label1.Location = new System.Drawing.Point(537, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 45);
            this.label1.TabIndex = 50;
            this.label1.Text = "Cadastro da Prova";
            // 
            // CmbProfessor
            // 
            this.CmbProfessor.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbProfessor.FormattingEnabled = true;
            this.CmbProfessor.Location = new System.Drawing.Point(450, 461);
            this.CmbProfessor.Name = "CmbProfessor";
            this.CmbProfessor.Size = new System.Drawing.Size(482, 37);
            this.CmbProfessor.TabIndex = 60;
            this.CmbProfessor.SelectedIndexChanged += new System.EventHandler(this.CmbProfessor_SelectedIndexChanged);
            // 
            // CmbDisciplina
            // 
            this.CmbDisciplina.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbDisciplina.FormattingEnabled = true;
            this.CmbDisciplina.Location = new System.Drawing.Point(450, 393);
            this.CmbDisciplina.Name = "CmbDisciplina";
            this.CmbDisciplina.Size = new System.Drawing.Size(482, 37);
            this.CmbDisciplina.TabIndex = 59;
            this.CmbDisciplina.SelectedIndexChanged += new System.EventHandler(this.CmbDisciplina_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(150, 461);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 31);
            this.label4.TabIndex = 58;
            this.label4.Text = "Professor:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(150, 393);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 31);
            this.label6.TabIndex = 57;
            this.label6.Text = "Disciplina:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // DtpDataRealizacao
            // 
            this.DtpDataRealizacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpDataRealizacao.Location = new System.Drawing.Point(449, 194);
            this.DtpDataRealizacao.Name = "DtpDataRealizacao";
            this.DtpDataRealizacao.Size = new System.Drawing.Size(482, 34);
            this.DtpDataRealizacao.TabIndex = 61;
            this.DtpDataRealizacao.ValueChanged += new System.EventHandler(this.DtpDataRealizacao_ValueChanged);
            // 
            // TextObservacao
            // 
            this.TextObservacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextObservacao.Location = new System.Drawing.Point(449, 256);
            this.TextObservacao.Name = "TextObservacao";
            this.TextObservacao.Size = new System.Drawing.Size(482, 34);
            this.TextObservacao.TabIndex = 63;
            this.TextObservacao.TextChanged += new System.EventHandler(this.TextObservacao_TextChanged);
            // 
            // TxtObservacao
            // 
            this.TxtObservacao.AutoSize = true;
            this.TxtObservacao.BackColor = System.Drawing.Color.Transparent;
            this.TxtObservacao.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtObservacao.Location = new System.Drawing.Point(150, 256);
            this.TxtObservacao.Name = "TxtObservacao";
            this.TxtObservacao.Size = new System.Drawing.Size(144, 31);
            this.TxtObservacao.TabIndex = 62;
            this.TxtObservacao.Text = "Observação:";
            this.TxtObservacao.Click += new System.EventHandler(this.TxtObservacao_Click);
            // 
            // BtnVoltar
            // 
            this.BtnVoltar.BackColor = System.Drawing.Color.DarkKhaki;
            this.BtnVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnVoltar.FlatAppearance.BorderSize = 0;
            this.BtnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnVoltar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVoltar.ForeColor = System.Drawing.Color.White;
            this.BtnVoltar.Location = new System.Drawing.Point(621, 546);
            this.BtnVoltar.Name = "BtnVoltar";
            this.BtnVoltar.Size = new System.Drawing.Size(130, 55);
            this.BtnVoltar.TabIndex = 66;
            this.BtnVoltar.Text = "Voltar";
            this.BtnVoltar.UseVisualStyleBackColor = false;
            this.BtnVoltar.Click += new System.EventHandler(this.BtnVoltar_Click);
            // 
            // BtnLimpar
            // 
            this.BtnLimpar.BackColor = System.Drawing.Color.DarkKhaki;
            this.BtnLimpar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLimpar.FlatAppearance.BorderSize = 0;
            this.BtnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLimpar.Font = new System.Drawing.Font("Segoe UI", 16.2F);
            this.BtnLimpar.ForeColor = System.Drawing.Color.White;
            this.BtnLimpar.Location = new System.Drawing.Point(981, 281);
            this.BtnLimpar.Name = "BtnLimpar";
            this.BtnLimpar.Size = new System.Drawing.Size(160, 80);
            this.BtnLimpar.TabIndex = 65;
            this.BtnLimpar.Text = "Limpar";
            this.BtnLimpar.UseVisualStyleBackColor = false;
            this.BtnLimpar.Click += new System.EventHandler(this.BtnLimpar_Click);
            // 
            // BtnCadastrar
            // 
            this.BtnCadastrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(34)))), ((int)(((byte)(64)))));
            this.BtnCadastrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCadastrar.FlatAppearance.BorderSize = 0;
            this.BtnCadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCadastrar.Font = new System.Drawing.Font("Segoe UI", 16.2F);
            this.BtnCadastrar.ForeColor = System.Drawing.Color.White;
            this.BtnCadastrar.Location = new System.Drawing.Point(981, 151);
            this.BtnCadastrar.Name = "BtnCadastrar";
            this.BtnCadastrar.Size = new System.Drawing.Size(160, 80);
            this.BtnCadastrar.TabIndex = 64;
            this.BtnCadastrar.Text = "Cadastrar";
            this.BtnCadastrar.UseVisualStyleBackColor = false;
            this.BtnCadastrar.Click += new System.EventHandler(this.BtnCadastrar_Click);
            // 
            // CadastrarProva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1348, 721);
            this.Controls.Add(this.BtnVoltar);
            this.Controls.Add(this.BtnLimpar);
            this.Controls.Add(this.BtnCadastrar);
            this.Controls.Add(this.TextObservacao);
            this.Controls.Add(this.TxtObservacao);
            this.Controls.Add(this.DtpDataRealizacao);
            this.Controls.Add(this.CmbProfessor);
            this.Controls.Add(this.CmbDisciplina);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CmbMatricula);
            this.Controls.Add(this.TxtNota);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CadastrarProva";
            this.Text = "CadastrarProva";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbMatricula;
        private System.Windows.Forms.TextBox TxtNota;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbProfessor;
        private System.Windows.Forms.ComboBox CmbDisciplina;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker DtpDataRealizacao;
        private System.Windows.Forms.TextBox TextObservacao;
        private System.Windows.Forms.Label TxtObservacao;
        private System.Windows.Forms.Button BtnVoltar;
        private System.Windows.Forms.Button BtnLimpar;
        private System.Windows.Forms.Button BtnCadastrar;
    }
}