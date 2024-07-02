namespace ProtoPlastics.Api.Content
{
    public static class Address
    {
        public static readonly string Street = "1880 Blackacre Dr";
        public static readonly string City = "Oldcastle";
        public static readonly string Province = "ON";
        public static readonly string ProvinceFull = "Ontario";
        public static readonly string Postal = "N0R 1L0";
        public static string FullAddress()
        {
            return Street + ", " + City + ", " + Province + " " + Postal;
        }
    }

    public static class Phone
    {
        public static readonly string Number = "(519) 737-7838";
        public static readonly string HTMLRef = $"tel:{{{Number}}}";
    }

    public static class Email
    {
        public static readonly string Address = "protop@mnsi.net";
        public static readonly string HTMLRef = $"mailto:{Address}";
    }
}
