namespace ApiClientes.Services
{
    public class ValidationService
    {
        private readonly HttpClient _httpClient;

        public ValidationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> IsCpfValido(string cpf)
        {
            var cpfLimpo = new string(cpf.Where(char.IsDigit).ToArray());
            var url = $"https://scpa-backend.saude.gov.br/public/scpa-usuario/validacao-cpf/{cpfLimpo}";

            try
            {
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }

                var contentString = await response.Content.ReadAsStringAsync();

                bool.TryParse(contentString, out bool isCpfValido);

                return isCpfValido;
            }
            catch
            {
                return false;
            }
        }
    }
}