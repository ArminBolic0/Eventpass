using EventPass.Application.DTOs.VenueDTOs;
using EventPass.Domain.Entities.Venues;
using EventPass.Domain.Interfaces.Venues;
using MediatR;

namespace EventPass.Application.Commands.Venues.Create
{
    public class CreateVenueCommandHandler : IRequestHandler<CreateVenueCommand, ResponseVenueDto>
    {

        IVenueRepository _repository;

        public CreateVenueCommandHandler(IVenueRepository repository)
        {
            _repository = repository;
        }




        public async Task<ResponseVenueDto> Handle(CreateVenueCommand request, CancellationToken cancellationToken)
        {
            var newVenue = new Venue { Adress = request.Adress,
                Capacity = request.Capacity,
                City = request.City,
                Country = request.Country, Name = request.Name,
                PostalCode = request.PostalCode,
                VenueTypeID = request.VenueTypeID };
            var createdVenue = await _repository.AddVenueAsync(newVenue, cancellationToken);

            var newVenueDto = new ResponseVenueDto
            {
                Adress = createdVenue.Adress,
                Capacity = createdVenue.Capacity,
                City = createdVenue.City,
                Country = createdVenue.Country,
                Name = createdVenue.Name,
                PostalCode = createdVenue.PostalCode,
                venueType = createdVenue.VenueType.Name
            };

            return newVenueDto; 
        }
    }

}
