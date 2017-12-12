namespace TaobaoExpress
{
    public static class Int64Extensions
    {
        public static string ToSwissFranc(this double d) => string.Format("{0:0.00}", d);
    }
}