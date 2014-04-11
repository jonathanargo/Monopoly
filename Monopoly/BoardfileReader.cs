using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Monopoly
{
    class BoardfileReader        
    {
        private String mBoardFile;

        public BoardfileReader(String boardFile)
        {
            mBoardFile = boardFile;    
        }//BoardfileReader

        public Board CreateBoard()
        {

            return null;
        }

        public String TestRead()
        {
            string result;
            try
            {
                StreamReader stream = new StreamReader(mBoardFile);
                result = stream.ReadToEnd();
            }
            catch (Exception ex)
            {
                result = "ERROR: " + ex.Message;
            }
            return result;
        }
        
    }//class BoardfileReader
}
