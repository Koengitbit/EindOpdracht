using AutoMapper;
using EindOpdracht.DTO;
using EindOpdracht.Models;
using EindOpdracht.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EindOpdracht.Services
{
    public class SearchService
    {
        private readonly EindOpdrachtRepository _repository;
        private readonly IMapper _mapper;

        public SearchService(EindOpdrachtRepository repository, IMapper mapper)
        {
            ArgumentNullException.ThrowIfNull(repository);
            ArgumentNullException.ThrowIfNull(mapper);
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LocationDTO>> GetLocationsAsync(CancellationToken cancellationToken)
        {
            var locations = await _repository.GetAllLocationsAsync(cancellationToken);
            return _mapper.Map<LocationDTO[]>(locations);
        }

        //V2 version of the API
        public async Task<IEnumerable<LocationDTOV2>> GetLocationsV2Async(CancellationToken cancellationToken)
        {
            var locations = await _repository.GetAllLocationsAsync(cancellationToken);
            return _mapper.Map<LocationDTOV2[]>(locations);
        }

        public async Task<float> GetMaxPriceAsync(CancellationToken cancellationToken)
        {
            return await _repository.GetMaxPriceAsync(cancellationToken);
        }

        public async Task<IEnumerable<LocationDTOV2>> SearchLocationsAsync(SearchDTO searchDto, CancellationToken cancellationToken)
        {
            Func<IQueryable<Location>, IQueryable<Location>> queryModifier = query =>
            {
                if (searchDto.Features.HasValue)
                    query = query.Where(l => (l.Features & (Features)searchDto.Features.Value) == (Features)searchDto.Features.Value);
                if (searchDto.Type.HasValue)
                    query = query.Where(l => l.LocationType == (LocationType)searchDto.Type.Value);
                if (searchDto.Rooms.HasValue)
                    query = query.Where(l => l.Rooms >= searchDto.Rooms.Value);
                if (searchDto.MinPrice.HasValue)
                    query = query.Where(l => l.PricePerDay >= searchDto.MinPrice.Value);
                if (searchDto.MaxPrice.HasValue)
                    query = query.Where(l => l.PricePerDay <= searchDto.MaxPrice.Value);

                return query.Include(l => l.Images).Include(l => l.Landlord);
            };

            var locations = await _repository.SearchLocationsAsync(queryModifier, cancellationToken);
            return _mapper.Map<LocationDTOV2[]>(locations);
        }

        public async Task<LocationDetailsDTO> GetLocationDetailsAsync(int id, CancellationToken cancellationToken)
        {
            var location = await _repository.GetLocationByIdAsync(id, cancellationToken);

            if (location == null)
            {
                return null;
            }
            return _mapper.Map<LocationDetailsDTO>(location);
        }

        public async Task<UnAvailableDatesResponseDTO> GetUnAvailableDatesAsync(int locationId, CancellationToken cancellationToken)
        {
            var unavailableDates = await _repository.GetUnAvailableDatesAsync(locationId, cancellationToken);
            return new UnAvailableDatesResponseDTO { UnAvailableDates = unavailableDates };
        }
    }
}
