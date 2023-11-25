using ClinicLibNamespace;
using System.Windows.Forms;

namespace ClinicDesctop
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonLoadLists_Click(object sender, EventArgs e)
        {

            ClinicLib connection = new ClinicLib("http://localhost:5115/", new HttpClient());



            //очищаем поле
            listViewPreview.Items.Clear();
            listViewPreview.Columns.Clear();

            if (radioButtonClients.Checked)
            {
                //Загружаем хедеры колонок и данные
                ItitializeListViewHeaderClients(connection);

            }

            if (radioButtonPets.Checked)
            {
                //Загружаем хедеры колонок и данные
                ItitializeListViewHeaderPets(connection);

            }

        }

        // Инициализируем хедеры Pets
        private void ItitializeListViewHeaderPets(ClinicLib connection)
        {
            // listViewPreview
            // 
            ColumnHeader columnHeaderID = new ColumnHeader();
            ColumnHeader columnClientID = new ColumnHeader();
            ColumnHeader columnHeaderName = new ColumnHeader();
            ColumnHeader columnHeaderBirstday = new ColumnHeader();

            //listViewPreview = new ListView();

            listViewPreview.Columns.AddRange(new ColumnHeader[] { columnHeaderID, columnClientID, columnHeaderName, columnHeaderBirstday });
            listViewPreview.Dock = DockStyle.Fill;
            listViewPreview.GridLines = true;
            listViewPreview.Location = new Point(3, 23);
            listViewPreview.Name = "listViewPreview";
            listViewPreview.Size = new Size(987, 568);
            listViewPreview.TabIndex = 0;
            listViewPreview.UseCompatibleStateImageBehavior = false;
            listViewPreview.View = View.Details;
            // 
            // columnHeaderID
            // 
            columnHeaderID.Text = "id#";
            columnHeaderID.Width = 120;
            // 
            // columnClientID
            // 
            columnClientID.Text = "Клиент id#";
            columnClientID.Width = 120;
            // 

            // columnHeaderName
            // 
            columnHeaderName.Text = "Кличка";
            columnHeaderName.Width = 120;
            // 
            // columnHeaderBirstday
            // 
            columnHeaderBirstday.Text = "День родждения";
            columnHeaderBirstday.Width = 150;
            // 


            // подготавливаем данные
            List<Pet> pets = connection.PetGetAllAsync().Result.ToList();

            foreach (Pet pet in pets)
            {
                ListViewItem item = new ListViewItem();
                item.Text = pet.PetId.ToString();

                item.SubItems.AddRange(new ListViewItem.ListViewSubItem[] {
                    new ListViewItem.ListViewSubItem(item,pet.ClientId.ToString()),
                    new ListViewItem.ListViewSubItem(item,pet.Name.ToString()),
                    new ListViewItem.ListViewSubItem(item,pet.Birthday.ToString()),
                });


                listViewPreview.Items.Add(item);
            }


        }

        // Инициализируем хедеры Clients
        private void ItitializeListViewHeaderClients(ClinicLib connection)
        {
            // listViewPreview
            // 
            ColumnHeader columnHeaderID = new ColumnHeader();
            ColumnHeader columnHeaderSurName = new ColumnHeader();
            ColumnHeader columnHeaderFirstName = new ColumnHeader();
            ColumnHeader columnHeaderBirstday = new ColumnHeader();
            ColumnHeader columnHeaderPatronimic = new ColumnHeader();
            ColumnHeader columnHeaderDocument = new ColumnHeader();

            //listViewPreview = new ListView();

            listViewPreview.Columns.AddRange(new ColumnHeader[] { columnHeaderID, columnHeaderSurName, columnHeaderFirstName, columnHeaderPatronimic, columnHeaderBirstday, columnHeaderDocument });
            listViewPreview.Dock = DockStyle.Fill;
            listViewPreview.GridLines = true;
            listViewPreview.Location = new Point(3, 23);
            listViewPreview.Name = "listViewPreview";
            listViewPreview.Size = new Size(987, 568);
            listViewPreview.TabIndex = 0;
            listViewPreview.UseCompatibleStateImageBehavior = false;
            listViewPreview.View = View.Details;
            // 
            // columnHeaderID
            // 
            columnHeaderID.Text = "id#";
            columnHeaderID.Width = 120;
            // 
            // columnHeaderSurName
            // 
            columnHeaderSurName.Text = "Фамилия";
            columnHeaderSurName.Width = 120;
            // 
            // columnHeaderFirstName
            // 
            columnHeaderFirstName.Text = "Имя";
            columnHeaderFirstName.Width = 120;
            // 
            // columnHeaderPatronimic
            // 
            columnHeaderPatronimic.Text = "Отчество";
            columnHeaderPatronimic.Width = 150;
            // 
            // columnHeaderBirstday
            // 
            columnHeaderBirstday.Text = "День родждения";
            columnHeaderBirstday.Width = 150;
            // 
            // columnHeaderDocument
            // 
            columnHeaderDocument.Text = "Документ";
            columnHeaderDocument.Width = 400;
            // 


            // подготавливаем данные
            List<Client> clients = connection.ClientGetAllAsync().Result.ToList();

            foreach (Client client in clients)
            {
                ListViewItem item = new ListViewItem();
                item.Text = client.ClientId.ToString();

                item.SubItems.AddRange(new ListViewItem.ListViewSubItem[] {
                    new ListViewItem.ListViewSubItem(item,client.SurName.ToString()),
                    new ListViewItem.ListViewSubItem(item,client.FirstName.ToString()),
                    new ListViewItem.ListViewSubItem(item,client.Patronymic.ToString()),
                    new ListViewItem.ListViewSubItem(item,client.Birthday.ToString()),
                    new ListViewItem.ListViewSubItem(item,client.Document.ToString()),
                });


                listViewPreview.Items.Add(item);
            }


        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            ClinicLib connection = new ClinicLib("http://localhost:5115/", new HttpClient());



            ListView.SelectedListViewItemCollection items = listViewPreview.SelectedItems;
            foreach (ListViewItem item in items)
            {
                if (radioButtonClients.Checked)
                {
                    connection.ClientDeleteAsync(Int32.Parse(item.Text));
                    listViewPreview.Items.Remove(item);
                    continue;
                }

                if (radioButtonPets.Checked)
                {
                    connection.PetDeleteAsync(Int32.Parse(item.Text));
                    listViewPreview.Items.Remove(item);
                }
            }

        }


        private void listViewPreview_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewPreview.SelectedItems.Count > 0) { 
                buttonRemove.Enabled = true; 
            }
            else
            { 
                buttonRemove.Enabled = false;
            }

        }
    }
}
