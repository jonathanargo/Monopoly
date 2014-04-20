using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace Monopoly
{
    class BoardfileReader        
    {
        private String mBoardPath;
        private UI ui;

        public BoardfileReader(String boardPath)
        {
            mBoardPath = boardPath;
            ui = new UI();
        }//BoardfileReader

        public Board CreateBoard()
        {
            String line = "";
            String[] strValues;
            int[] intValues;
            StreamReader stmReader;
            Char delimitChar = ',';
            Board resultBoard;
            ui.UIDebug("Attempting to create board...");

            try{
                stmReader = new StreamReader(mBoardPath);
                resultBoard = new Board();
                ui.UIDebug("Board stream initalized!");
                for (int i = 1; i <= resultBoard.BoardSpaces.Length - 1; i++)
                {
                    line = stmReader.ReadLine();
                    strValues = line.Split(delimitChar);
                    intValues = new int[strValues.Length];

                    //create int array for int values such as rent, mortagage, etc
                    for (int j = 0; j <= strValues.Length - 1; j++)
                    {
                        try
                        {
                            intValues[j] = int.Parse(strValues[j]);
                        }//try
                        catch (FormatException ex) 
                        {
                            intValues[j] = 0;
                            ex.GetType();
                        }//catch
                    }//for

                    //ugly switch, need to revise in the future
                    switch (strValues[0])
                    {
                        case "Property":
                            Rent tempRent = new Rent(intValues[5], intValues[6], intValues[7], intValues[8], intValues[9], intValues[10]);
                            resultBoard.BoardSpaces[i] = new Tiles.Property(intValues[2], strValues[1], (PropertyColor)intValues[4], intValues[3], tempRent, intValues[11]);
                            break;
                        case "Railroad":
                            resultBoard.BoardSpaces[i] = new Tiles.Railroad(intValues[2], strValues[1]);
                            break;
                        case "Utility":
                            resultBoard.BoardSpaces[i] = new Tiles.Utility(intValues[2], strValues[1]);
                            break;
                        case "LuxuryTax":
                            resultBoard.BoardSpaces[i] = new Tiles.LuxuryTax(intValues[2], strValues[1]);
                            break;
                        case "IncomeTax":                            
                            resultBoard.BoardSpaces[i] = new Tiles.IncomeTax(intValues[2], strValues[1]);
                            break;
                        case "CommunityChest":
                            resultBoard.BoardSpaces[i] = new Tiles.CommunityChest(intValues[2], strValues[1]);
                            break;
                        case "Chance":
                            resultBoard.BoardSpaces[i] = new Tiles.Chance(intValues[2], strValues[1]);
                            break;
                        case "Go":
                            resultBoard.BoardSpaces[i] = new Tiles.Go(intValues[2], strValues[1]);
                            break;
                        case "GoToJail":
                            resultBoard.BoardSpaces[i] = new Tiles.GoToJail(intValues[2], strValues[1]);
                            break;
                        case "Jail":
                            resultBoard.BoardSpaces[i] = new Tiles.Jail(intValues[2], strValues[1]);
                            break;
                        case "FreeParking":
                            resultBoard.BoardSpaces[i] = new Tiles.FreeParking(intValues[2], strValues[1]);
                            break;
                        default:
                            ui.Error("The BoardReader was unable to determine space type!");
                            break;
                    }//switch

                }//for

                stmReader.Close();

            }//try (open streamreader)         

            catch (FileNotFoundException ex){
                ui.Error("Stream couldn't be found.", ex);
                return null;
            }//catch FileNotFound (streamreader)

            return resultBoard;

        }//CreateBoard

        
    }//class BoardfileReader
}



/*
Property
 * 0 type, 1 name, 2 position, 3 cost, 4 color, 5 rent1 ... 10 rentfinal, 10 mortgage val
*/