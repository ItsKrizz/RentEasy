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
    public partial class ClientForm : Form
    {

        private readonly ClientService clientService = new ClientService();
        public ClientForm()
        {
            InitializeComponent();
            Load += ClientForm_Load;
        }


        private void ClientForm_Load(object sender, EventArgs e)
        {
            var clients = clientService.GetAllClients(); // Assuming you have a ClientService instance named clientService

            // Clear the list box before adding new items
            listBox2.Items.Clear();

            foreach (var client in clients)
            {
                // Use string interpolation to format the client information
                listBox2.Items.Add($"{client.Name}, {client.PhoneNumber}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int id))
            {
                var client = clientService.GetClientById(id);
                if (client != null)
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add(client);
                }
                else
                {
                    MessageBox.Show("No client found with the specified ID.", "Search Result");
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox5.Text;
            string phoneNumber = textBox4.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phoneNumber))
            {
                MessageBox.Show("Name and Phone Number are required fields.", "Input Error");
                return;
            }

            // Assuming you have a ClientService instance named clientService
            clientService.AddClient(name, phoneNumber);

            MessageBox.Show("Client added successfully", "Success");

            // Clear text boxes after adding
            textBox5.Clear();
            textBox4.Clear();

            // Refresh the list of clients in listBox2
            RefreshClientList();
        }

        private void RefreshClientList()
        {
            var clients = clientService.GetAllClients();

            // Clear the list box before adding new items
            listBox2.Items.Clear();

            foreach (var client in clients)
            {
                // Use string interpolation to format the client information
                listBox2.Items.Add($"{client.Name}, {client.PhoneNumber}");
            }
        }

        private void ClientForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
