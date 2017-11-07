using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace List_of_Game_Objects
{
    public class GameFactory
    {
        XmlSerializer serial;
        StreamWriter sw;
        List<Game> ListOfGames;
        const string FilePath = @"..\..\Matches.xml";

        public void CreateGameList()
        {
            ListOfGames = new List<Game>();
            Game G = new Game("Locos", "Mages", 14, 36);
            ListOfGames.Add(G);
            G = new Game("Fire", "Hielo", 67, 44);
            ListOfGames.Add(G);
            G = new Game("Adios", "Olas", 1, 132);
            ListOfGames.Add(G);
            G = new Game("Ubuntu", "MACS", 88, 99);
            ListOfGames.Add(G);
            G = new Game("Kawas", "Kuurus", 8, 4);
            ListOfGames.Add(G);
            G = new Game("Woodland", "Buzzers", 444, 1000);
            ListOfGames.Add(G);


            serial = new XmlSerializer(ListOfGames.GetType());
            sw = new StreamWriter(FilePath);
            serial.Serialize(sw, ListOfGames);
            sw.Close();
        }

        public List<Game> DeserializeGameList(out string ResultMessage)
        {
            try
            {
                ListOfGames = new List<Game>();
                StreamReader sr = new StreamReader(FilePath);
                serial = new XmlSerializer(ListOfGames.GetType());
                ListOfGames = (List<Game>)serial.Deserialize(sr);
                sr.Close();
                ResultMessage = "yeah it worked!";
                return ListOfGames;

                //foreach (Game G in ListOfGames)
                //{
                //    if (MatchupGoesHere.Text == "")
                //    {
                //        MatchupGoesHere.Text = (G.ToString());
                //    }
                //    else
                //    {
                //        MatchupGoesHere.Text = MatchupGoesHere.Text + "\n" + (G.ToString());
                //    }
                //}
            }
            catch (Exception e)
            {
                ResultMessage = "Exception has been Thrown!"+e.Message;
                return null;
            }
        }
    }
}
