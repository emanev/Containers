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

        public async Task CreateSchemeAsync(SRSObjectIndustrialSchemeInputModel input, string userId)
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

        public IEnumerable<SRSObjectIndustrialSchemeViewModel> GetAllSchemesBySrsObjectIndustrialId(int id)
        {
            var schemes = this.srsObjectIndurstiralSchemaRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                 .Select(x => new SRSObjectIndustrialSchemeViewModel
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
