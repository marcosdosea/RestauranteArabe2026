using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class ItemCardapioService : IItemCardapioService
    {
        private readonly RestauranteContext context;

        public ItemCardapioService(RestauranteContext context)
        {
            this.context = context;
        }

        private void ValidarItem(Itemcardapio item)
        {
            if(item.Preco is null or <= 0)
                throw new ArgumentException("O preço deve ser maior que zero.");
            if(!context.Restaurantes.Any(r => r.Id == item.IdRestaurante))
                throw new ArgumentException("Restaurante inválido.");
            if(!context.Grupocardapios.Any(g => g.Id == item.IdGrupoCardapio))
                throw new ArgumentException("Grupo inválido.");
        }

        /// <summary>
        /// Insere um novo item de cardápio na base de dados e retorna o ID do mesmo.
        /// </summary>
        /// <param name="itemCardapio"></param>
        /// <returns>O id do item de cardápio criado</returns>
        public uint Create(Itemcardapio itemCardapio)
        {
            ValidarItem(itemCardapio);
            context.Add(itemCardapio);
            context.SaveChanges();
            return itemCardapio.Id;
        }

        /// <summary>
        /// Remove um item de cardápio da base de dados de acordo com o ID fornecido.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(uint id)
        {
            var itemCardapio = context.Itemcardapios.Find(id);
            if(itemCardapio != null)
            {
                context.Remove(itemCardapio);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Edita as informações de um item de cardápio existente na base de dados.
        /// </summary>
        /// <param name="itemCardapio"></param>
        public void Edit(Itemcardapio itemCardapio)
        {
            ValidarItem(itemCardapio);
            var existente = context.Itemcardapios.Find(itemCardapio.Id);
            if(existente == null) return;

            existente.Nome = itemCardapio.Nome;
            existente.Preco = itemCardapio.Preco;
            existente.Detalhes = itemCardapio.Detalhes;
            existente.IdRestaurante = itemCardapio.IdRestaurante;
            existente.IdGrupoCardapio = itemCardapio.IdGrupoCardapio;
            existente.Ativo = itemCardapio.Ativo;
            context.SaveChanges();
        }

        /// <summary>
        /// Busca um item de cardápio na base de dados.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Itemcardapio? Get(uint id)
        {
            return context.Itemcardapios
                .Include(i => i.IdGrupoCardapioNavigation)
                .Include(j => j.IdRestauranteNavigation)
                .AsNoTracking()
                .FirstOrDefault(i => i.Id == id);
        }

        /// <summary>
        /// Busca todos os itens de cardápio na base de dados.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Itemcardapio> GetAll()
        {
            return context.Itemcardapios
                .Include(i => i.IdGrupoCardapioNavigation)
                .Include(j => j.IdRestauranteNavigation)
                .AsNoTracking()
                .ToList();
        }
    }
}
