namespace TaobaoExpress
{
    public static class DoubleExtensions
    {
        public static string ToSwissFranc(this double d) => string.Format("{0:0.00}", d);
    }
}