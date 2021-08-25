using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yamcs.Shared.Models
{
   public class FileTransferService {
 public string  instance { set; get; }
        public string name { set; get; }
        public Entity[] localEntities { set; get; }
        public Entity[] remoteEntities { set; get; }
 public FileTransferCapabilities capabilities { set; get; }
    }

public class FileTransferCapabilities {
  public bool upload { set; get; }
        public bool download { set; get; }
        public bool reliable { set; get; }
        public bool remotePath { set; get; }
}

public class Entity {
        public string name { set; get; }
        public int id { set; get; }
}

public class Transfer {
  public int id { set; get; }
        public string startTime { set; get; }
        public string creationTime { set; get; }
        //state: 'RUNNING' | 'PAUSED' | 'FAILED' | 'COMPLETED' | 'CANCELLING' | 'QUEUED';
  public string bucket{ set; get; }
    public string objectName { set; get; }
        public string remotePath { set; get; }
       // direction: 'UPLOAD' | 'DOWNLOAD';
  public int totalSize { set; get; }
        public int  sizeTransferred { set; get; }
        public string failureReason { set; get; }
    }

public class UploadOptions {
        public bool overwrite { set; get; }
        public bool createPath { set; get; }
        public bool reliable { set; get; }
    }

public class CreateTransferRequest {
  //direction: 'UPLOAD' | 'DOWNLOAD';
         public string bucket { set; get; }
        public string objectName { set; get; }
        public string remotePath { set; get; }
        public string source { set; get; }
        public string destination { set; get; }
        public UploadOptions uploadOptions { set; get; }
    }

public class TransfersPage {
 public Transfer[] transfers { set; get; }
}

public class ServicesPage {
 public FileTransferService[] services { set; get; }
}

public class SubscribeTransfersRequest {
        public string instance { set; get; }
        public string serviceName { set; get; }
    }
}
