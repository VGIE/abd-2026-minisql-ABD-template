using DbManager;

namespace OurTests
{
    public class ConditionTests
    {
        //TODO DEADLINE 1A : Create your own tests for Condition

        [Fact]
        public void TestIsTrueString()
        {
            Condition condIg = new Condition("Name", "=", "Rodolfo");
            Assert.True(condIg.IsTrue("Rodolfo", ColumnDefinition.DataType.String));
            Assert.False(condIg.IsTrue("Maider", ColumnDefinition.DataType.String));

            Condition condMa = new Condition("Name", ">", "Abba");
            Assert.True(condMa.IsTrue("Zappa", ColumnDefinition.DataType.String));
            Assert.False(condMa.IsTrue("Abba", ColumnDefinition.DataType.String));

            Condition condMe = new Condition("Name", "<", "Zappa");
            Assert.True(condMe.IsTrue("Abba", ColumnDefinition.DataType.String));
            Assert.False(condMe.IsTrue("Zappa", ColumnDefinition.DataType.String));
        }

        [Fact]
        public void TestIsTrueInt()
        {
            Condition condIg = new Condition("Age", "=", "25");
            Assert.True(condIg.IsTrue("25", ColumnDefinition.DataType.Int));
            Assert.False(condIg.IsTrue("30", ColumnDefinition.DataType.Int));

            Condition condMa = new Condition("Age", ">", "9");
            Assert.True(condMa.IsTrue("10", ColumnDefinition.DataType.Int));
            Assert.False(condMa.IsTrue("5", ColumnDefinition.DataType.Int));

            Condition condMe = new Condition("Age", "<", "100");
            Assert.True(condMe.IsTrue("99", ColumnDefinition.DataType.Int));
            Assert.False(condMe.IsTrue("110", ColumnDefinition.DataType.Int));
        }

        [Fact]
        public void TestIsTrueDouble()
        {
            Condition condIg = new Condition("Price", "=", "10.5");
            Assert.True(condIg.IsTrue("10.5", ColumnDefinition.DataType.Double));
            Assert.False(condIg.IsTrue("10.5000001", ColumnDefinition.DataType.Double));

            Condition condMa = new Condition("Price", ">", "10.5");
            Assert.True(condMa.IsTrue("10.5000001", ColumnDefinition.DataType.Double));
            Assert.False(condMa.IsTrue("10.5", ColumnDefinition.DataType.Double));

            Condition condMe = new Condition("Price", "<", "10.5");

            Assert.True(condMe.IsTrue("10.49999", ColumnDefinition.DataType.Double));
            Assert.False(condMe.IsTrue("10.5000001", ColumnDefinition.DataType.Double));

        }

        [Fact]
        public void TestIsTrueNull()
        {
            Condition cond1 = new Condition("Name", "=", "");
            Assert.True(cond1.IsTrue(null, ColumnDefinition.DataType.String));

            Condition cond2 = new Condition("Name", "=", null);
            Assert.True(cond2.IsTrue("", ColumnDefinition.DataType.String));
        }

    }
}