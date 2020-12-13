namespace Containers.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Containers.Common;
    using Containers.Data.Common.Repositories;
    using Containers.Data.Models;
    using Containers.Web.ViewModels.SRSObjects.Industrial;

    public class SRSObjectIndustrialService : ISRSObjectIndustrialService
    {
        private readonly IDeletableEntityRepository<SrsobjectIndustrial> srsObjectIndurstiralRepository;
        private readonly IDeletableEntityRepository<SrsobjectIndustrialSchema> srsObjectIndurstiralSchemaRepository;
        private readonly IDeletableEntityRepository<SrsobjectIndustrialContainer> srsObjectIndurstiralContainerRepository;
        private readonly IRepository<Movement> movementRepository;
        private readonly IDeletableEntityRepository<Warehouse> warehousesRepository;
        private readonly IDeletableEntityRepository<Container> containersRepository;

        public SRSObjectIndustrialService(
            IDeletableEntityRepository<SrsobjectIndustrial> srsObjectIndurstiralRepository,
            IDeletableEntityRepository<SrsobjectIndustrialSchema> srsObjectIndurstiralSchemaRepository,
            IDeletableEntityRepository<SrsobjectIndustrialContainer> srsObjectIndurstiralContainerRepository,
            IRepository<Movement> movementRepository,
            IDeletableEntityRepository<Warehouse> warehousesRepository,
            IDeletableEntityRepository<Container> containersRepository)
        {
            this.srsObjectIndurstiralRepository = srsObjectIndurstiralRepository;
            this.srsObjectIndurstiralSchemaRepository = srsObjectIndurstiralSchemaRepository;
            this.srsObjectIndurstiralContainerRepository = srsObjectIndurstiralContainerRepository;
            this.movementRepository = movementRepository;
            this.warehousesRepository = warehousesRepository;
            this.containersRepository = containersRepository;
        }

        public IEnumerable<SRSObjectIndustrialViewModel> GetAll()
        {
            var industrialObjects = this.srsObjectIndurstiralRepository.AllAsNoTracking()
                .Select(x => new SRSObjectIndustrialViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    ContactPerson = x.ContactPerson,
                    Note = x.Note,
                    EntryDate = x.EntryDate,
                    DistrictName = x.District.Name,
                    UserId = x.AddedByUserId,
                }).ToList();

            return industrialObjects;
        }

        public SRSObjectIndustrialViewModel GetById(int id)
        {
            var srsObjectIndustrial = this.srsObjectIndurstiralRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                 .Select(x => new SRSObjectIndustrialViewModel
                 {
                     Id = x.Id,
                     Name = x.Name,
                     Address = x.Address,
                     ContactPerson = x.ContactPerson,
                     Note = x.Note,
                     EntryDate = x.EntryDate,
                     DistrictName = x.District.Name,
                     UserId = x.AddedByUserId,
                 })
                .FirstOrDefault();

            return srsObjectIndustrial;
        }

        public async Task CreateAsync(SRSObjectIndustrialInputModel input, string userId)
        {
            var srsobjectIndustrial = new SrsobjectIndustrial
            {
                Name = input.Name,
                Address = input.Address,
                ContactPerson = input.ContactPerson,
                Note = input.Note,
                EntryDate = input.EntryDate,
                DistrictId = input.DistrictId,
                AddedByUserId = userId,
            };

            await this.srsObjectIndurstiralRepository.AddAsync(srsobjectIndustrial);
            await this.srsObjectIndurstiralRepository.SaveChangesAsync();
        }

        public async Task CreateSchemeAsync(SRSObjectIndustrialSchemeInputModel input, int id, string userId)
        {
            var schema = new SrsobjectIndustrialSchema
            {
                SrsobjectIndustrialId = id,
                EntryDate = input.EntryDate,
                WeekDay = (byte)input.WeekDay,
                Hour = input.Hour,
                AddedByUserId = userId,
            };

            await this.srsObjectIndurstiralSchemaRepository.AddAsync(schema);
            await this.srsObjectIndurstiralSchemaRepository.SaveChangesAsync();
        }

        public IEnumerable<SRSObjectIndustrialSchemeViewModel> GetAllSchemesBySrsObjectIndustrialId(int id)
        {
            var schemes = this.srsObjectIndurstiralSchemaRepository.AllAsNoTracking()
                .Where(x => x.SrsobjectIndustrialId == id)
                 .Select(x => new SRSObjectIndustrialSchemeViewModel
                 {
                     EntryDate = x.EntryDate,
                     WeekDay = (Weekday)x.WeekDay,
                     Hour = x.Hour,
                     UserId = x.AddedByUserId,
                 }).ToList();

            return schemes;
        }

        public async Task CreateContainersAsync(SRSObjectIndustrialContainerInputModel input, int id, string userId)
        {
            var lastContainerMovement = this.movementRepository.All()
                .FirstOrDefault(x => x.ContainerId == input.ContainerId && x.IsLastMovement == true);

            lastContainerMovement.IsLastMovement = false;
            await this.movementRepository.SaveChangesAsync();

            var srsObjectIndustrialId = this.warehousesRepository.All()
                .Where(x => x.Name == GlobalConstants.SRSObjectIndustrialName)
                .Select(x => x.Id)
                .FirstOrDefault();

            var movement = new Movement
            {
                ContainerId = input.ContainerId,
                WarehouseFromId = lastContainerMovement.WarehouseToId,
                WarehouseToId = srsObjectIndustrialId,
                IsLastMovement = true,
                EntryDate = DateTime.UtcNow,
                AddedByUserId = userId,
            };

            await this.movementRepository.AddAsync(movement);
            await this.movementRepository.SaveChangesAsync();

            var movementId = movement.Id;

            var container = new SrsobjectIndustrialContainer
            {
                SrsobjectIndustrialId = id,
                ContainerId = input.ContainerId,
                MovementId = movementId,
                AddedByUserId = userId,
            };

            await this.srsObjectIndurstiralContainerRepository.AddAsync(container);
            await this.srsObjectIndurstiralContainerRepository.SaveChangesAsync();
        }

        public IEnumerable<SRSObjectIndustrialContainerViewModel> GetAllContainersBySrsObjectIndustrialId(int id)
        {
            var containers = this.srsObjectIndurstiralContainerRepository.AllAsNoTracking()
                .Where(x => x.SrsobjectIndustrialId == id)
                 .Select(x => new SRSObjectIndustrialContainerViewModel
                 {
                     SrsobjectIndustrialId = id,
                     SrsobjectIndustrialName = x.SrsobjectIndustrial.Name,
                     ContainerId = x.ContainerId,
                     ContainerInventarNumber = x.Container.InventarNumber,
                     MovementId = x.MovementId,
                     UserId = x.AddedByUserId,
                 }).ToList();

            return containers;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.srsObjectIndurstiralRepository.AllAsNoTracking()
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
