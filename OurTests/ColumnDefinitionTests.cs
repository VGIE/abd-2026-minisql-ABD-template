using DbManager;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OurTests
{
    public class ColumnDefinitionsTests
    {
        //TODO DEADLINE 1A : Create your own tests for Table
        
        [Fact]
        public void TestConstructor()
        {
            ColumnDefinition columnString = new ColumnDefinition(ColumnDefinition.DataType.String, "Nombre");
            ColumnDefinition columnInt = new ColumnDefinition(ColumnDefinition.DataType.Int, "Numero");
            ColumnDefinition columnDouble = new ColumnDefinition(ColumnDefinition.DataType.Double, "Precio");

            Assert.Equal(ColumnDefinition.DataType.String, columnString.Type);
            Assert.Equal("Nombre", columnString.Name);

            Assert.Equal(ColumnDefinition.DataType.Int, columnString.Type);
            Assert.Equal("Numero", columnInt.Name);

            Assert.Equal(ColumnDefinition.DataType.Double, columnString.Type);
            Assert.Equal("Precio", columnDouble.Name);

        }

       
        [Fact]
        public void TestAsText()
        {
            ColumnDefinition columnString = new ColumnDefinition(ColumnDefinition.DataType.String, "Nombre");
            ColumnDefinition columnInt = new ColumnDefinition(ColumnDefinition.DataType.Int, "Numero");
            ColumnDefinition columnDouble = new ColumnDefinition(ColumnDefinition.DataType.Double, "Precio");

            string textString = columnString.AsText();
            string textInt = columnInt.AsText();
            string textDouble = columnDouble.AsText();

            Assert.Equal("Nombre->String", textString);
            Assert.Equal("Numero->Int", textInt);
            Assert.Equal("Precio->Double", textDouble);

        }

        [Fact]
        public void TestParse()
        {
            ColumnDefinition columnString = new ColumnDefinition(ColumnDefinition.DataType.String, "Nombre");
            ColumnDefinition columnInt = new ColumnDefinition(ColumnDefinition.DataType.Int, "Numero");
            ColumnDefinition columnDouble = new ColumnDefinition(ColumnDefinition.DataType.Double, "Precio");

            string textString = columnString.AsText();
            string textInt = columnInt.AsText();
            string textDouble = columnDouble.AsText();

            ColumnDefinition parseString = ColumnDefinition.Parse(textString);
            ColumnDefinition parseInt = ColumnDefinition.Parse(textInt);
            ColumnDefinition parseDouble = ColumnDefinition.Parse(textDouble);

            Assert.Equal(ColumnDefinition.DataType.String, parseString.Type);
            Assert.Equal("Nombre", parseString.Name);

            Assert.Equal(ColumnDefinition.DataType.Int, parseInt.Type);
            Assert.Equal("Numero", parseInt.Name);

            Assert.Equal(ColumnDefinition.DataType.Double, parseDouble.Type);
            Assert.Equal("Precio", parseDouble.Name);

        }

    }
}