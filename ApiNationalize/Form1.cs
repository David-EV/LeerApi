using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApiNationalize
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //devuelve el contenido del json
            string respuesta = await GetHttp();
            //deserializamos el json
            VerDatos datos = JsonConvert.DeserializeObject<VerDatos>(respuesta);
            string[] valores = new string[datos.country.Count];
            int contador=0;
            //meter todos los datos que encuentre en un arreglo
            foreach(var d in datos.country)
            {
                valores[contador] = d.country_id.ToString();
                contador++;
            }
            label3.Text = "El nombre ingresado es mas comun en: ";
            label2.Text = string.Join(", ", valores);
           
        }
        public async Task<string> GetHttp()
        {
            string url = "https://api.nationalize.io/?name="+textBox1.Text;
            WebRequest oRequest = WebRequest.Create(url);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
