using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotePadDev.Notepad.Backend.Data
{
    /// <summary>
    /// Class to represent a text document
    /// </summary>
    public class Document
    {

        #region Fields
        /// <summary>
        /// Contente of the text docuement
        /// </summary>
        public string Content;

        /// <summary>
        /// True if the document was modified after the last saving
        /// </summary>
        public Boolean Modified;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Creates a new instance of an empty document, not modified
        /// </summary>
        public Document()
        {
            Modified = false;
        }

        /// <summary>
        /// Creates a new instance of a document from a given text, the document results not modified
        /// </summary>
        /// <param name="text">Text from which build the Document</param>
        public Document(string text)
        {
            Content = text;
            Modified = false;
        }
        #endregion Construtor


        #region FileSavingMethods
        
        #endregion FileSavingMethods



    }
}
