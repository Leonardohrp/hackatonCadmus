using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cadmus.monster.src
{
    public class WriteFile
    {
        public const string INSERT = "Insert";
        public string WriteClass(string className, List<string> propertys)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("public class {0}", className).AppendLine();
            sb.AppendLine("{");
            sb.AppendFormat("   public Task {0}{1}()", INSERT, className).AppendLine();
            sb.AppendLine("     {");
            sb.AppendLine("         using (var db = new SqlConnection(ConnectionString))");
            sb.AppendLine("         {");
            sb.AppendFormat("             const string sql = @{0};", GenerateSQL(propertys, "INSERT INTO", className)).AppendLine();
            sb.AppendLine("             await db.ExecuteAsync(sql, new");
            sb.AppendLine("             {");
            sb.AppendFormat("{0}", GenerateObject(propertys, className));
            sb.AppendLine("             }, commandType: CommandType.Text);");
            sb.AppendLine("         }");
            sb.AppendLine("     }");
            sb.AppendLine("}");
            return sb.ToString();

        }

        private string GenerateColumns(List<string> propertys)
        {
            var columns = new StringBuilder();
            columns.Append(propertys.First());
            for (int i = 1; i < propertys.Count; i++)
            {
                columns.AppendFormat(", {0}", propertys[i]);
            };
            return columns.ToString();
        }

        private string GenerateValues(List<string> propertys)
        {
            var values = new StringBuilder();
            values.AppendFormat("@{0}", propertys.First());
            for(int i = 1; i < propertys.Count; i++)
            {
                values.AppendFormat(", @{0}", propertys[i]);
            };
            return values.ToString();
        }

        public string GenerateSQL(List<string> propertys, string command, string className)
        {
            var sql = new StringBuilder();
            var columns = GenerateColumns(propertys);
            var values = GenerateValues(propertys);
            sql.AppendFormat("{0} [{1}] ({2}) VALUES ({3})", command, className, columns, values);
            return sql.ToString();
        }

        private string GenerateObject(List<string> propertys, string className)
        {
            var property = new StringBuilder();
            foreach (string p in propertys)
            {
                property.AppendFormat("                   {0} " + "="+" {1}.{2},", p, className, p).AppendLine();
            };
            return property.ToString();
        }
    }
}
