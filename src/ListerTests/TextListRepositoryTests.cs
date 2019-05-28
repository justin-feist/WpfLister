using System.Linq;
using WpfLister;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfLister.Repository;

namespace ListerTests
{
    [TestClass]
    public class TextListRepositoryTests
    {
        [TestMethod]
        public void Get_Valid_Number_Of_List_Items()
        {
            var repository = new TextListRepository();
            var listItems = repository.GetListItems(5).Result;

            //The repository should ignore the blank lines, hence 5 items
            Assert.AreEqual(5, listItems.Count());
        }
    }
}
