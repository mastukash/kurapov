using System;
using System.Windows.Forms;
using Kurapov.DAL.Entities;
using Kurapov.Bll.HttpClients.Abstractions;
using Kurapov.Bll.HttpClients.Implementations;

namespace Kurapov
{
    public partial class MainForm : Form
    {
        public IClient httpClient = new Client();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = openFile.ShowDialog();

            if (result != DialogResult.OK)
                return;

            var pathToFile = openFile.FileName;

            try
            {
                ITxtDocument service = new TxtDocument(pathToFile);
                var document = service.Read();

                textBoxFormat.Text = document.Header.Format;
                textBoxSourceOfData.Text = document.Header.SourceOfData;
                textBoxStationName.Text = document.Header.StationName;
                textBoxIAGACODE.Text = document.Header.IAGACODE;
                textBoxGeodeticLatitude.Text = document.Header.GeodeticLatitude.ToString();
                textBoxGeodeticLongitude.Text = document.Header.GeodeticLatitude.ToString();
                textBoxElevation.Text = document.Header.Elevation.ToString();
                textBoxReported.Text = document.Header.Reported;
                textBoxSensorOrientation.Text = document.Header.SensorOrientation;
                textBoxDigitalSampling.Text = document.Header.DigitalSampling;
                textBoxDataIntervalType.Text = document.Header.DataIntervalType;
                textBoxDataType.Text = document.Header.DataType;

                dataGrid1.DataSource = document.Body.Lines;
            }
            catch (Exception ex)
            {
                toolStripError.Text = ex.Message;
                return;
            }

        }
    }
}
