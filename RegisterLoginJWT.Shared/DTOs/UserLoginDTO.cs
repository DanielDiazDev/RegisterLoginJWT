namespace RegisterLoginJWT.Model.DTOs
{
    [Serializable]
    public class UserLoginDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

}
