using Sistema_Bancario_Sprint3.Models;

namespace Sistema_Bancario_Sprint3.Repositories.conta
{
    public interface IContaRepository
    {
        Task<IEnumerable<Conta>> GetContas();
        Task<Conta> GetContaById(long id);
        Task<Conta> PostConta(Conta conta);
        Task<Conta> UpdateConta(Conta conta);
        Task DeleteConta(long id);
    }
}
