using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace WpfStarmap3dLibrary
{
    public class SpectralClassUtils
    {

        public static readonly string FILTER_ALL = "All Spectral Classes";

        public static List<string> buildComboList() {

            ObjectCache cache = MemoryCache.Default;
            List<Dictionary<string, string>> starsData = cache["starsdata"] as List<Dictionary<string, string>>;
            HashSet<string> mappedSpectralClasses = cache["spectrumlist"] as HashSet<string>;

            List<string> spectralTypes = new List<string>(); 
            spectralTypes.Add(FILTER_ALL);

            foreach (string item in mappedSpectralClasses.Distinct().Order())
            {
                
                //item.TryGetValue(itemNested, out string tmp);
                spectralTypes.Add(item);
                
                    
                
            }


            /*
            spectralTypes.Add("A");
            spectralTypes.Add("A 0 I");
            spectralTypes.Add("A 0 II");
            spectralTypes.Add("A 0 III");
            spectralTypes.Add("A 0 IV");
            spectralTypes.Add("A 0 V");
            spectralTypes.Add("A 0 Vm");
            spectralTypes.Add("A 0 Vn");
            spectralTypes.Add("A 0 Vs");

            spectralTypes.Add("A 1 I");
            spectralTypes.Add("A 1 II");
            spectralTypes.Add("A 1 III");
            spectralTypes.Add("A 1 IV");
            spectralTypes.Add("A 1 V");
            spectralTypes.Add("A 1 Vm");
            spectralTypes.Add("A 1 Vn");
            spectralTypes.Add("A 1 Vs");

            spectralTypes.Add("A 2 I");
            spectralTypes.Add("A 2 II");
            spectralTypes.Add("A 2 III");
            spectralTypes.Add("A 2 IV");
            spectralTypes.Add("A 2 V");
            spectralTypes.Add("A 2 Vm");
            spectralTypes.Add("A 2 Vn");
            spectralTypes.Add("A 2 Vs");

            spectralTypes.Add("A 3 I");
            spectralTypes.Add("A 3 II");
            spectralTypes.Add("A 3 III");
            spectralTypes.Add("A 3 IV");
            spectralTypes.Add("A 3 V");
            spectralTypes.Add("A 3 Vm");
            spectralTypes.Add("A 3 Vn");
            spectralTypes.Add("A 3 Vs");

            spectralTypes.Add("A 4 I");
            spectralTypes.Add("A 4 II");
            spectralTypes.Add("A 4 III");
            spectralTypes.Add("A 4 IV");
            spectralTypes.Add("A 4 V");
            spectralTypes.Add("A 4 Vm");
            spectralTypes.Add("A 4 Vn");
            spectralTypes.Add("A 4 Vs");

            spectralTypes.Add("A 5 I");
            spectralTypes.Add("A 5 II");
            spectralTypes.Add("A 5 III");
            spectralTypes.Add("A 5 IV");
            spectralTypes.Add("A 5 V");
            spectralTypes.Add("A 5 Vm");
            spectralTypes.Add("A 5 Vn");
            spectralTypes.Add("A 5 Vs");

            spectralTypes.Add("A 6 I");
            spectralTypes.Add("A 6 II");
            spectralTypes.Add("A 6 III");
            spectralTypes.Add("A 6 IV");
            spectralTypes.Add("A 6 V");
            spectralTypes.Add("A 6 Vm");
            spectralTypes.Add("A 6 Vn");
            spectralTypes.Add("A 6 Vs");

            spectralTypes.Add("A 7 I");
            spectralTypes.Add("A 7 II");
            spectralTypes.Add("A 7 III");
            spectralTypes.Add("A 7 IV");
            spectralTypes.Add("A 7 V");
            spectralTypes.Add("A 7 Vm");
            spectralTypes.Add("A 7 Vn");
            spectralTypes.Add("A 7 Vs");

            spectralTypes.Add("A 8 I");
            spectralTypes.Add("A 8 II");
            spectralTypes.Add("A 8 III");
            spectralTypes.Add("A 8 IV");
            spectralTypes.Add("A 8 V");
            spectralTypes.Add("A 8 Vm");
            spectralTypes.Add("A 8 Vn");
            spectralTypes.Add("A 8 Vs");

            spectralTypes.Add("A 9 I");
            spectralTypes.Add("A 9 II");
            spectralTypes.Add("A 9 III");
            spectralTypes.Add("A 9 IV");
            spectralTypes.Add("A 9 V");
            spectralTypes.Add("A 9 Vm");
            spectralTypes.Add("A 9 Vn");
            spectralTypes.Add("A 9 Vs");

            spectralTypes.Add("B 0 I");
            spectralTypes.Add("B 0 II");
            spectralTypes.Add("B 0 III");
            spectralTypes.Add("B 0 IV");
            spectralTypes.Add("B 0 V");
            spectralTypes.Add("B 0 Vm");
            spectralTypes.Add("B 0 Vn");
            spectralTypes.Add("B 0 Vs");

            spectralTypes.Add("B");
            spectralTypes.Add("B 1 I");
            spectralTypes.Add("B 1 II");
            spectralTypes.Add("B 1 III");
            spectralTypes.Add("B 1 IV");
            spectralTypes.Add("B 1 V");
            spectralTypes.Add("B 1 Vm");
            spectralTypes.Add("B 1 Vn");
            spectralTypes.Add("B 1 Vs");

            spectralTypes.Add("B 2 I");
            spectralTypes.Add("B 2 II");
            spectralTypes.Add("B 2 III");
            spectralTypes.Add("B 2 IV");
            spectralTypes.Add("B 2 V");
            spectralTypes.Add("B 2 Vm");
            spectralTypes.Add("B 2 Vn");
            spectralTypes.Add("B 2 Vs");

            spectralTypes.Add("B 3 I");
            spectralTypes.Add("B 3 II");
            spectralTypes.Add("B 3 III");
            spectralTypes.Add("B 3 IV");
            spectralTypes.Add("B 3 V");
            spectralTypes.Add("B 3 Vm");
            spectralTypes.Add("B 3 Vn");
            spectralTypes.Add("B 3 Vs");

            spectralTypes.Add("B 4 I");
            spectralTypes.Add("B 4 II");
            spectralTypes.Add("B 4 III");
            spectralTypes.Add("B 4 IV");
            spectralTypes.Add("B 4 V");
            spectralTypes.Add("B 4 Vm");
            spectralTypes.Add("B 4 Vn");
            spectralTypes.Add("B 4 Vs");

            spectralTypes.Add("B 5 I");
            spectralTypes.Add("B 5 II");
            spectralTypes.Add("B 5 III");
            spectralTypes.Add("B 5 IV");
            spectralTypes.Add("B 5 V");
            spectralTypes.Add("B 5 Vm");
            spectralTypes.Add("B 5 Vn");
            spectralTypes.Add("B 5 Vs");

            spectralTypes.Add("B 6 I");
            spectralTypes.Add("B 6 II");
            spectralTypes.Add("B 6 III");
            spectralTypes.Add("B 6 IV");
            spectralTypes.Add("B 6 V");
            spectralTypes.Add("B 6 Vm");
            spectralTypes.Add("B 6 Vn");
            spectralTypes.Add("B 6 Vs");

            spectralTypes.Add("B 7 I");
            spectralTypes.Add("B 7 II");
            spectralTypes.Add("B 7 III");
            spectralTypes.Add("B 7 IV");
            spectralTypes.Add("B 7 V");
            spectralTypes.Add("B 7 Vm");
            spectralTypes.Add("B 7 Vn");
            spectralTypes.Add("B 7 Vs");

            spectralTypes.Add("B 8 I");
            spectralTypes.Add("B 8 II");
            spectralTypes.Add("B 8 III");
            spectralTypes.Add("B 8 IV");
            spectralTypes.Add("B 8 V");
            spectralTypes.Add("B 8 Vm");
            spectralTypes.Add("B 8 Vn");
            spectralTypes.Add("B 8 Vs");

            spectralTypes.Add("B 9 I");
            spectralTypes.Add("B 9 II");
            spectralTypes.Add("B 9 III");
            spectralTypes.Add("B 9 IV");
            spectralTypes.Add("B 9 V");
            spectralTypes.Add("B 9 Vm");
            spectralTypes.Add("B 9 Vn");
            spectralTypes.Add("B 9 Vs");

            spectralTypes.Add("C");
            spectralTypes.Add("C 0 I");
            spectralTypes.Add("C 0 II");
            spectralTypes.Add("C 0 III");
            spectralTypes.Add("C 0 IV");
            spectralTypes.Add("C 0 V");
            spectralTypes.Add("C 0 Vm");
            spectralTypes.Add("C 0 Vn");
            spectralTypes.Add("C 0 Vs");

            spectralTypes.Add("C 1 I");
            spectralTypes.Add("C 1 II");
            spectralTypes.Add("C 1 III");
            spectralTypes.Add("C 1 IV");
            spectralTypes.Add("C 1 V");
            spectralTypes.Add("C 1 Vm");
            spectralTypes.Add("C 1 Vn");
            spectralTypes.Add("C 1 Vs");

            spectralTypes.Add("C 2 I");
            spectralTypes.Add("C 2 II");
            spectralTypes.Add("C 2 III");
            spectralTypes.Add("C 2 IV");
            spectralTypes.Add("C 2 V");
            spectralTypes.Add("C 2 Vm");
            spectralTypes.Add("C 2 Vn");
            spectralTypes.Add("C 2 Vs");

            spectralTypes.Add("C 3 I");
            spectralTypes.Add("C 3 II");
            spectralTypes.Add("C 3 III");
            spectralTypes.Add("C 3 IV");
            spectralTypes.Add("C 3 V");
            spectralTypes.Add("C 3 Vm");
            spectralTypes.Add("C 3 Vn");
            spectralTypes.Add("C 3 Vs");

            spectralTypes.Add("C 4 I");
            spectralTypes.Add("C 4 II");
            spectralTypes.Add("C 4 III");
            spectralTypes.Add("C 4 IV");
            spectralTypes.Add("C 4 V");
            spectralTypes.Add("C 4 Vm");
            spectralTypes.Add("C 4 Vn");
            spectralTypes.Add("C 4 Vs");

            spectralTypes.Add("C 5 I");
            spectralTypes.Add("C 5 II");
            spectralTypes.Add("C 5 III");
            spectralTypes.Add("C 5 IV");
            spectralTypes.Add("C 5 V");
            spectralTypes.Add("C 5 Vm");
            spectralTypes.Add("C 5 Vn");
            spectralTypes.Add("C 5 Vs");

            spectralTypes.Add("C 6 I");
            spectralTypes.Add("C 6 II");
            spectralTypes.Add("C 6 III");
            spectralTypes.Add("C 6 IV");
            spectralTypes.Add("C 6 V");
            spectralTypes.Add("C 6 Vm");
            spectralTypes.Add("C 6 Vn");
            spectralTypes.Add("C 6 Vs");

            spectralTypes.Add("C 7 I");
            spectralTypes.Add("C 7 II");
            spectralTypes.Add("C 7 III");
            spectralTypes.Add("C 7 IV");
            spectralTypes.Add("C 7 V");
            spectralTypes.Add("C 7 Vm");
            spectralTypes.Add("C 7 Vn");
            spectralTypes.Add("C 7 Vs");

            spectralTypes.Add("C 8 I");
            spectralTypes.Add("C 8 II");
            spectralTypes.Add("C 8 III");
            spectralTypes.Add("C 8 IV");
            spectralTypes.Add("C 8 V");
            spectralTypes.Add("C 8 Vm");
            spectralTypes.Add("C 8 Vn");
            spectralTypes.Add("C 8 Vs");

            spectralTypes.Add("C 9 I");
            spectralTypes.Add("C 9 II");
            spectralTypes.Add("C 9 III");
            spectralTypes.Add("C 9 IV");
            spectralTypes.Add("C 9 V");
            spectralTypes.Add("C 9 Vm");
            spectralTypes.Add("C 9 Vn");
            spectralTypes.Add("C 9 Vs");

            spectralTypes.Add("F");
            spectralTypes.Add("F 0 I");
            spectralTypes.Add("F 0 II");
            spectralTypes.Add("F 0 III");
            spectralTypes.Add("F 0 IV");
            spectralTypes.Add("F 0 V");
            spectralTypes.Add("F 0 Vm");
            spectralTypes.Add("F 0 Vn");
            spectralTypes.Add("F 0 Vs");

            spectralTypes.Add("F 1 I");
            spectralTypes.Add("F 1 II");
            spectralTypes.Add("F 1 III");
            spectralTypes.Add("F 1 IV");
            spectralTypes.Add("F 1 V");
            spectralTypes.Add("F 1 Vm");
            spectralTypes.Add("F 1 Vn");
            spectralTypes.Add("F 1 Vs");

            spectralTypes.Add("F 2 I");
            spectralTypes.Add("F 2 II");
            spectralTypes.Add("F 2 III");
            spectralTypes.Add("F 2 IV");
            spectralTypes.Add("F 2 V");
            spectralTypes.Add("F 2 Vm");
            spectralTypes.Add("F 2 Vn");
            spectralTypes.Add("F 2 Vs");

            spectralTypes.Add("F 3 I");
            spectralTypes.Add("F 3 II");
            spectralTypes.Add("F 3 III");
            spectralTypes.Add("F 3 IV");
            spectralTypes.Add("F 3 V");
            spectralTypes.Add("F 3 Vm");
            spectralTypes.Add("F 3 Vn");
            spectralTypes.Add("F 3 Vs");

            spectralTypes.Add("F 4 I");
            spectralTypes.Add("F 4 II");
            spectralTypes.Add("F 4 III");
            spectralTypes.Add("F 4 IV");
            spectralTypes.Add("F 4 V");
            spectralTypes.Add("F 4 Vm");
            spectralTypes.Add("F 4 Vn");
            spectralTypes.Add("F 4 Vs");

            spectralTypes.Add("F 5 I");
            spectralTypes.Add("F 5 II");
            spectralTypes.Add("F 5 III");
            spectralTypes.Add("F 5 IV");
            spectralTypes.Add("F 5 V");
            spectralTypes.Add("F 5 Vm");
            spectralTypes.Add("F 5 Vn");
            spectralTypes.Add("F 5 Vs");

            spectralTypes.Add("F 6 I");
            spectralTypes.Add("F 6 II");
            spectralTypes.Add("F 6 III");
            spectralTypes.Add("F 6 IV");
            spectralTypes.Add("F 6 V");
            spectralTypes.Add("F 6 Vm");
            spectralTypes.Add("F 6 Vn");
            spectralTypes.Add("F 6 Vs");

            spectralTypes.Add("F 7 I");
            spectralTypes.Add("F 7 II");
            spectralTypes.Add("F 7 III");
            spectralTypes.Add("F 7 IV");
            spectralTypes.Add("F 7 V");
            spectralTypes.Add("F 7 Vm");
            spectralTypes.Add("F 7 Vn");
            spectralTypes.Add("F 7 Vs");

            spectralTypes.Add("F 8 I");
            spectralTypes.Add("F 8 II");
            spectralTypes.Add("F 8 III");
            spectralTypes.Add("F 8 IV");
            spectralTypes.Add("F 8 V");
            spectralTypes.Add("F 8 Vm");
            spectralTypes.Add("F 8 Vn");
            spectralTypes.Add("F 8 Vs");

            spectralTypes.Add("F 9 I");
            spectralTypes.Add("F 9 II");
            spectralTypes.Add("F 9 III");
            spectralTypes.Add("F 9 IV");
            spectralTypes.Add("F 9 V");
            spectralTypes.Add("F 9 Vm");
            spectralTypes.Add("F 9 Vn");
            spectralTypes.Add("F 9 Vs");

            spectralTypes.Add("G");
            spectralTypes.Add("G 0 I");
            spectralTypes.Add("G 0 II");
            spectralTypes.Add("G 0 III");
            spectralTypes.Add("G 0 IV");
            spectralTypes.Add("G 0 V");
            spectralTypes.Add("G 0 Vm");
            spectralTypes.Add("G 0 Vn");
            spectralTypes.Add("G 0 Vs");

            spectralTypes.Add("G 1 I");
            spectralTypes.Add("G 1 II");
            spectralTypes.Add("G 1 III");
            spectralTypes.Add("G 1 IV");
            spectralTypes.Add("G 1 V");
            spectralTypes.Add("G 1 Vm");
            spectralTypes.Add("G 1 Vn");
            spectralTypes.Add("G 1 Vs");

            spectralTypes.Add("G 2 I");
            spectralTypes.Add("G 2 II");
            spectralTypes.Add("G 2 III");
            spectralTypes.Add("G 2 IV");
            spectralTypes.Add("G 2 V");
            spectralTypes.Add("G 2 Vm");
            spectralTypes.Add("G 2 Vn");
            spectralTypes.Add("G 2 Vs");

            spectralTypes.Add("G 3 I");
            spectralTypes.Add("G 3 II");
            spectralTypes.Add("G 3 III");
            spectralTypes.Add("G 3 IV");
            spectralTypes.Add("G 3 V");
            spectralTypes.Add("G 3 Vm");
            spectralTypes.Add("G 3 Vn");
            spectralTypes.Add("G 3 Vs");

            spectralTypes.Add("G 4 I");
            spectralTypes.Add("G 4 II");
            spectralTypes.Add("G 4 III");
            spectralTypes.Add("G 4 IV");
            spectralTypes.Add("G 4 V");
            spectralTypes.Add("G 4 Vm");
            spectralTypes.Add("G 4 Vn");
            spectralTypes.Add("G 4 Vs");

            spectralTypes.Add("G 5 I");
            spectralTypes.Add("G 5 II");
            spectralTypes.Add("G 5 III");
            spectralTypes.Add("G 5 IV");
            spectralTypes.Add("G 5 V");
            spectralTypes.Add("G 5 Vm");
            spectralTypes.Add("G 5 Vn");
            spectralTypes.Add("G 5 Vs");

            spectralTypes.Add("G 6 I");
            spectralTypes.Add("G 6 II");
            spectralTypes.Add("G 6 III");
            spectralTypes.Add("G 6 IV");
            spectralTypes.Add("G 6 V");
            spectralTypes.Add("G 6 Vm");
            spectralTypes.Add("G 6 Vn");
            spectralTypes.Add("G 6 Vs");

            spectralTypes.Add("G 7 I");
            spectralTypes.Add("G 7 II");
            spectralTypes.Add("G 7 III");
            spectralTypes.Add("G 7 IV");
            spectralTypes.Add("G 7 V");
            spectralTypes.Add("G 7 Vm");
            spectralTypes.Add("G 7 Vn");
            spectralTypes.Add("G 7 Vs");

            spectralTypes.Add("G 8 I");
            spectralTypes.Add("G 8 II");
            spectralTypes.Add("G 8 III");
            spectralTypes.Add("G 8 IV");
            spectralTypes.Add("G 8 V");
            spectralTypes.Add("G 8 Vm");
            spectralTypes.Add("G 8 Vn");
            spectralTypes.Add("G 8 Vs");

            spectralTypes.Add("G 9 I");
            spectralTypes.Add("G 9 II");
            spectralTypes.Add("G 9 III");
            spectralTypes.Add("G 9 IV");
            spectralTypes.Add("G 9 V");
            spectralTypes.Add("G 9 Vm");
            spectralTypes.Add("G 9 Vn");
            spectralTypes.Add("G 9 Vs");

            spectralTypes.Add("K");
            spectralTypes.Add("K 0 I");
            spectralTypes.Add("K 0 II");
            spectralTypes.Add("K 0 III");
            spectralTypes.Add("K 0 IV");
            spectralTypes.Add("K 0 V");
            spectralTypes.Add("K 0 Vm");
            spectralTypes.Add("K 0 Vn");
            spectralTypes.Add("K 0 Vs");

            spectralTypes.Add("K 1 I");
            spectralTypes.Add("K 1 II");
            spectralTypes.Add("K 1 III");
            spectralTypes.Add("K 1 IV");
            spectralTypes.Add("K 1 V");
            spectralTypes.Add("K 1 Vm");
            spectralTypes.Add("K 1 Vn");
            spectralTypes.Add("K 1 Vs");

            spectralTypes.Add("K 2 I");
            spectralTypes.Add("K 2 II");
            spectralTypes.Add("K 2 III");
            spectralTypes.Add("K 2 IV");
            spectralTypes.Add("K 2 V");
            spectralTypes.Add("K 2 Vm");
            spectralTypes.Add("K 2 Vn");
            spectralTypes.Add("K 2 Vs");

            spectralTypes.Add("K 3 I");
            spectralTypes.Add("K 3 II");
            spectralTypes.Add("K 3 III");
            spectralTypes.Add("K 3 IV");
            spectralTypes.Add("K 3 V");
            spectralTypes.Add("K 3 Vm");
            spectralTypes.Add("K 3 Vn");
            spectralTypes.Add("K 3 Vs");

            spectralTypes.Add("K 4 I");
            spectralTypes.Add("K 4 II");
            spectralTypes.Add("K 4 III");
            spectralTypes.Add("K 4 IV");
            spectralTypes.Add("K 4 V");
            spectralTypes.Add("K 4 Vm");
            spectralTypes.Add("K 4 Vn");
            spectralTypes.Add("K 4 Vs");

            spectralTypes.Add("K 5 I");
            spectralTypes.Add("K 5 II");
            spectralTypes.Add("K 5 III");
            spectralTypes.Add("K 5 IV");
            spectralTypes.Add("K 5 V");
            spectralTypes.Add("K 5 Vm");
            spectralTypes.Add("K 5 Vn");
            spectralTypes.Add("K 5 Vs");

            spectralTypes.Add("K 6 I");
            spectralTypes.Add("K 6 II");
            spectralTypes.Add("K 6 III");
            spectralTypes.Add("K 6 IV");
            spectralTypes.Add("K 6 V");
            spectralTypes.Add("K 6 Vm");
            spectralTypes.Add("K 6 Vn");
            spectralTypes.Add("K 6 Vs");

            spectralTypes.Add("K 7 I");
            spectralTypes.Add("K 7 II");
            spectralTypes.Add("K 7 III");
            spectralTypes.Add("K 7 IV");
            spectralTypes.Add("K 7 V");
            spectralTypes.Add("K 7 Vm");
            spectralTypes.Add("K 7 Vn");
            spectralTypes.Add("K 7 Vs");

            spectralTypes.Add("K 8 I");
            spectralTypes.Add("K 8 II");
            spectralTypes.Add("K 8 III");
            spectralTypes.Add("K 8 IV");
            spectralTypes.Add("K 8 V");
            spectralTypes.Add("K 8 Vm");
            spectralTypes.Add("K 8 Vn");
            spectralTypes.Add("K 8 Vs");

            spectralTypes.Add("K 9 I");
            spectralTypes.Add("K 9 II");
            spectralTypes.Add("K 9 III");
            spectralTypes.Add("K 9 IV");
            spectralTypes.Add("K 9 V");
            spectralTypes.Add("K 9 Vm");
            spectralTypes.Add("K 9 Vn");
            spectralTypes.Add("K 9 Vs");

            spectralTypes.Add("M");
            spectralTypes.Add("M 0 I");
            spectralTypes.Add("M 0 II");
            spectralTypes.Add("M 0 III");
            spectralTypes.Add("M 0 IV");
            spectralTypes.Add("M 0 V");
            spectralTypes.Add("M 0 Vm");
            spectralTypes.Add("M 0 Vn");
            spectralTypes.Add("M 0 Vs");

            spectralTypes.Add("M 1 I");
            spectralTypes.Add("M 1 II");
            spectralTypes.Add("M 1 III");
            spectralTypes.Add("M 1 IV");
            spectralTypes.Add("M 1 V");
            spectralTypes.Add("M 1 Vm");
            spectralTypes.Add("M 1 Vn");
            spectralTypes.Add("M 1 Vs");

            spectralTypes.Add("M 2 I");
            spectralTypes.Add("M 2 II");
            spectralTypes.Add("M 2 III");
            spectralTypes.Add("M 2 IV");
            spectralTypes.Add("M 2 V");
            spectralTypes.Add("M 2 Vm");
            spectralTypes.Add("M 2 Vn");
            spectralTypes.Add("M 2 Vs");

            spectralTypes.Add("M 3 I");
            spectralTypes.Add("M 3 II");
            spectralTypes.Add("M 3 III");
            spectralTypes.Add("M 3 IV");
            spectralTypes.Add("M 3 V");
            spectralTypes.Add("M 3 Vm");
            spectralTypes.Add("M 3 Vn");
            spectralTypes.Add("M 3 Vs");

            spectralTypes.Add("M 4 I");
            spectralTypes.Add("M 4 II");
            spectralTypes.Add("M 4 III");
            spectralTypes.Add("M 4 IV");
            spectralTypes.Add("M 4 V");
            spectralTypes.Add("M 4 Vm");
            spectralTypes.Add("M 4 Vn");
            spectralTypes.Add("M 4 Vs");

            spectralTypes.Add("M 5 I");
            spectralTypes.Add("M 5 II");
            spectralTypes.Add("M 5 III");
            spectralTypes.Add("M 5 IV");
            spectralTypes.Add("M 5 V");
            spectralTypes.Add("M 5 Vm");
            spectralTypes.Add("M 5 Vn");
            spectralTypes.Add("M 5 Vs");

            spectralTypes.Add("M 6 I");
            spectralTypes.Add("M 6 II");
            spectralTypes.Add("M 6 III");
            spectralTypes.Add("M 6 IV");
            spectralTypes.Add("M 6 V");
            spectralTypes.Add("M 6 Vm");
            spectralTypes.Add("M 6 Vn");
            spectralTypes.Add("M 6 Vs");

            spectralTypes.Add("M 7 I");
            spectralTypes.Add("M 7 II");
            spectralTypes.Add("M 7 III");
            spectralTypes.Add("M 7 IV");
            spectralTypes.Add("M 7 V");
            spectralTypes.Add("M 7 Vm");
            spectralTypes.Add("M 7 Vn");
            spectralTypes.Add("M 7 Vs");

            spectralTypes.Add("M 8 I");
            spectralTypes.Add("M 8 II");
            spectralTypes.Add("M 8 III");
            spectralTypes.Add("M 8 IV");
            spectralTypes.Add("M 8 V");
            spectralTypes.Add("M 8 Vm");
            spectralTypes.Add("M 8 Vn");
            spectralTypes.Add("M 8 Vs");

            spectralTypes.Add("M 9 I");
            spectralTypes.Add("M 9 II");
            spectralTypes.Add("M 9 III");
            spectralTypes.Add("M 9 IV");
            spectralTypes.Add("M 9 V");
            spectralTypes.Add("M 9 Vm");
            spectralTypes.Add("M 9 Vn");
            spectralTypes.Add("M 9 Vs");

            spectralTypes.Add("N");
            spectralTypes.Add("N 0 I");
            spectralTypes.Add("N 0 II");
            spectralTypes.Add("N 0 III");
            spectralTypes.Add("N 0 IV");
            spectralTypes.Add("N 0 V");
            spectralTypes.Add("N 0 Vm");
            spectralTypes.Add("N 0 Vn");
            spectralTypes.Add("N 0 Vs");

            spectralTypes.Add("N 1 I");
            spectralTypes.Add("N 1 II");
            spectralTypes.Add("N 1 III");
            spectralTypes.Add("N 1 IV");
            spectralTypes.Add("N 1 V");
            spectralTypes.Add("N 1 Vm");
            spectralTypes.Add("N 1 Vn");
            spectralTypes.Add("N 1 Vs");

            spectralTypes.Add("N 2 I");
            spectralTypes.Add("N 2 II");
            spectralTypes.Add("N 2 III");
            spectralTypes.Add("N 2 IV");
            spectralTypes.Add("N 2 V");
            spectralTypes.Add("N 2 Vm");
            spectralTypes.Add("N 2 Vn");
            spectralTypes.Add("N 2 Vs");

            spectralTypes.Add("N 3 I");
            spectralTypes.Add("N 3 II");
            spectralTypes.Add("N 3 III");
            spectralTypes.Add("N 3 IV");
            spectralTypes.Add("N 3 V");
            spectralTypes.Add("N 3 Vm");
            spectralTypes.Add("N 3 Vn");
            spectralTypes.Add("N 3 Vs");

            spectralTypes.Add("N 4 I");
            spectralTypes.Add("N 4 II");
            spectralTypes.Add("N 4 III");
            spectralTypes.Add("N 4 IV");
            spectralTypes.Add("N 4 V");
            spectralTypes.Add("N 4 Vm");
            spectralTypes.Add("N 4 Vn");
            spectralTypes.Add("N 4 Vs");

            spectralTypes.Add("N 5 I");
            spectralTypes.Add("N 5 II");
            spectralTypes.Add("N 5 III");
            spectralTypes.Add("N 5 IV");
            spectralTypes.Add("N 5 V");
            spectralTypes.Add("N 5 Vm");
            spectralTypes.Add("N 5 Vn");
            spectralTypes.Add("N 5 Vs");

            spectralTypes.Add("N 6 I");
            spectralTypes.Add("N 6 II");
            spectralTypes.Add("N 6 III");
            spectralTypes.Add("N 6 IV");
            spectralTypes.Add("N 6 V");
            spectralTypes.Add("N 6 Vm");
            spectralTypes.Add("N 6 Vn");
            spectralTypes.Add("N 6 Vs");

            spectralTypes.Add("N 7 I");
            spectralTypes.Add("N 7 II");
            spectralTypes.Add("N 7 III");
            spectralTypes.Add("N 7 IV");
            spectralTypes.Add("N 7 V");
            spectralTypes.Add("N 7 Vm");
            spectralTypes.Add("N 7 Vn");
            spectralTypes.Add("N 7 Vs");

            spectralTypes.Add("N 8 I");
            spectralTypes.Add("N 8 II");
            spectralTypes.Add("N 8 III");
            spectralTypes.Add("N 8 IV");
            spectralTypes.Add("N 8 V");
            spectralTypes.Add("N 8 Vm");
            spectralTypes.Add("N 8 Vn");
            spectralTypes.Add("N 8 Vs");

            spectralTypes.Add("N 9 I");
            spectralTypes.Add("N 9 II");
            spectralTypes.Add("N 9 III");
            spectralTypes.Add("N 9 IV");
            spectralTypes.Add("N 9 V");
            spectralTypes.Add("N 9 Vm");
            spectralTypes.Add("N 9 Vn");
            spectralTypes.Add("N 9 Vs");

            spectralTypes.Add("O");
            spectralTypes.Add("O 0 I");
            spectralTypes.Add("O 0 II");
            spectralTypes.Add("O 0 III");
            spectralTypes.Add("O 0 IV");
            spectralTypes.Add("O 0 V");
            spectralTypes.Add("O 0 Vm");
            spectralTypes.Add("O 0 Vn");
            spectralTypes.Add("O 0 Vs");

            spectralTypes.Add("O 1 I");
            spectralTypes.Add("O 1 II");
            spectralTypes.Add("O 1 III");
            spectralTypes.Add("O 1 IV");
            spectralTypes.Add("O 1 V");
            spectralTypes.Add("O 1 Vm");
            spectralTypes.Add("O 1 Vn");
            spectralTypes.Add("O 1 Vs");

            spectralTypes.Add("O 2 I");
            spectralTypes.Add("O 2 II");
            spectralTypes.Add("O 2 III");
            spectralTypes.Add("O 2 IV");
            spectralTypes.Add("O 2 V");
            spectralTypes.Add("O 2 Vm");
            spectralTypes.Add("O 2 Vn");
            spectralTypes.Add("O 2 Vs");

            spectralTypes.Add("O 3 I");
            spectralTypes.Add("O 3 II");
            spectralTypes.Add("O 3 III");
            spectralTypes.Add("O 3 IV");
            spectralTypes.Add("O 3 V");
            spectralTypes.Add("O 3 Vm");
            spectralTypes.Add("O 3 Vn");
            spectralTypes.Add("O 3 Vs");

            spectralTypes.Add("O 4 I");
            spectralTypes.Add("O 4 II");
            spectralTypes.Add("O 4 III");
            spectralTypes.Add("O 4 IV");
            spectralTypes.Add("O 4 V");
            spectralTypes.Add("O 4 Vm");
            spectralTypes.Add("O 4 Vn");
            spectralTypes.Add("O 4 Vs");

            spectralTypes.Add("O 5 I");
            spectralTypes.Add("O 5 II");
            spectralTypes.Add("O 5 III");
            spectralTypes.Add("O 5 IV");
            spectralTypes.Add("O 5 V");
            spectralTypes.Add("O 5 Vm");
            spectralTypes.Add("O 5 Vn");
            spectralTypes.Add("O 5 Vs");

            spectralTypes.Add("O 6 I");
            spectralTypes.Add("O 6 II");
            spectralTypes.Add("O 6 III");
            spectralTypes.Add("O 6 IV");
            spectralTypes.Add("O 6 V");
            spectralTypes.Add("O 6 Vm");
            spectralTypes.Add("O 6 Vn");
            spectralTypes.Add("O 6 Vs");

            spectralTypes.Add("O 7 I");
            spectralTypes.Add("O 7 II");
            spectralTypes.Add("O 7 III");
            spectralTypes.Add("O 7 IV");
            spectralTypes.Add("O 7 V");
            spectralTypes.Add("O 7 Vm");
            spectralTypes.Add("O 7 Vn");
            spectralTypes.Add("O 7 Vs");

            spectralTypes.Add("O 8 I");
            spectralTypes.Add("O 8 II");
            spectralTypes.Add("O 8 III");
            spectralTypes.Add("O 8 IV");
            spectralTypes.Add("O 8 V");
            spectralTypes.Add("O 8 Vm");
            spectralTypes.Add("O 8 Vn");
            spectralTypes.Add("O 8 Vs");

            spectralTypes.Add("O 9 I");
            spectralTypes.Add("O 9 II");
            spectralTypes.Add("O 9 III");
            spectralTypes.Add("O 9 IV");
            spectralTypes.Add("O 9 V");
            spectralTypes.Add("O 9 Vm");
            spectralTypes.Add("O 9 Vn");
            spectralTypes.Add("O 9 Vs");

            spectralTypes.Add("R");
            spectralTypes.Add("R 0 I");
            spectralTypes.Add("R 0 II");
            spectralTypes.Add("R 0 III");
            spectralTypes.Add("R 0 IV");
            spectralTypes.Add("R 0 V");
            spectralTypes.Add("R 0 Vm");
            spectralTypes.Add("R 0 Vn");
            spectralTypes.Add("R 0 Vs");

            spectralTypes.Add("R 1 I");
            spectralTypes.Add("R 1 II");
            spectralTypes.Add("R 1 III");
            spectralTypes.Add("R 1 IV");
            spectralTypes.Add("R 1 V");
            spectralTypes.Add("R 1 Vm");
            spectralTypes.Add("R 1 Vn");
            spectralTypes.Add("R 1 Vs");

            spectralTypes.Add("R 2 I");
            spectralTypes.Add("R 2 II");
            spectralTypes.Add("R 2 III");
            spectralTypes.Add("R 2 IV");
            spectralTypes.Add("R 2 V");
            spectralTypes.Add("R 2 Vm");
            spectralTypes.Add("R 2 Vn");
            spectralTypes.Add("R 2 Vs");

            spectralTypes.Add("R 3 I");
            spectralTypes.Add("R 3 II");
            spectralTypes.Add("R 3 III");
            spectralTypes.Add("R 3 IV");
            spectralTypes.Add("R 3 V");
            spectralTypes.Add("R 3 Vm");
            spectralTypes.Add("R 3 Vn");
            spectralTypes.Add("R 3 Vs");

            spectralTypes.Add("R 4 I");
            spectralTypes.Add("R 4 II");
            spectralTypes.Add("R 4 III");
            spectralTypes.Add("R 4 IV");
            spectralTypes.Add("R 4 V");
            spectralTypes.Add("R 4 Vm");
            spectralTypes.Add("R 4 Vn");
            spectralTypes.Add("R 4 Vs");

            spectralTypes.Add("R 5 I");
            spectralTypes.Add("R 5 II");
            spectralTypes.Add("R 5 III");
            spectralTypes.Add("R 5 IV");
            spectralTypes.Add("R 5 V");
            spectralTypes.Add("R 5 Vm");
            spectralTypes.Add("R 5 Vn");
            spectralTypes.Add("R 5 Vs");

            spectralTypes.Add("R 6 I");
            spectralTypes.Add("R 6 II");
            spectralTypes.Add("R 6 III");
            spectralTypes.Add("R 6 IV");
            spectralTypes.Add("R 6 V");
            spectralTypes.Add("R 6 Vm");
            spectralTypes.Add("R 6 Vn");
            spectralTypes.Add("R 6 Vs");

            spectralTypes.Add("R 7 I");
            spectralTypes.Add("R 7 II");
            spectralTypes.Add("R 7 III");
            spectralTypes.Add("R 7 IV");
            spectralTypes.Add("R 7 V");
            spectralTypes.Add("R 7 Vm");
            spectralTypes.Add("R 7 Vn");
            spectralTypes.Add("R 7 Vs");

            spectralTypes.Add("R 8 I");
            spectralTypes.Add("R 8 II");
            spectralTypes.Add("R 8 III");
            spectralTypes.Add("R 8 IV");
            spectralTypes.Add("R 8 V");
            spectralTypes.Add("R 8 Vm");
            spectralTypes.Add("R 8 Vn");
            spectralTypes.Add("R 8 Vs");

            spectralTypes.Add("R 9 I");
            spectralTypes.Add("R 9 II");
            spectralTypes.Add("R 9 III");
            spectralTypes.Add("R 9 IV");
            spectralTypes.Add("R 9 V");
            spectralTypes.Add("R 9 Vm");
            spectralTypes.Add("R 9 Vn");
            spectralTypes.Add("R 9 Vs");

            spectralTypes.Add("S");
            spectralTypes.Add("W");
            */
            return spectralTypes;

        }

    }
}
