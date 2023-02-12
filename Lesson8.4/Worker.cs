namespace Lesson8._4
{
    public struct Worker
    {
        public string Fio { get; set; }

        public string Street { get; set; }

        public int HouseNumber { get; set; }

        public int FlatNumber { get; set; }

        public string MobilePhone { get; set; }

        public string FlatPhone { get; set; }

        public Worker(string fio, string street, int houseNumber, int flatNumber, string mobilePhone, string flatPhone)
        {
            this.Fio = fio;
            this.Street = street;
            this.HouseNumber = houseNumber;
            this.FlatNumber = flatNumber;
            this.MobilePhone = mobilePhone;
            this.FlatPhone = flatPhone;
        }
    }
}
