
using System;

namespace ConsoleApp
{


    public class NullableTypes
    {

        public static void MainNull()
        {


            Nullable<DateTime> date = null;

            // We can rewrite this code and make it a little bit shorter
            DateTime? date2 = null;

            DateTime? date3 = new DateTime(2020, 1, 1);

            DateTime date4 = date3.GetValueOrDefault();


            //
            DateTime? date5 = null;
            DateTime date5_6 = (date5 != null) ? date5.GetValueOrDefault() : DateTime.Today;
            DateTime date6 = date5 ?? DateTime.Today;

        }
    }
}