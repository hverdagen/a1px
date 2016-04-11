using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Drawing;
using System.Windows.Forms;
using System.IO;


namespace a1px
{
    class Program
    {
        static void Main(string[] args)
        {
            bool hasArgs = false;
            bool isPng = false;
            bool badArgs;
            string filename = ""; // has to be initialized so VS doesnt throw an error for later... a bit sloppy

            hasArgs = args.Length != 0;
            if (hasArgs)
            {
                filename = args[0];
                isPng = filename.ToLower().EndsWith(".png");
            }

            badArgs = !(hasArgs && isPng);
            if (badArgs)
            {
                if (!hasArgs) 
                {
                    throw new System.ArgumentException("Bad argument: No argument error");
                }
                else if (!isPng)
                {
                    throw new System.ArgumentException("Bad argument: Not a png");
                }
                else 
                {
                    throw new System.ArgumentException("Bad argument: Unknown error");
                }
            }
            else 
            {
                
                Image img = Image.FromFile(filename); //format: @"C:\test.bmp"
                Bitmap bmp = new Bitmap(img);
                int w = bmp.Width - 1;
                int h = bmp.Height - 1;
                Color px = bmp.GetPixel(w, h); //afaik the bottom right
                Color changedpx = Color.FromArgb(254 ,px.R, px.G, px.B);
                bmp.SetPixel(w, h, changedpx);

                string newfilename = Path.GetFileNameWithoutExtension(filename) + "_a1px.png";
                bmp.Save(newfilename, System.Drawing.Imaging.ImageFormat.Png); 
            }

        }
    }
}
