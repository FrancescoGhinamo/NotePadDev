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

            NewDocument();
        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDocument();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDocument();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void NotePadDevForm_Load(object sender, EventArgs e)
        {

        }

        private void NotePadDevForm_Closing(object sender, EventArgs e)
        {
            Exit();
        }



        private void txtText_TextChanged(object sender, EventArgs e)
        {
            doc.Content = txtText.Text;
            doc.Modified = true;
        }


        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtText.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtText.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtText.Paste();
        }

        #endregion EventHandlers

        #region MainMethods

        /// <summary>
        /// Prepares the notepad for a new document
        /// </summary>
        /// <returns>Result of the dialog displayed in case of a non-saved file</returns>
        public DialogResult NewDocument()
        {
            DialogResult confirmResult = DialogResult.Yes;
            if (doc.Modified)
            {
                confirmResult = MessageBox.Show("Save changes to " + fileName + "?", TITLE, MessageBoxButtons.YesNoCancel);
                switch (confirmResult)
                {
                    case DialogResult.Yes:
                        SaveDocument();
                        break;

                    case DialogResult.No:
                        break;

                    case DialogResult.Cancel:
                        return confirmResult;

                    default:
                        return confirmResult;

                }
            }

            currentFile = null;
            DisplayFileTitle(DEFAULT_FILE_NAME);
            UpdateDisplayedText();
            doc = new Document();
            return confirmResult;

        }

        /// <summary>
        /// Opens a new text document
        /// </summary>
        public void OpenDocument()
        {
            OpenFileDialog open = new OpenFileDialog
            {
                AddExtension = true,
                DefaultExt = "txt"
            };

            if (open.ShowDialog() == DialogResult.OK)
            {
                currentFile = open.FileName;
                DisplayFileTitle(currentFile);
                doc = new Document(currentFile);
                UpdateDisplayedText();
            }
        }

        /// <summary>
        /// Saves the document to the currentFile. I there's no current the method <see cref="SaveAs"/> is called
        /// </summary>
        public void SaveDocument()
        {
            if (currentFile != null)
            {
                doc.SaveToFile(currentFile);
                doc.Modified = false;
            }
            else
            {
                SaveAs();
            }
        }

        /// <summary>
        /// Saves the document to a file, the user will be prompted to choose the file
        /// </summary>
        public void SaveAs()
        {
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                AddExtension = true,
                DefaultExt = "txt"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                currentFile = saveDialog.FileName;
                DisplayFileTitle(currentFile);
                SaveDocument();
            }
        }

        /// <summary>
        /// Exits the program. If the file is not saved, displays a confirmaion dialog
        /// </summary>
        public void Exit()
        {
            if(NewDocument() != DialogResult.Cancel)
            {
                Environment.Exit(0);
            }
        }



        #endregion MainMethods

        
    }
}