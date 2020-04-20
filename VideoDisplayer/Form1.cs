using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace VideoDisplayer
{
    public partial class VideoDisplayer : Form
    {
        public ListBox videoDIRs = new ListBox();
        public VideoDisplayer()
        {
            InitializeComponent();
            MediaPlayer.URL = null;
        }

        private void videoURL_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MediaPlayer.URL = videoURLs.SelectedItem.ToString();
            MediaPlayer.URL = videoDIRs.Items[videoURLs.SelectedIndex].ToString();
            MediaPlayer.Ctlcontrols.stop();
        }

        private void videoURL_1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void videoURL_1_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for (i = 0; i < s.Length; i++)
            {
                videoURLs.Items.Add(Path.GetFileName(s[i]));
                videoDIRs.Items.Add(s[i]);
            }
                
        }

        private void MediaPlayer_Enter(object sender, EventArgs e)
        {
            MediaPlayer.Ctlcontrols.play();
        }

        private void videoURLs_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void videoURLs_DragOver(object sender, DragEventArgs e)
        {

        }

    }

    public class DragItem
    {
        public ListBox Client;
        public int Index;
        public object Item;

        public DragItem(ListBox client, int index, object item)
        {
            Client = client;
            Index = index;
            Item = item;
        }
    }
}
