namespace Containers.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Containers.Data.Common.Repositories;
    using Containers.Data.Models;
    using Containers.Web.ViewModels.Warehouses;

    public class WarehouseService : IWarehouseService
    {
        private readonly IDeletableEntityRepository<Warehouse> warehousesRepository;

        public WarehouseService(IDeletableEntityRepository<Warehouse> warehousesRepository)
        {
            this.warehousesRepository = warehousesRepository;
        }

        public async Task CreateAsync(WarehouseInputModel input, string userId)
        {
            var warehouse = new Warehouse
            {
                DistrictId = input.DistrictId,
                CityId = input.CityId,
                Address = input.Address,
                ContactPerson = input.ContactPerson,
                Name = input.Name,
                Email = input.Email,
                Phone = input.Phone,
                AddedByUserId = userId,
            };

            await this.warehousesRepository.AddAsync(warehouse);
            await this.warehousesRepository.SaveChangesAsync();
        }

        public IEnumerable<WarehouseViewModel> GetAll()
        {
            var warehouses = this.warehousesRepository.AllAsNoTracking()
                .Select(x => new WarehouseViewModel
                {
                    Id = x.Id,
                    DistrictId = x.DistrictId,
                    CityId = x.CityId,
                    Address = x.Address,
                    ContactPerson = x.ContactPerson,
                    Name = x.Name,
                    Email = x.Email,
                    Phone = x.Phone,
                }).ToList();

            return warehouses;
        }

        public WarehouseViewModel GetById(int id)
        {
            var warehouse = this.warehousesRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                 .Select(x => new WarehouseViewModel
                 {
                     Id = x.Id,
                     DistrictId = x.DistrictId,
                     CityId = x.CityId,
                     Address = x.Address,
                     ContactPerson = x.ContactPerson,
                     Name = x.Name,
                     Email = x.Email,
                     Phone = x.Phone,
                 })
                .FirstOrDefault();

            return warehouse;
        }

        public async Task UpdateAsync(int id, WarehouseViewModel input)
        {
            var warehouse = this.warehousesRepository.All().FirstOrDefault(x => x.Id == id);
            warehouse.Name = input.Name;
            warehouse.DistrictId = input.DistrictId;
            warehouse.CityId = input.CityId;
            warehouse.Address = input.Address;
            warehouse.Email = input.Email;
            warehouse.Phone = input.Phone;
            warehouse.ContactPerson = input.ContactPerson;
            await this.warehousesRepository.SaveChangesAsync();
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.warehousesRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                })
                .OrderBy(x => x.Name)
                .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}
