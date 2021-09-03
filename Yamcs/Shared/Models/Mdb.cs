namespace Yamcs.Shared.Models
{
    public class MissionDatabase
    {
        public string ConfigName { set; get; }
        public string Name { set; get; }
        public string Version { set; get; }
        public SpaceSystem[] SpaceSystem { set; get; }
        public int ParameterCount { set; get; }
        public int containerCount { set; get; }
        public int CommandCount { set; get; }
        public int AlgorithmCount { set; get; }
        public int ParameterTypeCount { set; get; }
    }

    public class NameDescription
    {
        public string Name { set; get; }
        public string QualifiedName { set; get; }
        public NamedObjectId[] Alias { set; get; }
        public string ShortDescription { set; get; }
        public string LongDescription { set; get; }
    }

    public class SpaceSystem : NameDescription
    {
        public string Version { set; get; }

        public HistoryInfo[] History { set; get; }
        public SpaceSystem[] Sub { set; get; }
    }

    public class SpaceSystemsPage
    {
        public SpaceSystem[] SpaceSystems { set; get; }
        public string ContinuationToken { set; get; }
        public int TotalSize { set; get; }
    }

    public class HistoryInfo
    {
        public string Version { set; get; }
        public string Date { set; get; }
        public string Message { set; get; }
        public string Author { set; get; }
    }


    public class Parameter : NameDescription
    {
        public string Datasource { set; get; }
        public ParameterType Type { set; get; }
        public UsedByInfo UsedBy { set; get; }
        public string[] Path { set; get; }
    }

    public class UsedByInfo
    {
        public Algorithm[] Algorithm { set; get; }
        public Container[] Container { set; get; }
    }

    public class UnitInfo
    {
        public string Unit { set; get; }
    }

    public class NamedObjectId
    {
        public string NameSpace { set; get; }
        public string Name { set; get; }
    }

    public class ParameterType
    {
        public string EngType { set; get; }
        public ArrayInfo ArrayInfo { set; get; }
        public DataEncoding DataEncoding { set; get; }
        public UnitInfo[] UnitSet { set; get; }
        public AlarmInfo DefaultAlarm { set; get; }
        public ContextAlarmInfo ContextAlarm { set; get; }
        public EnumValue[] EnumValue { set; get; }
        public AbsoluteTimeInfo AbsoluteTimeInfo { set; get; }
        public Member[] Member { set; get; }
    }

    public class ArrayInfo
    {
        public ParameterType Type { set; get; }
        public int Dimensions { set; get; }
    }

    public class Member
    {
        public string Name { set; get; }
        //type: ParameterType , ArgumentType;
    }

    public class ArgumentMember : Member
    {
        public ArgumentType Type { set; get; }
    }

    public class AbsoluteTimeInfo
    {
        public string InitialValue { set; get; }
        public int Scale { set; get; }
        public int Offset { set; get; }
        public Parameter OffsetFrom { set; get; }
        public string Epoch { set; get; }
    }

    public class AlarmInfo
    {
        public int MinViolations { set; get; }
        public AlarmRange[] StaticAlarmRange { set; get; }
        public EnumerationAlarm[] EnumerationAlarm { set; get; }
    }

    public class ContextAlarmInfo
    {
        ComparisonInfo[] Comparison { set; get; }
        public string Context { set; get; }
        public AlarmInfo Alarm { set; get; }
    }

    public class EnumerationAlarm
    {
        public AlarmLevelType level { set; get; }
        public string label { set; get; }
    }

    public class DataEncoding
    {
        public string Type { set; get; }
        public bool LittleEndian { set; get; }
        public int SizeInBits { set; get; }
        public string Encoding { set; get; }
        public Calibrator DefaultCalibrator { set; get; }
        public Calibrator[] ContextCalibrator { set; get; }
    }

    public class Calibrator
    {
        public string Type { set; get; }
        public PolynomialCalibrator PolynomialCalibrator { set; get; }
        public SplineCalibrator SplineCalibrator { set; get; }
        public JavaExpressionCalibrator JavaExpressionCalibrator { set; get; }
    }

    public class PolynomialCalibrator
    {
        public int[] Coefficient { set; get; }
    }

    public class SplineCalibrator
    {
        SplinePoint[] Point { set; get; }
    }

    public class SplinePoint
    {
        public int Raw { set; get; }
        public int Calibrated { set; get; }
    }

    public class JavaExpressionCalibrator
    {
        public string Formula { set; get; }
    }

    public class Command : NameDescription
    {
        public Command BaseCommand { set; get; }
        public bool Abbstract { set; get; }
        public Argument[] Argument { set; get; }
        public ArgumentAssignment[] ArgumentAssignment { set; get; }
        public Significance Significance { set; get; }
        public TransmissionConstraint[] constraint { set; get; }
        public CommandContainer CommandContainer { set; get; }
        public Verifier[] Verifier { set; get; }
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
        public string consequence { set; get; }
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
        public string Time { set; get; }
        public ParameterValue[] Inputs { set; get; }
        public ParameterValue[] Outputs { set; get; }
        public string ReturnValue { set; get; }
        public string Error { set; get; }
    }

    public class AlgorithmLog
    {
        public string Time { set; get; }
        public string Msg { set; get; }
    }

    public class AlgorithmOverrides
    {
        public AlgorithmTextOverride TextOverride { set; get; }
    }

    public class AlgorithmTextOverride
    {
        public string Algorithm { set; get; }
        public string Text { set; get; }

    }

    public class InputParameter
    {
        public Parameter Parameter { set; get; }
        public string InputName { set; get; }
        public string ParameterInstance { set; get; }
        public bool Mandatory { set; get; }
    }

    public class OutputParameter
    {
        public Parameter Parameter { set; get; }
        public string OutputName { set; get; }
    }

    public class Container : NameDescription
    {
        public int MaxInterval { set; get; }
        public int sizeInBits { set; get; }
        public Container BaseContainer { set; get; }
        public ComparisonInfo[] RestrictionCriteria { set; get; }
        public SequenceEntry[] Entry { set; get; }
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
        public Parameter Parameter { set; get; }
        public OperatorType OperatorType { set; get; }
        public string Value { set; get; }
    }
    public enum ReferenceLocation { CONTAINER_START, PREVIOUS_ENTRY }
    public class SequenceEntry
    {
        public int LocationInBits { set; get; }
        public string ReferenceLocation { set; get; }
        public RepeatInfo Repeat { set; get; }

        Container Container { set; get; }
        public Parameter Parameter { set; get; }
        public Argument Argument { set; get; }
        public FixedValue FixedValue { set; get; }
    }

    public class FixedValue
    {
        public string Name { set; get; }
        public string HexValue { set; get; }
        public int SizeInBits { set; get; }
    }

    public class RepeatInfo
    {
        public int FixedCount { set; get; }
        Parameter DynamicCount { set; get; }
        public int BitsBetween { set; get; }
    }

    public class GetParametersOptions
    {
        public string Type { set; get; }
        public string Source { set; get; }
        public string q { set; get; }
        public string System { set; get; }
        public bool SearchMembers { set; get; }
        public int Pos { set; get; }
        public int Limit { set; get; }
    }

    public class ParametersPage
    {
        public string[] SpaceSystems { set; get; }
        public Parameter[] Parameters { set; get; }
        public string ContinuationToken { set; get; }
        public int TotalSize { set; get; }
    }

    public class GetAlgorithmsOptions
    {
        public string Scope { set; get; }
        public string Q { set; get; }
        public string System { set; get; }
        public int Pos { set; get; }
        public int Limit { set; get; }
    }

    public class AlgorithmsPage
    {
        public string[] SpaceSystems { set; get; }
        public Algorithm[] Algorithms { set; get; }
        public string ContinuationToken { set; get; }
        public int TotalSize { set; get; }
    }

    public class GetContainersOptions
    {
        public string q { set; get; }
        public string System { set; get; }
        public int Pos { set; get; }
        public int Limit { set; get; }
    }

    public class ContainersPage
    {
        public string[] SpaceSystems { set; get; }
        public Container[] Containers { set; get; }
        public string ContinuationToken { set; get; }
        public int TotalSize { set; get; }
    }

    public class GetCommandsOptions
    {
        public bool NoAbstract { set; get; }
        public string Q { set; get; }

        public string System { set; get; }
        public int Pos { set; get; }
        public int Limit { set; get; }
        public bool details
        {
            set; get;
        }

        public class CommandsPage
        {
            public string[] SpaceSystems { set; get; }
            public Command[] Commands { set; get; }
            public string ContinuationToken { set; get; }
            public int TotalSize { set; get; }
        }
    }


    public class CommandsPage
    {
        public string[] SpaceSystems { set; get; }
        public Command[] Commands { set; get; }
        public string continuationToken { set; get; }

        public int TotalSize { set; get; }
    }

}


