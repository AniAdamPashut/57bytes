using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    // If I don't have algebraic data types imma have to implement it myself
    public struct Option<T>
    {
        private enum Values
        {
            None,
            Some,
        }
        private T value;
        private Values whichValue; 

        public Option()
        {
            this.whichValue = Values.None;
        }

        public Option(T value)
        {
            this.value = value;
            this.whichValue = Values.Some;
        }
        
        // mutatable vs immutable
        public void set(T value)
        {
            this.value = value;
            this.whichValue = Values.Some;
        }

        public bool isNone()
        {
            return this.whichValue == Values.None;
        }

        public bool isSome() {
            return !isNone();
        }

        public Option<V> map<V>(Func<T, V> f)
        {
            if (isNone())
            {
                return new Option<V>();
            }
            return new Option<V>(f(this.value));
        }

        public Option<V> bind<V>(Func<T, Option<V>> f)
        {
            if (isNone())
            {
                /*
                 * In a utopian world we could optimize
                 * for a non-null value T 
                 * that the null value would be None
                 * and the rest will be Some(T)
                 * in that way we could just do 
                 * return this;
                 * and get on with our lives knowing we haven't allocated anything.
                 * BUT, C# allows (and somewhat encourages) nullable types
                 * this makes our life miserable and forces us to allocate new structs
                 * because the null couldnt be optimized 
                 * If we had this "null optimization"
                 * an Option<T> that holds a None
                 * will equal an Option<V> that holds a None,
                 * allowing for an easy conversion.
                 */
                return new Option<V>();
            }
            return f(this.value);
        }

        public T unwrap()
        {
            if (!isNone())
            {
                return value;
            }
            throw new NullReferenceException("Unwraping an option with no value is not cool");
        }

        public override string ToString()
        {
            if (isNone())
                return "None";
            else return $"Some({value})";
        }

        public static bool operator ==(Option<T> right, Option<T> left)

        {
            if (right.isNone() && left.isNone()) return true;
            if (right.isSome() && left.isSome())
            {
                dynamic v1 = right.value;
                dynamic v2 = left.value;
                return v1 == v2;
                // This throws, but hey, my usecase will work
            }
            return false;
        }
        public static bool operator !=(Option<T> right, Option<T> left)

        {
            if (right.isNone() && left.isNone()) return false;
            if (right.isSome() && left.isSome())
            {
                dynamic v1 = right.value;
                dynamic v2 = left.value;
                return v1 != v2;
                // This throws, but hey, my usecase will work
            }
            return true;
        }
    }
}
