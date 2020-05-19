namespace IdentityServerMysql.AspNetIdentity.Controllers
{
    public class LoginViewModelASpid
    {
        // for aspid auth controller
        public string Username { get; set; }
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

    }
}