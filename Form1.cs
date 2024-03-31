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
            
            BindingSource bs = new BindingSource();
            bs.DataSource = typeof(City);
            foreach (City city in cities)
            {
                bs.Add(city);
            }
            dataGridView1.DataSource = bs;
            dataGridView1.AutoGenerateColumns = true;
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            var sunInfo = await SunProcessor.LoadSunInformation();           
            txtSunRise.Text = displayInformation(sunInfo);           
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            double latitude = 35.045631;
            double longitude = -85.309677;
             //MessageBox.Show("The selected value is " + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"));            
            String aDate = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
            var sunInfo = await SunProcessor.LoadSunInformation(latitude, longitude, aDate);
            txtBox02.Text = displayInformation(sunInfo);
        }

        private static String displayInformation(SunModel sunInfo)
        {
            StringBuilder sunNotice = new StringBuilder();            
            sunNotice.Append($"Sunrise is at { sunInfo.Sunrise.ToLocalTime().ToLongTimeString() }");
            sunNotice.Append(Environment.NewLine);
            sunNotice.Append($"Sunset is at { sunInfo.Sunset.ToLocalTime().ToLongTimeString()}");
            sunNotice.Append(Environment.NewLine);
            sunNotice.Append($"Solar Noon is at { sunInfo.solar_noon.ToLocalTime().ToLongTimeString()}");
            sunNotice.Append(Environment.NewLine);
            sunNotice.Append($"Day Length is at { sunInfo.day_length.ToLocalTime().ToLongTimeString()}");
            sunNotice.Append(Environment.NewLine);
            sunNotice.Append($"Civil Twilight Begins at { sunInfo.civil_twilight_begin.ToLocalTime().ToLongTimeString()}");
            sunNotice.Append(Environment.NewLine);
            sunNotice.Append($"Civil Twilight Ends at { sunInfo.civil_twilight_end.ToLocalTime().ToLongTimeString()}");
            sunNotice.Append(Environment.NewLine);
            sunNotice.Append($"Nautical Twilight Begins at { sunInfo.nautical_twilight_begin.ToLocalTime().ToLongTimeString()}");
            sunNotice.Append(Environment.NewLine);
            sunNotice.Append($"Nautical Twilight Ends at { sunInfo.nautical_twilight_end.ToLocalTime().ToLongTimeString()}");
            sunNotice.Append(Environment.NewLine);
            sunNotice.Append($"Astronomical Twilight Begins at { sunInfo.astronomical_twilight_begin.ToLocalTime().ToLongTimeString()}");
            sunNotice.Append(Environment.NewLine);
            sunNotice.Append($"Astronomical Twilight Ends at { sunInfo.astronomical_twilight_end.ToLocalTime().ToLongTimeString()}");
            return sunNotice.ToString();
        }

        private async void btnSubmitPlace_ClickAsync(object sender, EventArgs e)
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
                txtBox03.Text = displayInformation(sunInfo);
                //MessageBox.Show(sb.ToString());
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit application?", "", MessageBoxButtons.YesNo) ==
      DialogResult.Yes)
            {
                Application.Exit();
            }
        }

    
        public void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Exit application?", "", MessageBoxButtons.YesNo) ==
      DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        
    }
}
