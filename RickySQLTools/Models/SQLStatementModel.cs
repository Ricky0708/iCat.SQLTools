using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickySQLTools.Models
{
    public class SQLStatementModel
    {
        public Sqlscript SqlScript { get; set; }
    }

    public class Sqlscript
    {
        public string Location { get; set; }
        public object Errors { get; set; }
        public Sqlbatch SqlBatch { get; set; }
    }

    public class Sqlbatch
    {
        public string Location { get; set; }
        public Sqlselectstatement SqlSelectStatement { get; set; }
        public Tokens Tokens { get; set; }
    }

    public class Sqlselectstatement
    {
        public string Location { get; set; }
        public Sqlselectspecification SqlSelectSpecification { get; set; }
    }

    public class Sqlselectspecification
    {
        public string Location { get; set; }
        public Sqlqueryspecification SqlQuerySpecification { get; set; }
    }

    public class Sqlqueryspecification
    {
        public string Location { get; set; }
        public Sqlselectclause SqlSelectClause { get; set; }
        public Sqlfromclause SqlFromClause { get; set; }
        public Sqlgroupbyclause SqlGroupByClause { get; set; }
    }

    public class Sqlselectclause
    {
        public string Location { get; set; }
        public string IsDistinct { get; set; }
        public Sqlselectscalarexpression[] SqlSelectScalarExpression { get; set; }
    }

    public class Sqlselectscalarexpression
    {
        public string Location { get; set; }
        public Sqlscalarrefexpression SqlScalarRefExpression { get; set; }
        public string Alias { get; set; }
        public Sqlidentifier1 SqlIdentifier { get; set; }
        public Sqlaggregatefunctioncallexpression SqlAggregateFunctionCallExpression { get; set; }
        public Sqlliteralexpression SqlLiteralExpression { get; set; }
        public Sqlcolumnrefexpression Sqlcolumnrefexpression { get; set; }
    }

    public class Sqlcolumnrefexpression
    {
        public string Location { get; set; }
        public string ColumnName { get; set; }
        public string MultipartIdentifier { get; set; }
        public Sqlobjectidentifier3 SqlObjectIdentifier { get; set; }
    }

    public class Sqlscalarrefexpression
    {
        public string Location { get; set; }
        public string ColumnOrPropertyName { get; set; }
        public string MultipartIdentifier { get; set; }
        public Sqlobjectidentifier SqlObjectIdentifier { get; set; }
    }

    public class Sqlobjectidentifier
    {
        public string Location { get; set; }
        public string SchemaName { get; set; }
        public string ObjectName { get; set; }
        public Sqlidentifier[] SqlIdentifier { get; set; }
    }

    public class Sqlidentifier
    {
        public string Location { get; set; }
        public string Value { get; set; }
    }

    public class Sqlidentifier1
    {
        public string Location { get; set; }
        public string Value { get; set; }
    }

    public class Sqlaggregatefunctioncallexpression
    {
        public string Location { get; set; }
        public string SetQuantifier { get; set; }
        public string FunctionName { get; set; }
        public string IsStar { get; set; }
        public string ArgCount { get; set; }
        public Sqlscalarrefexpression1 SqlScalarRefExpression { get; set; }
    }

    public class Sqlscalarrefexpression1
    {
        public string Location { get; set; }
        public string ColumnOrPropertyName { get; set; }
        public string MultipartIdentifier { get; set; }
        public Sqlobjectidentifier1 SqlObjectIdentifier { get; set; }
    }

    public class Sqlobjectidentifier1
    {
        public string Location { get; set; }
        public string SchemaName { get; set; }
        public string ObjectName { get; set; }
        public Sqlidentifier2[] SqlIdentifier { get; set; }
    }

    public class Sqlidentifier2
    {
        public string Location { get; set; }
        public string Value { get; set; }
    }

    public class Sqlliteralexpression
    {
        public string Location { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
    }

    public class Sqlfromclause
    {
        public string Location { get; set; }
        public Sqlqualifiedjointableexpression SqlQualifiedJoinTableExpression { get; set; }
        public Sqltablerefexpression SqlTableRefExpression { get; set; }

    }

    public class Sqlqualifiedjointableexpression
    {
        public string Location { get; set; }
        public string JoinOperator { get; set; }
        public List<Sqltablerefexpression> SqlTableRefExpression { get; set; }
        public Sqlconditionclause SqlConditionClause { get; set; }
    }

    public class Sqlconditionclause
    {
        public string Location { get; set; }
        public Sqlcomparisonbooleanexpression SqlComparisonBooleanExpression { get; set; }
    }

    public class Sqlcomparisonbooleanexpression
    {
        public string Location { get; set; }
        public string ComparisonOperator { get; set; }
        public Sqlscalarrefexpression2[] SqlScalarRefExpression { get; set; }
    }

    public class Sqlscalarrefexpression2
    {
        public string Location { get; set; }
        public string ColumnOrPropertyName { get; set; }
        public string MultipartIdentifier { get; set; }
        public Sqlobjectidentifier2 SqlObjectIdentifier { get; set; }
    }

    public class Sqlobjectidentifier2
    {
        public string Location { get; set; }
        public string SchemaName { get; set; }
        public string ObjectName { get; set; }
        public Sqlidentifier3[] SqlIdentifier { get; set; }
    }

    public class Sqlidentifier3
    {
        public string Location { get; set; }
        public string Value { get; set; }
    }

    public class Sqltablerefexpression
    {
        public string Location { get; set; }
        public string ObjectIdentifier { get; set; }
        public string Alias { get; set; }
        public Sqlobjectidentifier3 SqlObjectIdentifier { get; set; }
        public Sqlidentifier5 SqlIdentifier { get; set; }
    }

    public class Sqlobjectidentifier3
    {
        public string Location { get; set; }
        public string ObjectName { get; set; }
        public Sqlidentifier4 SqlIdentifier { get; set; }
    }

    public class Sqlidentifier4
    {
        public string Location { get; set; }
        public string Value { get; set; }
    }

    public class Sqlidentifier5
    {
        public string Location { get; set; }
        public string Value { get; set; }
    }

    public class Sqlgroupbyclause
    {
        public string Location { get; set; }
        public string HasAll { get; set; }
        public string Option { get; set; }
        public Sqlsimplegroupbyitem SqlSimpleGroupByItem { get; set; }
    }

    public class Sqlsimplegroupbyitem
    {
        public string Location { get; set; }
        public Sqlscalarrefexpression3 SqlScalarRefExpression { get; set; }
    }

    public class Sqlscalarrefexpression3
    {
        public string Location { get; set; }
        public string ColumnOrPropertyName { get; set; }
        public string MultipartIdentifier { get; set; }
        public Sqlobjectidentifier4 SqlObjectIdentifier { get; set; }
    }

    public class Sqlobjectidentifier4
    {
        public string Location { get; set; }
        public string SchemaName { get; set; }
        public string ObjectName { get; set; }
        public Sqlidentifier6[] SqlIdentifier { get; set; }
    }

    public class Sqlidentifier6
    {
        public string Location { get; set; }
        public string Value { get; set; }
    }

    public class Tokens
    {
        public Token[] Token { get; set; }
    }

    public class Token
    {
        public string location { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public string text { get; set; }
    }

}