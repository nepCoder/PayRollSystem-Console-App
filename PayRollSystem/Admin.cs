namespace PayRollSystem
{
    class Admin : Staff
    {
        #region private fields
        private const float overTimeRate = 15.5F;
        private const float adminHourlyRate = 30;
        #endregion

        #region property
        public float OverTime { get; private set; }
        #endregion

        #region constructor
        public Admin(string name) : base(name, adminHourlyRate)
        {

        }
        #endregion

        #region methods
        public override void CalculatePay()
        {
            Console.WriteLine("\nCalculating Payment...");
            base.CalculatePay();
            if (HoursWorked > 160)
            {
                OverTime = overTimeRate * (HoursWorked - 160);
                TotalPay = BasicPay + OverTime;
            }
        }

        public override string ToString()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"Name of Staff : {NameOfStaff}");
            Console.WriteLine($"Hours Worked : {HoursWorked}");
            Console.WriteLine($"Hourly Rate : {adminHourlyRate}");
            Console.WriteLine($"Basic Pay : {BasicPay}");
            Console.WriteLine($"Over Time : {OverTime}");
            Console.WriteLine($"Total Pay : {TotalPay}");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
            return " ";
        }
        #endregion

    }
}
