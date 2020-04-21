﻿using System;
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
            if (videoURLs.SelectedIndex >= 0)
            {
                //MediaPlayer.URL = videoURLs.SelectedItem.ToString();
                MediaPlayer.URL = videoDIRs.Items[videoURLs.SelectedIndex].ToString();
                MediaPlayer.Ctlcontrols.stop();
            }    
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
                videoDIRs.Items.Add(s[i]);
                videoURLs.Items.Add(Path.GetFileName(s[i]));
            }       
        }

        private void MediaPlayer_Enter(object sender, EventArgs e)
        {
            MediaPlayer.Ctlcontrols.play();
        }
    }
}
