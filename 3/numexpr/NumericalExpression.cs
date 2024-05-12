namespace _3.numexpr
{

    internal class NumericalExpression
    {
        private int Number;
        private IExpressable Expr; // Func<int, string> 🤡🤡🤡

        public NumericalExpression(int n)
        {
            Number = n;
            Expr = new Expressive();
        }
        public NumericalExpression(int n, IExpressable e)
        {
            Number = n;
            Expr = e;
        }
        public int GetValue()
        {
            return Number;
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
            return Expr.Express(Number);
        }
    }
}
