using System;
namespace lms.config.Utils
{
	public class Util
	{
        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyMMddHHmmssfff");
        }
    }
}

