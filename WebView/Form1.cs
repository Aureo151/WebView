using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InicializarWebView();
        }

        public async void InicializarWebView()
        {
            await webView21.EnsureCoreWebView2Async(null);
            webView21.Source = new Uri("https://www.google.com");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            webView21.Source = new Uri("https://www.google.com");
        }

        private void btnIr_Click(object sender, EventArgs e)
        {
            NavegarDesdeTextBox();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webView21.Source = new Uri("https://www.google.com");
        }

        private void haciaAtrásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webView21.CanGoBack) webView21.GoBack();
        }

        private void haciaDelanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(webView21.CanGoForward) webView21.GoForward();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string url = ObtenerURLValida(comboBox1.SelectedItem.ToString());
                txtDireccion.Text = url;
            }
        }
        private void NavegarDesdeTextBox()
        {
            string url = ObtenerURLValida(txtDireccion.Text);
            webView21.Source = new Uri(url);
            txtDireccion.Text = url;
        }

        private string ObtenerURLValida(string entrada)
        {
            entrada = entrada.Trim();

            if (!entrada.Contains("."))
            {
                return "https://www.google.com/search?q=" + Uri.EscapeDataString(entrada);
            }

            if (!entrada.StartsWith("https://", StringComparison.OrdinalIgnoreCase) &&
                !entrada.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
            {
                entrada = "https://" + entrada;
            }

            return entrada;
        }
    }
}
