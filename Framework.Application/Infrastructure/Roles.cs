namespace Framework.Application.Infrastructure
{
    public static class RolesSystem
    {
        public const string Developer = "1";
        public const string Admin = "2";
        public const string Accountent = "3";
        public const string OrderManager = "4";
        public const string OrderUser = "5";
        public const string ProductManager = "6";
        public const string ProductUser = "7";
        public const string ShipmentManager = "8";
        public const string ShipmentUser = "9";

        public static string GetRoleBy(long id)
        {
            switch (id)
            {
                case 1:
                    return "مدیرسیستم";
                case 3:
                    return "محتوا گذار";
                default:
                    return "Not Implmnted";
            }
        }
    }
}
