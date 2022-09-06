using Refit;

namespace AR.Apresentacao
{
    public interface InterfaceCepApiService
    {
        [Get("/ws/{cep}/json")]
        Task<CepResponse> GetAddressAsync(string cep);
    }
}
