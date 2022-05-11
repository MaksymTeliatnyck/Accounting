using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using FirebirdSql.Data.FirebirdClient;

namespace Accounting
{
    class Periods
    {
        public class Period
        {
            public short Month { get; set; }
            public short Year { get; set; }
            public bool? State { get; set; }

            public string MonthText { get; set; }
            public string YearText { get; set; }
            public string StateText { get; set; }
        }

        public class PeriodInterval
        {
            public DateTime BeginDate { get; set; }
            public DateTime EndDate { get; set; }
        }

        private DataTable TablePeriods;
        public void GetPeriods()
        {
            TablePeriods = DataModule.ExecuteFill
            (
                @"SELECT
                    LPAD(""Periods"".""Month"", 2, '0') || ' ' || (SELECT * FROM ""Get_Month_Name_By_Number""(""Periods"".""Month"")) AS ""Month"", ""Periods"".""Year""
                FROM
                    ""Periods"""
            );
        }

		public DataTable GetOpenedPeriods()
		{
			return DataModule.ExecuteFill
			(
				@"SELECT
                    *
                FROM
                    ""Periods""
				WHERE
					""Periods"".""State"" = 1"
			);
		}

		public DataTable GetClosedPeriods()
		{
			return DataModule.ExecuteFill
			(
				@"SELECT
                    *
                FROM
                    ""Periods""
				WHERE
					""Periods"".""State"" = 0"
			);
		}

        public Period[] GetYears()
        {
            if (TablePeriods == null)
                GetPeriods();
            return TablePeriods.AsEnumerable().GroupBy(g => g.Field<short>("Year")).Select(g => new Period { Year = g.Key, YearText = g.First().Field<short>("Year").ToString() }).ToArray();
        }

        public Period[] GetMonths(short year)
        {
            if (TablePeriods == null)
                GetPeriods();
            return TablePeriods.AsEnumerable().Where(c => c.Field<short>("Year") == year).Select(c => new Period { Month = short.Parse(c.Field<string>("Month").Substring(0, 2)), MonthText = c.Field<string>("Month") }).Distinct().ToArray();
        }

        public Period[] GetEndYears(short year)
        {
            if (TablePeriods == null)
                GetPeriods();
            return TablePeriods.AsEnumerable().Where(c => c.Field<short>("Year") >= year).GroupBy(g => g.Field<short>("Year")).Select(g => new Period { Year = g.Key, YearText = g.First().Field<short>("Year").ToString() }).ToArray();
        }

        public Period[] GetEndMonths(short month, short year)
        {
            if (TablePeriods == null)
                GetPeriods();
            return TablePeriods.AsEnumerable().Where(c => c.Field<short>("Year") == year && short.Parse(c.Field<string>("Month").Substring(0, 2)) >= month).Select(c => new Period { Month = short.Parse(c.Field<string>("Month").Substring(0, 2)), MonthText = c.Field<string>("Month") }).Distinct().ToArray();
        }

        public PeriodInterval BuildPeriodDate(short beginMonth, short beginYear, short endMonth, short endYear)
        {
            return new PeriodInterval { BeginDate = DateTime.Parse("01." + beginMonth + "." + beginYear), EndDate = DateTime.Parse(DateTime.DaysInMonth(endYear, endMonth) + "." + endMonth + "." + endYear) };
        }

        public static bool? CheckPeriodState(int year, int month)
        {
            DataModule.Connection.Open();
            short? State = (short?)DataModule.ExecuteScalar(@"SELECT ""State"" FROM ""Periods"" WHERE ""Month"" = @Month AND ""Year"" = @Year", new FbParameter("Month", month), new FbParameter("Year", year));
            DataModule.Connection.Close();
            switch (State)
            {
                case null:
                    return null;
                case 0:
                    return false;
                case 1:
                    return true;
                default:
                    return null;
            }
        }
    }
}
