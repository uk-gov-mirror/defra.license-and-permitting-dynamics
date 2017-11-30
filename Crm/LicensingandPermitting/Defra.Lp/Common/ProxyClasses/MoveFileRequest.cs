﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defra.Lp.Common.ProxyClasses
{
    internal class MoveFileRequest
    {
        public MoveFileRequest()
        {
            this.Metadata = new MetadataValues();
        }

        public string ActivityId { get; internal set; }
        public string ActivityName { get; internal set; }
        public Guid AttachmentId { get; internal set; }
        public string AttachmentType { get; internal set; }
        public string DocumentId { get; internal set; }
        public string CaseNo { get; internal set; }
        public object FileBody { get; internal set; }
        public string FileName { get; internal set; }
        public string FileRelativeUrl { get; internal set; }
        public string FileURL { get; internal set; }
        public string ListName { get; internal set; }
        public MetadataValues Metadata { get; internal set; }
    }
}