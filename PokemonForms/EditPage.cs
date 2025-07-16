using PokemonForms.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonForms
{
    public partial class EditPage : Form
    {
        private readonly string _dataType;
        private readonly HttpClient _httpClient;
        private List<OwnerDto> _owners = new();
        private List<CategoryDto> _categories = new();
        private List<CountryDto> _countries = new();
        private ComboBox cmbOwner;
        private ComboBox cmbCategory;
        private ComboBox cmbCountry;

        public EditPage(string dataType)
        {
            InitializeComponent();
            _dataType = dataType;
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://localhost:7295")
            };
        }

        private async void EditPage_Load(object sender, EventArgs e)
        {
            this.Text = $"Edit {_dataType} Data";
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.SteelBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.AliceBlue;
            dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10);

            if (_dataType == "pokemon")
            {
                _owners = await _httpClient.GetFromJsonAsync<List<OwnerDto>>("/api/owner") ?? new();
                _categories = await _httpClient.GetFromJsonAsync<List<CategoryDto>>("/api/category") ?? new();
            }
            else if (_dataType == "owner")
            {
                _countries = await _httpClient.GetFromJsonAsync<List<CountryDto>>("/api/country") ?? new();
            }

            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                object? data = null;
                switch (_dataType)
                {
                    case "pokemon":
                        var pokemons = await _httpClient.GetFromJsonAsync<List<PokemonDto>>("/api/pokemon") ?? new List<PokemonDto>();
                        data = pokemons;
                        break;
                    case "country":
                        var countries = await _httpClient.GetFromJsonAsync<List<CountryDto>>("/api/country") ?? new List<CountryDto>();
                        countries.Add(new CountryDto());
                        data = countries;
                        break;
                    case "owner":
                        var owners = await _httpClient.GetFromJsonAsync<List<OwnerDto>>("/api/owner") ?? new List<OwnerDto>();
                        owners.Add(new OwnerDto());
                        data = owners;
                        break;
                    case "review":
                        var reviews = await _httpClient.GetFromJsonAsync<List<ReviewDto>>("/api/review") ?? new List<ReviewDto>();
                        reviews.Add(new ReviewDto());
                        data = reviews;
                        break;
                    case "category":
                        var categories = await _httpClient.GetFromJsonAsync<List<CategoryDto>>("/api/category") ?? new List<CategoryDto>();
                        categories.Add(new CategoryDto());
                        data = categories;
                        break;
                    case "move":
                        var moves = await _httpClient.GetFromJsonAsync<List<MoveDto>>("/api/move") ?? new List<MoveDto>();
                        moves.Add(new MoveDto());
                        data = moves;
                        break;
                    case "reviewer":
                        var reviewers = await _httpClient.GetFromJsonAsync<List<ReviewerDto>>("/api/reviewer") ?? new List<ReviewerDto>();
                        reviewers.Add(new ReviewerDto());
                        data = reviewers;
                        break;
                    default:
                        MessageBox.Show("Unknown data type.");
                        return;
                }

                if (data != null)
                {
                    dataGridView1.DataSource = data;
                }
                else
                {
                    MessageBox.Show("No data found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var cellValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            }
        }

        private Panel updatePanel;
        private Dictionary<string, TextBox> updateTextBoxes = new();

        private void UpdateData_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("No row selected for update.");
                return;
            }

            var selectedData = dataGridView1.SelectedRows[0].DataBoundItem;
            ShowUpdatePopup(selectedData);
        }

        private void ShowUpdatePopup(object selectedData)
        {
            // Paneli oluştur veya temizle
            if (updatePanel != null)
                this.Controls.Remove(updatePanel);

            updatePanel = new Panel
            {
                Width = 350,
                Height = 40 * selectedData.GetType().GetProperties().Length + 60,
                Left = (this.Width - 350) / 2,
                Top = (this.Height - 200) / 2,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = System.Drawing.Color.White
            };

            updateTextBoxes.Clear();
            int y = 10;
            foreach (var prop in selectedData.GetType().GetProperties())
            {
                if (prop.Name == "Id" || typeof(System.Collections.IEnumerable).IsAssignableFrom(prop.PropertyType) && prop.PropertyType != typeof(string))
                    continue; // Id ve koleksiyonları atla

                var label = new Label { Text = prop.Name, Left = 10, Top = y, Width = 100 };
                var textBox = new TextBox { Left = 120, Top = y, Width = 200, Text = prop.GetValue(selectedData)?.ToString() ?? "" };
                updatePanel.Controls.Add(label);
                updatePanel.Controls.Add(textBox);
                updateTextBoxes[prop.Name] = textBox;
                y += 35;
            }

            var btnSave = new Button { Text = "Kaydet", Left = 120, Top = y, Width = 80 };
            btnSave.Click += (s, e) => SaveUpdate(selectedData);
            updatePanel.Controls.Add(btnSave);

            var btnCancel = new Button { Text = "İptal", Left = 210, Top = y, Width = 80 };
            btnCancel.Click += (s, e) => updatePanel.Visible = false;
            updatePanel.Controls.Add(btnCancel);

            this.Controls.Add(updatePanel);
            updatePanel.BringToFront();
            updatePanel.Visible = true;
        }

        private async void SaveUpdate(object selectedData)
        {
            foreach (var kvp in updateTextBoxes)
            {
                var prop = selectedData.GetType().GetProperty(kvp.Key);
                if (prop != null && prop.CanWrite)
                {
                    object? value = kvp.Value.Text;
                    if (prop.PropertyType == typeof(int) && int.TryParse(kvp.Value.Text, out int intVal))
                        value = intVal;
                    else if (prop.PropertyType == typeof(DateTime) && DateTime.TryParse(kvp.Value.Text, out DateTime dtVal))
                        value = dtVal;
                    prop.SetValue(selectedData, value);
                }
            }

            var idProp = selectedData.GetType().GetProperty("Id");
            var idValue = idProp?.GetValue(selectedData);
            var endpoint = $"/api/{_dataType}/{idValue}";
            var response = await _httpClient.PutAsJsonAsync(endpoint, selectedData);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Güncelleme başarılı.");
                updatePanel.Visible = false;
                LoadData();
            }
            else
            {
                MessageBox.Show("Güncelleme başarısız.");
            }
        }

        private void AddData_Click(object sender, EventArgs e)
        {
            ShowAddPopup();
        }

        private void ShowAddPopup()
        {
            if (updatePanel != null)
                this.Controls.Remove(updatePanel);

            Type dtoType = _dataType switch
            {
                "pokemon" => typeof(PokemonDto),
                "category" => typeof(CategoryDto),
                "country" => typeof(CountryDto),
                "owner" => typeof(OwnerDto),
                "move" => typeof(MoveDto),
                "review" => typeof(ReviewDto),
                "reviewer" => typeof(ReviewerDto),
                _ => null
            };

            if (dtoType == null)
            {
                MessageBox.Show("Unknown data type.");
                return;
            }

            updatePanel = new Panel
            {
                Width = 350,
                Height = 40 * dtoType.GetProperties().Length + 100,
                Left = (this.Width - 350) / 2,
                Top = (this.Height - 200) / 2,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = System.Drawing.Color.White
            };

            updateTextBoxes.Clear();
            int y = 10;
            foreach (var prop in dtoType.GetProperties())
            {
                if (prop.Name == "Id" || typeof(System.Collections.IEnumerable).IsAssignableFrom(prop.PropertyType) && prop.PropertyType != typeof(string))
                    continue;

                // ownerId ve catId için textbox eklemiyoruz, aşağıda ComboBox ekleyeceğiz
                if (_dataType == "pokemon" && (prop.Name == "ownerId" || prop.Name == "catId"))
                    continue;

                var label = new Label { Text = prop.Name, Left = 10, Top = y, Width = 100 };
                var textBox = new TextBox { Left = 120, Top = y, Width = 200 };
                if (prop.PropertyType == typeof(DateTime))
                    textBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                updatePanel.Controls.Add(label);
                updatePanel.Controls.Add(textBox);
                updateTextBoxes[prop.Name] = textBox;
                y += 35;
            }

            // Sadece pokemon eklerken Owner ve Category için ComboBox ekle
            if (_dataType == "pokemon")
            {
                // Owner ComboBox
                var lblOwner = new Label { Text = "Owner", Left = 10, Top = y, Width = 100 };
                cmbOwner = new ComboBox { Left = 120, Top = y, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
                cmbOwner.DataSource = _owners;
                cmbOwner.DisplayMember = "FirstName";
                cmbOwner.ValueMember = "Id";
                updatePanel.Controls.Add(lblOwner);
                updatePanel.Controls.Add(cmbOwner);
                y += 35;

                // Category ComboBox
                var lblCategory = new Label { Text = "Category", Left = 10, Top = y, Width = 100 };
                cmbCategory = new ComboBox { Left = 120, Top = y, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
                cmbCategory.DataSource = _categories;
                cmbCategory.DisplayMember = "Name";
                cmbCategory.ValueMember = "Id";
                updatePanel.Controls.Add(lblCategory);
                updatePanel.Controls.Add(cmbCategory);
                y += 35;
            }
            else if (_dataType == "owner")
            {
                var lblCountry = new Label { Text = "Country", Left = 10, Top = y, Width = 100 };
                cmbCountry = new ComboBox { Left = 120, Top = y, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
                cmbCountry.DataSource = _countries;
                cmbCountry.DisplayMember = "Name";
                cmbCountry.ValueMember = "Id";
                updatePanel.Controls.Add(lblCountry);
                updatePanel.Controls.Add(cmbCountry);
                y += 35;
            }

            var btnSave = new Button { Text = "Ekle", Left = 120, Top = y, Width = 80 };
            btnSave.BackColor = System.Drawing.Color.MediumSeaGreen;
            btnSave.ForeColor = System.Drawing.Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += async (s, e) => await SaveAdd(dtoType);
            updatePanel.Controls.Add(btnSave);

            var btnCancel = new Button { Text = "İptal", Left = 210, Top = y, Width = 80 };
            btnCancel.BackColor = System.Drawing.Color.IndianRed;
            btnCancel.ForeColor = System.Drawing.Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => updatePanel.Visible = false;
            updatePanel.Controls.Add(btnCancel);

            this.Controls.Add(updatePanel);
            updatePanel.BringToFront();
            updatePanel.Visible = true;
        }

        private async Task SaveAdd(Type dtoType)
        {
            var newItem = Activator.CreateInstance(dtoType);

            foreach (var kvp in updateTextBoxes)
            {
                var prop = dtoType.GetProperty(kvp.Key);
                if (prop != null && prop.CanWrite)
                {
                    string text = kvp.Value.Text?.Trim() ?? "";

                    object? value = null;
                    if (prop.PropertyType == typeof(int))
                    {
                        if (int.TryParse(text, out int intVal))
                            value = intVal;
                        else
                        {
                            MessageBox.Show($"{prop.Name} alanı sayısal olmalı.");
                            return;
                        }
                    }
                    else if (prop.PropertyType == typeof(DateTime))
                    {
                        if (DateTime.TryParse(text, out DateTime dtVal))
                            value = dtVal;
                        else
                        {
                            MessageBox.Show($"{prop.Name} alanı tarih olmalı (örn: yyyy-MM-dd).");
                            return;
                        }
                    }
                    else if (prop.PropertyType == typeof(string))
                    {
                        if (string.IsNullOrWhiteSpace(text))
                        {
                            MessageBox.Show($"{prop.Name} alanı boş olamaz.");
                            return;
                        }
                        value = text;
                    }
                    else
                    {
                        value = text;
                    }

                    prop.SetValue(newItem, value);
                }
            }

            // Special handling for pokemon: set OwnerName and CategoryName
            if (_dataType == "pokemon")
            {
                if (cmbOwner.SelectedItem is OwnerDto selectedOwner)
                    ((PokemonDto)newItem).OwnerName = selectedOwner.FirstName;
                else
                {
                    MessageBox.Show("Please select an owner.");
                    return;
                }
                if (cmbCategory.SelectedItem is CategoryDto selectedCategory)
                    ((PokemonDto)newItem).CategoryName = selectedCategory.Name;
                else
                {
                    MessageBox.Show("Please select a category.");
                    return;
                }
            }

            var options = new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault };
            var json = JsonSerializer.Serialize(newItem, options);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            string endpoint;
            HttpResponseMessage response;

            if (_dataType == "pokemon")
            {
                endpoint = "/api/pokemon";
                response = await _httpClient.PostAsync(endpoint, content);
            }
            else if (_dataType == "owner")
            {
                if (cmbCountry.SelectedValue is int countryId)
                    endpoint = $"/api/owner?countryId={countryId}";
                else
                {
                    MessageBox.Show("Please select a country.");
                    return;
                }
                response = await _httpClient.PostAsync(endpoint, content);
            }
            else
            {
                endpoint = $"/api/{_dataType}";
                response = await _httpClient.PostAsync(endpoint, content);
            }

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show($"{_dataType} added successfully.");
                updatePanel.Visible = false;
                LoadData();
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Failed to add {_dataType}. Status: {response.StatusCode}\n{error}");
            }
        }

        private async void DeleteData_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                var selectedData = selectedRow.DataBoundItem;

                var idProperty = selectedData?.GetType().GetProperty("Id");
                if (idProperty == null)
                {
                    MessageBox.Show("Selected data does not have an Id property.");
                    return;
                }

                var idValue = idProperty.GetValue(selectedData);
                if (idValue == null)
                {
                    MessageBox.Show("Could not retrieve Id value.");
                    return;
                }

                var result = MessageBox.Show("Are you sure you want to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string endpoint = $"/api/{_dataType}/{idValue}";
                        var response = await _httpClient.DeleteAsync(endpoint);

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Item deleted successfully.");
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show($"Failed to delete item. Status: {response.StatusCode}");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error occurred: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("No row selected for deletion.");
            }
        }

        private void BringDetail_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                var selectedData = selectedRow.DataBoundItem;
                MessageBox.Show($"Selected Data Detail: {JsonSerializer.Serialize(selectedData)}");
            }
            else
            {
                MessageBox.Show("No row selected for detail.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
