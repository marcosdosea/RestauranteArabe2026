using System.Collections.Generic;
using Core;

namespace Core.Service
{
    public interface IPedidoService
    {
        uint Create(Pedido pedido);
        void Update(Pedido pedido);
        void Delete(uint id);
        Pedido Get(uint id);
        IEnumerable<Pedido> GetAll();
        IEnumerable<Pedido> GetByAtendimento(uint idAtendimento);
        IEnumerable<Pedido> GetByStatus(string status);
        bool AtendimentoPodeReceberPedidos(uint idAtendimento);
    }
}