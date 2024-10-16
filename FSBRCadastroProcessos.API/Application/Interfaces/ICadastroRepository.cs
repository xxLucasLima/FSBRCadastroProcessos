﻿using FSBRCadastroProcessos.API.Domain.Entities;

namespace FSBRCadastroProcessos.API.Application.Interfaces
{
    public interface ICadastroRepository
    {
        Task<Cadastro> Create(Cadastro entity);
        Task<Cadastro> Update(Cadastro entity);
        Task<bool> Delete(int id);
        Task<List<Cadastro>> GetAll();
        Task<Cadastro> GetById(int id);
        Task<Cadastro> ConfirmacaoVisualizacao(Cadastro entity);

    }
}
