namespace _3.numexpr
{

    internal class NumericalExpression
    {
        private int number;
        private IExpressable expr; // Func<int, string> 🤡🤡🤡

        public NumericalExpression(int n)
        {
            number = n;
            expr = new Expressive();
        }
        public NumericalExpression(int n, IExpressable e)
        {
            number = n;
            expr = e;
        }
        public int GetValue()
        {
            return number;
        }

        public int SumLetters()
        {
            return this.ToString().Replace(" ", "").Length;
        }

        // Polymorphism
        public int SumLetters(NumericalExpression other)
        {
            return other.ToString().Replace(" ", "").Length;
        }

        public override string ToString()
        {
            return expr.Express(number);
        }
    }
}
