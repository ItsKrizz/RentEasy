using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RentEasy.Models;
using RentEasy.Services; // Include the appropriate namespace

namespace RentEasy.FormApp
{
    public partial class ApartmentForm : Form
    {
        private ApartmentService apartmentService; // Create an instance of your ApartmentService

        public ApartmentForm()
        {
            InitializeComponent();
            apartmentService = new ApartmentService(); // Initialize the ApartmentService
            LoadApartments(); // Load apartments when the form is initialized
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Add code for handling listBox2 selection change here
        }


        private void LoadApartments()
        {
            // Get a list of all apartments
            List<Apartment> apartments = apartmentService.GetAllApartments();

            // Bind the list of apartments to listBox2
            listBox2.DataSource = apartments;
            listBox2.DisplayMember = "Name" + "Location"; // Set the property to display in the list
        }



        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox5.Text;
            string location = textBox4.Text;
            if (decimal.TryParse(textBox3.Text, out decimal pricePerNight) && int.TryParse(textBox2.Text, out int numOfBeds))
            {
                var apartment = apartmentService.AddApartment(name, location, pricePerNight, numOfBeds);
                MessageBox.Show($"Apartment added successfully with ID: {apartment.Id}", "Success");

                // Clear the text boxes
                textBox5.Text = "";
                textBox4.Text = "";
                textBox3.Text = "";
                textBox2.Text = "";

                // Refresh the list of apartments
                LoadApartments();
            }
            else
            {
                MessageBox.Show("Please enter valid numeric values for Price Per Night and Number of Beds.", "Input Error");
            }
        }


        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int id))
            {
                // Retrieve the apartment by ID
                var apartment = apartmentService.GetApartmentById(id);

                if (apartment != null)
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add(apartment.ToString());
                }
                else
                {
                    MessageBox.Show("No apartment found with the specified ID.", "Search Result");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid integer ID.", "Input Error");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox8.Text, out int id))
            {
                var apartment = apartmentService.GetApartmentById(id);

                if (apartment != null)
                {
                    // Confirm deletion with a message box
                    var result = MessageBox.Show($"Do you want to delete the apartment: {apartment.Name}?", "Confirm Deletion", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        // Delete the apartment using the service
                        if (apartmentService.DeleteApartment(id))
                        {
                            // Remove the apartment from the list
                            listBox2.Items.Remove(apartment);
                            textBox8.Clear();
                            MessageBox.Show("Apartment deleted successfully", "Success");

                            // Refresh the listBox2
                            LoadApartments();
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete apartment", "Error");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No apartment found with the specified ID.", "Search Result");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid integer ID.", "Input Error");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox6.Text, out int id) && int.TryParse(textBox7.Text, out int newBedCount))
            {
                var apartment = apartmentService.GetApartmentById(id);

                if (apartment != null)
                {
                    // Confirm the update with a message box
                    var result = MessageBox.Show($"Do you want to update the bed count for apartment: {apartment.Name}?", "Confirm Update", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        // Update the apartment's bed count using the service
                        if (apartmentService.UpdateApartment(id, newBedCount))
                        {
                            MessageBox.Show($"Bed count for apartment with ID {id} updated successfully.", "Success");
                            textBox6.Clear();
                            textBox7.Clear();

                            // Refresh the listBox2
                            LoadApartments();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update bed count for the apartment.", "Error");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No apartment found with the specified ID.", "Search Result");
                }
            }
            else
            {
                MessageBox.Show("Please enter valid integer values for ID and new bed count.", "Input Error");
            }
        }


        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
