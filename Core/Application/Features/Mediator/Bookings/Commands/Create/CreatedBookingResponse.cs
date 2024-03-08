

namespace Application.Features.Mediator.Bookings.Commands.Create
{
    public class CreatedBookingResponse
    {
        public int BookingID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public int PersonCount { get; set; }
        public DateTime Date { get; set; }
    }
}
