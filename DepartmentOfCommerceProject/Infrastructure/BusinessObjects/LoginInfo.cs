namespace DepartmentOfCommerceProject.Infrastructure.BusinessObjects
{
    public class LoginInfo
    {
        private string login = "";
        private string pass = "";
        private string hash = "";

        public bool IsLoginAdjusted { get; private set; } = false;
        public bool IsPassAdjusted { get; private set; } = false;

        public string Login
        {
            set
            {
                IsLoginAdjusted = true;
                hash = CryptoService.GetMd5Hash(value + ":" + pass);
            }
        }

        public string Pass
        {
            set
            {
                IsPassAdjusted = true;
                hash = CryptoService.GetMd5Hash(login + ":" + value);
            }
        }

        public string Hash
        {
            get
            {
                return hash;
            }
        }
    }
}
