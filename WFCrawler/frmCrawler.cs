using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SofascoreLibrary.Object;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFCrawler
{
    public partial class frmCrawler : Form
    {
        public frmCrawler()
        {
            InitializeComponent();
        }
        private static readonly int delayInMiliseconds = 500;
        private static WebDriver? driver;

        private void btnCrawl_Click(object sender, EventArgs e)
        {
            string teamLink = txtTeamLink.Text;
            if (!teamLink.Contains("https://www.sofascore.com/team/football/") || teamLink.Length == 0)
            {
                MessageBox.Show("Invalid team link or null string detected!");
            }
            else
            {
                open(teamLink);
                Team t = getTeamInfo();
                List<Competition> comps = getParticipatedLeague();
                List<Player> players = getFullInfo();
                string storeDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
                string fileName = t.name + ".txt";
                saveToFile(t, comps, players, storeDirectory, fileName);
                close();
                MessageBox.Show("Done!");
            }
        }
        public void open(string teamLink)
        {

            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--incoginto");
            //options.AddArguments("proxy-server=https://"+proxy); //use when your network is fast enough or it'll return proxy error
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(teamLink);
            Thread.Sleep(delayInMiliseconds);
            string pageTitle = driver.Title;
            if (pageTitle.Contains("Access denied", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Cloudflare detected! This program will be stopped! Open VPN and try again.");
                Environment.Exit(1);
            }
        }

        public void close()
        {
            driver.Quit();
        }
        public Team getTeamInfo()
        {
            Team t = new Team();
            string teamName = driver.FindElement(By.XPath("(//h2[@class='sc-bqWxrE eiCVUy'])")).GetAttribute("textContent");
            string nation = driver.FindElement(By.XPath("(//span[@class='sc-bqWxrE gaVDXZ'])")).GetAttribute("textContent");
            string stadium = driver.FindElement(By.XPath("(//div[@class='sc-hLBbgP sc-eDvSVe hfbzDf bbcOkn'])[4]")).GetAttribute("textContent").Remove(0, 7);
            t = new Team(teamName, nation, stadium);
            return t;
        }
        public List<Competition> getParticipatedLeague()
        {
            List<Competition> list = new List<Competition>();
            ReadOnlyCollection<IWebElement> webElements = driver.FindElements(By.XPath("(//div[@class='sc-bqWxrE fIDBxA'])"));
            List<WebElement> webElementsList = webElements.Cast<WebElement>().ToList();
            for (int i = 0; i < webElementsList.Count / 2; i++)
            {
                string competitionName = webElementsList[i].GetAttribute("textContent");
                Competition competition = new Competition(competitionName);
                list.Add(competition);
            }


            return list;
        }
        public List<Player> getFullInfo()
        {
            ReadOnlyCollection<IWebElement> list = driver.FindElements(By.XPath("(//div[@class='sc-hLBbgP kIfRA'])"));
            List<WebElement> webElementsList = list.Cast<WebElement>().ToList();
            ReadOnlyCollection<IWebElement> linkList = driver.FindElements(By.XPath("(//div[@class='sc-hLBbgP kIfRA']//a)"));
            List<WebElement> webElementsLinkList = linkList.Cast<WebElement>().ToList();
            List<Player> playerList = new List<Player>();
            int countNullKitNumber = 0;
            int index = 0;
            foreach (WebElement webElement in webElementsList)
            {
                string result = webElement.GetAttribute("textContent");
                string position = result.Substring(result.Length - 4, 1);
                string nationality = result.Substring(result.Length - 3, 3);
                string fullName = "";
                string kitNumber = "";
                int check = 0;

                try
                {
                    check = Int32.Parse(result.Substring(0, 2));
                    kitNumber = check.ToString();
                    fullName = result.Substring(2, result.Length - 6);
                }
                catch (Exception e)
                {
                    try
                    {
                        check = Int32.Parse(result.Substring(0, 1));
                        kitNumber = check.ToString();
                        fullName = result.Substring(1, result.Length - 5);
                    }
                    catch (Exception ex)
                    {
                        kitNumber = "Null";
                        fullName = result.Substring(0, result.Length - 4);
                        countNullKitNumber++;
                    }
                }
                Player p = new Player(kitNumber, fullName, position, nationality, webElementsLinkList[index].GetAttribute("href"));
                playerList.Add(p);
                index++;
            }

            return playerList;
        }
        public void saveToFile(Team t, List<Competition> competitions, List<Player> players, string directoryPath, string fileName)
        {
            string filePath = Path.Combine(directoryPath, fileName);
            string directory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);

            }
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                streamWriter.WriteLine(t);
                foreach (Competition competition in competitions)
                {
                    streamWriter.WriteLine(competition);
                }
                foreach (Player p in players)
                {
                    streamWriter.WriteLine(p);
                }
            }
        }

    }
}