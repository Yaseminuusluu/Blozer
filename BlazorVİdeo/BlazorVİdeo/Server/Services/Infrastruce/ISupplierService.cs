using BlazorVİdeo.Shared.DTO;

namespace BlazorVİdeo.Server.Services.Infrastruce
{
    public interface ISupplierService
    {
        public Task<List<SupplierDTO>> GetSuppliers();

        public Task<SupplierDTO> CreateSupplier(SupplierDTO Order);

        public Task<SupplierDTO> UpdateSupplier(SupplierDTO Order);

        public Task DeleteSupplier(Guid SupplierId);

        public Task<SupplierDTO> GetSupplierById(Guid Id);
    }
}
