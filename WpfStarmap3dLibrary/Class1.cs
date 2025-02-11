
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Text;

using System.Runtime.Caching;

namespace WpfStarmap3dLibrary
{
    public class Class1
    {

        private static readonly int COL_ID = 0, COL_HIP = 1, COL_HD = 2, COL_HR = 3, COL_GL = 4, COL_BF = 5, COL_PROPER = 6, COL_RA = 7, COL_DEC = 8, COL_DIST = 9,
            COL_MAG = 13, COL_ABSMAG = 14, COL_SPECT = 15,
            COL_X = 17, COL_Y = 18, COL_Z = 19;



        public static void LoadCsv(string[] args)
        {

            ObjectCache cache = MemoryCache.Default;
            List<Dictionary<string, string>> starsData = cache["starsdata"] as List<Dictionary<string, string>>;
/*
            if (starsData == null)
            {
                CacheItemPolicy policy = new CacheItemPolicy();

                List<string> filePaths = new List<string>();
                filePaths.Add("c:\\cache\\example.txt");

                policy.ChangeMonitors.Add(new
                HostFileChangeMonitor(filePaths));

                // Fetch the file contents.
                starsData =
                    File.ReadAllText("c:\\cache\\example.txt");

                //cache.Set("starsdata", starsData, policy);
                cache.Set("starsdata", starsData, policy);
            }
*/
            string appFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string path = appFolder + @"\WpfStarmap3dLibrary.dll";

            //new Uri(@"/WpfStarmap3dLibrary;stardata/hyglike_from_athyg_24.csv.gz", UriKind.Relative)

            using (var inputFileStream = new FileStream(@"stardata\hyglike_from_athyg_24.csv.gz", FileMode.Open))
            using (var gzipStream = new GZipStream(inputFileStream, CompressionMode.Decompress))
            using (var outputFileStream = new FileStream("stardata\\hyglike_from_athyg_24.csv", FileMode.Create))
            {
                //await gzipStream.CopyToAsync(outputFileStream);
                gzipStream.CopyTo(outputFileStream);
            }


            string[] tokens;
            char[] separators = { ',' };
            string str = "";
            int cnt = 0;

            starsData = new List<Dictionary<string, string>>();

            FileStream fs = new FileStream(@"stardata\hyglike_from_athyg_24.csv",
                                           FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.Default);

            HashSet<string> mappedSpectralClasses = new HashSet<string>();

            while ((str = sr.ReadLine()) != null)
            {
                tokens = str.Split(separators, StringSplitOptions.TrimEntries);

                /*
                Trace.WriteLine(String.Format("Id: {0}\t\t", tokens[COL_ID]) +
                                  String.Format("Name: {0}\t\t", tokens[COL_PROPER]) +
                                  String.Format("Magnitude: {0};", tokens[COL_MAG]) +
                                  String.Format("Spectral Type: {0}", tokens[COL_SPECT]));
                */

                string spectrum = tokens[COL_SPECT];
                bool skipSpectrum = spectrum.StartsWith("(") 
                    || spectrum.Contains(")")
                    || spectrum.Contains("\"")
                    || spectrum.Contains("\'")
                    || spectrum.Contains(":")
                    || spectrum.Contains(";")
                    || spectrum.Contains("+")
                    || spectrum.Contains("-")
                    || spectrum.Contains(".")
                    || spectrum.Contains("/")
                    || spectrum.Contains("\\")
                    || spectrum.Contains("?")
                    || spectrum.Length > 7
                    || spectrum.Split(" ").Length > 3
                    ;

                if (!skipSpectrum) mappedSpectralClasses.Add(spectrum);

                cnt++;
                if (cnt != 1 && starsData != null)
                {

                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    dict.Add("COL_ID", tokens[COL_ID]);
                    dict.Add("COL_PROPER", tokens[COL_PROPER]);
                    dict.Add("COL_MAG", tokens[COL_MAG]);
                    dict.Add("COL_SPECT", tokens[COL_SPECT]);

                    dict.Add("COL_X", tokens[COL_X]);
                    dict.Add("COL_Y", tokens[COL_Y]);
                    dict.Add("COL_Z", tokens[COL_Z]);

                    dict.Add("SOURCE_LINE", str);

                    starsData.Add(dict);
                    
                }


            }

            sr.Close();

            CacheItemPolicy policy = new CacheItemPolicy();
            cache.Set("starsdata", starsData, policy);
            cache.Set("spectrumlist", mappedSpectralClasses, policy);

            Trace.WriteLine("DEBUG ==> Verify: " + starsData.Count);

        }

    }


}
