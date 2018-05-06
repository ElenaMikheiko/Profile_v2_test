using System;

namespace ProfileV2Test.Infrastructure
{
    public static class HelperMethods
    {
        /// <summary>
        /// Converts RGBA color value to HEX format and returns a string.
        /// <para></para>
        /// <para>Example: (192,192,192,0) -> #c0c0c0</para>
        /// </summary>
        /// <param name="rgbaValue"></param>
        /// <returns></returns>
        public static string RgbaToHexConverter(string rgbaValue)
        {
            //split the inbound string
            string[] stringArray = rgbaValue.Split(new[] { '(', ',', ')' });

            //convert to int
            int a = Convert.ToInt32(stringArray[1]);
            int b = Convert.ToInt32(stringArray[2]);
            int c = Convert.ToInt32(stringArray[3]);

            //convert to hex
            string a1 = a.ToString("X2");
            string b1 = b.ToString("X2");
            string c1 = c.ToString("X2");

            return String.Format($"#{a1}{b1}{c1}");
        }
    }
}
