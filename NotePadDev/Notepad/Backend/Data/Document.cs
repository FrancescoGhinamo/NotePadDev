using System;
using System.IO;
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
        /// <summary>
        /// Saves the document on a file
        /// </summary>
        /// <param name="path">Path of the file where to save the document</param>
        public void SaveToFile(string path)
        {
            //here I have to overwrite the file
            FileStream stream = File.Create(path);
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(this.Content);
            writer.Flush();
            writer.Close();
            stream.Close();
        }
        #endregion FileSavingMethods



    }
}
