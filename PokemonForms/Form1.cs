using PokemonForms.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PokemonForms
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient;

        public Form1()
        {
            InitializeComponent();

            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://localhost:7295")
            };
        }

        private void btnPokemonLoad_Click(object sender, EventArgs e)
        {
            var editPage = new EditPage("pokemon");
            editPage.ShowDialog();
        }

        private  void btnCountryLoad_Click(object sender, EventArgs e)
        {
            var editPage = new EditPage("country");
            editPage.ShowDialog();


        }

        private  void btnOwnerLoad_Click(object sender, EventArgs e)
        {
            var editPage = new EditPage("owner");
            editPage.ShowDialog();

        }

        private  void btnReviewLoad_Click(object sender, EventArgs e)
        {
            var editPage = new EditPage("review");
            editPage.ShowDialog();


        }

        private  void btnCategoryLoad_Click(object sender, EventArgs e)
        {
            var editPage = new EditPage("category");
            editPage.ShowDialog();


        }

        private  void btnReviewerLoad_Click(object sender, EventArgs e)
        {
            var editPage = new EditPage("reviewer");
            editPage.ShowDialog();

        }

        private  void btnMoveLoad_Click(object sender, EventArgs e)
        {
            var editPage = new EditPage("move");
            editPage.ShowDialog();

        }
    }
}
