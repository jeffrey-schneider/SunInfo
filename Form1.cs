using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SunInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Solution explorer, right click on references, manage nuget packages and install 
        // Microsoft.AspNet.WebApi.Client
        // Then update Newtonsoft_Json 

        private void Form1_Load(object sender, EventArgs e)
        {
            APIHelper.IntializeClient();
            List<City> cities = new List<City>();
            cities.Add(new City("Chattanooga", "TN", 35.045631, -85.309677));
            cities.Add(new City("Dallas", "TX", 32.779167, -96.808891));
            cities.Add(new City("San Diego", "CA", 32.715736, -117.161087));
            cities.Add(new City("Miami", "FL", 25.761681, -80.191788));
            cities.Add(new City("London", "UK", 51.50853, -0.12574));
            cities.Add(new City("Rio De Janeiro", "Brazil" , -22.901449, -43.17892));
            cities.Add(new City("Jerusalem", "Israel", 31.768318, 35.213711));
            cities.Add(new City("Paris", "France", 48.856613, 2.352222));
            cities.Add(new City("Berlin", "Germany", 52.520008, 13.404954));

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            BindingSource bs = new BindingSource
            {
                DataSource = typeof(City)
            };
            foreach (City city in cities)
            {
                bs.Add(city);
            }
            dataGridView1.DataSource = bs;
            dataGridView1.AutoGenerateColumns = true;
        }

        private async void BtnSubmit_Click(object sender, EventArgs e)
        {
            var sunInfo = await SunProcessor.LoadSunInformation();           
            txtSunRise.Text = DisplayInformation(sunInfo);           
        }

        private async void Button1_ClickAsync(object sender, EventArgs e)
        {
            double latitude = 35.045631;
            double longitude = -85.309677;
             //MessageBox.Show("The selected value is " + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"));            
            String aDate = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
            var sunInfo = await SunProcessor.LoadSunInformation(latitude, longitude, aDate);
            txtBox02.Text = DisplayInformation(sunInfo);
        }

        private static String DisplayInformation(SunModel sunInfo)
        {
            StringBuilder sunNotice = new StringBuilder();            
            sunNotice.AppendLine($"Sunrise is at { sunInfo.Sunrise.ToLocalTime().ToLongTimeString() }");
            sunNotice.AppendLine($"Sunset is at { sunInfo.Sunset.ToLocalTime().ToLongTimeString()}");
            sunNotice.AppendLine($"Solar Noon is at { sunInfo.Solar_noon.ToLocalTime().ToLongTimeString()}");
            sunNotice.AppendLine($"Day Length is at { sunInfo.Day_length.ToLocalTime().ToLongTimeString()}");
            sunNotice.AppendLine($"Civil Twilight Begins at { sunInfo.Civil_twilight_begin.ToLocalTime().ToLongTimeString()}");
            sunNotice.AppendLine($"Civil Twilight Ends at { sunInfo.Civil_twilight_end.ToLocalTime().ToLongTimeString()}");
            sunNotice.AppendLine($"Nautical Twilight Begins at { sunInfo.Nautical_twilight_begin.ToLocalTime().ToLongTimeString()}");
            sunNotice.AppendLine($"Nautical Twilight Ends at { sunInfo.Nautical_twilight_end.ToLocalTime().ToLongTimeString()}");
            sunNotice.AppendLine($"Astronomical Twilight Begins at { sunInfo.Astronomical_twilight_begin.ToLocalTime().ToLongTimeString()}");
            sunNotice.AppendLine($"Astronomical Twilight Ends at { sunInfo.Astronomical_twilight_end.ToLocalTime().ToLongTimeString()}");
            return sunNotice.ToString();
        }

        private async void BtnSubmitPlace_ClickAsync(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            StringBuilder sb = new StringBuilder();
            double latitude = 0.0;
            double longitude = 0.0;
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {
                    sb.Append("Row: ");
                    sb.Append(dataGridView1.SelectedRows[i].Index.ToString());
                    Double.TryParse(dataGridView1.SelectedCells[2].Value.ToString(), out latitude);
                    Double.TryParse(dataGridView1.SelectedCells[3].Value.ToString(), out longitude);                    
                    sb.Append(Environment.NewLine);
                }
                String aDate = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
                var sunInfo = await SunProcessor.LoadSunInformation(latitude, longitude, aDate);
                txtBox03.Text = DisplayInformation(sunInfo);
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

    
        public void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                string message = "Are you sure you want to exit?";
                string caption = "SunInfo Exit";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(this,
                    message, caption, 
                    buttons,
                    MessageBoxIcon.Stop );
                if (result == DialogResult.Yes)
                {
                    Application.Exit();                    
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        
    }
}
