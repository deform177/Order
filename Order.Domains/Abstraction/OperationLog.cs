using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Order.Domain.Abstraction
{
    [ComplexType]
    public class OperationLog
    {
        protected OperationLog()
        {
        }

        [JsonConstructor]
        public OperationLog(string source, string operatorId, DateTime operationTime)
        {
            if (string.IsNullOrWhiteSpace(source))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(source));
            if (string.IsNullOrWhiteSpace(operatorId))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(operatorId));

            Source = source;
            OperatorId = operatorId;
            OperationTime = operationTime;
        }

        public OperationLog(string source, string operatorId) : this(source, operatorId, DateTime.UtcNow)
        {
        }
        public int Id { get; protected set; }
        public string Source { get; protected set; }
        public string OperatorId { get; protected set; }
        public DateTime OperationTime { get; protected set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"At {OperationTime} by {OperatorId} from {Source}";
        }
    }

}
