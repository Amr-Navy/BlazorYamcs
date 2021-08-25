using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yamcs.Shared.Models;

namespace Yamcs.Shared.Models
{
    public class MissionDatabase
    {
        public string configName { set; get; }
        public string name { set; get; }
        public string version { set; get; }
        public SpaceSystem[] spaceSystem { set; get; }
        public int parameterCount { set; get; }
        public int containerCount { set; get; }
        public int commandCount { set; get; }
        public int algorithmCount { set; get; }
        public int parameterTypeCount { set; get; }
    }

    public class NameDescription
    {
        public string name { set; get; }
        public string qualifiedName { set; get; }
        public NamedObjectId[] alias { set; get; }
        public string shortDescription { set; get; }
        public string longDescription { set; get; }
    }

    public class SpaceSystem : NameDescription
    {
        public string version { set; get; }
       
        public HistoryInfo[] history { set; get; }
        public SpaceSystem[] sub { set; get; }
    }

    public class SpaceSystemsPage
    {
        public SpaceSystem[] spaceSystems { set; get; }
        public string continuationToken { set; get; }
        public int totalSize { set; get; }
    }

    public class HistoryInfo
    {
        public string version { set; get; }
        public string date { set; get; }
        public string message { set; get; }
        public string author { set; get; }
    }


    public class Parameter : NameDescription
    {
        public DataSourceType datasource { set; get; }
        public ParameterType type { set; get; }
        public UsedByInfo usedBy { set; get; }
        public string[] path { set; get; }
    }

    public class UsedByInfo
    {
        public Algorithm[] algorithm { set; get; }
        public Container[] container { set; get; }
    }

    public class UnitInfo
    {
        public string unit { set; get; }
    }

    public class NamedObjectId
    {
        public string nameSpace { set; get; }
        public string name { set; get; }
    }

    public class ParameterType
    {
        public string engType { set; get; }
        public ArrayInfo arrayInfo { set; get; }
        public DataEncoding dataEncoding { set; get; }
        public UnitInfo[] unitSet { set; get; }
        public AlarmInfo defaultAlarm { set; get; }
        public ContextAlarmInfo contextAlarm { set; get; }
        public EnumValue[] enumValue { set; get; }
        public AbsoluteTimeInfo absoluteTimeInfo { set; get; }
        public Member[] member { set; get; }
    }

    public class ArrayInfo
    {
        public ParameterType type { set; get; }
        public int dimensions { set; get; }
    }

    public class Member
    {
        public string name { set; get; }
        //type: ParameterType , ArgumentType;
    }

    public class ArgumentMember : Member
    {
        public ArgumentType type { set; get; }
    }

    public class AbsoluteTimeInfo
    {
        public string initialValue { set; get; }
        public int scale { set; get; }
        public int offset { set; get; }
        public Parameter offsetFrom { set; get; }
        public string epoch { set; get; }
    }

    public class AlarmInfo
    {
        public int minViolations { set; get; }
        public AlarmRange[] staticAlarmRange { set; get; }
        public EnumerationAlarm[] enumerationAlarm { set; get; }
    }

    public class ContextAlarmInfo
    {
        ComparisonInfo[] comparison { set; get; }
        public string context { set; get; }
        public AlarmInfo alarm { set; get; }
    }

    public class EnumerationAlarm
    {
        public AlarmLevelType level { set; get; }
        public string label { set; get; }
    }

    public class DataEncoding
    {
        public string type { set; get; }
        public bool littleEndian { set; get; }
        public int sizeInBits { set; get; }
        public string encoding { set; get; }
        public Calibrator defaultCalibrator { set; get; }
        public Calibrator[] contextCalibrator { set; get; }
    }

    public class Calibrator
    {
        public string type { set; get; }
        public PolynomialCalibrator polynomialCalibrator { set; get; }
        public SplineCalibrator splineCalibrator { set; get; }
        public JavaExpressionCalibrator javaExpressionCalibrator { set; get; }
    }

    public class PolynomialCalibrator
    {
        public int[] coefficient { set; get; }
    }

    public class SplineCalibrator
    {
        SplinePoint[] point { set; get; }
    }

    public class SplinePoint
    {
        public int raw { set; get; }
        public int calibrated { set; get; }
    }

    public class JavaExpressionCalibrator
    {
        public string formula { set; get; }
    }

    public class Command : NameDescription
    {
        public Command baseCommand { set; get; }
        public bool abbstract { set; get; }
        public Argument[] argument { set; get; }
        public ArgumentAssignment[] argumentAssignment { set; get; }
        public Significance significance { set; get; }
        public TransmissionConstraint[] constraint { set; get; }
        public CommandContainer commandContainer { set; get; }
        public Verifier[] verifier { set; get; }
    }

    public enum TerminationActionType { SUCCESS, FAIL }

    public class Verifier
    {
        public string stage { set; get; }
        Container container { set; get; }
        Algorithm algorithm { set; get; }
        TerminationActionType onSuccess { set; get; }
        TerminationActionType onFail { set; get; }
        TerminationActionType onTimeout { set; get; }
        CheckWindow checkWindow { set; get; }
    }

    public class CheckWindow
    {
        public string timeToStartChecking { set; get; }
        public string timeToStopChecking { set; get; }
        public string relativeTo { set; get; }
    }

    public class CommandContainer : NameDescription
    {
        public int sizeInBits { set; get; }
       // public Containerbase Container { set; get; }
        public SequenceEntry[] entry { set; get; }
    }

    public class Argument
    {
        public string name { set; get; }
        public string description { set; get; }
        public int initialValue { set; get; }
        ArgumentType type { set; get; }
    }

    public class ArgumentType
    {
        public string engType { set; get; }
        public DataEncoding dataEncoding { set; get; }
        public UnitInfo[] unitSet { set; get; }
        public EnumValue[] enumValue { set; get; }
        public int rangeMin { set; get; }
        public int rangeMax { set; get; }
        public int minChars { set; get; }
        public int maxChars { set; get; }
        public ArgumentMember[] member { set; get; }
        public string zeroStringValue { set; get; }
        public string oneStringValue { set; get; }
    }

    public class ArgumentAssignment
    {
        public string name { set; get; }
        public string value { set; get; }
    }
    public enum consequenceLevel { NONE, WATCH, WARNING, DISTRESS, CRITICAL, SEVERE }
    public class Significance
    {
        public consequenceLevel consequence { set; get; }
        public string reasonForWarning { set; get; }
    }

    public class TransmissionConstraint
    {
        public string expression { set; get; }
        public int timeout { set; get; }
    }

    public class EnumValue
    {
        public int value { set; get; }
        public string label { set; get; }
    }

    public enum AlarmLevelType { NORMAL, WATCH, WARNING, DISTRESS, CRITICAL, SEVERE }

    public class AlarmRange
    {
        AlarmLevelType level { set; get; }
        public int minInclusive { set; get; }
        public int maxInclusive { set; get; }
        public int minExclusive { set; get; }
        public int maxExclusive { set; get; }
    }
    public enum scope { GLOBAL, COMMAND_VERIFICATION, CONTAINER_PROCESSING }
    public class Algorithm : NameDescription
    {
        public scope scop { set; get; }
        public string language { set; get; }
        public string text { set; get; }
        public InputParameter[] inputParameter { set; get; }
        public OutputParameter[] outputParameter { set; get; }
        public Parameter[] onParameterUpdate { set; get; }
        public int[] onPeriodicRate { set; get; }
    }

    public class AlgorithmStatus
    {
        public bool active { set; get; }
        public bool traceEnabled { set; get; }
        public int runCount { set; get; }
        public string lastRun { set; get; }
        public int errorCount { set; get; }
        public int execTimeNs { set; get; }
        public string errorMessage { set; get; }
        public string errorTime { set; get; }
    }

    public class AlgorithmTrace
    {
        public AlgorithmRun[] runs { set; get; }
        public AlgorithmLog[] logs { set; get; }
    }

    public class AlgorithmRun
    {
        public string time { set; get; }
        public ParameterValue[] inputs { set; get; }
        public ParameterValue[] outputs { set; get; }
        public string returnValue { set; get; }
        public string error { set; get; }
    }

    public class AlgorithmLog
    {
        public string time { set; get; }
        public string msg { set; get; }
    }

    public class AlgorithmOverrides
    {
        public AlgorithmTextOverride textOverride { set; get; }
    }

    public class AlgorithmTextOverride
    {
        public string algorithm { set; get; }
        public string text { set; get; }
    }

    public class InputParameter
    {
        public Parameter parameter { set; get; }
        public string inputName { set; get; }
        public string parameterInstance { set; get; }
        public bool mandatory { set; get; }
    }

    public class OutputParameter
    {
        public Parameter parameter { set; get; }
        public string outputName { set; get; }
    }

    public class Container : NameDescription
    {
        public int maxInterval { set; get; }
        public int sizeInBits { set; get; }
        public Container baseContainer { set; get; }
        public ComparisonInfo[] restrictionCriteria { set; get; }
        public SequenceEntry[] entry { set; get; }
    }

    public class OperatorType
    {
        public const string EQUAL_TO = "EQUAL_TO";
        public const string NOT_EQUAL_TO = "NOT_EQUAL_TO";
        public const string GREATER_THAN = "GREATER_THAN";
        public const string GREATER_THAN_OR_EQUAL_TO = "GREATER_THAN_OR_EQUAL_TO";
        public const string SMALLER_THAN = "SMALLER_THAN";
        public const string SMALLER_THAN_OR_EQUAL_TO = "SMALLER_THAN_OR_EQUAL_TO";
    }

    public class ComparisonInfo
    {
        public Parameter parameter { set; get; }
        public OperatorType OperatorType { set; get; }
        public string value { set; get; }
    }
    public enum referenceLocation { CONTAINER_START, PREVIOUS_ENTRY }
    public class SequenceEntry
    {
        public int locationInBits { set; get; }
        public referenceLocation referenceLocation { set; get; }
        public RepeatInfo repeat { set; get; }

        Container container { set; get; }
        public Parameter parameter { set; get; }
        public Argument argument { set; get; }
        public FixedValue fixedValue { set; get; }
    }

    public class FixedValue
    {
        public string name { set; get; }
        public string hexValue { set; get; }
        public int sizeInBits { set; get; }
    }

    public class RepeatInfo
    {
        public int fixedCount { set; get; }
        Parameter dynamicCount { set; get; }
        public int bitsBetween { set; get; }
    }

    public class GetParametersOptions
    {
        public string type { set; get; }
        public string source { set; get; }
        public string q { set; get; }
        public string system { set; get; }
        public bool searchMembers { set; get; }
        public int pos { set; get; }
        public int limit { set; get; }
    }

    public class ParametersPage
    {
        public string[] spaceSystems { set; get; }
        public Parameter[] parameters { set; get; }
        public string continuationToken { set; get; }
        public int totalSize { set; get; }
    }

    public class GetAlgorithmsOptions
    {
        public string scope { set; get; }
        public string q { set; get; }
        public string system { set; get; }
        public int pos { set; get; }
        public int limit { set; get; }
    }

    public class AlgorithmsPage
    {
        public string[] spaceSystems { set; get; }
        public Algorithm[] algorithms { set; get; }
        public string continuationToken { set; get; }
        public int totalSize { set; get; }
    }

    public class GetContainersOptions
    {
        public string q { set; get; }
        public string system { set; get; }
        public int pos { set; get; }
        public int limit { set; get; }
    }

    public class ContainersPage
    {
        public string[] spaceSystems { set; get; }
        public Container[] containers { set; get; }
        public string continuationToken { set; get; }
        public int totalSize { set; get; }
    }

    public class GetCommandsOptions
    {
        public bool noAbstract { set; get; }
        public string q { set; get; }

        public string system { set; get; }
        public int pos { set; get; }
        public int limit { set; get; }
        public bool details
        {
            set; get;
        }

        public class CommandsPage
        {
            public string[] spaceSystems { set; get; }
            public Command[] commands { set; get; }
            public string continuationToken { set; get; }
            public int totalSize { set; get; }
        }
    }
}


