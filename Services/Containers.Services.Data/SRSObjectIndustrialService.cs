namespace Containers.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Containers.Data.Common.Repositories;
    using Containers.Data.Models;
    using Containers.Web.ViewModels.SRSObjects.Industrial;

    public class SRSObjectIndustrialService : ISRSObjectIndustrialService
    {
        private readonly IDeletableEntityRepository<SrsobjectIndustrial> srsObjectIndurstiralRepository;
        private readonly IDeletableEntityRepository<SrsobjectIndustrialSchema> srsObjectIndurstiralSchemaRepository;

        public SRSObjectIndustrialService(
            IDeletableEntityRepository<SrsobjectIndustrial> srsObjectIndurstiralRepository,
            IDeletableEntityRepository<SrsobjectIndustrialSchema> srsObjectIndurstiralSchemaRepository)
        {
            this.srsObjectIndurstiralRepository = srsObjectIndurstiralRepository;
            this.srsObjectIndurstiralSchemaRepository = srsObjectIndurstiralSchemaRepository;
        }

        public IEnumerable<SRSObjectIndustrialViewModel> GetAll()
        {
            var containers = this.srsObjectIndurstiralRepository.AllAsNoTracking()
                .Select(x => new SRSObjectIndustrialViewModel
                {
                    Name = x.Name,
                    Address = x.Address,
                    ContactPerson = x.ContactPerson,
                    Note = x.Note,
                    EntryDate = x.EntryDate,
                    DistrictId = x.DistrictId,
                    UserId = x.AddedByUserId,
                }).ToList();

            return containers;
        }

        public SRSObjectIndustrialViewModel GetById(int id)
        {
            var srsObjectIndustrial = this.srsObjectIndurstiralRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                 .Select(x => new SRSObjectIndustrialViewModel
                 {
                     Name = x.Name,
                     Address = x.Address,
                     ContactPerson = x.ContactPerson,
                     Note = x.Note,
                     EntryDate = x.EntryDate,
                     DistrictId = x.DistrictId,
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

        public async Task CreateSchemaAsync(SRSObjectIndustrialSchemaInputModel input, int srsObjectIndustrialId, string userId)
        {
            var schema = new SrsobjectIndustrialSchema
            {
                SrsobjectIndustrialId = input.SrsobjectIndustrialId,
                EntryDate = input.EntryDate,
                WeekDay = input.WeekDay,
                Hour = input.Hour,
                AddedByUserId = userId,
            };

            await this.srsObjectIndurstiralSchemaRepository.AddAsync(schema);
            await this.srsObjectIndurstiralSchemaRepository.SaveChangesAsync();
        }

        public IEnumerable<SRSObjectIndustrialSchemaViewModel> GetAllSchemesBySrsObjectIndustrialId(int id)
        {
            var schemes = this.srsObjectIndurstiralSchemaRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                 .Select(x => new SRSObjectIndustrialSchemaViewModel
                 {
                     EntryDate = x.EntryDate,
                     WeekDay = x.WeekDay,
                     Hour = x.Hour,
                     UserId = x.AddedByUserId,
                 }).ToList();

            return schemes;
        }
    }
}
