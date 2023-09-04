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
    public partial class ReservationForm : Form
    {

        private readonly ReservationService reservationService = new ReservationService();
        private readonly ApartmentService apartmentService = new ApartmentService();

        private readonly ClientService clientService = new ClientService();

        public ReservationForm()
        {
            InitializeComponent();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }






        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Parse the input values
            if (!int.TryParse(textBox2.Text, out int apartmentId) ||
                !int.TryParse(textBox3.Text, out int clientId) ||
                dateTimePicker1.Value >= dateTimePicker2.Value)
            {
                MessageBox.Show("Invalid input values. Please enter valid Apartment ID, Client ID, and Check-in/Check-out dates.", "Input Error");
                return;
            }

            // Retrieve the selected apartment and client
            var apartment = apartmentService.GetApartmentById(apartmentId);
            var client = clientService.GetClientById(clientId);

            if (apartment == null)
            {
                MessageBox.Show("Apartment not found with the specified ID.", "Input Error");
                return;
            }

            if (client == null)
            {
                MessageBox.Show("Client not found with the specified ID.", "Input Error");
                return;
            }

            // Create a new reservation
            var startDate = dateTimePicker1.Value;
            var endDate = dateTimePicker2.Value;

            var reservation = reservationService.AddReservation(startDate, endDate, apartment.Id, client.Id);

            if (reservation != null)
            {
                MessageBox.Show("Reservation added successfully.", "Success");
            }
            else
            {
                MessageBox.Show("Failed to add the reservation.", "Error");
            }
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
