﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Yamcs.Shared.Models
{
    public class GlobalAlarmStatus
    {
        public int unacknowledgedCount { set; get; }
        public bool unacknowledgedActive { set; get; }
        public int acknowledgedCount { set; get; }
        public bool acknowledgedActive { set; get; }
        public int shelvedCount { set; get; }
        public bool shelvedActive { set; get; }
    }

    public class SubscribeGlobalAlarmStatusRequest
    {
        public string instance { set; get; }
        public string processor { set; get; }
    }

    public class SubscribeAlarmsRequest
    {
        public string instance { set; get; }
        public string processor { set; get; }

       
    }
    public class ListAlarmsResponse
    {
        public AlarmData[] alarms { set; get; }
    }
    // Summary of an alarm applicable for Parameter or Event (possibly
    // other in the future) alarms.
    // Contains detailed information on the value occurrence that initially
    // triggered the alarm, the most severe value since it originally triggered,
    // and the latest value at the time of your request
    public class AlarmData
    {
        // Distinguisher between multiple alarms for the same id
        public int seqNum { set; get; }
        public AlarmType type { set; get; }
        public AlarmNotificationType notificationType { set; get; }
        // For parameter alarms, this is the id of the parameters
        // For event alarms
        // - the id.namespace is /yamcs/event/<EVENT_SOURCE>, unless
        // EVENT_SOURCE starts with a "/" in which case the namespace
        // is just the <EVENT_SOURCE>
        // - the id.name is the <EVENT_TYPE>
        public NamedObjectId id { set; get; }
        
        public string triggerTime { set; get; } // RFC 3339
        // Number of times the object was in alarm state
        
        public int violations { set; get; }
        // Number of samples received for the object
        public int count { set; get; }
        public AcknowledgeInfo acknowledgeInfo { set; get; }
        public ShelveInfo shelveInfo { set; get; }
        public ClearInfo clearInfo { set; get; }
        public AlarmSeverity severity { set; get; }
        // Whether the alarm will stay triggered even when the process is OK
        public bool latching { set; get; }
        // if the process that generated the alarm is ok (i.e. parameter is within limits)
        public bool processOK { set; get; }
        // triggered is same with processOK except when the alarm is latching
        public bool triggered { set; get; }
        // if the operator has acknowledged the alarm
        public bool acknowledged { set; get; }

        public ParameterAlarmData parameterDetail { set; get; }
        public EventAlarmData eventDetail { set; get; }
    }

    public class ParameterAlarmData
    {
       public ParameterValue triggerValue { set; get; }
        public ParameterValue  mostSevereValue { set; get; }
        public ParameterValue  currentValue { set; get; }
        public PParameterInfo parameter { set; get; }
    }
    public class PParameterInfo
    {
        public string name { set; get; }
        public string qualifiedName { set; get; }
        public string shortDescription { set; get; }
        public string longDescription { set; get; }
        public NamedObjectId[] alias { set; get; }
        public ParameterTypeInfo type { set; get; }
        public DataSourceType dataSource { set; get; }
        public UsedByInfo usedBy { set; get; }
        //Dictionary<string, AncillaryDataInfo>  ancillaryData { set; get; }
    

// Operations that return aggregate members or array entries
// may use this field to indicate the path within the parameter.
public string[]  path { set; get; } 
}
    public class DataSourceType
    {
        public const string TELEMETERED = "TELEMETERED";
        public const string DERIVED = "DERIVED";
        public const string CONSTANT = "CONSTANT";
        public const string LOCAL = "LOCAL";
        public const string SYSTEM = "SYSTEM";
        public const string COMMAND = "COMMAND";
        public const string COMMAND_HISTORY = "COMMAND_HISTORY";
        public const string EXTERNAL1 = "EXTERNAL1";
        public const string EXTERNAL2 = "EXTERNAL2";
        public const string EXTERNAL3 = "EXTERNAL3";
    }
    public class ParameterTypeInfo
    {
        public string engType { set; get; }
        public DataEncodingInfo dataEncoding { set; get; }
        public UnitInfo[]  unitSet { set; get; }
        public AlarmInfo defaultAlarm { set; get; }
        public EnumValue[] enumValue { set; get; }
        public AbsoluteTimeInfo absoluteTimeInfo { set; get; }
        public ContextAlarmInfo[] contextAlarm { set; get; }
        public MemberInfo[] member { set; get; }
        public ArrayInfo arrayInfo { set; get; }
      //  public Dictionary<string, AncillaryDataInfo> publicancillaryData { set; get; }
    }
    public class DataEncodingInfo
    {
        public ValueType type { set; get; }
         public bool littleEndian { set; get; }
        public int sizeInBits { set; get; }
        public string encoding { set; get; }
        public CalibratorInfo defaultCalibrator { set; get; }
        public ContextCalibratorInfo[] contextCalibrator { set; get; }



    }
    public class CalibratorInfo
    {
       public PolynomialCalibratorInfo polynomialCalibrator { set; get; }
        public SplineCalibratorInfo splineCalibrator { set; get; }
        public JavaExpressionCalibratorInfo javaExpressionCalibrator { set; get; }
        public ValueType type { set; get; } 
    }
    public class PolynomialCalibratorInfo
    {
        public double[] coefficient { set; get; }
    }
    public class SplineCalibratorInfo
    {
       public SplinePointInfo[]  point { set; get; }
}
    public class SplinePointInfo
    {
      public int  raw { set; get; }
      public int calibrated { set; get; }
    }
    public class JavaExpressionCalibratorInfo
    {
        string formula { set; get; }
}
    public class ContextCalibratorInfo
    {
        public ComparisonInfo[] comparison { set; get; }
       public  CalibratorInfo calibrator { set; get; }
        // This can be used in UpdateParameterRequest to pass a context
        // that is parsed on the server, according to the rules in the
        // excel spreadsheet. Either this or a comparison has to be
        // used (not both at the same time)
       public string context { set; get; }
    }

    public class ArgumentInfo
    {
        public string name { set; get; }
        public string description { set; get; }
        //optional string type = 3;
        public string initialValue { set; get; }
        // repeated UnitInfo unitSet = 5;
        public ArgumentTypeInfo type { set; get; }
    }
    public class ArgumentTypeInfo
    {
        public string engType { set; get; }
        DataEncodingInfo dataEncoding { set; get; }
        UnitInfo[] unitSet { set; get; }
        EnumValue[] enumValue { set; get; }
        // Minimum value (only used by integer and float arguments)
        public int rangeMin { set; get; }
        // Maximum value (only used by integer and float arguments)
        public int rangeMax { set; get; }
        // Member information (only used by aggregate arguments)
        public ArgumentMemberInfo[] member { set; get; }
        // String representation of a boolean zero (only used by boolean arguments)
        public string zeroStringValue { set; get; }
        // String representation of a boolean one (only used by boolean arguments)
        public string oneStringValue { set; get; }
        // Minimum character count (only used by string arguments)
        public int minChars { set; get; }
        // Maximum character count (only used by string arguments)
        public int maxChars { set; get; }
    }
        public class ArgumentMemberInfo
    {
        public string  name { set; get; }
        public string shortDescription { set; get; }
        public string longDescription { set; get; }
        public NamedObjectId[]  alias { set; get; }
        public ArgumentTypeInfo type { set; get; }
    }


//    public class AbsoluteTimeInfo
//    {
//      public string  initialValue { set; get; }
//   public int  scaleParameterInfo { set; get; }
//        public int offset { set; get; }
//        public ParameterInfo offsetFrom  { set; get; }
//    public string epoch { set; get; }
//}
    public class ParameterValue
    {
        public NamedObjectId id { set; get; }
        public Value rawValue { set; get; }
        public Value engValue { set; get; }
        public string acquisitionTime { set; get; } // RFC 3339
        public string generationTime { set; get; }// RFC 3339
        public AcquisitionStatus acquisitionStatus { set; get; }
        //this field has been originally created for compatibility with Airbus CGS/CD-
        //˓→MCS system
        //when it was set to false, then the acquisitionStatus was also set to INVALID;
        //it has been therefore removed from yamcs
        public bool processingStatus { set; get; }
        public MonitoringResult monitoringResult { set; get; }
        public RangeCondition rangeCondition { set; get; }
        // same as the Timestamps above
        public string acquisitionTimeUTC { set; get; }
        public string generationTimeUTC { set; get; }
        // Context-dependent ranges
        public AlarmRange[] alarmRange { set; get; }
        // How long (in milliseconds) this parameter value is valid
        // Note that there is an option when subscribing to parameters to get
        // updated when the parameter values expire.
        public string expireMillis { set; get; }
        // String decimal
        // When transferring parameters over WebSocket, this value might be used
        // instead of the id above in order to reduce the bandwidth.
        // Note that the id <-> numericId assignment is only valid in the context
        // of a single WebSocket connection.

        public int numericId { set; get; }
            }

  
    public class EventAlarmData
    {
        public Evvent triggerEvent { set; get; }
        public Evvent mostSevereEvent { set; get; }
        public Evvent currentEvent { set; get; }
    }

    public class AcknowledgeInfo
    {
        public string acknowledgedBy { set; get; }
        public string acknowledgeMessage { set; get; }
        public string acknowledgeTime { set; get; }
    }

    public class ShelveInfo
    {
        public string shelvedBy { set; get; }
        public string shelveMessage { set; get; }
        public string shelveTime { set; get; }
        public string shelveExpiration { set; get; }
    }

    public class ClearInfo
    {
        public string clearedBy { set; get; }
        public string clearTime { set; get; }
        public string clearMessage { set; get; }
    }

    public class GetAlarmsOptions
    {
        public string start { set; get; }
        public string stop { set; get; }
        public bool detail { set; get; }
        public int pos { set; get; }
        public int limit { set; get; }
       public order order { set; get; }
}
    public enum order
    {
       asc ,desc
    }
    //public class EditAlarmOptions
    //{
    //    public state state { set; get; }
        
    //    public string comment { set; get; }
    //    public int shelveDuration { set; get; }
        
    //}
    public  class AlarmType
    {
        public  const string PARAMETER = "PARAMETER";
        public  const string EVENT = "EVENT";
    }

    public class AlarmSeverity
    {
        public const string WATCH = "WATCH";
      public const string WARNING = "WARNING";
       public const string DISTRESS = "DISTRESS";
       public const string CRITICAL = "CRITICAL";
       public const string SEVERE = "SEVERE";
    }

    public class AlarmNotificationType
    {
        public const string ACTIVE = "ACTIVE";
        public const string TRIGGERED = "TRIGGERED";
        public const string SEVERITY_INCREASED = "SEVERITY_INCREASED";
        public const string VALUE_UPDATED = "VALUE_UPDATED";
       public const string ACKNOWLEDGED = "ACKNOWLEDGED";
        public const string CLEARED = "CLEARED";
       public const string RTN = "RTN";
       public const string SHELVED = "SHELVED";
       public const string UNSHELVED = "UNSHELVED";
        public const string RESET = "RESET";
    }

    public class ParameterRawType
    {
        public const string FLOAT = "FLOAT";
        public const string DOUBLE = "DOUBLE";
        public const string UINT32 = "UINT32";
        public const string SINT32 = "SINT32";
        public const string BINARY = "BINARY";
        public const string STRING = "STRING";
        public const string TIMESTAMP = "TIMESTAMP";
        public const string UINT64 = "UINT64";
        public const string SINT64 = "SINT64";
        public const string BOOLEAN = "BOOLEAN";
        public const string AGGREGATE = "AGGREGATE";
        public const string ARRAY = "ARRAY";

        // Enumerated values have both an integer (sint64Value) and a string representation
        public const string ENUMERATED = "ENUMERATED";
        public const string NONE = "NONE";
    }
    public class AcquisitionStatus
    {
        public const string ACQUIRED = "ACQUIRED";
        public const string NOT_RECEIVED = "NOT_RECEIVED";
        public const string INVALID = "INVALID";
        public const string EXPIRED = "EXPIRED";
    }
    public class MonitoringResult
    {
        public const string DISABLED = "DISABLED";
        public const string IN_LIMITS = "IN_LIMITS";
        public const string WATCH = "WATCH";
        public const string WARNING = "WARNING";
        public const string DISTRESS = "DISTRESS";
        public const string CRITICAL = "CRITICAL";
        public const string SEVERE = "SEVERE";
    }

    public class RangeCondition
    {
        public const string LOW = "LOW";
        public const string HIGH = "HIGH";
    }


    public class VType
    {
        public const string BINARY = "BINARY";
        public const string BOOLEAN = "BOOLEAN";
        public const string FLOAT = "FLOAT";
        public const string INTEGER = "INTEGER";
        public const string STRING = "STRING";
    }

    public class CalibrationType
    {
        public const string POLYNOMIAL = "POLYNOMIAL";
        public const string SPLINE = "SPLINE";
        public const string MATH_OPERATION = "MATH_OPERATION";
        public const string JAVA_EXPRESSION = "JAVA_EXPRESSION";
    }

    //public class OperatorType
    //{
    //    public const string EQUAL_TO = "EQUAL_TO";
    //    public const string NOT_EQUAL_TO = "NOT_EQUAL_TO";
    //    public const string GREATER_THAN = "GREATER_THAN";
    //    public const string GREATER_THAN_OR_EQUAL_TO = "GREATER_THAN_OR_EQUAL_TO";
    //    public const string SMALLER_THAN = "SMALLER_THAN";
    //    public const string SMALLER_THAN_OR_EQUAL_TO = "SMALLER_THAN_OR_EQUAL_TO";
    //}

    //public class AlarmLevelType
    //{
    //    public const string NORMAL = "NORMAL";
    //    public const string WATCH = "WATCH";
    //    public const string WARNING = "WARNING";
    //    public const string DISTRESS = "DISTRESS";
    //    public const string CRITICAL = "CRITICAL";
    //    public const string SEVERE = "SEVERE";
    //}

  

    public class Scope
    {
        public const string GLOBAL = "GLOBAL";
        public const string COMMAND_VERIFICATION = "COMMAND_VERIFICATION";
        public const string CONTAINER_PROCESSING = "CONTAINER_PROCESSING";
    }

    public class ReferenceLocationType
    {
        public const string CONTAINER_START = "CONTAINER_START";
        public const string PREVIOUS_ENTRY = "PREVIOUS_ENTRY";
    }

//    public class EventSeverity
//{
//        public const string INFO = "INFO";
//        public const string WARNING = "WARNING";
//        public const string ERROR = "ERROR";

//        //the levels below are compatible with XTCE
//        // we left the 4 out since it could be used
//        // for warning if we ever decide to get rid of the old ones
//        public const string WATCH = "WATCH";
//        public const string DISTRESS = "DISTRESS";
//        public const string CRITICAL = "CRITICAL";
//        public const string SEVERE = "SEVERE";
//    }

}
