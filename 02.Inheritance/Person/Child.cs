namespace _01.Person
{
    public class Child : Person
    {
        private int age;
        public Child(string name, int age) : base(name, age)
        {
        }

        public new int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value > 15)
                {
                    throw new System.Exception("Children cannot be older than 15");
                }

                this.age = value;
            }
        }
    }
}
