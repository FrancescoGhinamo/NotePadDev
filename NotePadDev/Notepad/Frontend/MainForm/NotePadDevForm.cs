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
        #region Fields
        private Document doc;

        #endregion Fields

        #region Constructor
        /// <summary>
        /// Constructor for the form
        /// </summary>
        public NotePadDevForm()
        {
            doc = new Document();
            InitializeComponent();
        }
        #endregion Constructor

        #region Outputmethods

        /// <summary>
        /// Updates the content of the text box with the content of the document
        /// </summary>
        public void UpdateDisplayedText()
        {
            txtText.Text = doc.Content;
        }
        #endregion OutputMethods


        #region EventHandlers

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txtText_TextChanged(object sender, EventArgs e)
        {
            doc.Content = txtText.Text;
            doc.Modified = true;
        }

        #endregion EventHandlers
    }
}
