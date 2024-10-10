using FSBRCadastroProcessos.API.Application.Interfaces;
using FSBRCadastroProcessos.API.Domain.Entities;
using FSBRCadastroProcessos.API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FSBRCadastroProcessos.API.Infrastructure
{
    public class CadastroRepository : ICadastroRepository
    {
        private readonly ApplicationDbContext _context;

        public CadastroRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Cadastro?> Create(Cadastro entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                _context.Cadastros.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar o cadastro: {ex.Message}");
            }

            return null;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var entity = await _context.Cadastros.FindAsync(id);
                if (entity == null)
                    return false;

                _context.Cadastros.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Erro ao atualizar o banco de dados: {dbEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar o cadastro: {ex.Message}");
            }

            return false;
        }


        public async Task<List<Cadastro>> GetAll()
        {
            try
            {
                return await _context.Cadastros.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar cadastros: {ex.Message}");
                return new List<Cadastro>();
            }
        }


        public async Task<Cadastro?> GetById(int id)
        {
            try
            {
                return await _context.Cadastros.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar cadastro: {ex.Message}");
                return null;
            }
        }

        public async Task<Cadastro?> Update(Cadastro entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                var existingEntity = await _context.Cadastros.FindAsync(entity.Id);
                if (existingEntity == null)
                    return null;

                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return existingEntity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar o cadastro: {ex.Message}");
            }

            return null;
        }

    }
}
