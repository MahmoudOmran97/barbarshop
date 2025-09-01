using System;
using System.IO;
using System.Drawing;

namespace el_shabander.bl
{
    class methods
    {
        public static byte[] convert_byte(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public static Image convert_image(byte[] by)
        {
            if (by == null || by.Length == 0)
                return null;
            using (MemoryStream ms = new MemoryStream(by))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
