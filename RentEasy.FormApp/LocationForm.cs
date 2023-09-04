using RentEasy.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RentEasy.FormApp
{
    public partial class LocationForm : Form
    {

        private readonly LocationService locationService = new LocationService();
        public LocationForm()
        {
            InitializeComponent();
            Load += ClientForm_Load;
        }
        private void ClientForm_Load(object sender, EventArgs e)
        {
            var locations = locationService.GetAllLocations(); // Assuming you have a LocationService instance named locationService

            // Clear the list box before adding new items
            listBox2.Items.Clear();

            foreach (var location in locations)
            {
                // Use string interpolation to format the location information
                listBox2.Items.Add($"{location.Name}");
            }
        }




        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int id))
            {
                var location = locationService.GetLocationById(id);
                if (location != null)
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add(location);
                }
                else
                {
                    MessageBox.Show("No location found with the specified ID.", "Search Result");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid integer ID.", "Input Error");
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string locationName = textBox5.Text;

            if (string.IsNullOrWhiteSpace(locationName) || locationName.Length < 2)
            {
                MessageBox.Show("Invalid location name. Please enter a valid name.", "Input Error");
                return;
            }

            var locationService = new LocationService();
            locationService.AddLocation(locationName);

            MessageBox.Show("Location added successfully", "Success");

            // Refresh the list of locations in listBox2
            RefreshLocationList();
        }

        private void RefreshLocationList()
        {
            listBox2.Items.Clear();
            var locations = locationService.GetAllLocations(); // Assuming you have a LocationService instance named locationService

            foreach (var location in locations)
            {
                listBox2.Items.Add(location.Name);
            }
        }


        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
