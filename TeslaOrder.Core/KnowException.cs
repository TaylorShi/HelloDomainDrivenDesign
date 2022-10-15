namespace TeslaOrder.Core
{
    public class KnowException : IKnowException
    {
        public string Message { get; private set; }

        public int ErrorCode { get; private set; }

        public object[] ErrorData { get; private set; }

        public readonly static IKnowException Unknown = new KnowException { Message = "未知错误", ErrorCode = 9999 };

        public static IKnowException FromKnowException(IKnowException knowException)
        {
            return new KnowException { Message = knowException.Message, ErrorCode = knowException.ErrorCode, ErrorData = knowException.ErrorData };
        }
    }
}
