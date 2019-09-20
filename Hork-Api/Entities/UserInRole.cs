namespace Hork_Api.Entities
{
    public class UserInRole : IEntity
    {

        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}