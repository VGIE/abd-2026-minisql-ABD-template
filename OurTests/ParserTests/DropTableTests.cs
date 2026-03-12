
using DbManager;

namespace OurTests
{
    public class DropTableTests
    {
        
        [Fact]
        public void TestDropQueryIncorrectCapitalization()
        {
            Database database = Database.CreateTestDatabase();
            Table table = database.TableByName(Table.TestTableName);

            DropTable query1= new DropTable(Table.TestTableName);
            string result= query1.Execute(database);
            Assert.Equal(Constants.DropTableSuccess, result);

            DropTable query = MiniSQLParser.Parse("DroP TablE Table") as DropTable;
            Assert.Null(query);

            query = MiniSQLParser.Parse("drop table Table") as DropTable;
            Assert.Null(query);
            
            query = MiniSQLParser.Parse("DROP TABLE table") as DropTable;
            Assert.NotNull(query);

            query = MiniSQLParser.Parse("DROP TABLE TABLE1") as DropTable;
            Assert.NotNull(query);

            query = MiniSQLParser.Parse("DROP TABLE Table1") as DropTable;
            Assert.NotNull(query);

           
        }
    }
}