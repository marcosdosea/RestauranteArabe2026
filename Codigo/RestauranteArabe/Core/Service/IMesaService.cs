using System.Collections.Generic;

namespace Core.Service
{
    public interface IMesaService
    {
        uint Create(Mesa mesa);
        void Edit(Mesa mesa);
        void Delete(uint id);
        Mesa? Get(uint id);
        IEnumerable<Mesa> GetAll();
    }
}
