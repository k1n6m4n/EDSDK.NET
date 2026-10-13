using System;
using System.Collections.Generic;
using System.Reflection;

namespace EDSDK.NET
{
    /// <summary>
    /// A non-OK EDSDK return code. The message keeps the historic
    /// "SDK Error: 0x.." prefix (callers parse the hex out of it) and adds the
    /// SDK constant name, so a log or a crash dialog says what went wrong
    /// without a lookup table.
    /// </summary>
    public class SDKException : Exception
    {
        /// <summary>
        /// The raw EDSDK error code
        /// </summary>
        public uint ErrorCode { get; }

        public SDKException(uint errorCode)
            : base("SDK Error: 0x" + errorCode.ToString("X") + " (" + GetErrorName(errorCode) + ")")
        {
            ErrorCode = errorCode;
        }

        private static Dictionary<uint, string> names;

        /// <summary>
        /// The EDS_ERR_* constant name for a code, or "unknown" when the SDK
        /// header has no name for it.
        /// </summary>
        public static string GetErrorName(uint errorCode)
        {
            if (names == null)
            {
                var map = new Dictionary<uint, string>();
                foreach (var f in typeof(EDSDKLib.EDSDK).GetFields(BindingFlags.Public | BindingFlags.Static))
                {
                    if (!f.IsLiteral || f.FieldType != typeof(uint) || !f.Name.StartsWith("EDS_ERR_")) continue;
                    uint v = (uint)f.GetRawConstantValue();
                    if (!map.ContainsKey(v)) map[v] = f.Name;
                }
                names = map;
            }
            return names.TryGetValue(errorCode, out var name) ? name : "unknown";
        }
    }
}
