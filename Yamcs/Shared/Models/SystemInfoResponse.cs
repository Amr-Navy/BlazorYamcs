using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yamcs.Shared
{
   public class SystemInfoResponse
    {
   
  public string YamcsVersion { set; get; }
  public string Revision { set; get; }
  public string ServerId { set; get;}
  public string Uptime { set; get; }
   public string Jvm { set; get; }
   public string WorkingDirectory { set; get; }
  public string ConfigDirectory { set; get; }
  public string DataDirectory { set; get; }
  public string CacheDirectory { set; get; }
   public string Os { set; get; }
  public string Arch { set; get; }
  public int AvailableProcessors { set; get; }
  public float LoadAverage { set; get; }
  public string HeapMemory { set; get; }
  public string UsedHeapMemory { set; get; }
  public string MaxHeapMemory { set; get; }
  public string NonHeapMemory { set; get; }
  public string UsedNonHeapMemory { set; get; }
  public string JvmThreadCount { set; get; }
 // public RootDirectory RootDirectories { set; get; }

    }
    public class RootDirectory
    {
    public string Directory { set; get; }
    public string Type { set; get; }
    public string TotalSpace { set; get; }
    public string UnallocatedSpace { set; get; }
    public string UsableSpace { set; get;}
    }
}
