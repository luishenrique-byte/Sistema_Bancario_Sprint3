using Sistema_Bancario_Sprint3.Models;

namespace Sistema_Bancario_Sprint3.Repositories.usuario
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> GetByEmailAsync(string email);

        Task AddAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
    }
}
