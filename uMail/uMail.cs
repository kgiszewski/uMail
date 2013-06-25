using System;
using System.Web;
using System.Threading;
using umbraco.BusinessLogic;

namespace uMailDefender
{
    public class uMail
    {
        public static string EncodeEmail(string email)
        {
            try
            {
                int atSignPosition = email.IndexOf('@');

                string encoded = email.Remove(atSignPosition, 1);
                int encodedLength = encoded.Length;

                int sliceBegin, sliceEnd;

                Random random = uMail.GetRandom();

                sliceBegin = random.Next(0, encodedLength - 2);
                sliceEnd = random.Next(sliceBegin, encodedLength);

                string slice = encoded.Substring(sliceBegin, (sliceEnd - sliceBegin));
                encoded = encoded.Remove(sliceBegin, (sliceEnd - sliceBegin));

                return "({'a':" + atSignPosition + ", 'sb':" + sliceBegin + ", 's':'" + slice + "', 'lo':'" + encoded + "'})";
            }
            catch (Exception e)
            {
                Log.Add(LogTypes.Debug, 0, "umail=>" + e.Message);
                return "";
            }
        }

        public static Random GetRandom()
        {
            Thread.Sleep(1);
            return new Random(DateTime.Now.Millisecond);
        }
    }
}
