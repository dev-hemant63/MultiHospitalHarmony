using MultiHospitalHarmony.Enum;
using Newtonsoft.Json.Linq;
using System.Linq.Expressions;

namespace MultiHospitalHarmony.Static
{
    public static class Utility
    {
        public static string GetUserName(AppRole appRole)
        {
            int charLength = 3;
            int digitLength = 6;
            string prefix = string.Empty;
            switch (appRole)
            {
                case AppRole.SuperDistributor:
                    prefix = "SD";
                    break;
                case AppRole.Distributor:
                    prefix = "AD";
                    break;
                case AppRole.Agent:
                    prefix = "AG";
                    break;
                case AppRole.Hospital:
                    prefix = "HS";
                    break;
                case AppRole.Doctor:
                    prefix = "DR";
                    break;
                case AppRole.Patient:
                    prefix = "PA";
                    break;
                case AppRole.Reception:
                    prefix = "RP";
                    break;
            }
            string charSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string digitSet = "0123456789";
            Random random = new Random();

            System.Text.StringBuilder randomString = new System.Text.StringBuilder();

            for (int i = 0; i < charLength; i++)
            {
                char randomChar = charSet[random.Next(charSet.Length)];
                randomString.Append(randomChar);
            }
            for (int i = 0; i < digitLength; i++)
            {
                char randomDigit = digitSet[random.Next(digitSet.Length)];
                randomString.Append(randomDigit);
            }

            return prefix+randomString.ToString();
        }
    }
}
