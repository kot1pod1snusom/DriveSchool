using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace DriveSchool
{
    public partial class WatchVideo : Form
    {
        public WatchVideo()
        {
            InitializeComponent();
            string url = "https://www.youtube.com/watch?v=ne1FWo0eOzI".Replace("/watch?v=", "/v/");
            axWindowsMediaPlayer1.URL = url;
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
    }
}
