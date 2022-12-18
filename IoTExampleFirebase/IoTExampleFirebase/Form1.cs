using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IoTExampleFirebase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "yoursecret",
            BasePath = "youraddress"
        };

        IFirebaseClient istemci_firebase;


        private async void timer1_TickAsync(object sender, EventArgs e)
        {/*
            FirebaseResponse response = istemci_firebase.Get("Sicaklik");
            label2.Text = response.ResultAs<String>();

            */
             
            FirebaseResponse response = await istemci_firebase.GetAsync("Sicaklik");
            label2.Text = response.ResultAs<String>();
            
             
            //bu kısım sınavda yok csharp

             response = istemci_firebase.Get("Durum");
            label4.Text = response.ResultAs<String>();
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            istemci_firebase = new FirebaseClient(config);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                textBox1.Text = "24";
            }
            istemci_firebase.Set("Ayarlanan",Int32.Parse(textBox1.Text));
            //ilk parametre v.t. nin parametresi.
        }
    }
}
