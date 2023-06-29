namespace Seguimiento6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            
                CheckForIllegalCrossThreadCalls = false;
                var filePath = string.Empty;

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "txt files (*.txt)|*.txt";
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                    {
                        filePath = openFileDialog.FileName;
                        string[] lines = File.ReadAllLines(filePath);

                        foreach (string line in lines)
                        {
                            dataBox.Items.Add(line);
                        }
                    }
                }
                CheckForIllegalCrossThreadCalls = true;   
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string line;

            if(txtID.Text == "" || txtName.Text == "" || txtLname.Text == "")
            {
                MessageBox.Show("Verificar lso campos que non estan ingresados", "Error en datos", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                line = txtID.Text + '|' + txtName.Text + '|' + txtLname.Text;
                dataBox.Items.Add(line);
                txtID.Text = "";
                txtName.Text = "";
                txtLname.Text = "";
            }

        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string line;
            int index = dataBox.SelectedIndex;
            line = txtID.Text + '|' + txtName.Text + '|' + txtLname.Text;
            dataBox.Items.RemoveAt(index);
            dataBox.Items.Insert(index, line);
            txtID.Text = "";
            txtName.Text = "";
            txtLname.Text = "";

        }

        private void dataBox_Click(object sender, EventArgs e)
        {
            string[] row = dataBox.SelectedItem.ToString().Split('|');

            txtID.Text = row[0];
            txtName.Text = row[1];
            txtLname.Text = row[2];

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dataBox.Items.Remove(dataBox.SelectedItem);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"C:\Database.txt");
            foreach (object lista in dataBox.Items)
            {
                sw.WriteLine(lista.ToString());
            }
            sw.Close();
            MessageBox.Show("Se han guardado los datos", "Guardado", MessageBoxButtons.OKCancel);
        }
    }
}