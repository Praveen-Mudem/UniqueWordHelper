using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniqueWordService;

namespace UniqueWordHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFolderPath.Text) && Directory.Exists(txtFolderPath.Text))
            {
                //process only if path given and exists.
                string[] fileList = Directory.GetFiles(txtFolderPath.Text);
                if(fileList != null && fileList.Length > 0)
                {
                    IWordService wordsService = null;
                    if (radioMemory.Checked)
                    {
                        wordsService = new MemoryService();
                    }
                    else if (radioDB.Checked)
                    {
                        wordsService = new DBService();
                    }
                    List<Task> fileTaskList = new List<Task>();
                    foreach (string file in fileList)
                    {
                        //process parallel thread for each file.
                        fileTaskList.Add(Task.Factory.StartNew(() => FileProcess(file, wordsService)));
                    }
                    // wait for all threads to finish.
                    Task.WaitAll(fileTaskList.ToArray());
                    //get the final words list.
                    List<KeyValuePair<string,int>> words = wordsService.GetWords();

                    string outputFilePath = string.Format("{0}\\finalresult.txt", txtFolderPath.Text);
                    if (File.Exists(outputFilePath))
                    {
                        File.Delete(outputFilePath);
                    }
                    using (var fileStream = File.OpenWrite(string.Format("{0}\\finalresult.txt", txtFolderPath.Text)))
                    {
                        using (var streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
                        {
                            foreach(KeyValuePair<string,int> word in words)
                            {
                                streamWriter.WriteLine(string.Format("{0}. {1}", word.Value, word.Key));
                            }
                        }
                    }
                    MessageBox.Show("Done, please check the result at : " + outputFilePath);
                }
            }
        }
        //process for each file.
        private void FileProcess(string filePath,IWordService wordsService)
        {
            try
            {
                using (var fileStream = File.OpenRead(filePath))
                {
                    using (var streamReader = new StreamReader(fileStream,Encoding.UTF8))
                    {
                        while (!streamReader.EndOfStream)
                        {
                            var lineText = streamReader.ReadLine();
                            if (!string.IsNullOrEmpty(lineText.Trim()))
                            {
                                //split line with space char to get words
                                var words = lineText.Split(' ');
                                //remove empty words
                                words.ToList().RemoveAll(word => string.IsNullOrEmpty(word.Trim()));
                                if (words.Any())
                                {
                                    //if still any words left.
                                    foreach (string word in words)
                                    {
                                        wordsService.AddWord(word);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                //logs for file
                TextLogger.WriteEventLog(filePath,ex);
            }
        }
       
        
    }
}
