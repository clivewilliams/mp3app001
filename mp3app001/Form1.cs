using FlexCel.Core;
using FlexCel.XlsAdapter;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mp3app001
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version 004", "MP3 App", MessageBoxButtons.OK);
        }

        int line = 0;
        int maxline = 9999999;

        private void button1_Click(object sender, EventArgs e)
        {
            string inputs = tbInputs.Text;
            string outputs = tbOutputs.Text;
            string howmany = tbHowmany.Text;
            if (!(int.TryParse(howmany, out maxline)))
            {
                maxline = 9999999;
            }
            string r = "";

            Directory.CreateDirectory(outputs);
            ExcelFile xls = null;
            string fn = Path.Combine(outputs, "stage1-" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + ".xlsx");
            r = xlsutils.OpenXLS(ref xls);
            xlsutils.SetCellString("root", ref xls, 1, 1);
            xlsutils.SetCellString("dir", ref xls, 1, 2);
            xlsutils.SetCellString("fn", ref xls, 1, 3);
            xlsutils.SetCellString("artist", ref xls, 1, 4);
            xlsutils.SetCellString("album", ref xls, 1, 5);
            xlsutils.SetCellString("artist2", ref xls, 1, 6);
            xlsutils.SetCellString("trackname", ref xls, 1, 7);
            xlsutils.SetCellString("tracknum", ref xls, 1, 8);
            xlsutils.SetCellString("size", ref xls, 1, 9);
            xlsutils.SetCellString("newdir", ref xls, 1, 10);
            xlsutils.SetCellString("newfn", ref xls, 1, 11);
            xlsutils.SetCellString("newartist", ref xls, 1, 12);
            xlsutils.SetCellString("newalbum", ref xls, 1, 13);
            xlsutils.SetCellString("newartist2", ref xls, 1, 14);
            xlsutils.SetCellString("newtrackname", ref xls, 1, 15);
            xlsutils.SetCellString("newtracknum", ref xls, 1, 16);
            xlsutils.SetCellString("what", ref xls, 1, 17);
            line = 2;


            foreach (string i in inputs.Split(';'))
            {
                ProcessDir(ref xls, i, i);
            }

            xlsutils.CloseXLS(fn, ref xls);
            tbStage1.Text = fn;
            MessageBox.Show("Done", "MP3 App", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ProcessDir(ref ExcelFile xls, string rootdir, string dirtoread)
        {
            DirectoryInfo di = new DirectoryInfo(dirtoread);
            foreach (FileInfo f in di.GetFiles())
            {
                if (line > maxline)
                {
                    break;
                }
                if (f.Extension == ".mp3")
                {
                    xlsutils.SetCellString(rootdir, ref xls, line, 1);
                    xlsutils.SetCellString(f.DirectoryName, ref xls, line, 2);
                    xlsutils.SetCellString(f.Name, ref xls, line, 3);
                    xlsutils.SetCellInt((int)(f.Length), ref xls, line, 9);
                    TagLib.File tagFile = null;
                    try {
                        tagFile = TagLib.File.Create(f.FullName);
                    }
                    catch
                    {

                    }
                    if (!(tagFile is null))
                    {
                        string artist1 = "";
                        string artist2 = "";
                        string album = tagFile.Tag.Album;
                        xlsutils.SetCellString(album, ref xls, line, 5);
                        string title = tagFile.Tag.Title;
                        xlsutils.SetCellString(title, ref xls, line, 7);
                        try
                        {
                            if (!(tagFile.Tag.AlbumArtists is null))
                            {
                                foreach (string a in tagFile.Tag.AlbumArtists)
                                {
                                    if (artist1 == "")
                                    {
                                        artist1 = a;
                                    }
                                    else
                                    {
                                        artist1 = a + ", " + artist1;
                                    }
                                }
                                xlsutils.SetCellString(artist1, ref xls, line, 4);
                            }
                        }
                        catch
                        {

                        }
                        try
                        {
                            if (!(tagFile.Tag.Artists is null))
                            {
                                foreach (string a in tagFile.Tag.Artists)
                                {
                                    if (artist2 == "")
                                    {
                                        artist2 = a;
                                    } else
                                    {
                                        artist2 = a + ", "  + artist2;
                                    }
                                }
                                xlsutils.SetCellString(artist2, ref xls, line, 6);
                            }
                        }
                        catch
                        {

                        }

                        uint tracknumber = tagFile.Tag.Track;
                        xlsutils.SetCellInt((int)tracknumber, ref xls, line, 8);
                        if (line % 100 == 0) {
                            tbStatus.AppendText(line.ToString() + Environment.NewLine);
                            tbStatus.ScrollToCaret();
                            Console.WriteLine(line.ToString());
                            Application.DoEvents();
                        }
                    }

                    line++;
                }
            }

            foreach (DirectoryInfo d in di.GetDirectories())
            {
                if (line > maxline)
                {
                    break;
                }
                ProcessDir(ref xls, rootdir, d.FullName);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (tbOutputs.Text != "")
            {
                if (Directory.Exists(tbOutputs.Text))
                {
                    DirectoryInfo di = new DirectoryInfo(tbOutputs.Text);
                    string oldest1 = "aaaa";
                    string oldest2 = "aaaa";
                    foreach (FileInfo f in  di.GetFiles())
                    {
                        if (f.Extension == ".xlsx")
                        {
                            if (Strings.Left(f.Name, 6) == "stage1")
                            {
                                if (f.Name.CompareTo(oldest1) > 0) 
                                {
                                    oldest1 = f.Name;
                                    tbStage1.Text = f.FullName;
                                }
                            }
                        }
                        if (f.Extension == ".xlsx")
                        {
                            if (Strings.Left(f.Name, 6) == "stage2")
                            {
                                if (f.Name.CompareTo(oldest2) > 0)
                                {
                                    oldest2 = f.Name;
                                    tbStage2.Text = f.FullName;
                                }
                            }
                        }
                    }
                }
            }

        }

        private void btnStage2_Click(object sender, EventArgs e)
        {
            if (tbStage1.Text == "")
            {
                return;
            }
            string fn1 = tbStage1.Text;
            if (!(File.Exists(fn1)))
            {
                return;
            }
            string fn2 = fn1.Replace("stage1", "stage2");
            ExcelFile xls = new XlsFile(true); //Create a new file.
            xls.Open(fn1); //Import the csv text.     
            DoStage2(ref xls);
            if (File.Exists(fn2))
            {
                try
                {
                    File.Delete(fn2);
                }
                catch
                {
                    MessageBox.Show("Can't delete " + fn2 + " - is it open?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            xls.Save(fn2);
            tbStage2.Text = fn2;
            MessageBox.Show("Done.", "MP3 App", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DoStage2(ref ExcelFile xls)
        {
            int line = 2;

            string olddir = "";
            int counter = 0;

            while (true)
            {
                string dir = xlsutils.GetCell(ref xls, line, 1);
                if (dir == "")
                {
                    return;
                }
                if (line % 100 == 0)
                {
   //                 Console.WriteLine(line.ToString());
    //                Application.DoEvents();
                }

                // 1 root 2 dir 3 fn 4  artist 5 album 6 artist2 7 trackname 8 tracknum 9 size 
                // 10 newdir 11 newfn 12 newartist 13 newalbum 14 newartist2 15 newtrackname 16 newtracknum 17 what

                string artist = xlsutils.GetCell(ref xls, line, 4).Trim();
                string artist2 = xlsutils.GetCell(ref xls, line, 6).Trim();
                if (artist == "")
                {
                    artist = artist2;
                }
                if (artist2 == "")
                {
                    artist2 = artist;
                }
                string fn = xlsutils.GetCell(ref xls, line, 3).Trim();
                string album = xlsutils.GetCell(ref xls, line, 5).Trim();
                string trackname = xlsutils.GetCell(ref xls, line, 7).Trim();
                string tracknum = xlsutils.GetCell(ref xls, line, 8).Trim();
                string root = xlsutils.GetCell(ref xls, line, 1).Trim();
                string mydir = xlsutils.GetCell(ref xls, line, 2).Trim();
                int trackno = 0;
                if (!(int.TryParse(tracknum, out trackno)))
                {
                    trackno = 0;
                }
                if (album == "")
                {
                    // Try the directory.
                    string localdir = mydir.Replace(root, "");
                    if (Strings.InStr(localdir, "\\") > 0)
                    {
                        string[] dirparts = localdir.Split('\\');
                        if (dirparts.Length == 2)
                        {
                            album = dirparts[1];
                            if (artist == "")
                            {
                                artist = dirparts[0];
                            }
                            if (artist2 == "")
                            {
                                artist2 = dirparts[0];
                            }
                        }
                    }
                }

                string[] parts = { };
                string fnx = Regex.Replace(fn, "^[0-9\\- \\.]*", "");  // leading number off please
                if (Strings.InStr(fnx, " - ") > 0)
                {
                    parts = fnx.Split(new string[] { " - " }, StringSplitOptions.None); // split on that string
                }

                if (trackname == "")
                {
                    if (parts.Length >= 1)
                    {
                        trackname = parts[parts.Length - 1].Replace(".mp3", "");
 //                       Console.WriteLine(fnx + " >> " + trackname);
                    } else
                    {
                        trackname = fnx.Trim();
                    }
                }

                if (trackno == 0)
                {
                    if (parts.Length == 4)
                    {
                        if (int.TryParse(parts[1], out trackno))
                        {

                        }
                    }
                }

                if (album == "")
                {
                    album = "Unknown"; // really should have it by now
                }

                if (artist == "")
                {
                    artist = "Unknown"; // really should have it by now
                }

                // 10 newdir 11 newfn 12 newartist 13 newalbum 14 newartist2 15 newtrackname 16 newtracknum 17 what
                if (trackno == 0)
                {
                    string tmp = "";
                    char[] fnarray = fn.ToArray();
                    foreach (char c in fnarray)
                    {
                        if (c >= '0' && c <= '9')
                        {
                            tmp = tmp + c.ToString();
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (int.TryParse(tmp, out trackno))
                    {

                    }
                }

                string dirname = Path.Combine(Regex.Replace(artist, "[\\.\"\\\\]", " "), Regex.Replace(album, "[\\.\"\\\\]", " "));
                xlsutils.SetCellString(dirname, ref xls, line, 10);

                if (trackno == 0)
                {
                    if (dirname == olddir)
                    {
                        counter = counter + 1;
                        trackno = counter;
                    } else
                    {
                        counter = 1;
                        olddir = dirname;
                        trackno = counter;
                    }
                }

                int tmpi = 0;
                trackname = Regex.Replace(trackname, " mp3$", "");
                trackname = Regex.Replace(trackname, "[\\.\"\\\\]", " ").Trim();

                if (!(int.TryParse(trackname, out tmpi))) { // only if the entire track isn't a number
                    trackname = Regex.Replace(trackname, "^[0-9\\- \\.]*", "");  // leading number off please
                }

                if (trackname == "mp3" || trackname == "")
                {
                    trackname = trackno.ToString("00");
                }
                xlsutils.SetCellString(artist, ref xls, line, 12);
                xlsutils.SetCellString(album, ref xls, line, 13);
                xlsutils.SetCellString(artist2, ref xls, line, 14);
                xlsutils.SetCellString(trackname, ref xls, line, 15);

                if (trackno > 0)
                {
                    xlsutils.SetCellString((trackno.ToString("00") + " " + trackname).Replace("/","").Trim() + ".mp3", ref xls, line, 11);
                }
                else
                {
                    xlsutils.SetCellString(trackname.Replace("/","").Trim() + ".mp3", ref xls, line, 11);
                }
                xlsutils.SetCellInt(trackno, ref xls, line, 16);

                line++;
            }


        }

        private void btnStage3_Click(object sender, EventArgs e)
        {
            if (tbStage2.Text == "")
            {
                return;
            }
            string fn2 = tbStage2.Text;
            if (!(File.Exists(fn2)))
            {
                return;
            }
            string fn3 = fn2.Replace("stage2", "stage3");
            ExcelFile xls = new XlsFile(true); //Create a new file.
            xls.Open(fn2); //Import the csv text.     
            DoStage3(tbOutputs.Text, ref xls, fn3.Replace(".xlsx", ".txt"));
            if (File.Exists(fn3))
            {
                try
                {
                    File.Delete(fn2);
                }
                catch
                {
                    MessageBox.Show("Can't delete " + fn3 + " - is it open?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            xls.Save(fn3);
            MessageBox.Show("Done.", "MP3 App", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Log(string logfile, string msg)
        {
            using (StreamWriter sw = File.AppendText(logfile))
            {
                sw.WriteLine(DateAndTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + " >> " + msg) ;
            }
        }

        private void DoStage3(string outdir, ref ExcelFile xls, string logfile)
        {
            Log(logfile, "Start " + xls.ActiveFileName);
            int line = 2;
            while (true)
            {
                string root = xlsutils.GetCell(ref xls, line, 1);
                if (root == "")
                {
                    Log(logfile, "End");
                    return;
                }

                // 1 root 2 dir 3 fn 4  artist 5 album 6 artist2 7 trackname 8 tracknum 9 size 
                // 10 newdir 11 newfn 12 newartist 13 newalbum 14 newartist2 15 newtrackname 16 newtracknum 17 what
                string dir = xlsutils.GetCell(ref xls, line, 2);
                string fn = xlsutils.GetCell(ref xls, line, 3);
                string newdir = xlsutils.GetCell(ref xls, line, 10);
                string newfn = xlsutils.GetCell(ref xls, line, 11);
                string newartist = xlsutils.GetCell(ref xls, line, 12);
                string newalbum = xlsutils.GetCell(ref xls, line, 13);
                string newartist2 = xlsutils.GetCell(ref xls, line, 14);
                string newtrackname = xlsutils.GetCell(ref xls, line, 15);
                uint newtracknum = (uint)xlsutils.GetCellAsInteger(ref xls, line, 16);
                newdir = newdir.Replace(">", "").Replace("<", "").Replace("..", ".").Replace(",", " ").Replace("&", " and ");
                newfn = newfn.Replace(">", "").Replace("<", "").Replace("..", ".").Replace(",", " ").Replace("&", " and ");
                newdir = Regex.Replace(newdir, "[+\\*\\/={}#;:@\\?]", string.Empty);
                newfn = Regex.Replace(newfn, "[+\\*\\/={}#;:@\\?]", string.Empty);
                newdir = Regex.Replace(newdir, "  *", " ");
                newfn = Regex.Replace(newfn, "  *", " ");
                if (newfn.Length > 50)
                {
                    newfn = Strings.Left(Path.GetFileNameWithoutExtension(newfn), 50) + Path.GetExtension(newfn);
                }
                string oldpath = "";
                string tmppath = "";

                string what = "OK";
                try
                {
                    oldpath = Path.Combine(root, dir, fn);
                    tmppath = "c:\\temp\\" + newfn;

                    Directory.CreateDirectory(Path.Combine(outdir, newdir));
                    if (File.Exists(tmppath))
                    {
                        File.SetAttributes(tmppath, FileAttributes.Normal);
                        File.Delete(tmppath);
                    }
                    File.Copy(oldpath, tmppath, true);
                    File.SetAttributes(tmppath, FileAttributes.Normal);
                }
                catch (Exception ex)
                {
                    what = "FILECOPY TMP: " + ex.Message;
                    Log(logfile, "ERROR: " + what + " >> " + oldpath + " >> " + tmppath);
                    Console.WriteLine(what);
                }

                try
                {
                    if (what == "OK")
                    {
                        TagLib.File file = TagLib.File.Create(tmppath); // Change file path accordingly.
                        file.Tag.Title = newtrackname;
                        file.Tag.Album = newalbum;
                        file.Tag.Track = newtracknum;
                        string[] a = { newartist };
                        string[] a2 = { newartist2 };

                        file.Tag.AlbumArtists = a;
                        file.Tag.Artists = a2;

                        var year = file.Tag.Year;

                        // Save Changes:
                        file.Save();
                    }
                } catch (Exception ex)
                {
                    what = "TAG: " + ex.Message;
                    Console.WriteLine(what);
                    Log(logfile, "ERROR: " + what + " >> " + tmppath);
                }

                string newpath = "";

                try
                {
                    newpath = Path.Combine(outdir, newdir, newfn);
                    tmppath = "c:\\temp\\" + newfn;

                    Directory.CreateDirectory(Path.Combine(outdir, newdir));
                    File.Copy(tmppath, newpath, true);
                    File.Delete(tmppath);
                }
                catch (Exception ex)
                {
                    what = "FILECOPY PLEX: " + ex.Message;
                    Log(logfile, "ERROR: " + what + " >> " + tmppath + " >> " + newpath);
                    Console.WriteLine(what);
                }



                Console.WriteLine(line.ToString() + ": " + newpath);
                tbStatus.AppendText(line.ToString() + Environment.NewLine);
                tbStatus.ScrollToCaret();
                Application.DoEvents();

                xlsutils.SetCellString(what, ref xls, line, 17);
                xlsutils.SetCellString(oldpath, ref xls, line, 18);
                xlsutils.SetCellString(newpath, ref xls, line, 19);

                line++;
                if (line % 100 == 0)
                {
                    Log(logfile, "TICK: " + line.ToString());
                }
            }
        }

        private void DoStage5(string outdir, ref ExcelFile xls)
        {
            int line = 2;
            while (true)
            {
                string root = xlsutils.GetCell(ref xls, line, 1);
                if (root == "")
                {
                    return;
                }

                // 1 root 2 dir 3 fn 4  artist 5 album 6 artist2 7 trackname 8 tracknum 9 size 
                // 10 newdir 11 newfn 12 newartist 13 newalbum 14 newartist2 15 newtrackname 16 newtracknum 17 what
                string fn = xlsutils.GetCell(ref xls, line, 3).Trim();
                string album = xlsutils.GetCell(ref xls, line, 5).Trim();
                string trackname = xlsutils.GetCell(ref xls, line, 7).Trim();
                string tracknum = xlsutils.GetCell(ref xls, line, 8).Trim();
                string mydir = xlsutils.GetCell(ref xls, line, 2).Trim();
                string flag = xlsutils.GetCell(ref xls, line, 10).Trim();
                if (flag != "x") {
                    line = line + 1;
                    continue;
                }
                string newdir = mydir.Replace(root, outdir);
                if (File.Exists(Path.Combine(newdir, fn)))
                {
                    File.Delete(Path.Combine(newdir, fn));
                }

                Directory.CreateDirectory(newdir);
                File.Copy(Path.Combine(mydir, fn), Path.Combine(newdir, fn));


                Console.WriteLine(Path.Combine(newdir, fn));
                tbStatus.AppendText(Path.Combine(newdir, fn).ToString() + Environment.NewLine);
                tbStatus.ScrollToCaret();
                Application.DoEvents();

                line++;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(tbStage1.Text);
            if (fi.Exists)
            {
                System.Diagnostics.Process.Start(tbStage1.Text);
            }
            else
            {
                //file doesn't exist
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(tbStage2.Text);
            if (fi.Exists)
            {
                System.Diagnostics.Process.Start(tbStage2.Text);
            }
            else
            {
                //file doesn't exist
            }
        }

        private void btnOpenIndexFile_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(tbIndexFile.Text);
            if (fi.Exists)
            {
                System.Diagnostics.Process.Start(tbIndexFile.Text);
            }
            else
            {
                //file doesn't exist
            }
        }

        private void btnStage4_Click(object sender, EventArgs e)
        {
            string outputs = tbOutputs.Text;

            Directory.CreateDirectory(outputs);
            ExcelFile xls = null;
            string fn = Path.Combine(outputs, "stage4-" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + ".xlsx");
            string r = "";
            r = xlsutils.OpenXLS(ref xls);
            xlsutils.SetCellString("root", ref xls, 1, 1);
            xlsutils.SetCellString("dir", ref xls, 1, 2);
            xlsutils.SetCellString("fn", ref xls, 1, 3);
            xlsutils.SetCellString("artist", ref xls, 1, 4);
            xlsutils.SetCellString("album", ref xls, 1, 5);
            xlsutils.SetCellString("artist2", ref xls, 1, 6);
            xlsutils.SetCellString("trackname", ref xls, 1, 7);
            xlsutils.SetCellString("tracknum", ref xls, 1, 8);
            xlsutils.SetCellString("size", ref xls, 1, 9);
            xlsutils.SetCellString("selected", ref xls, 1, 10);
            line = 2;

            ProcessDir(ref xls, outputs, outputs);
            xls.Save(fn);
            tbIndexFile.Text = fn;
            MessageBox.Show("Done.", "MP3 App", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button4_Click(object sender, EventArgs e) // stage 5 button
        {

            string fn3 = tbIndexFile.Text;
            ExcelFile xls = new XlsFile(true); //Create a new file.
            xls.Open(fn3); //Import the csv text.     
            DoStage5(tbExternalDrive.Text, ref xls);

            MessageBox.Show("Done.", "MP3 App", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnBuildMP3_Click(object sender, EventArgs e)
        {
            string readdir = tbVideoDir.Text;
            string mp3dir = tbMP3Dir.Text;

            MP3Dirs(readdir, mp3dir);
        }

        private void MP3Dirs(string readdir, string mp3dir)
        {
            if (Directory.Exists(readdir))
            {
                Directory.CreateDirectory(mp3dir);
                DirectoryInfo di = new DirectoryInfo(readdir);
                foreach (DirectoryInfo di2 in di.GetDirectories())
                {
                    MP3Dirs(Path.Combine(readdir, di2.Name), Path.Combine(mp3dir, di2.Name));
                }
                foreach (FileInfo fi2 in di.GetFiles())
                {
                    if (fi2.Name.EndsWith(".mp4"))
                    {
                            MP3Files(Path.Combine(readdir, fi2.Name), Path.Combine(mp3dir, Path.GetFileNameWithoutExtension(fi2.FullName) + ".mp3"));
                    }
                }
            }
            else
            {
                tbStatus.AppendText("No directory: " + readdir + Environment.NewLine);
                tbStatus.ScrollToCaret();
                Application.DoEvents();
            }
        }

        private void MP3Files(string readfile, string mp3file)
        {
            if (File.Exists(mp3file))
            {
                tbStatus.AppendText(mp3file + " exists" + Environment.NewLine);
                tbStatus.ScrollToCaret();
                Application.DoEvents();
                return;
            }
            
            var ffmpegProcess = new Process();
            ffmpegProcess.StartInfo.FileName = "D:\\Apps\\ffmpeg\\bin\\ffmpeg.exe";
            ffmpegProcess.StartInfo.Arguments = " -i \"" + readfile + "\" -vn -f mp3 -ab 320k \"" + mp3file + "\"";
            tbStatus.AppendText(ffmpegProcess.StartInfo.FileName + " " + ffmpegProcess.StartInfo.Arguments + Environment.NewLine);
            tbStatus.ScrollToCaret();
            Application.DoEvents();

            ffmpegProcess.Start();
            ffmpegProcess.WaitForExit();
            if (!ffmpegProcess.HasExited)
            {
                ffmpegProcess.Kill();
            }
            tbStatus.ScrollToCaret();
            Application.DoEvents();
        }
    }
}
