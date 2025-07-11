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

        private async void btnPokemonLoad_Click(object sender, EventArgs e)
        {
            try
            {
                var pokemons = await _httpClient.GetFromJsonAsync<List<PokemonDto>>("/api/pokemon");
                dataGridView1.DataSource = pokemons;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri çekilirken hata oluþtu: " + ex.Message);
            }
        }

        private async void btnCountryLoad_Click(object sender, EventArgs e)
        {
            try
            {
                var country = await _httpClient.GetFromJsonAsync<List<CountryDto>>("/api/country");
                dataGridView1.DataSource = country;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri çekilirken hata oluþtu: " + ex.Message);
            }


        }

        private async void btnOwnerLoad_Click(object sender, EventArgs e)
        {
            try
            {
                var owners = await _httpClient.GetFromJsonAsync<List<OwnerDto>>("/api/owner");
                dataGridView1.DataSource = owners;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri çekilirken hata oluþtu: " + ex.Message);
            }

        }

        private async void btnReviewLoad_Click(object sender, EventArgs e)
        {
            try
            {
                var reviews = await _httpClient.GetFromJsonAsync<List<ReviewDto>>("/api/review");
                dataGridView1.DataSource = reviews;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri çekilirken hata oluþtu: " + ex.Message);
            }

        }

        private async void btnCategoryLoad_Click(object sender, EventArgs e)
        {
            try
            {
                var categories = await _httpClient.GetFromJsonAsync<List<CategoryDto>>("/api/category");
                dataGridView1.DataSource = categories;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri çekilirken hata oluþtu: " + ex.Message);
            }

        }

        private async void btnReviewerLoad_Click(object sender, EventArgs e)
        {
            try
            {
                var reviewers = await _httpClient.GetFromJsonAsync<List<ReviewerDto>>("/api/reviewer");
                dataGridView1.DataSource = reviewers;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri çekilirken hata oluþtu: " + ex.Message);
            }

        }

        private async void btnMoveLoad_Click(object sender, EventArgs e)
        {
            try
            {
                var moves = await _httpClient.GetFromJsonAsync<List<MoveDto>>("/api/move");
                dataGridView1.DataSource = moves;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri çekilirken hata oluþtu: " + ex.Message);
            }

        }
    }
}
