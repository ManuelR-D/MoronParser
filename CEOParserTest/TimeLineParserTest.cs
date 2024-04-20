using CEOParser.Parser;
using CEOParser.Model;
using HtmlAgilityPack;
namespace CEOParserTest
{
    [TestClass]
    public class TimeLineParserTest
    {
        [TestMethod]
        public void ParseTimeline()
        {
            int expectedCount1 = 1;
            int expectedCount2 = 4;
            string fileName = "TimeLine.html";
            string filePath = Path.Combine("../../../Resources", fileName);

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load(filePath);

            TimelineParser timelineParser = new TimelineParser();
            List<Timeline> timeline = timelineParser.Parse(htmlDocument);

            int actualCount1 = timeline[0].Items.Count;
            int actualCount2 = timeline[1].Items.Count;


            Assert.AreEqual(actualCount1, expectedCount1);
            Assert.AreEqual(actualCount2, expectedCount2);
        }
    }
}