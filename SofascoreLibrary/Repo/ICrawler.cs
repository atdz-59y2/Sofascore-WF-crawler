using SofascoreLibrary.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofascoreLibrary.Repo
{
    public interface ICrawler
    {
        
        public void open(string link);
        public void close();
        public Team getTeamInfo();
        public List<Competition> getParticipatedLeague();
        public List<Player> getFullInfo();
        public void saveToFile(Team t, List<Competition> list1, List<Player> list2, string directoryPath, string fileName);
    }
}
