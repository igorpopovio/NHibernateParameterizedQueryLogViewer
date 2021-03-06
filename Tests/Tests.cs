using NHibernateParameterizedQueryLogViewer;

using NUnit.Framework;

using System.Text;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void CanEmbedParametersInQuery()
        {
            var model = new MainViewModel();
            var sb = new StringBuilder();
            sb.Append("SELECT this_.Id as y0_ FROM Person this_ WHERE Id = @p1;");
            sb.Append("@p1 = 1 [Type: Int32 (0:0:0)]");

            model.Input = sb.ToString();

            Assert.That(model.Output, Is.EqualTo("SELECT this_.Id as y0_ FROM Person this_ WHERE Id = 1"));
        }

        [Test]
        public void EmbedsParametersInReverseOrder()
        {
            var model = new MainViewModel();
            var sb = new StringBuilder();
            sb.Append("SELECT this_.Id as y0_ FROM Person this_ WHERE Id IN (@p1, @p1234);");
            sb.Append("@p1 = 1 [Type: Int32 (0:0:0)], @p1234 = 2 [Type: Int32 (0:0:0)]");

            model.Input = sb.ToString();

            Assert.That(model.Output, Is.EqualTo("SELECT this_.Id as y0_ FROM Person this_ WHERE Id IN (1, 2)"));
        }
    }
}
