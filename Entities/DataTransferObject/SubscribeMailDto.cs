

namespace Entities.DataTransferObject
{
    public record class SubscribeMailDto
    {
        public int MailId { get; init; }
        public string MailAddress { get; init; }
    }
}
