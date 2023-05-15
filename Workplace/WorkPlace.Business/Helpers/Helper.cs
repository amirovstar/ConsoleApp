namespace WorkPlace.Business.Helpers
{
    public class Helper
	{
		public static Dictionary<string, string> Errors = new Dictionary<string, string>()
		{
			{"AlreadyExistsException","Object already exists"},
			{"LackOfCapacityException","Group is full" },
			{"InvalidFormatException","Included word's format is invalid"},
			{"SizeException","Length doesn't match" },
             {"MinimumWageException","Wage too low" },
             {"NotFoundException","The object not found" },
             {"EmployeeLimitNotEnough","Employee Limit is not enough" },
             {"DataNullException","Data is null" },

        };
	}
}

