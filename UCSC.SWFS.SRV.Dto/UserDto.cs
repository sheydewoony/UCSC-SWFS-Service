using UCSC.SWFS.SRV.Entity.Entities;

namespace UCSC.SWFS.SRV.Dto
{
    public class UserDto : AuditFields
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
    }
}
