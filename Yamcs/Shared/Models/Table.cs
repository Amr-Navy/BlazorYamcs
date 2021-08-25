using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yamcs.Shared.Models
{
    public class ListTableRespnse
    {
        public Table[] Tables { set; get; }
    }
    public class Table
    {
    }
    public class SubscribeStreamStatisticsRequest
    {
        public int Instance { get; set; }

    }
    public class StreamEvent
    {
        public CreatedType Type { get; set; }
        public string Name { get; set; }
        public string DataCount { get; set; }

    }
    public enum CreatedType
    {
        CREATED,
        DELETED,
        UPDATED,

    }
    public  class StreamData
    {
        public string Stream { get; set; }
        public  ColumnData Column { set; get; }
    }
    public class ColumnData
    {

        public string Name { get; set; }
        public Value Value { set; get; }
    }
    public class Value
    {
        public ValueType Type { set; get; }
        public int MyProperty { get; set; }
        public int FloatValue { get; set; }
        public int DoubleValue { get; set; }
        public int Sint32Value { get; set; }
        public int Uint32Value { get; set; }
        public string BinaryValue { get; set; }
        public string StringValue { get; set; }
        public string TimestampValue { get; set; }
        public int Uint64Value { get; set; }
        public int Sint64Value { get; set; }
        public int BooleanValue { get; set; }
        public AggregateValue aggregateValue { get; set; }
        public Value[] arrayValue { get; set; }

    }
    public class AggregateValue
    {

        public string Name { get; set; }
        public Value Value { get; set; }

    }
    public enum ValueType
    {
        FLOAT ,
        DOUBLE ,
        UINT32 ,
        SINT32 ,
        BINARY ,
        STRING ,
        TIMESTAMP,
        UINT64 ,
        SINT64,
        BOOLEAN,
        AGGREGATE ,
        ARRAY ,

        // Enumerated values have both an integer (sint64Value) and a string representation
        ENUMERATED ,
        NONE ,
    }
}
