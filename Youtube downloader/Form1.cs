using System;

using System.Windows.Forms;
using VideoLibrary;
using System.IO;


namespace Youtube_downloader
{
    public partial class Form1 : Form
    {
        Progress<double> Progress = new Progress<double>();

        public Form1()
        {
            InitializeComponent();


        }

        private async void DownloadButton_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text;
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonMusic);
            if (!string.IsNullOrEmpty(url))
            {
                var yt = YouTube.Default;
                var video = await yt.GetVideoAsync(url);
                string title;
                if(checkBox1.Checked)
                    title = video.Title + ".mp4";
                else
                    title = video.Title + ".mp3";
                string fullPath = Path.Combine(path, title);
                File.WriteAllBytes(fullPath, await video.GetBytesAsync());
            }

        }
    }
}

        

     

