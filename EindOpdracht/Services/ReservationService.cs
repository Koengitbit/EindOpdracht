using AutoMapper;
using EindOpdracht.DTO.Exchange;
using EindOpdracht.Models;
using EindOpdracht.Repository;

public class ReservationService
{
    private readonly EindOpdrachtRepository _repository;
    private readonly IMapper _mapper;

    public ReservationService(EindOpdrachtRepository repository, IMapper mapper)
    {
        ArgumentNullException.ThrowIfNull(repository);
        ArgumentNullException.ThrowIfNull(mapper);
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ReservationResponseDto> CreateReservationAsync(ReservationRequestDTO requestDto, CancellationToken cancellationToken)
    {
        var customer = await _repository.FindOrCreateCustomerAsync(requestDto.Email, requestDto.FirstName, requestDto.LastName, cancellationToken);

        var reservation = new Reservation
        {
            StartDate = requestDto.StartDate,
            EndDate = requestDto.EndDate,
            LocationId = requestDto.LocationId,
            CustomerId = customer.Id,
            Discount = requestDto.Discount ?? 0
        };

        await _repository.CreateReservationAsync(reservation, cancellationToken);

        var (locationName, pricePerDay) = await _repository.GetLocationDetailsAsync(requestDto.LocationId, cancellationToken);

        int numberOfDays = (int)(requestDto.EndDate - requestDto.StartDate).TotalDays;
        float price = numberOfDays * pricePerDay;
        float totalPrice = price - (price * requestDto.Discount ?? 0);

        var responseDto = new ReservationResponseDto
        {
            LocationName = locationName,
            CustomerName = $"{customer.FirstName} {customer.LastName}",
            Price = totalPrice,
            Discount = requestDto.Discount ?? 0
        };

        return responseDto;
    }
}
