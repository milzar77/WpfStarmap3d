using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.Caching;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfStarmap3dLibrary;

namespace WpfStarmap3d
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //public static Panel p;

        
        public string filterBy = SpectralClassUtils.FILTER_ALL;

        public MainWindow()
        {


            Class1.LoadCsv(null);


            InitializeComponent();

            // Creazione dell'elemento WindowsFormsHost
            /*System.Windows.Forms.Integration.WindowsFormsHost host =
                new System.Windows.Forms.Integration.WindowsFormsHost();

            // Creazione di un controllo Windows Form da ospitare (ad esempio, un WebBrowser)
            System.Windows.Forms.WebBrowser webBrowser = new System.Windows.Forms.WebBrowser();

            // Aggiunta del controllo Windows Form all'elemento WindowsFormsHost
            host.Child = webBrowser;

            // Aggiunta dell'elemento WindowsFormsHost al contenitore WPF (ad esempio, una griglia)
            unityViewport.Children.Add(host);*/


            Process process = new Process();
            process.StartInfo.FileName = @"Starmap3dUnity.exe";
            process.StartInfo.Arguments = "-parentHWND " + myPanel.Handle.ToInt32() + " " + Environment.CommandLine;
            process.Start();

            /*p = (Panel)this.Parent;
            IntPtr windowHandle = new WindowInteropHelper(this).Handle;

            IntPtr windowHandle2 = Process.GetCurrentProcess().MainWindowHandle;

            var hWnd = new WindowInteropHelper(Application.Current.MainWindow).EnsureHandle();*/



        }


        /* WIDGET EVENTS */

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            // ... A List.
            List<string> spectralTypes = SpectralClassUtils.buildComboList();
            
            // ... Get the ComboBox reference.
            var comboBox = sender as System.Windows.Controls.ComboBox;

            // ... Assign the ItemsSource to the List.
            comboBox.ItemsSource = spectralTypes;

            // ... Make the first item selected.
            comboBox.SelectedIndex = 0;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // ... Get the ComboBox.
            var comboBox = sender as System.Windows.Controls.ComboBox;

            // ... Set SelectedItem as Window Title.
            string value = comboBox.SelectedItem as string;
            this.filterBy = value;
            this.Title = "Selected: " + value;
            this.b1_Click(sender, e);
        }

        public void button1_Load() {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {


            string s01 = tbDistanceFromOrigin.Text;
            int distance = 1;
            if (int.TryParse(s01, out int i1))
            {
                Trace.WriteLine("DEBUG ==> Distance: " + i1);
                distance = i1;
            }

            

            ObjectCache cache = MemoryCache.Default;
            List<Dictionary<string, string>> starsData = cache["starsdata"] as List<Dictionary<string, string>>;

            Trace.WriteLine("DEBUG ==> Total Stars Count: " + starsData.Count);

            if (!Directory.Exists(@"\tmp\cache-stardata-csv"))
            {
                //Directory.CreateDirectory(@"\tmp\cache-myjournaldata-txt");
                return;
            }
                


            //"/../Temp/cache-stardata-csv/starsdata-snapshot.csv";
            //STAR-DATA-SNAPSHOT.NEW

            int rowIdx = 0;
            list1.Items.Clear();

            //list1.Items.
            System.Windows.Controls.ListView l1 = list1;

            using (FileStream fsSnapshot = new FileStream(@"\tmp\cache-stardata-csv\starsdata-snapshot-TMP.csv",
                                           FileMode.Create))
            {
                // Use stream
            

            //FileStream fsSnapshot = new FileStream(@"\tmp\cache-stardata-csv\starsdata-snapshot-TMP.csv",
            //                               FileMode.Create);


            foreach (Dictionary<string, string> item in starsData)
            {
                string tmp1 = "", tmp2 = "", tmp3 = "", tmp4 = "";
                    
                    item.TryGetValue("COL_ID", out tmp1);
                item.TryGetValue("COL_PROPER", out tmp2);
                item.TryGetValue("COL_MAG", out tmp3);
                item.TryGetValue("COL_SPECT", out tmp4);

                    item.TryGetValue("COL_X", out string tmpX);
                    item.TryGetValue("COL_Y", out string tmpY);
                    item.TryGetValue("COL_Z", out string tmpZ);
                    item.TryGetValue("SOURCE_LINE", out string tmpLine);

                    /*if (tmpX.Equals("")|| tmpX.StartsWith("EU"))
                        continue;
                    if (tmpY.Equals("") || tmpY.StartsWith("EU"))
                        continue;
                    if (tmpZ.Equals("") || tmpZ.StartsWith("EU"))
                        continue;*/

                    /*                    double x = double.Parse(tmpX);
                                        double y = double.Parse(tmpY);
                                        double z = double.Parse(tmpZ);*/

                    double starDistance = Double.MaxValue;
                    if (double.TryParse(tmpX, out double xdec) && double.TryParse(tmpY, out double ydec) && double.TryParse(tmpZ, out double zdec)) 
                    {
                        starDistance = Math3DUtils.distance(0, xdec, 0, ydec, 0, zdec);
                    }
                    
                    
                    if (starDistance > distance && distance != -1) { continue; }
                    //TODO:FIXME: sistemare con regular expression il filtering ad esempio delle classi I e II che inglobano dopo il filtro anche la III, ma necessario lo startswith perché
                    //vi sono classi come IIPS e così via
                    if (this.filterBy.Equals(SpectralClassUtils.FILTER_ALL) || tmp4.StartsWith(this.filterBy))//(tmp4.StartsWith(this.filterBy) || this.filterBy == "")
                    {
                        l1.Items.Add(new MyItem
                        {
                            Id = tmp1,
                            Name = tmp2,
                            Magnitude = tmp3,
                            SpectralType = tmp4,
                            DistanceFromSun = Math3DUtils.roundUpTo(starDistance, 0).ToString(),
                        }
                        );
                        byte[] byteArray = Encoding.UTF8.GetBytes(tmpLine+"\n");

                        fsSnapshot.Write(byteArray);
                    }
            }

            fsSnapshot.Flush();
            fsSnapshot.Close();

            }

            FileStream fsSnapshotAlert = new FileStream(@"\tmp\cache-stardata-csv\STAR-DATA-SNAPSHOT.NEW",
                               FileMode.Create);
            byte[] byteArray2 = Encoding.UTF8.GetBytes("THIS IS A TRIGGER!" + "\n");
            fsSnapshotAlert.Write(byteArray2);
            fsSnapshotAlert.Flush();
            fsSnapshotAlert.Close();

            Trace.WriteLine("DEBUG ==> Total Stars Filtered: " + l1.Items.Count);

        }

        private void l1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        
    }

    public class MyItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Magnitude { get; set; }
        public string SpectralType { get; set; }
        public string DistanceFromSun { get; set; }
    }



    /* WIP */
    /*
    public partial class Form1
    {
        [DllImport("User32.dll")]
        private static extern bool MoveWindow(IntPtr handle, int x, int y, int width, int height, bool redraw);

        internal delegate int WindowEnumProc(IntPtr hwnd, IntPtr lparam);

        [DllImport("user32.dll")]
        internal static extern bool EnumChildWindows(IntPtr hwnd, WindowEnumProc func, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        private Process process;
        private IntPtr unityHWND = IntPtr.Zero;

        private const int WM_ACTIVATE = 0x0006;
        private readonly IntPtr WA_ACTIVE = new IntPtr(1);
        private readonly IntPtr WA_INACTIVE = new IntPtr(0);

        

        public void tryUnity(object sender, EventArgs e)
        {


            IntPtr windowHandle2 = Process.GetCurrentProcess().MainWindowHandle;

            try
            {
                process = new Process();
                process.StartInfo.FileName = "unity_test.exe";
                process.StartInfo.Arguments = "-parentHWND " + windowHandle2.ToInt32() + " " + Environment.CommandLine;
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.CreateNoWindow = true;

                process.Start();

                process.WaitForInputIdle();
                // Doesn't work for some reason ?!
                //unityHWND = process.MainWindowHandle;
                EnumChildWindows(Process.GetCurrentProcess().Handle, WindowEnum, IntPtr.Zero);

                //unityHWNDLabel.Text = "Unity HWND: 0x" + unityHWND.ToString("X8");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ".\nCheck if Container.exe is placed next to Child.exe.");
            }
        }

        private void ActivateUnityWindow()
        {
            SendMessage(unityHWND, WM_ACTIVATE, WA_ACTIVE, IntPtr.Zero);
        }

        private void DeactivateUnityWindow()
        {
            SendMessage(unityHWND, WM_ACTIVATE, WA_INACTIVE, IntPtr.Zero);
        }

        private int WindowEnum(IntPtr hwnd, IntPtr lparam)
        {
            unityHWND = hwnd;
            ActivateUnityWindow();
            return 0;
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            MoveWindow(unityHWND, 0, 0, panel1.Width, panel1.Height, true);
            ActivateUnityWindow();
        }

        // Close Unity application
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                process.CloseMainWindow();

                Thread.Sleep(1000);
                while (process.HasExited == false)
                    process.Kill();
            }
            catch (Exception)
            {
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            ActivateUnityWindow();
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            DeactivateUnityWindow();
        }
    }

    class SelectablePanel : Panel
    {
        public SelectablePanel()
        {
            this.SetStyle(ControlStyles.Selectable, true);
            this.TabStop = true;
        }
    }
    */

}