using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    enum Type { Int, Double, String, Float, Char}
    internal class List
    {
        public List(Type type, int Count)
        {
            switch (type)
            {
                case Type.Int:
                    int[] list = new int[Count];
                    break;
                case Type.Double:
                    double[] list = new double[Count];
                    break;
                case Type.Float:
                    int[] list = new int[Count];
                    break;
                case Type.String:
                    int[] list = new int[Count];
                    break;
                case Type.Char:
                    char[] list = new char[Count];
                    break;
            }
        }


    }
}
