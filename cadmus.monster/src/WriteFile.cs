using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cadmus.monster.src
{
    public class WriteFile
    {
        public const string INSERT = "Insert";
        public const string UPDATE = "Update";
        public const string DELETE = "Delete";
        public const string SELECT = "Select";

        public string WriteClass(string className, List<string> propertys)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("public class {0}Repository", className).AppendLine();
            sb.AppendLine("{");
            sb.Append(GenerateInsert(className, propertys));
            sb.Append(GenerateUpdate(className, propertys));
            sb.Append(GenerateSelect(className, propertys));
            sb.Append(GenerateDelete(className));
            sb.AppendLine("}");
            return sb.ToString();
        }

        private string GenerateInsert(string className, List<string> propertys)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("   public async Task {0}{1}()", INSERT, className).AppendLine();
            sb.AppendLine("     {");
            sb.AppendLine("         using (var db = new SqlConnection(ConnectionString))");
            sb.AppendLine("         {");
            sb.AppendFormat("             const string sql = \"@{0}\";", GenerateSQLInsert(propertys, "INSERT INTO", className)).AppendLine();
            sb.AppendLine("             await db.ExecuteAsync(sql, new");
            sb.AppendLine("             {");
            sb.AppendFormat("{0}", GenerateObject(propertys, className));
            sb.AppendLine("             }, commandType: CommandType.Text);");
            sb.AppendLine("         }");
            sb.AppendLine("     }\n");
            return sb.ToString();
        }

        private string GenerateUpdate(string className, List<string> propertys)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("   public async Task {0}{1}()", UPDATE, className).AppendLine();
            sb.AppendLine("     {");
            sb.AppendLine("         using (var db = new SqlConnection(ConnectionString))");
            sb.AppendLine("         {");
            sb.AppendFormat("             const string sql = \"@{0}\";", GenerateSQLUpdate(propertys, UPDATE.ToUpper(), className)).AppendLine();
            sb.AppendLine("             await db.ExecuteAsync(sql, new");
            sb.AppendLine("             {");
            sb.AppendFormat("{0}", GenerateObject(propertys, className));
            sb.AppendLine("             }, commandType: CommandType.Text);");
            sb.AppendLine("         }");
            sb.AppendLine("     }\n");
            return sb.ToString();
        }

        private string GenerateSelect(string className, List<string> propertys)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("   public async Task<{0}> {1}{2}()", className, SELECT, className).AppendLine();
            sb.AppendLine("    {");
            sb.AppendFormat("         {0} ret;", className).AppendLine();
            sb.AppendLine("         using (var db = new SqlConnection(ConnectionString))");
            sb.AppendLine("         {");
            sb.AppendFormat("             const string sql = \"@{0}\";", GenerateSQLSelect(propertys, SELECT.ToUpper(), className)).AppendLine();
            sb.Append("             ret = await db.QueryFirstOrDefaultAsync<");
            sb.AppendFormat("{0}", className);
            sb.Append(">(sql, new { ");
            sb.Append("Id = id }, commandType: CommandType.Text);").AppendLine();
            sb.AppendLine("         }");
            sb.AppendLine("         return ret;");
            sb.AppendLine("    }\n");
            return sb.ToString();
        }

        private string GenerateDelete(string className)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("   public async Task {0}{1}({1} {2})", DELETE, className, className.ToLower()).AppendLine();
            sb.AppendLine("     {");
            sb.AppendLine("         using (var db = new SqlConnection(ConnectionString))");
            sb.AppendLine("         {");
            sb.AppendFormat("             const string sql = \"@{0} FROM [{1}] WHERE ID = @ID\";", DELETE.ToUpper(), className).AppendLine();
            sb.Append("               await db.ExecuteAsync(sql, new { ");
            sb.AppendFormat("{0}.ID ", className.ToLower());
            sb.Append(" }, commandType: CommandType.Text);").AppendLine();
            sb.AppendLine("         }");
            sb.AppendLine("     }\n");
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
            for (int i = 1; i < propertys.Count; i++)
            {
                values.AppendFormat(", @{0}", propertys[i]);
            };
            return values.ToString();
        }

        public string GenerateSQLInsert(List<string> propertys, string command, string className)
        {
            var sql = new StringBuilder();
            var columns = GenerateColumns(propertys);
            var values = GenerateValues(propertys);
            sql.AppendFormat("{0} [{1}] ({2}) VALUES ({3})", command, className, columns, values);
            return sql.ToString();
        }

        public string GenerateSQLUpdate(List<string> propertys, string command, string className)
        {
            var sql = new StringBuilder();
            var columns = GeneratesUpdateColumns(propertys);
            sql.AppendFormat("{0} [{1}] SET {2}", command, className, columns);
            return sql.ToString();
        }

        public string GenerateSQLSelect(List<string> propertys, string command, string className)
        {
            var sql = new StringBuilder();
            var columns = GenerateColumns(propertys);
            sql.AppendFormat("{0} TOP 1 {1} FROM {2} WIHT (NOLOCK) WHERE ID = @ID", command, columns, className);
            return sql.ToString();
        }

        private string GeneratesUpdateColumns(List<string> propertys)
        {
            var columns = new StringBuilder();
            columns.AppendFormat("{0} " + "=" + " @{1}", propertys.First(), propertys.First());
            for (int i = 1; i < propertys.Count; i++)
            {
                columns.AppendFormat(", {0} " + "=" + " @{1}", propertys[i], propertys[i]);
            };
            return columns.ToString();
        }

        private string GenerateObject(List<string> propertys, string className)
        {
            var property = new StringBuilder();
            foreach (string p in propertys)
            {
                property.AppendFormat("                   {0} " + "=" + " {1}.{2},", p, className, p).AppendLine();
            };
            return property.ToString();
        }
    }
}
