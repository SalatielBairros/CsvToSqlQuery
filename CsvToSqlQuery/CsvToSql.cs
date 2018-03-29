using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomFramework.Util.SQL;

namespace CsvToSqlQuery
{
    public partial class CsvToSql : Form
    {
        public CsvToSql()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK || openFileDialog1.SafeFileName == null) return;

            txtFile.Text = openFileDialog1.FileName;
            txtTabela.Text = openFileDialog1.SafeFileName.Replace(".csv", string.Empty).ToUpper();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;
            SqlQueryExport.CsvToQuery(txtFile.Text, txtTabela.Text, txtFile.Text.Replace(".csv", ".sql"));
            Clean();
            MessageBox.Show(Properties.Resources.GeradoOk, Properties.Resources.Sucesso, MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk);
        }

        private bool Validar()
        {
            if (!string.IsNullOrWhiteSpace(txtFile.Text) && !string.IsNullOrWhiteSpace(txtTabela.Text)) return true;

            MessageBox.Show(Properties.Resources.DadosInvalidos, Properties.Resources.Validacao,
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;

        }

        private void Clean()
        {
            txtFile.Text = txtTabela.Text = openFileDialog1.FileName = string.Empty;
        }
    }
}
