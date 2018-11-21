using NotePadDev.Notepad.Backend.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePadDev
{
    public partial class NotePadDevForm : Form
    {
        #region Constants
        /// <summary>
        /// Title of the window
        /// </summary>
        private static string TITLE = "NotePadDev";

        /// <summary>
        /// Default file name
        /// </summary>
        private static string DEFAULT_FILE_NAME = "Untitled";
        #endregion Constants

        #region Fields
        /// <summary>
        /// Document being edited by the editor
        /// </summary>
        private Document doc;


        /// <summary>
        /// String containing the reference to the current file
        /// </summary>
        private string currentFile;

        /// <summary>
        /// Name of the file as the title of the window
        /// </summary>
        private string fileName;

        #endregion Fields

        #region Constructor
        /// <summary>
        /// Constructor for the form
        /// </summary>
        public NotePadDevForm()
        {
            doc = new Document();
            currentFile = null;
            DisplayFileTitle(DEFAULT_FILE_NAME);            
            InitializeComponent();
        }
        #endregion Constructor

        #region OutputMethods

        /// <summary>
        /// Updates the content of the text box with the content of the document
        /// </summary>
        public void UpdateDisplayedText()
        {
            txtText.Text = doc.Content;
        }

        /// <summary>
        /// Displays the title on the form
        /// </summary>
        /// <param name="file">Path of the file used to initialize the title</param>
        public void DisplayFileTitle(string file)
        {
            string _path = file;
            if (_path.Contains("\\"))
            {
                int _i = _path.LastIndexOf("\\") + 1;
                _path = _path.Substring(_i);
            }
            fileName = _path;
           
            this.Text = fileName + " - " + TITLE;
        }

        #endregion OutputMethods


        #region EventHandlers


        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (doc.Modified)
            {
                DialogResult confirmResult = MessageBox.Show("Save changes to " + fileName + "?", TITLE, MessageBoxButtons.YesNoCancel);
                switch (confirmResult)
                {
                    case DialogResult.Yes:
                        saveToolStripMenuItem_Click(sender, e);
                        break;

                    case DialogResult.No:
                        break;

                    case DialogResult.Cancel:
                        return;

                    default:
                        return;

                }
            }

            currentFile = null;
            DisplayFileTitle(DEFAULT_FILE_NAME);
            UpdateDisplayedText();
            doc = new Document();
        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.AddExtension = true;
            open.DefaultExt = "txt";
            if(open.ShowDialog() == DialogResult.OK)
            {
                currentFile = open.FileName;
                DisplayFileTitle(currentFile);
                doc = new Document(currentFile);
                UpdateDisplayedText();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(currentFile != null)
            {
                doc.SaveToFile(currentFile);
                doc.Modified = false;
            }
            else
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.AddExtension = true;
            saveDialog.DefaultExt = "txt";
            if(saveDialog.ShowDialog() == DialogResult.OK)
            {
                currentFile = saveDialog.FileName;
                DisplayFileTitle(currentFile);
                saveToolStripMenuItem_Click(sender, e);
            }
           
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(sender, e);            
            System.Environment.Exit(0);
        }

        private void txtText_TextChanged(object sender, EventArgs e)
        {
            doc.Content = txtText.Text;
            doc.Modified = true;
        }




        #endregion EventHandlers

       
    }
}