using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;


namespace WpfStarmap3dLibrary
{
    public class Math3DUtils
    {


        public static double distance(double xStart, double xEnd, double yStart, double yEnd, double zStart, double zEnd)
        {
            double distance = 0D;

            double dx = xEnd - xStart;
            double dxPow = dx * dx;
            double xPow = Math.Pow((xEnd - xStart), 2);

            //TODO: assert dxPow.equals(xPow) : String.format("La distanza al quadrato X1,X2 non corrisponde, dxPow=%1$s; xPow=%2$s",dxPow, xPow);

            double dy = yEnd - yStart;
            double dyPow = dy * dy;
            double yPow = Math.Pow((yEnd - yStart), 2);

            //TODO: assert dyPow.equals(yPow) : String.format("La distanza al quadrato Y1,Y2 non corrisponde, dyPow=%1$s; yPow=%2$s",dyPow, yPow);

            double dz = zEnd - zStart;
            double dzPow = dz * dz;
            double zPow = Math.Pow((zEnd - zStart), 2);

            //TODO: assert dzPow.equals(zPow) : String.format("La distanza al quadrato Z1,Z2 non corrisponde, dzPow=%1$s; zPow=%2$s",dzPow, zPow);

            double distanceSum = dxPow + dyPow + dzPow;

            distance = Math.Sqrt(distanceSum);

            double distanceSquareRoot = Math3DUtils.rootNumber(distanceSum, 2);

            //TODO: assert distance.equals(distanceSquareRoot): String.format("Rilevata radice quadrata differente distance=%1$s; distanceSquareRoot=%2$s",distance, distanceSquareRoot);

            return distance;
        }


        /**
         *
         * Calcola la radice n
         *
         * @param number
         * @param nRoot
         * @return
        */
        public static double rootNumber(double number, int nRoot)
        {
            return Math.Pow(number, 1.0F / nRoot);
        }

        public static string roundUpTo(double num, int nRound)
        {
            int pattern = 0;
            for (int i = 0; i < nRound; i++)
            {
                pattern += 1;
            }

            //Debug.Log("Decimal pattern set to: " +  string.Format("{0:N"+pattern+"}", num) );
            return string.Format("{0:N" + pattern + "}", num);
        }


    }
}

