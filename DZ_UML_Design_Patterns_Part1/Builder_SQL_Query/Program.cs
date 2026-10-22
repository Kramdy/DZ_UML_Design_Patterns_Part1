using System;
using System.Collections.Generic;

namespace BuilderSQLQuery
{
    internal class SqlQuery
    {
        public string Table { get; set; }
        public List<string> Columns { get; set; } = new List<string>();
        public List<string> WhereConditions { get; set; } = new List<string>();
        public string OrderBy { get; set; }
    }
    internal class SqlQueryBuilder
    {
        private SqlQuery query = new SqlQuery();
        public SqlQueryBuilder SetTable(string table) { query.Table = table; return this; }
        public SqlQueryBuilder AddColumn(string column) { query.Columns.Add(column); return this; }
        public SqlQueryBuilder AddWhereCondition(string condition) { query.WhereConditions.Add(condition); return this; }
        public SqlQueryBuilder SetOrderBy(string orderBy) { query.OrderBy = orderBy; return this; }
        public string Build()
        {
            string columns = query.Columns.Count == 0 ? "*" : string.Join(", ", query.Columns);
            string result = "SELECT " + columns + " FROM " + query.Table;
            if (query.WhereConditions.Count > 0) result += " WHERE " + string.Join(" AND ", query.WhereConditions);
            if (!string.IsNullOrEmpty(query.OrderBy)) result += " ORDER BY " + query.OrderBy;
            return result + ";";
        }
    }
    internal class Program
    {
        private static void Main()
        {
            // Задание 3. Создайте SqlQuery: Table, Columns, WhereConditions, OrderBy.
            // Создайте SqlQueryBuilder с SetTable, AddColumn, AddWhereCondition,
            // SetOrderBy и Build для пошагового создания SQL-запроса.
            SqlQueryBuilder builder = new SqlQueryBuilder();
            string query = builder.SetTable("Employees").AddColumn("Name").AddColumn("Position").AddWhereCondition("Salary > 50000").SetOrderBy("Name ASC").Build();
            Console.WriteLine(query);
            Console.ReadKey();
        }
    }
}
