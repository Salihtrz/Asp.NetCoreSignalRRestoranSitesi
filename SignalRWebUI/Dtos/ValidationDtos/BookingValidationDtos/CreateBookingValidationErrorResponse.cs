namespace SignalRWebUI.Dtos.ValidationDtos.BookingValidationDtos
{
    public class CreateBookingValidationErrorResponse
    {
            public string type { get; set; }
            public string title { get; set; }
            public int status { get; set; }
            public Dictionary<string,List<string>> Errors { get; set; }
            public string traceId { get; set; }
    }
}
